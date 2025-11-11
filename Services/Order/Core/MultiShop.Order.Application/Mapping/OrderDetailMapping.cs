using AutoMapper;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Mapping;

public class OrderDetailMapping :Profile
{
    public OrderDetailMapping()
    {
        CreateMap<OrderDetail,CreateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, RemoveOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail,GetOrderDetailByIdQueryResult>().ReverseMap();
        CreateMap<OrderDetail,GetOrderDetailQueryResult>().ReverseMap();
    }
}
