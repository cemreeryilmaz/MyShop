using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponenPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
