using MultiShop.DtoLayer.BasketDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.BasketServices;

public class BasketService : IBasketService
{
    private readonly HttpClient _httpClient;

    public BasketService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddBasketItem(BasketItemDto basketItemDto)
    {
        var values = await GetBasket();
        if(values != null) {
            if (!values.BasketItems.Any(x => x.ProductId == basketItemDto.ProductId))
            {
                values.BasketItems.Add(basketItemDto);
            }
            else
                values = new BasketTotalDto();
                values.BasketItems.Add(basketItemDto);
        }
        await SaveBasket(values);
    }

    public Task DeleteBasket(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteBasketItem(string productId)
    {
        var values = await GetBasket();
        var deleteItem = values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
        var result = values.BasketItems.Remove(deleteItem);
         await SaveBasket(values);
        return true;
    }

    public async Task<BasketTotalDto> GetBasket()
    {
        var responseMessage = await _httpClient.GetAsync("GetMyBasketDetail");
        var jsonData = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
        return jsonData;
    }

    public async Task SaveBasket(BasketTotalDto basketTotalDto)
    {
        await _httpClient.PostAsJsonAsync<BasketTotalDto>("", basketTotalDto);
    }
}
