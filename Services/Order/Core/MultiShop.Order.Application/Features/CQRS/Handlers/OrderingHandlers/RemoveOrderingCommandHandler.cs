using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderingHandlers;

public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
{
    private readonly IRepository<Ordering> _OrderingRepositories;
    private readonly IMapper _mapper;
    public RemoveOrderingCommandHandler(IRepository<Ordering> orderingRepositories, IMapper mapper)
    {
        _OrderingRepositories = orderingRepositories;
        _mapper = mapper;
    }

    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _OrderingRepositories.GetByIdAsync(request.Id);
        await _OrderingRepositories.DeleteAsync(value);
    }
}
