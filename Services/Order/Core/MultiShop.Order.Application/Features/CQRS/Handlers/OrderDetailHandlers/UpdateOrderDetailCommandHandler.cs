using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _orderDetailRepository.UpdateAsync(_mapper.Map<OrderDetail>(request));
    }
}
