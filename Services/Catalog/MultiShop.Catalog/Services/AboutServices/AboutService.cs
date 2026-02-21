using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.AboutServices;

public class AboutService : IAboutService
{
    private readonly IMongoCollection<About> _aboutCollection;
    private readonly IMapper _mapper;

    public AboutService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        _mapper = mapper;
    }

    public Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        var result = _mapper.Map<About>(createAboutDto);
        return  _aboutCollection.InsertOneAsync(result);
    }

    public Task DeleteAboutAsync(string Id)
    {
        return _aboutCollection.DeleteOneAsync(x => x.AboutId == Id);
    }

    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        var results = await _aboutCollection.Find(x=>true).ToListAsync();
        return _mapper.Map<List<ResultAboutDto>>(results);
    }

    public async Task<GetByIdAboutDto> GetByIdAboutAsync(string Id)
    {
        var result = _aboutCollection.Find(x=>x.AboutId==Id).FirstOrDefault();
        return _mapper.Map<GetByIdAboutDto>(result);
    }

    public Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        var result = _mapper.Map<About>(updateAboutDto);
        return _aboutCollection.ReplaceOneAsync(x=>x.AboutId==updateAboutDto.AboutId, result);
    }
}
