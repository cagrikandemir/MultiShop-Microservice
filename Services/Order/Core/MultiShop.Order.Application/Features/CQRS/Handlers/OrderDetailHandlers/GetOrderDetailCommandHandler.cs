using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailCommandHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public GetOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var values = await _orderDetailRepository.GetAllAsync();
        return _mapper.Map<List<GetOrderDetailQueryResult>>(values);
    }
}
