using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.IdentityDtos.UserDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.UserIdentityServices;

public class UserIdentityService : IUserIdentityService
{
    private readonly HttpClient _httpClient;

    public UserIdentityService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultUserDto>> GetAllUserListAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("User/GetAllUserList");
        var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
        return values;
    }
}
