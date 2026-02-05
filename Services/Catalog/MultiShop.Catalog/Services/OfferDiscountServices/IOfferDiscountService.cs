using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices;

public interface IOfferDiscountService
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountOffer();
    Task<GetByIdOfferDiscountDto> GetByIdOfferDiscount(string Id);

    Task CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto);
    Task UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto);
    Task DeleteOfferDiscount(string Id);
}
