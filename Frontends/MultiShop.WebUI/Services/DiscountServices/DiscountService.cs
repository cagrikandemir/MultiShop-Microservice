using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;

    public DiscountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
    {
        var responseMesssage = await _httpClient.GetAsync("Discount/GetCodeDetailByCode/" + code);
        var values = await responseMesssage.Content.ReadFromJsonAsync<GetDiscountCodeDetailByCode>();
        return values;

    }

    public async Task<int> GetDiscountCouponRate(string code)
    {
        var responseMessage = await _httpClient.GetAsync("Discount/GetDiscountCouponRate/" + code);
        var jsonData = await responseMessage.Content.ReadFromJsonAsync<int>();
        return jsonData;
    }
}
