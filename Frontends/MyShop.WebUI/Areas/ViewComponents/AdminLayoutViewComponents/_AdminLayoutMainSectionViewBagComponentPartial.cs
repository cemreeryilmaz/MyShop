using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Areas.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutMainSectionViewBagComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
