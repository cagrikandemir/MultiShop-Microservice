using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet("[action]")]
        public  async Task<IActionResult> GetAllUserMessage()
        {
           var values = await _userMessageService.GetAllMessagesAsync();
           return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdUserMessage(int Id)
        {
            var values = await _userMessageService.GetByIdMessageAsync(Id);
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetMessageSendBox(string Id)
        {
            var values = await _userMessageService.GetSendBoxMessagesAsync(Id);
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetMessageInBox(string Id)
        {
            var values = await _userMessageService.GetInBoxMessagesAsync(Id);
            return Ok(values);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTotalMessage()
        {
            var values = await _userMessageService.GetTotalMessages();
            return Ok(values);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult>CreateUserMessage(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("User Message Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteUserMessage(int Id) {

            await _userMessageService.DeleteMessageAsync(Id);
            return Ok("User Message Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUserMessage(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("User Message Güncellendi");
        }
    }
}
