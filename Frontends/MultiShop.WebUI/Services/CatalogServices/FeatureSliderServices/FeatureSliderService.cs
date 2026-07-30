using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

public class FeatureSliderService : IFeatureSliderService
{
    private readonly HttpClient _httpClient;

    public FeatureSliderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
        await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders/CreateFeatureSlider", createFeatureSliderDto);
    }

    public async Task DeleteFeatureSliderAsync(string Id)
    {
        await _httpClient.DeleteAsync("FeatureSliders/DeleteFeatureSlider/" + Id);
    }

    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
            var responseMessage = await _httpClient.GetAsync("FeatureSliders/GetAllFeatureSliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
            return values;
    }

    public async Task<UpdateFeatureSliderDto> GetByIdCategoryAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("FeatureSliders/GetFeatureSliderById/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
        return values;
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("FeatureSliders/UpdateFeatureSlider", updateFeatureSliderDto);
    }
}
