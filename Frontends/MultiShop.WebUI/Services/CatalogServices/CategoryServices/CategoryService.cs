using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

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
        await _httpClient.PostAsJsonAsync<CreateCategoryDto>("/Catalog/Category/CreateCategory", createCategoryDto);
    }

    public async Task DeleteCategoryAsync(string Id)
    {
        await _httpClient.DeleteAsync("/Category/DeleteCategory/" + Id);
    }

    public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("Category/GetAllCategories");
        var values = await ResponseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
        return values;
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string Id)
    {
        var ResponseMessage = await _httpClient.GetAsync("/Category/GetByIdCategories/" + Id);
        var values = await ResponseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
        return values;
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var ResponseMessage = await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("/Category/UpdateCategory", updateCategoryDto);

    }
}
