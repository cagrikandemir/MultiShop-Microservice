using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoOperationQueries;

public class GetCargoOperationByIdQuery : IRequest<GetCargoOperationByIdQueryResult>
{
    public int Id { get; set; }

    public GetCargoOperationByIdQuery(int ıd)
    {
        Id = ıd;
    }
}
