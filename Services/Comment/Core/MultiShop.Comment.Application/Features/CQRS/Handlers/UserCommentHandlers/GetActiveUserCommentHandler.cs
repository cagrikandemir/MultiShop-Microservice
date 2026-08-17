using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;
using MultiShop.Comment.Application.IRepository;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class GetActiveUserCommentHandler : IRequestHandler<GetActiveUserCommentQuery, int>
{
    private readonly ICommentRepository _commentRepository;

    public GetActiveUserCommentHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<int> Handle(GetActiveUserCommentQuery request, CancellationToken cancellationToken)
    {
        return await _commentRepository.GetActiveCommentCount();

    }
}
