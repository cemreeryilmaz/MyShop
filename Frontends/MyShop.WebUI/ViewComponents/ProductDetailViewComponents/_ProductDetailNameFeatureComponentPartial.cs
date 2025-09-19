using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailNameFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
