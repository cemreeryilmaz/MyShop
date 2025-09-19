using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListSizeFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
