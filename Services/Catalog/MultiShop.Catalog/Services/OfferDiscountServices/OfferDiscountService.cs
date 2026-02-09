using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    private readonly IMongoCollection<OfferDiscount> _offerdiscountServices;
    private readonly IMapper _mapper;
    public OfferDiscountService(IDatabaseSettings _databaseSettings, IMapper mapper)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _offerdiscountServices = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
    }

    public  Task CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
        var value =  _mapper.Map<OfferDiscount>(createOfferDiscountDto);
        return  _offerdiscountServices.InsertOneAsync(value);
    }

    public  Task DeleteOfferDiscount(string Id)
    {
        return  _offerdiscountServices.DeleteManyAsync(x=>x.OfferDiscountId==Id);
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountOffer()
    {
        var values = await _offerdiscountServices.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultOfferDiscountDto>>(values);
    }

    public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscount(string Id)
    {
        var value = await _offerdiscountServices.Find(x => x.OfferDiscountId == Id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdOfferDiscountDto>(value);
    }

    public Task UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
        return _offerdiscountServices.ReplaceOneAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, value);
    }
}
