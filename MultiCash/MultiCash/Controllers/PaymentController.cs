using Microsoft.AspNetCore.Mvc;

namespace MultiCash.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Transfer()
        {
            return View();
        }
    }
}
