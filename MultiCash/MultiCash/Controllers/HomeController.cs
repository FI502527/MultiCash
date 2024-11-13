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
        private readonly BankService _bankService;

        public HomeController(ILogger<HomeController> logger, UserService userService, BankService bankService)
        {
            _logger = logger;
            _userService = userService;
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            UserModel userModel = _userService.GetUserById(1);
            List<BankAccountModel> bankModels = _bankService.LoadBankAccountsByUserId(1);
            UserViewModel userViewModel = new UserViewModel(userModel.Id, userModel.Email, userModel.Password);
            List<BankViewModel> bankViewModels = new List<BankViewModel>();
            foreach (BankAccountModel bankModel in bankModels)
            {
                BankViewModel bankViewModel = new BankViewModel(bankModel);
                bankViewModels.Add(bankViewModel);
            }
            HomeViewModel homeViewModel = new HomeViewModel(userViewModel, bankViewModels);
            return View(homeViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddBank(BankViewModel bankViewModel)
        {
            BankAccountModel bankModel = new BankAccountModel(0, 1, bankViewModel.AccountType, 0);
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
