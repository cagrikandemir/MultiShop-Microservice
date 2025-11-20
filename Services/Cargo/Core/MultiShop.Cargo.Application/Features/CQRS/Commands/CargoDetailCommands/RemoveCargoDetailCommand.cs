using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;

public class RemoveCargoDetailCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCargoDetailCommand(int ıd)
    {
        Id = ıd;
    }
}
