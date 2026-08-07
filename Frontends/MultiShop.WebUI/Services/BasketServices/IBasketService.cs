using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices;

public interface IBasketService
{
    Task<BasketTotalDto> GetBasket();
    Task AddBasketItem(BasketItemDto basketItemDto);
    Task SaveBasket(BasketTotalDto basketTotalDto);
    Task DeleteBasket(string userId);
    Task<bool> DeleteBasketItem(string productId);

}
