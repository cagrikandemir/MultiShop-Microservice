using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
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
        public IActionResult GetBrandCount()
        {
            var values = _statisticService.GetBrandCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetCategoryCount()
        {
            var values = _statisticService.GetCategoryCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetProductCount()
        {
            var values = _statisticService.GetProductCount();
            return Ok(values);
        }
        [HttpGet("[action]")]
        public IActionResult GetAvgPrice()
        {
            var values = _statisticService.GetAveragePrice();
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
