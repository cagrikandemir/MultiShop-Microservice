using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommands>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public RemoveAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task Handle(RemoveAddressCommands request, CancellationToken cancellationToken)
    {
        var values = await _addressRepository.GetByIdAsync(request.Id);
        await _addressRepository.DeleteAsync(values);
    }
}
