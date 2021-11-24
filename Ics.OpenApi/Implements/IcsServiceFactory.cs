using System;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Ics.OpenApi.ConfigurationSection;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.Implements
{
    internal class IcsHttpClientFactory : IHttpClientFactory
    {
        static Lazy<HttpMessageHandler> HttpMessageHandler = new Lazy<HttpMessageHandler>(() =>
        {
#if NET5_0_OR_GREATER
            if (SocketsHttpHandler.IsSupported)
            {
                return new SocketsHttpHandler();
            }
            else
            {
                return new HttpClientHandler();
            }
#else
            return new HttpClientHandler();
#endif
        });
        public HttpClient CreateClient(string name) => new HttpClient(HttpMessageHandler.Value, false);
    }

    /// <summary>
    /// 跨境无忧ICS服务工厂
    /// </summary>
    public static class IcsServiceFactory
    {
        /// <summary>
        /// 创建跨境无忧ICS服务
        /// </summary>
        /// <param name="sectionName">配置节名称</param>
        /// <param name="icsTokenStorageService">自定义Token存取服务</param>
        /// <returns></returns>
        public static IIcsService CreateIcsService(string sectionName = null, IIcsTokenStorageService icsTokenStorageService = null)
        {
            sectionName ??= IcsConfigurationSection.DefaultConfigurationSectionName;
            var configSection = System.Configuration.ConfigurationManager.GetSection(sectionName);
            var icsConfigurationSection = configSection as IcsConfigurationSection;
            IOptions<IcsOptions> icsOptions = icsConfigurationSection.ToOptionsWrapper();
            return CreateIcsService(icsOptions, icsTokenStorageService);
        }

        /// <summary>
        /// 创建跨境无忧ICS服务
        /// </summary>
        /// <param name="icsOptions"></param>
        /// <param name="icsTokenStorageService">自定义Token存取服务</param>
        /// <returns></returns>
        public static IIcsService CreateIcsService(IOptions<IcsOptions> icsOptions, IIcsTokenStorageService icsTokenStorageService = null)
        {
            return new IcsService(icsOptions, icsTokenStorageService);
        }
    }

    /// <summary>
    /// 跨境无忧ICS服务接口
    /// </summary>
    public interface IIcsService : IDisposable
    {
        /// <summary>
        /// Token服务
        /// </summary>
        IIcsTokenService IcsTokenService { get; }
        /// <summary>
        ///  报关行接口
        /// </summary>
        IIcsDeclareService IcsDeclareService { get; }
    }

    internal class IcsService : IIcsService
    {
        private readonly IOptions<IcsOptions> icsOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IIcsHttpClient icsHttpClient;
        private readonly IIcsCacheProviderFactory icsCacheProviderFactory;
        private readonly IIcsTokenStorageService icsTokenStorageService;
        private readonly IIcsOutRequestService icsOutRequestService;

        public IcsService(
            IOptions<IcsOptions> icsOptions,
            IIcsTokenStorageService customsIcsTokenStorageService = null
            )
        {
            this.icsOptions = icsOptions;
            this.httpClientFactory = new IcsHttpClientFactory();
            this.icsHttpClient = new IcsHttpClient(httpClientFactory, icsOptions);
            if (icsOptions.Value.TokenStorageIn == Enums.IcsTokenStorageType.Custom)
            {
                if (customsIcsTokenStorageService is null)
                {
                    throw new ArgumentException("未指定自定义Token存储服务 IIcsTokenStorageService");
                }
                else
                {
                    this.icsTokenStorageService = customsIcsTokenStorageService;
                }
            }
            else
            {
                this.icsCacheProviderFactory = new IcsCacheProviderFactory(icsOptions);
                this.icsTokenStorageService = new IcsTokenStorageService(icsCacheProviderFactory, icsOptions);
            }


            this.icsOutRequestService = new IcsOutRequestService(icsOptions, icsHttpClient, icsTokenStorageService);
        }

        public void Dispose()
        {
            icsHttpClient?.Dispose();
            icsTokenStorageService?.Dispose();
        }

        public IIcsTokenService IcsTokenService => icsOutRequestService;

        private IIcsDeclareService icsDeclareService;
        public IIcsDeclareService IcsDeclareService => icsDeclareService ??= new IcsDeclareService(icsOutRequestService);
    }
}
