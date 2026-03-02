using AutoMapper;
using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class GetUserCommentByIdCommandHandler : IRequestHandler<GetUserCommentByIdQuery, GetUserCommentByIdQueryResult>
{
    private readonly IMapper _mapper;
    private readonly IRepository<UserComment> _repository;

    public GetUserCommentByIdCommandHandler(IMapper mapper, IRepository<UserComment> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<GetUserCommentByIdQueryResult> Handle(GetUserCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdCommentAsync(request.Id);
        return _mapper.Map<GetUserCommentByIdQueryResult>(value);
    }
}
