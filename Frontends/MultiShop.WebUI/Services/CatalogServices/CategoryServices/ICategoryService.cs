using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(string Id);
    Task<UpdateCategoryDto> GetByIdCategoryAsync(string Id);
}
