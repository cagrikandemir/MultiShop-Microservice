using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoDetailHandlers;

public class RemoveCargoDetailCommandHandler : IRequestHandler<RemoveCargoDetailCommand>
{
    private readonly IRepository<CargoDetail> _repository;

    public RemoveCargoDetailCommandHandler(IRepository<CargoDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCargoDetailCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
    }
}
