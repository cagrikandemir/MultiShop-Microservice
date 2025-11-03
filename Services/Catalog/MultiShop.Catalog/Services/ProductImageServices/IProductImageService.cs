using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
    Task CreateProductImageAsync(CreateProductImageDto productImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDto productImageDto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDto> GetProductImageByIdAsync(string id);

}
