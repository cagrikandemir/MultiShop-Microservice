using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoDetailHandlers;

public class CreateCargoDetailCommandHandler : IRequestHandler<CreateCargoDetailCommand>
{
    private readonly IRepository<CargoDetail> _cargoDetailRepository;
    private readonly IMapper _mapper;
    public CreateCargoDetailCommandHandler(IRepository<CargoDetail> cargoDetailRepository, IMapper mapper)
    {
        _cargoDetailRepository = cargoDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(CreateCargoDetailCommand request, CancellationToken cancellationToken)
    {
       await _cargoDetailRepository.CreateAsync(_mapper.Map<CargoDetail>(request));
    }
}
