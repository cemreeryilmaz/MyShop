using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
