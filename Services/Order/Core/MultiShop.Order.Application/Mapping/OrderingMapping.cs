using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.CQRS.Results.OrderingResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mapping;

public class OrderingMapping : Profile
{
    public OrderingMapping() {
        CreateMap<Ordering, GetOrderingByIdQueryResult>().ReverseMap();
        CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
        CreateMap<Ordering,CreateOrderingCommand>().ReverseMap();
        CreateMap<Ordering,RemoveOrderingCommand>().ReverseMap();
        CreateMap<Ordering,UpdateOrderingCommand>().ReverseMap();
        
    }
}
