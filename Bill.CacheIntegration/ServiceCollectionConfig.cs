using Bill.CacheAbstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bill.CacheIntegration
{
    public static class ServiceCollectionConfig 
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="services"></param>
        /// <param name="environmentName"></param>
        /// <returns></returns>
        public static IServiceCollection AddCache(this IServiceCollection services)
        {
            //通用配置
            var options = new JsonConfigurationHelper().Get<CacheOptions>("Cache","", true);
            if (options == null)
                return services;

            services.AddSingleton(options);

            var t = $"Bill.{options.Mode.ToString()}";

            var assembly = AssemblyHelper.LoadByNameEndString($"Bill.{options.Mode.ToString()}");

            VerifyHelper.NotNull(assembly, $"The assembly ({options.Mode.ToDescription()}) implementation object was not found(Reflection)");

            var configType = assembly.GetTypes().FirstOrDefault(m => m.Name.Equals("ServiceCollectionConfig"));
            if (configType != null)
            {
                var instance = (IServiceCollectionConfig)Activator.CreateInstance(configType);
                instance.Config(services, options);
            }

            return services;
        }
    }
}
