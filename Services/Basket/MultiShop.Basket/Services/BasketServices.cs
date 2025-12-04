using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services;

public class BasketServices : IBasketServices
{
    private readonly RedisService _redisService;

    public BasketServices(RedisService redisService)
    {
        _redisService = redisService;
    }

    public async Task DeleteBasket(string userId)
    {
        var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);
    }

    public async Task<BasketTotalDto> GetBasket(string userId)
    {
        var exitsBasket= await _redisService.GetDatabase().StringGetAsync(userId);
        return  JsonSerializer.Deserialize<BasketTotalDto>(exitsBasket);
    }

    public async Task SaveBasket(BasketTotalDto baskettotalDto)
    {
        await _redisService.GetDatabase().StringSetAsync(baskettotalDto.UserId,JsonSerializer.Serialize(baskettotalDto));
    }
}
