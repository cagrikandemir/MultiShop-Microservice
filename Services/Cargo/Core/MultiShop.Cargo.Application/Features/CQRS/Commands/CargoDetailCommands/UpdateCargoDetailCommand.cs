using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;

public class UpdateCargoDetailCommand :IRequest
{
    public int CargoDetailId { get; set; }
    public string SenderCustomer { get; set; }
    public string ReceiverCustomer { get; set; }
    public int Barcode { get; set; }
    public int CargoCompanyId { get; set; }
}
