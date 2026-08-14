using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;
using MultiShop.Cargo.Application.Interfaces;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class GetCargoCustomerByUserIdHandler : IRequestHandler<GetCargoCustomerByUserIdQuery, List<GetCargoCustomerByUserIdQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly ICargoCustomerService _cargoCustomerService;

    public GetCargoCustomerByUserIdHandler(IMapper mapper, ICargoCustomerService cargoCustomerService)
    {
        _mapper = mapper;
        _cargoCustomerService = cargoCustomerService;
    }

    public async Task<List<GetCargoCustomerByUserIdQueryResult>> Handle(GetCargoCustomerByUserIdQuery request, CancellationToken cancellationToken)
    {
        var values = _cargoCustomerService.GetCargoCustomerByUserId(request.UserId);
        return  _mapper.Map<List<GetCargoCustomerByUserIdQueryResult>>(values);
    }
}
