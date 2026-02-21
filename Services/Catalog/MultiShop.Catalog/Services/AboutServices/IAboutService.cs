using Microsoft.VisualBasic;
using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task<GetByIdAboutDto> GetByIdAboutAsync(string Id);
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string Id);
}
