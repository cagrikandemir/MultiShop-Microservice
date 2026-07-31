using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices;

public interface IBrandService
{
    Task<List<ResultBrandDto>> GetAllBrandAsync();
    Task CreateBrandAsync(CreateBrandDto createBrandDto);
    Task DeleteBrandAsync(String Id);
    Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
    Task<UpdateBrandDto>GetByIdBrandAsync(String Id);
}
