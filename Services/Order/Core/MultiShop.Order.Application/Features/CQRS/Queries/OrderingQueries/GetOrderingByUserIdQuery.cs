using MediatR;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;

namespace MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;

public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
{
    public string Id { get; set; }

    public GetOrderingByUserIdQuery(string ıd)
    {
        Id = ıd;
    }
}
