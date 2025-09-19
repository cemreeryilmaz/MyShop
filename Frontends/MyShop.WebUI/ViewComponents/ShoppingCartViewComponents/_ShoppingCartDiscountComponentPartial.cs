using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
