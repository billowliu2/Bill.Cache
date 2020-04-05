using Bill.CacheAbstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bill.MemoryCache
{
    public class ServiceCollectionConfig : IServiceCollectionConfig
    {
        public IServiceCollection Config(IServiceCollection services, CacheOptions options)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheHandler, MemoryCacheHandler>();
            return services;
        }
    }
}
