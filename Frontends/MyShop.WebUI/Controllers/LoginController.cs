using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MyShop.DtoLayer.IdentityDtos.LoginDtos;
using MyShop.WebUI.Models;
using MyShop.WebUI.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MyShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        IHttpClientFactory _httpClientFactory;
        ILoginService _loginService;
        IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
           
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "ali01";
            signInDto.Password = "1111aA*";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index","Test");
        }
    }
}