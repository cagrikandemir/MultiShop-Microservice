using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IHttpClientFactory httpClientFactory, IProductService productService, ICategoryService categoryService)
        {
            _httpClientFactory = httpClientFactory;
            _productService = productService;
            _categoryService = categoryService;
        }
        void CatalogViewBagList()
        {
            ViewBag.v1 = "Ana Menü";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürünler";
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {        
            CatalogViewBagList();
            var response = await _productService.GetAllProductsAsync();
            return View(response);
        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            CatalogViewBagList();
            var response = await _productService.GetProductsWithCategoryAsync();
            return View(response);
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            CatalogViewBagList();
            CatalogViewBagList();
            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CatagoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
                await _productService.CreateProductAsync(createProductDto);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
                await _productService.DeleteProductyAsync(id);
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }
        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            CatalogViewBagList();

            var values = await _categoryService.GetAllCategoriesAsync();
            List<SelectListItem> categoryValues = (from x in values
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CatagoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }
        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });

        }
    }
}
