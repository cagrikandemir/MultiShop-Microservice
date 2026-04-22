using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Index(CreateRegisterDto createRegisterDto)
        {
            if(createRegisterDto.Password == createRegisterDto.PassordConfirm)
            {
                var client = _httpClientFactory.CreateClient();
                var JsonData = JsonConvert.SerializeObject(createRegisterDto);
                StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5001/Register/UserRegister", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else 
                return Ok("Şifreler uyuşmuyor");

                return View();
        }
    }
}
