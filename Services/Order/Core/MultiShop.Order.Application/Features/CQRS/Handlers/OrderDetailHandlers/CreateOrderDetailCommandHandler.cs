using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
{
    private readonly IRepository<OrderDetail> _OrderDetailRepository;
    private readonly IMapper _mapper;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
    {
        _OrderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _OrderDetailRepository.AddAsync(_mapper.Map<OrderDetail>(request));
    }
}
