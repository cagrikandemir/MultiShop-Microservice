using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;

namespace MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

public class GetUserCommentQuery : IRequest<List<GetUserCommentQueryResult>>
{
}
