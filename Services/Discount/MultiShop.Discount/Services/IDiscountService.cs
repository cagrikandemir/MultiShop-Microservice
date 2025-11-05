using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultCouponDto>> GetAllCouponAsync();
    Task CreateCouponAsync (CreateCouponDto createCouponDto);
    Task DeleteCouponAsync (string Id);
    Task UpdateCouponAsync (UpdateCouponDto updateCouponDto);
    Task<GetByIdCouponDto> GetByIdCouponAsync(string Id);
}
