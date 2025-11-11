using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class GetOrderingByIdCommandHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _orderingRepository;
    private readonly IMapper _mapper;
    public GetOrderingByIdCommandHandler(IRepository<Ordering> orderingRepository, IMapper mapper)
    {
        _orderingRepository = orderingRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _orderingRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetOrderingByIdQueryResult>(value);
    }
}
