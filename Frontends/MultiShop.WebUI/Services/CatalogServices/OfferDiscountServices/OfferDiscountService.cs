using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

public class OfferDiscountService : IOfferDiscountService
{
    private readonly HttpClient _httpClient;

    public OfferDiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
        await _httpClient.PostAsJsonAsync<CreateOfferDiscountDto>("OfferDiscount/CreateOfferDiscount", createOfferDiscountDto);
    }

    public async Task DeleteOfferDiscountAsync(string Id)
    {
        await _httpClient.DeleteAsync("OfferDiscount/DeleteOfferDiscount/" + Id);
    }

    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        var responseMessage = await _httpClient.GetAsync("OfferDiscount/GetAllOfferDiscounts");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
        return values;
    }

    public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscount(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("OfferDiscount/GetByIdOfferDiscount/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
        return values;
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateOfferDiscountDto>("OfferDiscount/UpdateOfferDiscount", updateOfferDiscountDto);
    }
}
