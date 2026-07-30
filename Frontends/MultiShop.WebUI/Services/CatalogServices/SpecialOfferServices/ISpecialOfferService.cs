using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialAsync();
    Task CreateSpecialAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialAsync(string Id);
    Task<UpdateSpecialOfferDto> GetByIdSpecialAsync(string Id);
}
