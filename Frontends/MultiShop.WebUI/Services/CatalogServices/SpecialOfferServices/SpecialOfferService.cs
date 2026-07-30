using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Settings;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

public class SpecialOfferService : ISpecialOfferService
{
    private readonly HttpClient _httpClient;

    public SpecialOfferService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateSpecialAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("SpecialOffer/CreateSpecialOffer", createSpecialOfferDto);

    }

    public async Task DeleteSpecialAsync(string Id)
    {
        await _httpClient.DeleteAsync("SpecialOffer/DeleteSpecialOffer/" + Id);
    }

    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialAsync()
    {
            var responseMessage = await _httpClient.GetAsync("SpecialOffer/GetAllSpecialOffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return value;

    }

    public async Task<UpdateSpecialOfferDto> GetByIdSpecialAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("SpecialOffer/GetSpecialOfferById/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
        return value;
    }

    public async Task UpdateSpecialAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("SpecialOffer/UpdateSpecialOffer", updateSpecialOfferDto);
    }
}
