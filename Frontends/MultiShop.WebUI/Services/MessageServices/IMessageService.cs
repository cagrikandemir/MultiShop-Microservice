using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices;

public interface IMessageService
{
    Task<List<ResultInBoxMessageDto>> GetInBoxMessagesAsync(string Id);
    Task<List<ResultSendBoxMessageDto>> GetSendBoxMessagesAsync(string Id);
    Task <int> GetTotalMessageCountByReceiverId(string Id);
}
