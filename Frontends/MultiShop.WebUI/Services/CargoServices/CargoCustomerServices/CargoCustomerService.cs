using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.DtoLayer.CargoDtos.CargoCustomerDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly HttpClient _httpClient;

    public CargoCustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCargoCustomerByIdDto> GetCargoCustomerInfoByIdAsync(string Id)
    {
        var responseMessage = await _httpClient.GetAsync("CargoCustomer/GetCargoCustomerByUserId/"+Id);
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<GetCargoCustomerByIdDto>>(jsonData);
        return values.FirstOrDefault();
    }
}
