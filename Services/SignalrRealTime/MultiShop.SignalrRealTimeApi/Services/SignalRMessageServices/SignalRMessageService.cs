namespace MultiShop.SignalrRealTimeApi.Services.SignalRMessageServices;

public class SignalRMessageService : ISignalRMessageService
{
    private readonly HttpClient _httpClient;

    public SignalRMessageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("GetTotalMessageCountByReceiverId/" + Id);
        var values = await responseMessage.Content.ReadFromJsonAsync<int>();
        return values;
    }
}
