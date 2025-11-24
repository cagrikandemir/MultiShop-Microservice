using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoOperationQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoOperationHandlers;

public class GetCargoOperationCommandHandler : IRequestHandler<GetCargoOperationQuery, List<GetCargoOperationQueryResult>>
{
    private readonly IRepository<CargoOperation> _cargoOperationRepository;
    private readonly IMapper _mapper;
    public GetCargoOperationCommandHandler(IRepository<CargoOperation> cargoOperationRepository, IMapper mapper)
    {
        _cargoOperationRepository = cargoOperationRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCargoOperationQueryResult>> Handle(GetCargoOperationQuery request, CancellationToken cancellationToken)
    {
        var values = await _cargoOperationRepository.GetAllCargoAsync();
        return _mapper.Map<List<GetCargoOperationQueryResult>>(values);
    }
}
