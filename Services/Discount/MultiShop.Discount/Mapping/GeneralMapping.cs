using AutoMapper;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;

namespace MultiShop.Discount.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Coupon, ResultCouponDto>().ReverseMap();
        CreateMap<Coupon, CreateCouponDto>().ReverseMap();
        CreateMap<Coupon, UpdateCouponDto>().ReverseMap();
        CreateMap<Coupon, GetByIdCouponDto>().ReverseMap();
    }
}
