using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class UpdateCargoCustomerCommandHandler : IRequestHandler<UpdateCargoCustomerCommand>
{
    private readonly IRepository<CargoCustomer> _cargoCustomerRepository;
    private readonly IMapper _mapper;
    public UpdateCargoCustomerCommandHandler(IRepository<CargoCustomer> cargoCustomerRepository, IMapper mapper)
    {
        _cargoCustomerRepository = cargoCustomerRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCargoCustomerCommand request, CancellationToken cancellationToken)
    {
        await _cargoCustomerRepository.UpdateAsync(_mapper.Map<CargoCustomer>(request));
    }
}
