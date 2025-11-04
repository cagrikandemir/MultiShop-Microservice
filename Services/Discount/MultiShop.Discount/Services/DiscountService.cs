using AutoMapper;
using MongoDB.Driver;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Settings;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly IMongoCollection<Coupon> _couponCollection;
    private readonly IMapper _mapper;

    public DiscountService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _couponCollection = database.GetCollection<Coupon>(_databaseSettings.CouponCollectionName);
        _mapper = mapper;
    }

    public Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCouponAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultCouponDto>> GetAllCouponAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCouponDto> GetByIdCouponAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        throw new NotImplementedException();
    }
}
