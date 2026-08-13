using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

public class CargoCompanyService : ICargoCompanyService
{
    private readonly HttpClient _httpClient;

    public CargoCompanyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto)
    {
        await _httpClient.PostAsJsonAsync<CreateCargoCompanyDto>("CargoCompany/CreateCargoCompany", createCargoCompanyDto);
    }

    public async Task DeleteCargoCompanyAsync(string Id)
    {
        await _httpClient.DeleteAsync("CargoCompany/RemoveCargoCompany/" + Id);
    }

    public async Task<List<ResultCargoCompanyDto>> GetAllResultCargoCompanyAsync()
    {
        var responseMessage = await _httpClient.GetAsync("CargoCompany/GetAll");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultCargoCompanyDto>>(jsonData);
        return values;
    }

    public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("CargoCompany/GetById/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<UpdateCargoCompanyDto>(jsonData);
        return values;
    }

    public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
    {
        await _httpClient.PutAsJsonAsync<UpdateCargoCompanyDto>("CargoCompany/UpdateCargoCompany", updateCargoCompanyDto);
    }
}
