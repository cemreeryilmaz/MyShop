using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
