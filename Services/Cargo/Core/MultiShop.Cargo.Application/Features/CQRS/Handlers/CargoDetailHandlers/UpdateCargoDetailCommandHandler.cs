using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Commands.CargoDetailCommands;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoDetailHandlers;

public class UpdateCargoDetailCommandHandler : IRequestHandler<UpdateCargoDetailCommand>
{
    private readonly IRepository<CargoDetail> _cargoDetailRepository;
    private readonly IMapper _mapper;
    public UpdateCargoDetailCommandHandler(IRepository<CargoDetail> cargoDetailRepository, IMapper mapper)
    {
        _cargoDetailRepository = cargoDetailRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateCargoDetailCommand request, CancellationToken cancellationToken)
    {
        await _cargoDetailRepository.UpdateAsync(_mapper.Map<CargoDetail>(request));
    }
}
