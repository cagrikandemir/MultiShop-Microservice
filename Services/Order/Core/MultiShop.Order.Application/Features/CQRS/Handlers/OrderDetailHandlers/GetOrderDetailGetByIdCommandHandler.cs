using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailGetByIdCommandHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;
    public GetOrderDetailGetByIdCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
       var value= await _orderDetailRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetOrderDetailByIdQueryResult>(value);
    }
}
