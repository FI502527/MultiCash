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
            if(HttpContext.Session.GetInt32("userId") == null) return RedirectToAction("Login", "Account");

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

        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetInt32("userId") == null) return RedirectToAction("Login", "Account");
            //int userId = (int)HttpContext.Session.GetInt32("userId");

            UserModel userModel = _userService.GetUserById(1);
            BankAccountModel bankAccountModel = _bankService.LoadBankAccountById(id);

            UserViewModel userViewModel = new UserViewModel(userModel);
            BankTypeViewModel bankType = new BankTypeViewModel(bankAccountModel.BankType);
            BankAccountViewModel bankViewModel = new BankAccountViewModel(bankAccountModel.Id, bankAccountModel.Balance, userViewModel, bankType);

            return View(bankViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
