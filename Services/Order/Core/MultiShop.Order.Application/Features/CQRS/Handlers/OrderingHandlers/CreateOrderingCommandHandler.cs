using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _OrderingRepositories;
    private readonly IMapper _mapper;

    public CreateOrderingCommandHandler(IRepository<Ordering> orderingRepositories, IMapper mapper)
    {
        _OrderingRepositories = orderingRepositories;
        _mapper = mapper;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _OrderingRepositories.AddAsync(_mapper.Map<Ordering>(request));
    }
}
