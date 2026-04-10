using MyShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MyShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
