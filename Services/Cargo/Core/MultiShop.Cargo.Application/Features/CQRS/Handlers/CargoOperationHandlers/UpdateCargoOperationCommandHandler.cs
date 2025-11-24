using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoOperationHandlers;

public class UpdateCargoOperationCommandHandler : IRequestHandler<UpdateCargoOperationCommand>
{
    private readonly IRepository<CargoOperation> _cargoOperationRepository;
    private readonly IMapper _mapper;
    public UpdateCargoOperationCommandHandler(IRepository<CargoOperation> cargoOperationRepository, IMapper mapper)
    {
        _cargoOperationRepository = cargoOperationRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCargoOperationCommand request, CancellationToken cancellationToken)
    {
        await _cargoOperationRepository.UpdateAsync(_mapper.Map<CargoOperation>(request));
    }
}
