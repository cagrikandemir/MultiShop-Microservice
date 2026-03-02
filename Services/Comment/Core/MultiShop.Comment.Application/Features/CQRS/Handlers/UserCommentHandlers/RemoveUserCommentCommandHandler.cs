using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class RemoveUserCommentCommandHandler : IRequestHandler<RemoveUserCommentCommand>
{
    private readonly IRepository<UserComment> _repository;

    public RemoveUserCommentCommandHandler(IRepository<UserComment> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveUserCommentCommand request, CancellationToken cancellationToken)
    {
       var value = await _repository.GetByIdCommentAsync(request.Id);
       await _repository.DeleteComment(value);

    }
}
