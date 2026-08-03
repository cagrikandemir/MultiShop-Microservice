using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllResultAboutAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task DeleteAboutAsync(string Id);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task<UpdateAboutDto> GetByIdAboutAsync(string Id);
}
