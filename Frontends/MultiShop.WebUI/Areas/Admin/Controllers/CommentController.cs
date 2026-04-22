using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7088/UserComment/GetAllUserComment");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                Console.WriteLine(Result);
                return View(Result);
            }
            return View();
        }
        [Route("CreateComment")]
        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            return View();
        }
        [Route("CreateComment")]
        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var Jsondata = JsonConvert.SerializeObject(createCommentDto);
            StringContent stringContent = new StringContent(Jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7088/UserComment/CreateUserComment", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteComment/{Id}")]
        public async Task<IActionResult> DeleteComment(string Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7088/UserComment/DeleteUserComment/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateComment/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7088/UserComment/GetUserCommentById/" + Id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var Result = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(Result);
            }
            return View();
        }
        [Route("UpdateComment/{Id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            updateCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(updateCommentDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7088/UserComment/UpdateUserComment/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            Console.WriteLine($"Hata : {responseMessage.StatusCode} {stringContent}");
            return View();
        }
    }
}
