using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> InBox(string Id)
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInBoxMessagesAsync(user.Id);
            return View(values);
        }
        public async Task<IActionResult> SendBox(string Id)
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendBoxMessagesAsync(user.Id);
            return View(values);
        }
    }
}
