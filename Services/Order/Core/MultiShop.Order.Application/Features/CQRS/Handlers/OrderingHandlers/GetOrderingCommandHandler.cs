using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class GetOrderingCommandHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _OrderingRepositories;
    private readonly IMapper _Mapper;
    public GetOrderingCommandHandler(IRepository<Ordering> orderingRepositories, IMapper mapper)
    {
        _OrderingRepositories = orderingRepositories;
        _Mapper = mapper;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _OrderingRepositories.GetAllAsync();
        return _Mapper.Map<List<GetOrderingQueryResult>>(values);
    }
}
