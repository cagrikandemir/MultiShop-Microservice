using MediatR;
using MultiShop.Comment.Application.Features.CQRS.Results.UserCommentResults;

namespace MultiShop.Comment.Application.Features.CQRS.Queries.UserCommentQueries;

public class GetUserCommentByIdQuery : IRequest<GetUserCommentByIdQueryResult>
{
    public int Id { get; set; }

    public GetUserCommentByIdQuery(int ıd)
    {
        Id = ıd;
    }
}
