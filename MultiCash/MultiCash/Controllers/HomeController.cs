using Microsoft.AspNetCore.Mvc;
using MultiCash.Models;
using System.Diagnostics;
using Logic;
using Logic.Model;

namespace MultiCash.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;
        private readonly BankAccountService _bankService;

        public HomeController(ILogger<HomeController> logger, UserService userService, BankAccountService bankService)
        {
            _logger = logger;
            _userService = userService;
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            UserModel userModel = _userService.GetUserById(1);
            List<BankAccountModel> bankModels = _bankService.LoadBankAccountsByUserId(1);
            UserViewModel userViewModel = new UserViewModel(userModel);
            List<BankAccountViewModel> bankViewModels = new List<BankAccountViewModel>();
            foreach (BankAccountModel bankModel in bankModels)
            {
                UserViewModel user = new UserViewModel(bankModel.User);
                BankTypeViewModel bankType = new BankTypeViewModel(bankModel.BankType);
                BankAccountViewModel bankViewModel = new BankAccountViewModel(bankModel.Id, bankModel.Balance, user, bankType);
                bankViewModels.Add(bankViewModel);
            }
            HomeViewModel homeViewModel = new HomeViewModel(userViewModel, bankViewModels);
            return View(homeViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddBank(BankTypeViewModel bankTypeViewModel)
        {
            UserModel user = _userService.GetUserById(1);
            BankTypeModel bankType = _bankService.GetBankTypeByName(bankTypeViewModel.Name);
            BankAccountModel bankModel = new BankAccountModel(0, 0, user, bankType);
            _bankService.AddBankAccount(bankModel);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
