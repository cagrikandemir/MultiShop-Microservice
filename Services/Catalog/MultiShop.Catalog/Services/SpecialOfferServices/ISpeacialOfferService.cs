using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices;

public interface ISpeacialOfferService
{
    Task<List<ResultSpeacialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpeacialOfferDto createSpeacialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpeacialOfferDto updateSpeacialOfferDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
}
