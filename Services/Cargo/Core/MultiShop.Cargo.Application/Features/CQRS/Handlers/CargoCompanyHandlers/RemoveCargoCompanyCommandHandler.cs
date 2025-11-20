using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCompanyHandlers;

public class RemoveCargoCompanyCommandHandler : IRequestHandler<RemoveCargoCompanyCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<CargoCompany> _repository;
    public RemoveCargoCompanyCommandHandler(IMapper mapper, IRepository<CargoCompany> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Handle(RemoveCargoCompanyCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
    }
}
