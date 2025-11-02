using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdCategories(string Id)
        {
            var value = await _categoryService.GetByIdCategoryAsync(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteCategory(string Id)
        {
            await _categoryService.DeleteCategoryAsync(Id);
            return Ok("Kategori Başarıyla Silindi");
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }

    }
}
