using MediatR;

namespace MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

public class GetActiveUserCommentQuery : IRequest<int>
{
}
