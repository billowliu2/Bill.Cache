
using Bill.CacheAbstract;
using Bill.CacheIntegration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bill.CacheDITest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            IServiceCollection services = new ServiceCollection();

            services.AddCache();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //根据配置config/Cache.json文件中的枚举Model选项自动选择(默认Redis)
            var Cache = serviceProvider.GetService<ICacheHandler>();

            Cache.Set("b", "v");

            var value = Cache.Get("b");

            Console.WriteLine(value);


        }
    }
}
