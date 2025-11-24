using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoOperationHandlers;

public class CreateCargoOperationCommandHandler : IRequestHandler<CreateCargoOperationCommand>
{
    private readonly IRepository<CargoOperation> _cargoOperationRepository;
    private readonly IMapper _mapper;
    public CreateCargoOperationCommandHandler(IRepository<CargoOperation> cargoOperationRepository, IMapper mapper)
    {
        _cargoOperationRepository = cargoOperationRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateCargoOperationCommand request, CancellationToken cancellationToken)
    {
        await _cargoOperationRepository.CreateAsync(_mapper.Map<CargoOperation>(request));
    }
}
