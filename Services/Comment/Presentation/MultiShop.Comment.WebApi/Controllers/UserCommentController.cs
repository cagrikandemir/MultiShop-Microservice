using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

namespace MultiShop.Comment.WebApi.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class UserCommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserCommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserComment()
        {
            return Ok(await _mediator.Send(new GetUserCommentQuery()));
        }
        [HttpGet("[Action]/{Id}")]
        public async Task<IActionResult> GetUserCommentById(int Id)
        {
            return Ok( await _mediator.Send(new GetUserCommentByIdQuery(Id)));
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> CreateUserComment(CreateUserCommentCommand createUserCommentCommand)
        {
            await _mediator.Send(createUserCommentCommand);
            return Ok("Yorum Eklendi");
        }
        [HttpDelete("[Action]/{Id}")]
        public async Task<IActionResult>DeleteUserComment(int Id)
        {
            await _mediator.Send(new RemoveUserCommentCommand(Id));
            return Ok("Yorum Silindi");
        }
        [HttpPut("[Action]")]
        public async Task<IActionResult>UpdateUserComment(UpdateUserCommentCommand updateUserCommentCommand)
        {
            await _mediator.Send(updateUserCommentCommand);
            return Ok("Yorum Güncellendi");
        }
    }
}
