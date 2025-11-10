using MediatR;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

public class GetAddressQuery: IRequest<List<GetAddressQueryResult>>
{
}
