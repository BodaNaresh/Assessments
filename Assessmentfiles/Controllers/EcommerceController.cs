using Microsoft.AspNetCore.Mvc;

namespace ProjectonAsp.netCore.Controllers
{
    public class EcommerceController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
    }
}
