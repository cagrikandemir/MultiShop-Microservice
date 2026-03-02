using AutoMapper;
using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class UpdateUserCommentCommandHandler : IRequestHandler<UpdateUserCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<UserComment> _repository;
    public UpdateUserCommentCommandHandler(IMapper mapper, IRepository<UserComment> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Handle(UpdateUserCommentCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateComment(_mapper.Map<UserComment>(request));
    }
}
