using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;

public class RemoveCargoCustomerCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCargoCustomerCommand(int ıd)
    {
        Id = ıd;
    }
}
