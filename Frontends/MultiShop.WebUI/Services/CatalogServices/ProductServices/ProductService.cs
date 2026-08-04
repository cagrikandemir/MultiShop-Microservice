using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        var responseMessage = await _httpClient.PostAsJsonAsync<CreateProductDto>("Product/CreateProduct", createProductDto);
    }

    public async Task DeleteProductyAsync(string Id)
    {
        await _httpClient.DeleteAsync("Product/DeleteProduct/" + Id);

    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("Product/GetProductWithCategory");
        var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return values;

    }

    public async Task<UpdateProductDto> GetByIdProductAsync(string Id)
    {
        var ResponseMessage = await _httpClient.GetAsync("Product/GetByIdProduct/" + Id);
        var values = await ResponseMessage.Content.ReadFromJsonAsync<UpdateProductDto>();
        return values;
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
       var responseMessage = await _httpClient.PutAsJsonAsync<UpdateProductDto>("Product/UpdateProduct",updateProductDto);
    }
    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
    {
        var responseMessage = await _httpClient.GetAsync("Product/GetProductWithCategory");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        return values;
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
    {
        var responseMessage = await _httpClient.GetAsync("Product/GetProductWithCategoryByIdAsync/" + CategoryId);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        return values;
    }
}
