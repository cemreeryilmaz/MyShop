using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Basket.Dtos;
using MyShop.Basket.LoginServices;
using MyShop.Basket.Services;
using System.Security.Claims;

namespace MyShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        IBasketService _basketService;
        ILoginService _logisService;

        public BasketsController(ILoginService logisService, IBasketService basketService)
        {
            _logisService = logisService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_logisService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _logisService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteki Değişiklikler Kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyBasket()
        {
            await _basketService.DeleteBasket(_logisService.GetUserId);
            return Ok("Sepet başarıyla silindi.");
        }
    }
}
