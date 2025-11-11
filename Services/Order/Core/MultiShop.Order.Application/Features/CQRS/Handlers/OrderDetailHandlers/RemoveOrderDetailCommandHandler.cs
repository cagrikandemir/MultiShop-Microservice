using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class RemoveOrderDetailCommandHandler : IRequestHandler<RemoveOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;
    private readonly IMapper _mapper;

    public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
       var value = await _orderDetailRepository.GetByIdAsync(request.Id);
        await _orderDetailRepository.DeleteAsync(value);
    }
}
