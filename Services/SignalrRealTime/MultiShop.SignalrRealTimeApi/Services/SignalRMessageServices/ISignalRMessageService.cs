namespace MultiShop.SignalrRealTimeApi.Services.SignalRMessageServices;

public interface ISignalRMessageService
{
    Task<int> GetTotalMessageCountByReceiverId(string Id);


}
