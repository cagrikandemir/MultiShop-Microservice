using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;

public class UpdateCargoCompanyCommand :IRequest
{
    public int CargoCompanyId { get; set; }
    public string CargoCompanyName { get; set; }
}
