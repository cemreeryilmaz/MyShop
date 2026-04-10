using Microsoft.AspNetCore.Mvc;
using MyShop.WebUI.Services.Interfaces;

namespace MyShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View();
        }
    }
}
