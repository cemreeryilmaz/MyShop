using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
