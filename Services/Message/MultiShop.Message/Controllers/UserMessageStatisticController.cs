using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class UserMessageStatisticController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageStatisticController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int values = await _userMessageService.GetTotalMessages();
            return Ok(values);
        }
    }
}
