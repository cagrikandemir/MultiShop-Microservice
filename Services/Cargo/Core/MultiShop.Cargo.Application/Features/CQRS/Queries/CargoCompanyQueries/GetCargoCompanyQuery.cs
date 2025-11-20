using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCompanyResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCompanyQueries;

public class GetCargoCompanyQuery : IRequest<List<GetCargoCompanyQueryResult>>
{
}
