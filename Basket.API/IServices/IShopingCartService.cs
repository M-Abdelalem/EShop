using Basket.API.Entities;

namespace Basket.API.IServices
{
    public interface IShopingCartService
    {
        ShoppingCart SetShopingCart( ShoppingCart shoppingCart);
        ShoppingCart GetShopingCart(string UserName);
        bool RemoveShopingCart(string UserName);
    }
}
