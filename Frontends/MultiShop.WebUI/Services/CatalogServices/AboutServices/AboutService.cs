using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices;

public class AboutService : IAboutService
{
    private readonly HttpClient _httpClient;

    public AboutService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        await _httpClient.PostAsJsonAsync<CreateAboutDto>("About/CreateAbout", createAboutDto);
    }

    public async Task DeleteAboutAsync(string Id)
    {
        await _httpClient.DeleteAsync("About/DeleteAbout/" + Id);
    }

    public async Task<List<ResultAboutDto>> GetAllResultAboutAsync()
    {
        var responseMessage = await _httpClient.GetAsync("About/GetAllAbouts");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
        return values;
    }

    public async Task<UpdateAboutDto> GetByIdAboutAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("About/GetAboutById/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
        return values;
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateAboutDto>("About/UpdateAbout", updateAboutDto);
    }
}
