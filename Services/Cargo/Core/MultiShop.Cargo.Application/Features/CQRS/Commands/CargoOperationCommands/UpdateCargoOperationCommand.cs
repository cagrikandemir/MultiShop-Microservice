using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;

public class UpdateCargoOperationCommand : IRequest
{
    public int CargoOperationId { get; set; }
    public int Barcode { get; set; }
    public string Description { get; set; }
    public DateTime OperationDate { get; set; }
}
