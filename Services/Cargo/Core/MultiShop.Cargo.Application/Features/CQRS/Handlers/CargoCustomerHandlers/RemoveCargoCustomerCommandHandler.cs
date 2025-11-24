using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCustomerCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class RemoveCargoCustomerCommandHandler : IRequestHandler<RemoveCargoCustomerCommand>
{
    private readonly IRepository<CargoCustomer> _repository;
    
    public RemoveCargoCustomerCommandHandler(IRepository<CargoCustomer> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveCargoCustomerCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
    }
}
