using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly HttpClient _httpClient;

    public CategoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCategoryDto>("Category/CreateCategory", createCategoryDto);
    }

    public async Task DeleteCategoryAsync(string Id)
    {
        await _httpClient.DeleteAsync("Category/DeleteCategory/" + Id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("Category/GetAllCategories");
        var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
        return values;
    }

    public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string Id)
    {
        var ResponseMessage = await _httpClient.GetAsync("Category/GetByIdCategories/" + Id);
        var values = await ResponseMessage.Content.ReadFromJsonAsync<UpdateCategoryDto>();
        return values;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var ResponseMessage = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("Category/UpdateCategory", updateCategoryDto);

    }
}
