namespace MyShop.WebUI.Services.Interfaces
{
    public interface IClientCredientialTokenService
    {
        Task<string> GetToken();
    }
}
