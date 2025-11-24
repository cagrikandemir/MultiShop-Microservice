using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class CreateCargoCustomerCommandHandler : IRequestHandler<CreateCargoCustomerCommand>
{
    private readonly IRepository<CargoCustomer> _cargoCustomerRepository;
    private readonly IMapper _mapper;

    public CreateCargoCustomerCommandHandler(IRepository<CargoCustomer> cargoCustomerRepository, IMapper mapper)
    {
        _cargoCustomerRepository = cargoCustomerRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateCargoCustomerCommand request, CancellationToken cancellationToken)
    {
        await _cargoCustomerRepository.CreateAsync(_mapper.Map<CargoCustomer>(request));
    }
}
