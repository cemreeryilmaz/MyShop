using MyShop.WebUI.Models;

namespace MyShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();

    }
}
