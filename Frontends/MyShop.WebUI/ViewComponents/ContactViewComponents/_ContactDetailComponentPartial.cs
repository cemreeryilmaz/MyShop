using Microsoft.AspNetCore.Mvc;

namespace MyShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
