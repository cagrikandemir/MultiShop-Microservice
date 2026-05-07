using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers;

[Authorize]
[Route("[controller]")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> GetAllBrands()
    {
        return Ok(await _brandService.GetAllBrandAsync());
    }
    [HttpGet("[Action]/{id}")]
    public async Task<IActionResult> GetBrandById(string id)
    {
        return Ok(await _brandService.GetBrandByIdAsync(id));
    }
    [HttpPost("[Action]")]
    public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
    {
        var result = _brandService.CreateBrandAsync(createBrandDto);
        return Ok("Brand eklendi");
    }
    [HttpDelete("[Action]/{id}")]
    public async Task<IActionResult> DeleteBrand(string id)
    {
        var result = _brandService.DeleteBrandAsync(id);
        return Ok("Brand silindi");
    }
    [HttpPut("[Action]")]
    public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
    {
        var result = _brandService.UpdateBrandAsync(updateBrandDto);
        return Ok("Brand güncellendi");
    }
}
