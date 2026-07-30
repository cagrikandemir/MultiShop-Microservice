using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string Id);
    Task<UpdateFeatureSliderDto> GetByIdCategoryAsync(string Id);
}
