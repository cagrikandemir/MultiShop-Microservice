using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoOperationQueries;

public class GetCargoOperationQuery : IRequest<List<GetCargoOperationQueryResult>>
{
}
