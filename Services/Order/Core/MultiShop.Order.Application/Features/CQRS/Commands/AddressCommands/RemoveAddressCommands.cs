using MediatR;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;

public class RemoveAddressCommands :IRequest
{
    public int Id { get; set; }

    public RemoveAddressCommands(int ıd)
    {
        Id = ıd;
    }
}
