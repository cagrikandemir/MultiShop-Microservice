using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task DeleteFeatureAsync(string Id);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task<UpdateFeatureDto> GetByIdFeatureAsync(string Id);
}
