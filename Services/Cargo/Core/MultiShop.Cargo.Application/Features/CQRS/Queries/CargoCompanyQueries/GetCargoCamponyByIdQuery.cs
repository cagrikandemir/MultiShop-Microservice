using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCompanyResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCompanyQueries;

public class GetCargoCamponyByIdQuery : IRequest<GetCargoCompanyByIdQueryResult>
{
    public int Id { get; set; }

    public GetCargoCamponyByIdQuery(int id)
    {
        Id = id;
    }
}
