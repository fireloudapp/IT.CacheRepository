using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace IT.CacheRepository
{
    public static class RedisCache
    {
        public static async Task SetObjectAsync<T>(IDistributedCache cache, string key, T value)
        {
             await cache.SetStringAsync(key, JsonConvert.SerializeObject(value));
        }

        public static async Task<T> GetObjectAsync<T>(IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static async Task<bool> ExistObjectAsync<T>(IDistributedCache cache, string key)
        {
            var value = await cache.GetStringAsync(key);
            return value == null ? false : true;
        }

        internal static object SetObjectAsync<T>(IDistributedCache userCache, T user)
        {
            throw new NotImplementedException();
        }
    }

}

