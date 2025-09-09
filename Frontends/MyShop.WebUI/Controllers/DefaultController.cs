using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
