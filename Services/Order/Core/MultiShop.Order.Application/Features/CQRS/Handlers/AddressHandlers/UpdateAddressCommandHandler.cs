using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
{
    private readonly IRepository<Address> _repositoryAddress;
    private readonly IMapper _mapper;

    public UpdateAddressCommandHandler(IRepository<Address> repositoryAddress, IMapper mapper)
    {
        _repositoryAddress = repositoryAddress;
        _mapper = mapper;
    }

    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        await _repositoryAddress.UpdateAsync(_mapper.Map<Address>(request));
    }
}
