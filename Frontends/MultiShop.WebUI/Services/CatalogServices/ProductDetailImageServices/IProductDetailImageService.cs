using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailImageServices;

public interface IProductDetailImageService
{
    Task<List<ResultProductImageDto>> GetAllProductDetailImageAsync();
    Task CreateProductDetailImageAsync(CreateProductImageDto createProductImageDto);
    Task DeleteProductDetailImageAsync(string Id);
    Task UpdateProductDetailImageAsync(UpdateProductImageDto updateProductImageDto);
    Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id);
}
