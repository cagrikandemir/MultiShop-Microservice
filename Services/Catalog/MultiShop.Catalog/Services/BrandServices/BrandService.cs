using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.BrandServices;

public class BrandService : IBrandService
{
    private readonly IMongoCollection<Brand> _brandcollection;
    private readonly IMapper _mapper;

    public BrandService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _brandcollection=database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        _mapper = mapper;
    }

    public Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        var result = _mapper.Map<Brand>(createBrandDto);
        return _brandcollection.InsertOneAsync(result);
    }

    public Task DeleteBrandAsync(string id)
    {
        return _brandcollection.DeleteOneAsync(x => x.BrandId == id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        var values = await _brandcollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultBrandDto>>(values);
    }

    public async Task<GetByIdBrandDto> GetBrandByIdAsync(string id)
    {
        var value =  _brandcollection.Find(x=> x.BrandId==id).FirstOrDefault();
        return _mapper.Map<GetByIdBrandDto>(value);
    }

    public Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        var value = _mapper.Map<Brand>(updateBrandDto);
        return _brandcollection.ReplaceOneAsync(x=>x.BrandId== updateBrandDto.BrandId, value);
    }
}
