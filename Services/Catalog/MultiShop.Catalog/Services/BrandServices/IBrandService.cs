using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    Task<GetByIdBrandDto> GetBrandByIdAsync(string id);
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task DeleteBrandAsync(string id);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
}
