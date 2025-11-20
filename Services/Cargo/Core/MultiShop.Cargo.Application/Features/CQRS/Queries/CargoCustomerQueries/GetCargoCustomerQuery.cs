using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;

namespace MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;

public class GetCargoCustomerQuery :IRequest<List<GetCargoCustomerQueryResult>>
{
}
