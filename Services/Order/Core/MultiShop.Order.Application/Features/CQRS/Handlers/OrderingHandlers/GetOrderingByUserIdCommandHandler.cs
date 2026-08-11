using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class GetOrderingByUserIdCommandHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IOrderingRepository _orderingRepository;
    private readonly IMapper _mapper;

    public GetOrderingByUserIdCommandHandler(IOrderingRepository orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        var value =  _orderingRepository.GetOrderingsByUserId(request.Id);
        return _mapper.Map<List<GetOrderingByUserIdQueryResult>>(value);
    }
}
