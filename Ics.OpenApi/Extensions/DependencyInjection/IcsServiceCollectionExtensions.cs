using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ics.OpenApi.Implements;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.Extensions.DependencyInjection
{
    /// <summary>
    /// ICS 依赖注入
    /// </summary>
    public static class IcsServiceCollectionExtensions
    {
        /// <summary>
        /// 注入ICS服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddIcs(this IServiceCollection services)
        {
            services.AddOptions();

            services.AddDistributedMemoryCache();
            services.AddStackExchangeRedisCache(o => { });
            services.AddTransient<IIcsCacheProviderFactory, IcsCacheProviderFactory>();
            services.AddTransient<IIcsTokenStorageService, IcsTokenStorageService>();
            services.AddHttpClient();
            services.AddTransient<IIcsHttpClient, IcsHttpClient>();
            services.AddTransient<IIcsOutRequestService, IcsOutRequestService>();
            services.AddTransient<IIcsTokenService, IcsOutRequestService>();
            services.AddTransient<IIcsDeclareService, IcsDeclareService>();
        }

        /// <summary>
        /// 注入ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void AddIcs(this IServiceCollection services, Action<IcsOptions> setupAction)
        {
            services.AddIcs();
            services.ConfigIcs(setupAction);
        }

        /// <summary>
        /// 注入ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        public static void AddIcs(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddIcs();
            services.ConfigIcs(configurationSection);
        }

        /// <summary>
        /// 注入ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        public static void AddIcs(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.AddIcs();
            services.ConfigIcs(configurationRoot);
        }

        /// <summary>
        /// 配置ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="setupAction"></param>
        public static void ConfigIcs(this IServiceCollection services, Action<IcsOptions> setupAction)
        {
            services.Configure<IcsOptions>(setupAction);
        }

        /// <summary>
        /// 配置ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationSection"></param>
        public static void ConfigIcs(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<IcsOptions>(configurationSection);
        }

        /// <summary>
        /// 配置ICS服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configurationRoot"></param>
        public static void ConfigIcs(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services.ConfigIcs(configurationRoot.GetSection(IcsOptions.DefaultOptionsName));
        }
    }
}
