using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

public interface ICargoCompanyService
{
    Task<List<ResultCargoCompanyDto>> GetAllResultCargoCompanyAsync();
    Task CreateCargoCompanyAsync(CreateCargoCompanyDto createCargoCompanyDto);
    Task DeleteCargoCompanyAsync(string Id);
    Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto);
    Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(string Id);
}
