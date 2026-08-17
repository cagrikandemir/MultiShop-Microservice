using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services;

public class UserMessageService : IUserMessageService
{
    private readonly MessageContext _messageContext;
    private readonly IMapper _mapper;

    public UserMessageService(MessageContext messageContext, IMapper mapper)
    {
        _messageContext = messageContext;
        _mapper = mapper;
    }

    public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
    {
        var value = _mapper.Map<UserMessage>(createMessageDto);
        await _messageContext.UserMessages.AddAsync(value);
        await _messageContext.SaveChangesAsync();
    }

    public async Task DeleteMessageAsync(int Id)
    {
       var value = await _messageContext.UserMessages.FindAsync(Id);
         _messageContext.UserMessages.Remove(value);
        await _messageContext.SaveChangesAsync();

    }

    public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
    {
        var values =await _messageContext.UserMessages.ToListAsync();
        return _mapper.Map<List<ResultMessageDto>>(values);
    }

    public async Task<GetByIdMessageDto> GetByIdMessageAsync(int Id)
    {
        var value = await _messageContext.UserMessages.FindAsync(Id);
        return _mapper.Map<GetByIdMessageDto>(value);
    }

    public async Task<List<ResultInBoxMessageDto>> GetInBoxMessagesAsync(string Id)
    {
        var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == Id).ToListAsync();
        return _mapper.Map<List<ResultInBoxMessageDto>>(values);
    }

    public async Task<List<ResultSendBoxMessageDto>> GetSendBoxMessagesAsync(string Id)
    {
        var values = await _messageContext.UserMessages.Where(x => x.SenderId == Id).ToListAsync();
        return _mapper.Map<List<ResultSendBoxMessageDto>>(values);
    }

    public async Task<int> GetTotalMessageCountByReceiverId(string Id)
    {
        int value = await _messageContext.UserMessages.Where(x => x.ReceiverId == Id).CountAsync();
        return value;
    }

    public async Task<int> GetTotalMessages()
    {
        var values = await _messageContext.UserMessages.CountAsync();
        return values;
    }

    public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
    {
        var value = _mapper.Map<UserMessage>(updateMessageDto);
         _messageContext.UserMessages.Update(value);
        await _messageContext.SaveChangesAsync();

    }
}
