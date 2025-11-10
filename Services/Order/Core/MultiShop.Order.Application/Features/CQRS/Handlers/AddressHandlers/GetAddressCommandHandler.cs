using AutoMapper;
using MediatR;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressCommandHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
{
    private readonly IRepository<Address> _addressRepository;
    private readonly IMapper _mapper;

    public GetAddressCommandHandler(IRepository<Address> addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var values = await _addressRepository.GetAllAsync();
        return _mapper.Map<List<GetAddressQueryResult>>(values);
    }
}
