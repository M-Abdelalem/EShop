namespace Basket.API.IRedisRepository
{
    public interface ICacheRepository
    {
        T Get<T>(string key);
        T Set<T>(string key, T value);
        bool Remove<T>(string key);

    }
}
