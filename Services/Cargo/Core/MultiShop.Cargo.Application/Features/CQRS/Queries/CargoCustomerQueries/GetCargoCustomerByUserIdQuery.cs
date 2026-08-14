using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;

public class GetCargoCustomerByUserIdQuery  : IRequest<List<GetCargoCustomerByUserIdQueryResult>>
{
    public string UserId { get; set; }

    public GetCargoCustomerByUserIdQuery(string userId)
    {
        UserId = userId;
    }
}
