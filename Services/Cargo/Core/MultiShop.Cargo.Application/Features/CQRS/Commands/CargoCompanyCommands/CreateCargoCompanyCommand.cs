using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;

public class CreateCargoCompanyCommand : IRequest
{
    public string CargoCompanyName { get; set; }

}
