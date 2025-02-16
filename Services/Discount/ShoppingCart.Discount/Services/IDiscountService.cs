using ShoppingCart.Discount.Dtos;

namespace ShoppingCart.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();

        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);

        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);

        Task DeleteDiscountCouponAsync(int id);

        Task<GetByIdDiscountCouponDto> GetDiscountCouponByIdAsync(int id);
    }
}