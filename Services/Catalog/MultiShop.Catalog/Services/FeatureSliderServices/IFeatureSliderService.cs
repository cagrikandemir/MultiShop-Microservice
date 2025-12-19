using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
    Task CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSlider(string Id);
}
