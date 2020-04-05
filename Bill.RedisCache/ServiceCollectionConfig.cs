using Bill.CacheAbstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bill.RedisCache
{
    public  class ServiceCollectionConfig : IServiceCollectionConfig
    {
        /// <summary>
        /// 集成注入方式
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public  IServiceCollection Config(IServiceCollection services, CacheOptions options)
        {
            var redisHelper = new RedisCacheHelper(options.Redis);
            services.AddSingleton(redisHelper);
            services.AddSingleton<ICacheHandler, RedisCacheHandler>();
            return services;
        }
    }
}
