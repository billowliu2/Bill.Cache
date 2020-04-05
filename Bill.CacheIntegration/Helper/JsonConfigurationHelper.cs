using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Bill.CacheIntegration
{
    /// <summary>
    /// Json配置文件帮助类
    /// </summary>
    public class JsonConfigurationHelper
    {
        /// <summary>
        /// 根据配置名称加载指定的配置项
        /// </summary>
        /// <param name="configFileName">配置文件名称，使用约定，配置文件放在项目的config目录中，如logging配置：config/logging.json</param>
        /// <param name="environmentName"></param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public IConfiguration LoadConfig(string configFileName, string environmentName = "", bool reloadOnChange = false)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "config");
            if (!Directory.Exists(filePath))
                return null;

            var builder = new ConfigurationBuilder()
                .SetBasePath(filePath)
                .AddJsonFile(configFileName.ToLower() + ".json", true, reloadOnChange);

            if (string.IsNullOrWhiteSpace(environmentName))
            {
                builder.AddJsonFile(configFileName.ToLower() + "." + environmentName + ".json", true, reloadOnChange);
            }

            return builder.Build();
        }

        /// <summary>
        /// 根据配置名称加载指定的配置项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configFileName">配置文件名称，使用约定，配置文件放在项目的config目录中，如logging配置：config/logging.json</param>
        /// <param name="environmentName"></param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public T Get<T>(string configFileName, string environmentName = "", bool reloadOnChange = false)
        {
            var configuration = LoadConfig(configFileName, environmentName, reloadOnChange);
            if (configuration == null)
                return default;

            return configuration.Get<T>();
        }
    }
}
