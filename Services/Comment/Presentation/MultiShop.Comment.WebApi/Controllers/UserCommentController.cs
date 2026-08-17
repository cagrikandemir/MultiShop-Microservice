using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

[Authorize]
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

    [HttpGet("[action]/{Id}")]
    public async Task<IActionResult> GetUserCommentById(int Id)
    {
        return Ok(await _mediator.Send(new GetUserCommentByIdQuery(Id)));
    }

    [HttpGet("[action]/{Id}")]
    public async Task<IActionResult> GetUserCommentByProductId(string Id)
    {
        var result = await _mediator.Send(new GetUserCommentByProductIdQuery(Id));
        return Ok(result);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetActiveCommentCount()
    {
        var activeCount = await _mediator.Send(
            new GetActiveUserCommentQuery());

        return Ok(activeCount);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetPassiveCommentCount()
    {
        var passiveCount = await _mediator.Send(
            new GetPassiveUserCommentQuery());

        return Ok(passiveCount);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetTotalCommentCount()
    {
        // Burada TOTAL query kullanılmalı
        var totalCount = await _mediator.Send(
            new GetActiveUserCommentQuery());

        return Ok(totalCount);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateUserComment(
        CreateUserCommentCommand createUserCommentCommand)
    {
        await _mediator.Send(createUserCommentCommand);
        return Ok("Yorum Eklendi");
    }

    [HttpDelete("[action]/{Id}")]
    public async Task<IActionResult> DeleteUserComment(int Id)
    {
        await _mediator.Send(new RemoveUserCommentCommand(Id));
        return Ok("Yorum Silindi");
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUserComment(
        UpdateUserCommentCommand updateUserCommentCommand)
    {
        await _mediator.Send(updateUserCommentCommand);
        return Ok("Yorum Güncellendi");
    }
}