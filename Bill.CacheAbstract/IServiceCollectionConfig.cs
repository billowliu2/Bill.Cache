using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bill.CacheAbstract
{
   public  interface IServiceCollectionConfig
    {
        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="options">配置项</param>
        /// <returns></returns>
        IServiceCollection Config(IServiceCollection services, CacheOptions options);
    }
}
