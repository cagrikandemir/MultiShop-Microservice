using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateContactAsync(CreateContactDto createContactDto)
    {
        await _httpClient.PostAsJsonAsync<CreateContactDto>("Contact/CreateContact", createContactDto);
    }

    public async Task DeleteContactAsync(string Id)
    {
        await _httpClient.DeleteAsync("Contact/DeleteContact/" + Id);
    }

    public async Task<List<ResultContactDto>> GetAllContactsAsync()
    {
        var ResponseMessage = await _httpClient.GetAsync("Contact/GetAllContact");
        var jsonData = await ResponseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
        return values;
    }

    public async Task<UpdateContactDto> GetByIdContactAsync(string Id)
    {
        var ResponseMessage = await _httpClient.GetAsync("Contact/GetByIdContact/" + Id);
        var values = await ResponseMessage.Content.ReadFromJsonAsync<UpdateContactDto>();
        return values;
    }

    public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
    {
        var ResponseMessage = await _httpClient.PutAsJsonAsync<UpdateContactDto>("Contact/UpdateContact", updateContactDto);

    }
}
