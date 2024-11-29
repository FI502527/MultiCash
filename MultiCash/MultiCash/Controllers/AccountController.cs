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
                
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
