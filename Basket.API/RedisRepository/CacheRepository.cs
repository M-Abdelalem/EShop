using Basket.API.IRedisRepository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.RedisRepository
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDistributedCache _cache;

        public CacheRepository(IDistributedCache cache)
        {
            _cache = cache;
        }

        public T Get<T>(string key)
        {
            
            var value = _cache.GetString(key);

            if (value != null)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public T Set<T>(string key, T value)
        {
            //var options = new DistributedCacheEntryOptions
            //{
            //    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            //    SlidingExpiration = TimeSpan.FromMinutes(10)
            //};

            _cache.SetString(key, JsonConvert.SerializeObject(value));

            return value;
        }
        public bool Remove<T>(string key)
        {
            _cache.Remove(key);
           return _cache.Get(key) == null;
        }
    }
}
