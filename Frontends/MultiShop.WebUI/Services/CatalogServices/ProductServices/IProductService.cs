using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductyAsync(string Id);
    Task<UpdateProductDto> GetByIdProductAsync(string Id);
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId);
}
