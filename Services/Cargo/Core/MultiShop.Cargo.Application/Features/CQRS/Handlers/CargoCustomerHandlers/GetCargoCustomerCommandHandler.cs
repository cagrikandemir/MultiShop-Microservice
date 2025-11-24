using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class GetCargoCustomerCommandHandler : IRequestHandler<GetCargoCustomerQuery, List<GetCargoCustomerQueryResult>>
{
    private readonly IRepository<CargoCustomer> _repository;
    private readonly IMapper _mapper;
    public GetCargoCustomerCommandHandler(IRepository<CargoCustomer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<GetCargoCustomerQueryResult>> Handle(GetCargoCustomerQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllCargoAsync();
        return  _mapper.Map<List<GetCargoCustomerQueryResult>>(values);
    }
}
