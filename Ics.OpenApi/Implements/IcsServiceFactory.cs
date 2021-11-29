using Ics.OpenApi.ConfigurationSection;
using Ics.OpenApi.Implements.Internal;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements
{
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
        public static IIcsService CreateIcsService(string sectionName = null, ITokenStorageService icsTokenStorageService = null)
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
        public static IIcsService CreateIcsService(IOptions<IcsOptions> icsOptions, ITokenStorageService icsTokenStorageService = null)
        {
            return new IcsService(icsOptions, icsTokenStorageService);
        }
    }
}
