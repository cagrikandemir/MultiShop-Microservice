using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCompanyHandlers;

public class UpdateCargoCompanyCommandHandler : IRequestHandler<UpdateCargoCompanyCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<CargoCompany> _repository;
    public UpdateCargoCompanyCommandHandler(IMapper mapper, IRepository<CargoCompany> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Handle(UpdateCargoCompanyCommand request, CancellationToken cancellationToken)
    {
        await _repository.UpdateAsync(_mapper.Map<CargoCompany>(request));
    }
}
