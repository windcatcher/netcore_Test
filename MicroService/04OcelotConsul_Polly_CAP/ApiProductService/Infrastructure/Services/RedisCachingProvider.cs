using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProductService.Infrastructure.Services
{
    public class RedisCachingProvider : ICachingProvider
    {
        private readonly IDatabase _cache;
        private IConnectionMultiplexer _redis;

        public RedisCachingProvider(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _cache = _redis.GetDatabase();
        }

        public bool IsConnect => _redis.IsConnected;



        public async Task<string> GetStringAsync(string cacheKey)
        {

            return await _cache.StringGetAsync(cacheKey);
        }

        public async Task<bool> DeleteAsync(string cacheKey)
        {
            return await _cache.KeyDeleteAsync(cacheKey);
        }

        public IEnumerable<string> GetKeys()
        {
            var endpoint = _redis.GetEndPoints();
            var server = _redis.GetServer(endpoint.First());
            var originKeys = server.Keys();
            var keys = new List<string>();
            foreach (var item in originKeys)
                keys.Add(item.ToString());
            return keys;
        }

        public async Task SetStringAsync(string cacheKey, string cacheValue, TimeSpan absoluteExpirationRelativeToNow)
        {
            await _cache.StringSetAsync(cacheKey, cacheValue, absoluteExpirationRelativeToNow);
        }
    }
}
