using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Persistence.Context;

namespace MultiShop.Comment.WebApi.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class CommentStatisticController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentStatisticController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCommentCount()
        {
            int values = await _commentContext.UserComments.CountAsync();
            return Ok(values);
        }
    }
}
