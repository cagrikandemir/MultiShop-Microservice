using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCompanyQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCompanyResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCompanyHandlers;

public class GetCargoCompanyByIdCommandHandler : IRequestHandler<GetCargoCamponyByIdQuery, GetCargoCompanyByIdQueryResult>
{
    private readonly IRepository<CargoCompany> _cargoCompanyRepository;
    private readonly IMapper _mapper;

    public GetCargoCompanyByIdCommandHandler(IRepository<CargoCompany> cargoCompanyRepository, IMapper mapper)
    {
        _cargoCompanyRepository = cargoCompanyRepository;
        _mapper = mapper;
    }

    public async Task<GetCargoCompanyByIdQueryResult> Handle(GetCargoCamponyByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _cargoCompanyRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetCargoCompanyByIdQueryResult>(value);
    }
}
