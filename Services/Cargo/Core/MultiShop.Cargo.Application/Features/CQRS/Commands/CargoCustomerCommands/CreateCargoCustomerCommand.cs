using MediatR;

namespace MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;

public class CreateCargoCustomerCommand : IRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Adress { get; set; }
    public string UserCustomerId { get; set; }

}
