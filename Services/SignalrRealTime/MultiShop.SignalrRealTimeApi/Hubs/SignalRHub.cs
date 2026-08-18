using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalrRealTimeApi.Services.SignalRCommentServices;
using MultiShop.SignalrRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalrRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        //private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendCommentStatisticCount()
        {
            var GetTotalComment = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", GetTotalComment);

            //var GetTotalMessage = _signalRMessageService.GetTotalMessageCountByReceiverId(Id);
            //await Clients.All.SendAsync("ReceiveMessageCount", GetTotalMessage);
        } 
    }
}
