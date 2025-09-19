using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
