using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;

public class GetCargoCustomerByIdQuery : IRequest<GetCargoCustomerByIdQueryResult>
{
    public int Id { get; set; }

    public GetCargoCustomerByIdQuery(int ıd)
    {
        Id = ıd;
    }
}
