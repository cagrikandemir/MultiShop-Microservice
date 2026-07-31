using Microsoft.Build.Framework;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices;

public class FeatureService : IFeatureService
{
    private readonly HttpClient _httpClient;

    public FeatureService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureDto>("Feature/CreateFeature", createFeatureDto);
    }

    public async Task DeleteFeatureAsync(string Id)
    {
        await _httpClient.DeleteAsync("Feature/DeleteFeature/"+Id);
    }

    public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
    {
        var responseMessage = await _httpClient.GetAsync("Feature/GetAllFeature");
        var JsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(JsonData);
        return values;
        
    }
    public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("Feature/GetByIdFeature/" + Id);
        var JsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(JsonData);
        return values;
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("Feature/UpdateFeature", updateFeatureDto);
    }
}
