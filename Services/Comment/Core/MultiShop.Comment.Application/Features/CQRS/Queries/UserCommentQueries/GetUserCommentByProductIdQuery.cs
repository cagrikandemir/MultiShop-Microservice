using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;

namespace MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

public class GetUserCommentByProductIdQuery : IRequest<List<GetUserCommentByProductIdQueryResult>>
{
    public string Id { get; set; }

    public GetUserCommentByProductIdQuery(string ıd)
    {
        Id = ıd;
    }
}
