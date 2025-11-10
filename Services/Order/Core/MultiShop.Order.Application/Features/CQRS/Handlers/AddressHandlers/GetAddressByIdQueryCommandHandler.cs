using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryCommandHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public GetAddressByIdQueryCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _addressRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetAddressByIdQueryResult>(values);
    }
}
