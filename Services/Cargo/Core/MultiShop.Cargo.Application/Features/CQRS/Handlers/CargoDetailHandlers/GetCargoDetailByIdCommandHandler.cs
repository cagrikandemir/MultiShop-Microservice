using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoDetailQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoDetailResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoDetailHandlers;

public class GetCargoDetailByIdCommandHandler : IRequestHandler<GetCargoDetailByIdQuery, GetCargoDetailByIdQueryResult>
{
    private readonly IRepository<CargoDetail> _cargoDetailRepository;
    private readonly IMapper _mapper;
    public GetCargoDetailByIdCommandHandler(IRepository<CargoDetail> cargoDetailRepository, IMapper mapper)
    {
        _cargoDetailRepository = cargoDetailRepository;
        _mapper = mapper;
    }

    public async Task<GetCargoDetailByIdQueryResult> Handle(GetCargoDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _cargoDetailRepository.GetByIdAsync(request.Id);
        return  _mapper.Map<GetCargoDetailByIdQueryResult>(value);
    }
}
