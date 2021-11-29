using System.Collections.Generic;
using Ics.OpenApi.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;

namespace Ics.OpenApi.Options
{
    /// <summary>
    /// ICS Options
    /// </summary>
    public partial class IcsOptions
    {
        /// <summary>
        /// 默认Options名
        /// </summary>
        public const string DefaultOptionsName = "Ics";
        /// <summary>
        /// 默认Token缓存名
        /// </summary>
        public const string DefaultTokenKey = "IcsToken";

        private string baseUri;

        /// <summary>
        /// 环境
        /// </summary>
        public virtual IcsEnvironment Environment { get; set; } = IcsEnvironment.Test;
        /// <summary>
        /// 基地址
        /// </summary>
        public virtual string BaseUri
        {
            get
            {
                if (baseUri is null or { Length: 0 })
                {
                    baseUri = this.Environment switch
                    {
                        IcsEnvironment.Test => "http://insys.porteasy.cn:9001",
                        IcsEnvironment.Production => "",
                        IcsEnvironment.Custom => baseUri,
                        _ => throw new System.ArgumentOutOfRangeException("Environment not support")
                    };
                }
                return baseUri;
            }
            set
            {
                baseUri = this.Environment switch
                {
                    IcsEnvironment.Custom => value,
                    _ => null
                };
            }
        }
        /// <summary>
        /// 账号信息
        /// </summary>
        public virtual IcsAccountOptions Account { get; set; }
        /// <summary>
        /// Api列表
        /// </summary>
        public virtual Dictionary<string, string> Apis { get; set; } = new Dictionary<string, string>
        {
            // 1.2 api获取令牌（token）
            { "获取令牌", "/api/v2.0/User/gettoken" },

            // 2.1	获取报关单及制单明细 Get Delegate
            { "获取报关单及制单明细", "/api/v2.0/Declare/GetDelegate" },
            // 2.2	发送报关单及申报明细 Transfer Delegate
            { "发送报关单及申报明细", "/api/v2.0/Declare/TransferDelegate" },
            // 2.4	发送审核状态 TransferStatus
            { "发送审核状态", "/api/v2.0/Declare/TransferStatus" },
            // 2.5	获取报关单集装箱明细 Get DelegateBox
            { "获取报关单集装箱明细", "/api/v2.0/Declare/GetDelegateBox" },
            // 2.6	发送报关单集装箱明细 TransferDelegateBox
            { "发送报关单集装箱明细", "/api/v2.0/Declare/TransferDelegateBox" },
            // 2.7	获取随附单证 GetBFSCic
            { "获取随附单证", "/api/v2.0/Declare/GetBFSCic" },
            // 2.8	发送随附单证 TransferBFSCic
            { "发送随附单证", "/api/v2.0/Declare/TransferBFSCic" },
        };
        /// <summary>
        /// Token存储位置
        /// </summary>
        public virtual IcsTokenStorageType TokenStorageIn { get; set; } = IcsTokenStorageType.InMemory;
        /// <summary>
        /// 进程内Token存储相关配置
        /// </summary>
        public virtual MemoryDistributedCacheOptions InMemoryOptions { get; set; }
        /// <summary>
        /// Redis Token存储相关配置
        /// </summary>
        public virtual RedisCacheOptions RedisOptions { get; set; }
        /// <summary>
        /// Token缓存名
        /// </summary>
        public virtual string TokenKey { get; set; } = DefaultTokenKey;
    }
}
