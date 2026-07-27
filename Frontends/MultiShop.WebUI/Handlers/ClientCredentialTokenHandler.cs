using MultiShop.WebUI.Services.Interfaces;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler : DelegatingHandler
    {
        private readonly IClientCredentialTokenService _clientCredentialTokenService;

        public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
        {
            _clientCredentialTokenService = clientCredentialTokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
            var responseMessage = await base.SendAsync(request, cancellationToken);
            if(responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized) { 
             
                //hata Mesajı
            }
            return responseMessage;
        }
    }
}
