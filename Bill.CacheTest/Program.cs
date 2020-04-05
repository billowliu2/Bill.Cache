using System;
using Bill.CommonCache.Helper;
using Bill.CommonCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Bill.CacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //MemeoryCache
            {
                var options = new JsonConfigurationHelper().Get<CacheOptions>("Cache", "", true);
                if (options == null)
                    Console.WriteLine("配置文件错误");
               
                IMemoryCache memory = new MemoryCache(Options.Create(new MemoryCacheOptions()));
                ICacheHandler MemoryCahce = new MemoryCacheHandler(memory);
                MemoryCahce.Set("a", "测试内存缓存");
                MemoryCahce.Get("a");
                Console.WriteLine(MemoryCahce.Get("a"));
            }
            //RedisCache
            {
                var Redis = new RedisCacheHelper();//无需读取配置文件已内置
                ICacheHandler RedisCache = new RedisCacheHandler(Redis);
                RedisCache.Set("b","测试Redis缓存");
                RedisCache.Get("b");
                Console.WriteLine(RedisCache.Get("b"));
            }


        }
    }
}
