using MyShop.WebUI.Services.Interfaces;
using MyShop.WebUI.Settings;
using Microsoft.Extensions.Options;
using IdentityModel.Client;
using System.Collections.Concurrent;

namespace MyShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredientialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings;
        private static readonly ConcurrentDictionary<string, (string Token, DateTimeOffset Expiry)> _tokenCache = new();

        public ClientCredentialTokenService(
            IOptions<ClientSettings> clientSettings,
            HttpClient httpClient,
            IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _clientSettings = clientSettings.Value;
            _httpClient = httpClient;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<string> GetToken()
        {
            if (_tokenCache.TryGetValue("myshoptoken", out var cached) &&
                cached.Expiry > DateTimeOffset.UtcNow.AddSeconds(30))
            {
                return cached.Token;
            }

            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false
                    }
                });

            if (discoveryEndPoint.IsError)
            {
                throw new Exception($"Discovery document alınamadı: {discoveryEndPoint.Error}");
            }

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    ClientId = _clientSettings.MyShopVisitorClient.ClientId,
                    ClientSecret = _clientSettings.MyShopVisitorClient.ClientSecret,
                    Address = discoveryEndPoint.TokenEndpoint,
                    Scope = "OcelotFullPermission CatalogFullPermission"
                });

            if (tokenResponse.IsError)
            {
                throw new Exception($"Token alınamadı: {tokenResponse.Error}");
            }

            _tokenCache["myshoptoken"] = (tokenResponse.AccessToken, DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn));

            return tokenResponse.AccessToken;
        }
    }
}
