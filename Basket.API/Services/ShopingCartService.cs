using Basket.API.Entities;
using Basket.API.IRedisRepository;
using Basket.API.IServices;

namespace Basket.API.Services
{
    public class ShopingCartService: IShopingCartService
    {
        private readonly ICacheRepository _cache;
       public ShopingCartService(ICacheRepository cache)
        {
            _cache=cache;
        }
        public ShoppingCart SetShopingCart( ShoppingCart shoppingCart)
        {
            
            return _cache.Set<ShoppingCart>(shoppingCart.UserName, shoppingCart);

        }
        public ShoppingCart GetShopingCart(string UserName)
        {
            return _cache.Get<ShoppingCart>(UserName);

        }
        public bool RemoveShopingCart(string UserName)
        {
            return _cache.Remove<ShoppingCart>(UserName);

        }
    }
}
