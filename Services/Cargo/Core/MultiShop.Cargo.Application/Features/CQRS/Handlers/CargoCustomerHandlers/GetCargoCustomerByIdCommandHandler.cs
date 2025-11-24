using AutoMapper;
using MediatR;
using MultiShop.Cargo.Application.Features.CQRS.Queries.CargoCustomerQueries;
using MultiShop.Cargo.Application.Features.CQRS.Results.CargoCustomerResults;
using MultiShop.Cargo.Application.Interfaces;
using MultiShop.Cargo.Domain.Entities;

namespace MultiShop.Cargo.Application.Features.CQRS.Handlers.CargoCustomerHandlers;

public class GetCargoCustomerByIdCommandHandler : IRequestHandler<GetCargoCustomerByIdQuery, GetCargoCustomerByIdQueryResult>
{
    private readonly IRepository<CargoCustomer> _repository;
    private readonly IMapper _mapper;
    public GetCargoCustomerByIdCommandHandler(IRepository<CargoCustomer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetCargoCustomerByIdQueryResult> Handle(GetCargoCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<GetCargoCustomerByIdQueryResult>(value);
    }
}
