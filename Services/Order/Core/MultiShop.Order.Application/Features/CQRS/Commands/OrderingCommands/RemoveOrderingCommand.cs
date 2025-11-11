using MediatR;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;

public class RemoveOrderingCommand : IRequest
{
    public int Id { get; set; }

    public RemoveOrderingCommand(int id)
    {
        Id = id;
    }
}
