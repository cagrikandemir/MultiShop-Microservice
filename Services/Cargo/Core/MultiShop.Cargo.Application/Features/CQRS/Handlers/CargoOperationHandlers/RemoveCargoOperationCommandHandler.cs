using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoOperationCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoOperationHandlers;

public class RemoveCargoOperationCommandHandler : IRequestHandler<RemoveCargoOperationCommand>
{
    private readonly IRepository<CargoOperation> _cargoOperationRepository;
    private readonly IMapper _mapper;
    public RemoveCargoOperationCommandHandler(IRepository<CargoOperation> cargoOperationRepository, IMapper mapper)
    {
        _cargoOperationRepository = cargoOperationRepository;
        _mapper = mapper;
    }

    public async Task Handle(RemoveCargoOperationCommand request, CancellationToken cancellationToken)
    {
        var value = await _cargoOperationRepository.GetByIdAsync(request.Id);
        await _cargoOperationRepository.DeleteAsync(value);
    }
}
