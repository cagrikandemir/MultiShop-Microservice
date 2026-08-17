namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;

public class CatalogStatisticService : ICatalogStatisticService
{
    private readonly HttpClient _httpClient;
    public CatalogStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<long> GetBrandCount()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetBrandCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<long>();
        return values;
    }

    public async Task<long> GetCategoryCount()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetCategoryCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<long>();
        return values;
    }

    public async Task<string> GetMaxPriceProductName()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetProductMaxPrice");
        var values = await responseMessage.Content.ReadAsStringAsync();
        return values;
    }

    public async Task<string> GetMinPriceProductName()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetProductMinPrice");
        var values = await responseMessage.Content.ReadAsStringAsync();
        return values;
    }

    public async Task<decimal> GetProductAvgPrice()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetAvgPrice");
        var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
        return values;
    }

    public async Task<long> GetProductCount()
    {
        var responseMessage = await _httpClient.GetAsync("Statistic/GetProductCount");
        var values = await responseMessage.Content.ReadFromJsonAsync<long>();
        return values;
    }
}
