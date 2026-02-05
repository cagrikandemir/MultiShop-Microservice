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

    public Task CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOfferDiscount(string Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountOffer()
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdOfferDiscountDto> GetByIdOfferDiscount(string Id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        throw new NotImplementedException();
    }
}
