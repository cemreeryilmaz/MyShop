using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.Areas.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
