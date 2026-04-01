using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.IdentityServer.Dtos;
using MyShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MyShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        SignInManager<ApplicationUser> _signInManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Login işlemi başarılı.");

            }
            else
            {
                return Ok("Kullanıcı adı veya şifre hatalı.");
            }
        }
    }
}
