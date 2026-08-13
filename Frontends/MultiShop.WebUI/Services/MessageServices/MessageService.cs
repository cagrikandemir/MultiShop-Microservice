using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly HttpClient _httpClient;

    public MessageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultInBoxMessageDto>> GetInBoxMessagesAsync(string Id)
    {
        var responMessage = await _httpClient.GetAsync("GetMessageInBox/" + Id);
        var values = await responMessage.Content.ReadFromJsonAsync<List<ResultInBoxMessageDto>>();
        return values;
    }

    public async Task<List<ResultSendBoxMessageDto>> GetSendBoxMessagesAsync(string Id)
    {
        var responMessage = await _httpClient.GetAsync("GetMessageSendBox/" + Id);
        var values = await responMessage.Content.ReadFromJsonAsync<List<ResultSendBoxMessageDto>>();
        return values;
    }
}
