using Duende.IdentityModel.Client;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;
using static Duende.IdentityModel.OidcConstants;

namespace MultiShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly HttpClient _httpClient;
        private readonly ClientSettings _clientSettings;
        private readonly IMemoryCache _memoryCache;

        private const string TokenCacheKey = "multishoptoken";

        public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IOptions<ClientSettings> clientSettings, IMemoryCache memoryCache)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            _httpClient = httpClient;
            _clientSettings = clientSettings.Value;
            _memoryCache = memoryCache;
        }

        public async Task<string> GetToken()
        {
            if (_memoryCache.TryGetValue(TokenCacheKey, out string accessToken))
            {
                return accessToken;
            }

            var discovery = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            if (discovery.IsError)
            {
                throw new Exception(discovery.Error);
            }

            var tokenResponse = await _httpClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discovery.TokenEndpoint,
                    ClientId = _clientSettings.MultiShopVisitorClient.ClientId,
                    ClientSecret = _clientSettings.MultiShopVisitorClient.ClientSecret
                });

            if (tokenResponse.IsError)
            {
                throw new Exception(tokenResponse.Error);
            }

            _memoryCache.Set(
                TokenCacheKey,
                tokenResponse.AccessToken,
                TimeSpan.FromSeconds(tokenResponse.ExpiresIn)
            );

            return tokenResponse.AccessToken;
        }
    }
}
