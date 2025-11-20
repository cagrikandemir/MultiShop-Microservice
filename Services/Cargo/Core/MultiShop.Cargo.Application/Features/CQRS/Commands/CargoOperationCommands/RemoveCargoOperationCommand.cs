using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;

public class RemoveCargoOperationCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCargoOperationCommand(int ıd)
    {
        Id = ıd;
    }
}
