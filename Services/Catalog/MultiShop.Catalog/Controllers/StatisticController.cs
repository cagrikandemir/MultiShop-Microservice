using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values =await _statisticService.GetBrandCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task< IActionResult> GetCategoryCount()
        {
            var values = await _statisticService.GetCategoryCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductCount()
        {
            var values =await _statisticService.GetProductCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task< IActionResult> GetAvgPrice()
        {
            var values =await _statisticService.GetAveragePrice();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task< IActionResult> GetProductMaxPrice()
        {
            var values = await _statisticService.GetMaxPriceProductName();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public async Task< IActionResult> GetProductMinPrice()
        {
            var values = await _statisticService.GetMinPriceProductName();
            return Ok(values);
        }
    }
}
