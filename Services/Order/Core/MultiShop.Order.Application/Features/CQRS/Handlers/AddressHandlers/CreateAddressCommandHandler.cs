using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IMapper mapper, IRepository<Address> addressRepository)
    {
        _mapper = mapper;
        _addressRepository = addressRepository;
    }

    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.AddAsync(_mapper.Map<Address>(request));
    }
}
