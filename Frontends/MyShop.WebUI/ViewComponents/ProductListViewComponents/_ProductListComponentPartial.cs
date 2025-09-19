using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
