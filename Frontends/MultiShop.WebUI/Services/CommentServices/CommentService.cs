using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetUserCommentByProductId/"+ id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return result;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("UserComment/CreateUserComment", createCommentDto);
        }

        public async Task DeleteCommentAsync(string Id)
        {
            await _httpClient.DeleteAsync("UserComment/DeleteComment/" + Id);
        }

        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetAllUserComment");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return result;
        }

        public async Task<UpdateCommentDto> GetByIdCommentAsync(string Id)
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetUserCommentById/" + Id);
            var result = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return result;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("UserComment/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
            //    var responseMessage = await _httpClient.GetAsync(
            //"UserComment/GetTotalCommentCount");

            //    var content = await responseMessage.Content.ReadAsStringAsync();

            //    Console.WriteLine("================================");
            //    Console.WriteLine("STATUS CODE: " + responseMessage.StatusCode);
            //    Console.WriteLine("REQUEST URL: " + responseMessage.RequestMessage?.RequestUri);
            //    Console.WriteLine("CONTENT: [" + content + "]");
            //    Console.WriteLine("================================");

            //    if (!responseMessage.IsSuccessStatusCode)
            //    {
            //        throw new Exception(
            //            $"Comment API Hatası: {responseMessage.StatusCode} - {content}");
            //    }

            //    return int.Parse(content);
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("UserComment/UpdateUserComment", updateCommentDto);
        }
    }
}
