using Discount.ApI.Entities;

namespace Discount.ApI.IRepository
{
    public interface IDiscountRepository
    {
       Task< Coupon> getDiscount(string productName);
        Task<bool> insert(Coupon coupon);
        Task<bool> update(Coupon coupon);

        Task<bool> delete(string productName);

    }
}
