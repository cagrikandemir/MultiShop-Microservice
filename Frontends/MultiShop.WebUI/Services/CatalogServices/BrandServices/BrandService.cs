using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices;

public class BrandService : IBrandService
{
    private readonly HttpClient _httpClient;

    public BrandService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
        await _httpClient.PostAsJsonAsync<CreateBrandDto>("Brand/CreateBrand", createBrandDto);
    }

    public async Task DeleteBrandAsync(string Id)
    {
        await _httpClient.DeleteAsync("Brand/DeleteBrand/" + Id);
    }

    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        var responseMessage = await _httpClient.GetAsync("Brand/GetAllBrands");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
        return values;
    }

    public async Task<UpdateBrandDto> GetByIdBrandAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("Brand/GetBrandById/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
        return values;
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateBrandDto>("Brand/UpdateBrand", updateBrandDto);
    }
}
