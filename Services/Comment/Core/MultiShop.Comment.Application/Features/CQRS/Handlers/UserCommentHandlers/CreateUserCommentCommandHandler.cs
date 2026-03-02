using AutoMapper;
using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Commands.UserCommentCommands;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class CreateUserCommentCommandHandler : IRequestHandler<CreateUserCommentCommand>
{
    private readonly IRepository<UserComment> _repository;
    private readonly IMapper _mapper;

    public CreateUserCommentCommandHandler(IRepository<UserComment> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateUserCommentCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateComment(_mapper.Map<UserComment>(request));
    }
}
