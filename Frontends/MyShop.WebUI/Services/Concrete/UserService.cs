using MyShop.WebUI.Models;
using MyShop.WebUI.Services.Interfaces;

namespace MyShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("api/user/getuserinfo");
        }
    }
}
