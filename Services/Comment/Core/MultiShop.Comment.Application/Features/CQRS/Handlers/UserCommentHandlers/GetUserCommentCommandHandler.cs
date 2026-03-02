using AutoMapper;
using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;
using MultiShop.Comment.Application.IRepository;
using MultiShop.Comment.Domain.Entities;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class GetUserCommentCommandHandler : IRequestHandler<GetUserCommentQuery, List<GetUserCommentQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<UserComment> _repository;

    public GetUserCommentCommandHandler(IMapper mapper, IRepository<UserComment> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<GetUserCommentQueryResult>> Handle(GetUserCommentQuery request, CancellationToken cancellationToken)
    {
         var Results = await _repository.GetAllCommentAsync();
         return _mapper.Map<List<GetUserCommentQueryResult>>(Results);
    }
}
