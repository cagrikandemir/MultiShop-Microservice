using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoOperationQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoOperationQueries;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoOperationHandlers;

public class GetCargoOperationByIdCommandHandler : IRequestHandler<GetCargoOperationByIdQuery, GetCargoOperationByIdQueryResult>
{

    private readonly IRepository<CargoOperation> _cargoOperationRepository;
    private readonly IMapper _mapper;
    public GetCargoOperationByIdCommandHandler(IRepository<CargoOperation> cargoOperationRepository, IMapper mapper)
    {
        _cargoOperationRepository = cargoOperationRepository;
        _mapper = mapper;
    }

    public async Task<GetCargoOperationByIdQueryResult> Handle(GetCargoOperationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _cargoOperationRepository.GetByIdAsync(request.Id);
        return  _mapper.Map<GetCargoOperationByIdQueryResult>(value);
    }
}
