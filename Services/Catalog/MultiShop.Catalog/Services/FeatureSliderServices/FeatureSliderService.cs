using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
    private readonly IMapper _mapper;

    public FeatureSliderService(IMapper mapper , IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _featureSliderCollection=database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
        _mapper = mapper;
    }

    public Task CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
    {
        var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
        return _featureSliderCollection.InsertOneAsync(value);
    }

    public Task DeleteFeatureSlider(string Id)
    {
         return _featureSliderCollection.DeleteManyAsync(x=>x.FeatureSliderId==Id);
    }

    public Task FeatureSliderChangeStatusToFalse(string id)
    {
        throw new NotImplementedException();

    }

    public Task FeatureSliderChangeStatusToTrue(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
    {
        var values  = await _featureSliderCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultFeatureSliderDto>>(values);
    }

    public async Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id)
    {
        var value = await _featureSliderCollection.Find(x=>x.FeatureSliderId==id).FirstOrDefaultAsync();
        return _mapper.Map<GetFeatureSliderByIdDto>(value);
    }

    public Task UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
        return _featureSliderCollection.ReplaceOneAsync(x=>x.FeatureSliderId==updateFeatureSliderDto.FeatureSliderId,value);
    }
}
