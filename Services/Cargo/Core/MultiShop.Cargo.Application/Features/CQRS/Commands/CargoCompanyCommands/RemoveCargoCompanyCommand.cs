using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;

public class RemoveCargoCompanyCommand : IRequest
{
    public int Id { get; set; }

    public RemoveCargoCompanyCommand(int ıd)
    {
        Id = ıd;
    }
}
