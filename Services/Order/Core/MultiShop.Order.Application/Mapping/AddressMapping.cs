using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AdressResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mapping;

public class AddressMapping :Profile
{
    public AddressMapping()
    {
        CreateMap<Address,GetAddressQueryResult>().ReverseMap();
        CreateMap<Address,GetAddressByIdQueryResult>().ReverseMap();
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, RemoveAddressCommands>().ReverseMap();
    }
}
