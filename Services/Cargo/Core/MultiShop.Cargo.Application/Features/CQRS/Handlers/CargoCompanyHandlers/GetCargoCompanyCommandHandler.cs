using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCompanyQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCompanyResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCompanyHandlers;

public class GetCargoCompanyCommandHandler : IRequestHandler<GetCargoCompanyQuery, List<GetCargoCompanyQueryResult>>
{
    private readonly IRepository<CargoCompany> _cargoCompanyRepository;
    private readonly IMapper    _mapper;
    public GetCargoCompanyCommandHandler(IRepository<CargoCompany> cargoCompanyRepository, IMapper mapper)
    {
        _cargoCompanyRepository = cargoCompanyRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCargoCompanyQueryResult>> Handle(GetCargoCompanyQuery request, CancellationToken cancellationToken)
    {
        var values = await _cargoCompanyRepository.GetAllCargoAsync();
        return _mapper.Map<List<GetCargoCompanyQueryResult>>(values);
    }
}
