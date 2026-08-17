using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        var value = _mapper.Map<Coupon>(createCouponDto);
        await _couponCollection.InsertOneAsync(value);
    }

    public async Task DeleteCouponAsync(string Id)
    {
        await _couponCollection.DeleteOneAsync(x=>x.CouponId==Id);
    }

    public async Task<List<ResultCouponDto>> GetAllCouponAsync()
    {
        var values =await _couponCollection.Find(Coupon => true).ToListAsync();
        return _mapper.Map<List<ResultCouponDto>>(values);
    }

    public async Task<GetByIdCouponDto> GetByIdCouponAsync(string Id)
    {
        var value = await _couponCollection.Find<Coupon>(x=>x.CouponId==Id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCouponDto>(value);
    }

    public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
    {
        var value = await _couponCollection.Find<Coupon>(x => x.Code == code).FirstOrDefaultAsync();
        return _mapper.Map<ResultCouponDto>(value);
    }

    public async Task<int> GetDiscountCouponCount()
    {
        var count = await _couponCollection.CountDocumentsAsync(
        Builders<Coupon>.Filter.Empty
    );

        return (int)count;
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        var value = _mapper.Map<Coupon>(updateCouponDto);
        await _couponCollection.ReplaceOneAsync(x=>x.CouponId==updateCouponDto.CouponId,value);
    }

    async Task<int> IDiscountService.GetDiscountCouponRate(string code)
    {
        var value = await  _couponCollection.Find<Coupon>(x => x.Code == code).Project(x => x.Rate).FirstOrDefaultAsync();
        return value;
    }
}
