using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;

public interface IOfferDiscountService
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
    Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
    Task DeleteOfferDiscountAsync(string Id);
    Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
    Task<UpdateOfferDiscountDto> GetByIdOfferDiscount(string Id);
}
