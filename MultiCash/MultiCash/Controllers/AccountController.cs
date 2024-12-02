using Logic;
using Logic.Model;
using Microsoft.AspNetCore.Mvc;
using MultiCash.Models;

namespace MultiCash.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        public AccountController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult LoginCheck(UserViewModel user)
        {
            UserModel userModel = _userService.LoginCheck(user.Email, user.Password);
            if (userModel.Email != null)
            {
                HttpContext.Session.SetInt32("userId", userModel.Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
