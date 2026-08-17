using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;
using MultiShop.Comment.Application.IRepository;

namespace MultiShop.Comment.Application.Features.CQRS.Handlers.UserCommentHandlers;

public class GetPassiveUserCommentHandler : IRequestHandler<GetPassiveUserCommentQuery, int>
{
    private readonly ICommentRepository _commentRepository;

    public GetPassiveUserCommentHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<int> Handle(GetPassiveUserCommentQuery request, CancellationToken cancellationToken)
    {
        return await _commentRepository.GetPassiveCommentCount();

    }
}
