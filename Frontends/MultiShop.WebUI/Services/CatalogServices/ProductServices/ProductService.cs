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
        var responseMessage = await _httpClient.GetAsync("Category/GetAllCategories");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        List<SelectListItem> categoryValues = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CatagoryId,
                                               }).ToList();
        ViewBag.CategoryValues = categoryValues;
        return View();
    }

    public async Task DeleteProductyAsync(string Id)
    {
        await _httpClient.DeleteAsync("Product/DeleteProduct/" + Id);

    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("Product/GetAllProducts");
        var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
        return values;

    }

    public Task<UpdateProductDto> GetByIdProductAsync(string Id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategory()
    {
        var responseMessage = await _httpClient.GetAsync("Product/GetProductWithCategory");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
        return values;
    }

    public Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        throw new NotImplementedException();
    }
}
