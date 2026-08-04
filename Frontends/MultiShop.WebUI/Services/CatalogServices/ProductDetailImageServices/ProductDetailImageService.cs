using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailImageServices;

public class ProductDetailImageService : IProductDetailImageService
{
    private readonly HttpClient _httpClient;

    public ProductDetailImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductDetailImageAsync(CreateProductImageDto createProductImageDto)
    {
        await _httpClient.PostAsJsonAsync<CreateProductImageDto>("ProductImage/CreateProductImage", createProductImageDto);
    }

    public async Task DeleteProductDetailImageAsync(string Id)
    {
        await _httpClient.DeleteAsync("ProductImage/DeleteProductImage/" + Id);
    }

    public async Task<List<ResultProductImageDto>> GetAllProductDetailImageAsync()
    {
        var responseMessage = await _httpClient.GetAsync("ProductImage/GetAllProductImage");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
        return values;
    }

    public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("ProductImage/GetByIdProductImage" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return values;
    }

    public async Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
    {
        var responseMessage = await _httpClient.GetAsync("ProductImage/GetImageWithByProductId/" + id);
        var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
        return values;
    }

    public async Task UpdateProductDetailImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("ProductImage/UpdateProductImage", updateProductImageDto);
    }
}
