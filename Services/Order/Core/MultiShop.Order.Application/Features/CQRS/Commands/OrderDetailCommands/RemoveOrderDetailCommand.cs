using MediatR;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public class RemoveOrderDetailCommand : IRequest
{
    public int Id { get; set; }

    public RemoveOrderDetailCommand(int ıd)
    {
        Id = ıd;
    }
}
