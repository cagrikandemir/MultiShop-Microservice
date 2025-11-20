using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoDetailResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoDetailQueries;

public class GetCargoDetailQuery : IRequest<List<GetCargoDetailQueryResult>>
{
}
