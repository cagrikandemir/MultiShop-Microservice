using MediatR;

namespace MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;

public class RemoveUserCommentCommand : IRequest
{
    public int Id { get; set; }

    public RemoveUserCommentCommand(int ıd)
    {
        Id = ıd;
    }
}
