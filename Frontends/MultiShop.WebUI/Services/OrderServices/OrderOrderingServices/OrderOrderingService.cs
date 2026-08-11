using MultiShop.DtoLayer.BasketDtos;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;

public class OrderOrderingService : IOrderOrderingService
{
    private readonly HttpClient _httpClient;

    public OrderOrderingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultOrderingByUserIdDto>> OrderOrderingByUserIdAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("Ordering/GetOrderingByUserId/" + Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
        return values;
    }
}
