using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoDetailQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoDetailResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoDetailHandlers;

public class GetCargoDetailCommandHandler : IRequestHandler<GetCargoDetailQuery, List<GetCargoDetailQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<CargoDetail> _repository;
    public GetCargoDetailCommandHandler(IMapper mapper, IRepository<CargoDetail> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<GetCargoDetailQueryResult>> Handle(GetCargoDetailQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllCargoAsync();
        return  _mapper.Map<List<GetCargoDetailQueryResult>>(values);
    }
}
