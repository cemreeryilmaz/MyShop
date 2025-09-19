using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
