using MyShop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace MyShop.WebUI.Handlers
{
    public class ClientCredientialTokenHandler : DelegatingHandler
    {
        IClientCredientialTokenService _clientCredientialTokenService;

        public ClientCredientialTokenHandler(IClientCredientialTokenService clientCredientialTokenService)
        {
            _clientCredientialTokenService = clientCredientialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredientialTokenService.GetToken());
            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                // hata mesajı
            }

            return response;
        }
    }
}
