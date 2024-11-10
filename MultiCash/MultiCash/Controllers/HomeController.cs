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
            BankAccountModel bankModel = _bankService.LoadBankAccountById(1);
            UserViewModel userViewModel = new UserViewModel(userModel.Id, userModel.Email, userModel.Password);
            BankViewModel bankViewModel = new BankViewModel(bankModel);
            HomeViewModel homeViewModel = new HomeViewModel(userViewModel, bankViewModel);
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
