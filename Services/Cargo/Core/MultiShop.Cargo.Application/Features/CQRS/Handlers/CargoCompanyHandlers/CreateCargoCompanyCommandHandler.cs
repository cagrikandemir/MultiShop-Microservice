using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoCompanyCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCompanyHandlers;

public class CreateCargoCompanyCommandHandler : IRequestHandler<CreateCargoCompanyCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<CargoCompany> _repository;
    public CreateCargoCompanyCommandHandler(IMapper mapper, IRepository<CargoCompany> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Handle(CreateCargoCompanyCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(_mapper.Map<CargoCompany>(request));
    }
}
