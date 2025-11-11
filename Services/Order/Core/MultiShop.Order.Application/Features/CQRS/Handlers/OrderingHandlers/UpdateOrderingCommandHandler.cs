using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepositories;
    private readonly IMapper _mapper;

    public UpdateOrderingCommandHandler(IRepository<Ordering> orderingRepositories, IMapper mapper)
    {
        _orderingRepositories = orderingRepositories;
        _mapper = mapper;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _orderingRepositories.UpdateAsync(_mapper.Map<Ordering>(request));
    }
}
