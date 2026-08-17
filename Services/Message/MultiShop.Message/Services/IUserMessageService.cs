using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services;

public interface IUserMessageService
{
    Task<List<ResultMessageDto>> GetAllMessagesAsync();
    Task CreateMessageAsync(CreateMessageDto createMessageDto);
    Task DeleteMessageAsync(int Id);
    Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
    Task<GetByIdMessageDto> GetByIdMessageAsync(int Id);

    Task<List<ResultInBoxMessageDto>> GetInBoxMessagesAsync(string Id);
    Task<List<ResultSendBoxMessageDto>> GetSendBoxMessagesAsync(string Id);
    Task<int> GetTotalMessages();
    Task<int> GetTotalMessageCountByReceiverId(string Id);

}
