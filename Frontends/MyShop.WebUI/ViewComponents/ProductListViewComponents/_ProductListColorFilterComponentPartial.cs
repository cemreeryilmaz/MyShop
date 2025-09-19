using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListColorFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
