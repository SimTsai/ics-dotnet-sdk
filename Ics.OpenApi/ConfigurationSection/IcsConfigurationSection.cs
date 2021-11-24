using System;
using System.Configuration;
using Microsoft.Extensions.Options;
using Ics.OpenApi.Enums;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.ConfigurationSection
{
    /// <summary>
    /// ICS配置节
    /// </summary>
    public partial class IcsConfigurationSection : System.Configuration.ConfigurationSection
    {
        /// <summary>
        /// 默认配置节名称
        /// </summary>
        public const string DefaultConfigurationSectionName = "ics";

        private const string EnvironmentPropertyName = "environment";
        private const string BaseUriPropertyName = "baseUri";
        private const string AccountPropertyName = "account";
        private const string ApisPropertyName = "apis";
        private const string TokenStorageInPropertyName = "tokenStorageIn";
        private const string InMemoryOptionsPropertyName = "inMemoryOptions";
        private const string RedisOptionsPropertyName = "redisOptions";
        private const string TokenKeyPropertyName = "tokenKey";

        /// <summary>
        /// 环境
        /// </summary>
        [ConfigurationProperty(EnvironmentPropertyName, IsRequired = true)]
        public virtual IcsEnvironment Environment
        {
            get
            {
                return (IcsEnvironment)base[EnvironmentPropertyName];
            }
            set
            {
                base[EnvironmentPropertyName] = value;
            }
        }

        /// <summary>
        /// 基地址
        /// </summary>
        [ConfigurationProperty(BaseUriPropertyName)]
        public virtual string BaseUri
        {
            get
            {
                var baseUri = base[BaseUriPropertyName] as string;

                if (baseUri is null or { Length: 0 })
                {
                    baseUri = this.Environment switch
                    {
                        IcsEnvironment.Test => "http://insys.porteasy.cn:9001",
                        IcsEnvironment.Production => "https://zhiyunopenapi.95155.com",
                        IcsEnvironment.Custom => baseUri,
                        _ => throw new ArgumentOutOfRangeException("Environment not support")
                    };
                }
                return baseUri;
            }
            set
            {
                base[BaseUriPropertyName] = this.Environment switch
                {
                    IcsEnvironment.Custom => value,
                    _ => null
                };
            }
        }

        /// <summary>
        /// 账号信息
        /// </summary>
        [ConfigurationProperty(AccountPropertyName, IsRequired = true)]
        public virtual IcsAccountConfigurationElement Account
        {
            get
            {
                return (IcsAccountConfigurationElement)base[AccountPropertyName];
            }
            set
            {
                base[AccountPropertyName] = value;
            }
        }

        /// <summary>
        /// Api列表
        /// </summary>
        [ConfigurationProperty(ApisPropertyName)]
        public virtual KeyValueConfigurationCollection Apis
        {
            get
            {
                return (KeyValueConfigurationCollection)base[ApisPropertyName];
            }
            set
            {
                base[ApisPropertyName] = value;
            }
        }

        /// <summary>
        /// Token存储位置
        /// </summary>
        [ConfigurationProperty(TokenStorageInPropertyName)]
        public virtual IcsTokenStorageType TokenStorageIn
        {
            get
            {
                var settings = base[TokenStorageInPropertyName];
                if (settings is not null && settings is IcsTokenStorageType tokenStorageIn)
                {
                    return tokenStorageIn;
                }
                else
                {
                    return IcsTokenStorageType.InMemory;
                }

            }
            set
            {
                base[TokenStorageInPropertyName] = value;
            }
        }

        /// <summary>
        /// 进程内Token存储相关配置
        /// </summary>
        [ConfigurationProperty(InMemoryOptionsPropertyName)]
        public virtual IcsInMemoryOptionsConfigurationElement InMemoryOptions
        {
            get
            {
                return (IcsInMemoryOptionsConfigurationElement)base[InMemoryOptionsPropertyName];
            }
            set
            {
                base[InMemoryOptionsPropertyName] = value;
            }
        }

        /// <summary>
        /// Redis Token存储相关配置
        /// </summary>
        [ConfigurationProperty(RedisOptionsPropertyName)]
        public virtual IcsRedisOptionsConfigurationElement RedisOptions
        {
            get
            {
                return (IcsRedisOptionsConfigurationElement)base[RedisOptionsPropertyName];
            }
            set
            {
                base[RedisOptionsPropertyName] = value;
            }
        }

        /// <summary>
        /// Token缓存名
        /// </summary>
        [ConfigurationProperty(TokenKeyPropertyName)]
        public virtual string TokenKey
        {
            get
            {
                return (string)base[TokenKeyPropertyName];
            }
            set
            {
                base[TokenKeyPropertyName] = value;
            }
        }

        /// <summary>
        /// 将配置节转换为对应Options
        /// </summary>
        /// <returns></returns>
        public virtual IcsOptions ToOptions()
        {
            var options = new IcsOptions
            {
                Account = this.Account.ToOptions(),
                Environment = this.Environment,
                BaseUri = this.BaseUri,
                TokenStorageIn = this.TokenStorageIn,
            };

            if (this.Apis is not null and { Count: > 0 })
            {
                foreach (KeyValueConfigurationElement api in this.Apis)
                {
                    if (options.Apis.ContainsKey(api.Key))
                    {
                        options.Apis[api.Key] = api.Value;
                    }
                    else
                    {
                        options.Apis.Add(api.Key, api.Value);
                    }
                }
            }

            if (this.TokenStorageIn == IcsTokenStorageType.InMemory)
            {
                if (this.InMemoryOptions is not null)
                {
                    options.InMemoryOptions = this.InMemoryOptions.ToOptions();
                }
            }
            else if (this.TokenStorageIn == IcsTokenStorageType.Redis)
            {
                if (this.RedisOptions is not null && this.RedisOptions.ConnectionString is not null and { Length: > 0 })
                {
                    options.RedisOptions = this.RedisOptions.ToOptions();
                }
                else
                {
                    throw new ArgumentNullException("RedisOptions not set");
                }
            }

            if (this.TokenKey is not null and { Length: > 0 })
            {
                options.TokenKey = this.TokenKey;
            }

            return options;
        }

        /// <summary>
        /// 将配置节转换为对应OptionsWrapper
        /// </summary>
        /// <returns></returns>
        public virtual OptionsWrapper<IcsOptions> ToOptionsWrapper()
        {
            return new OptionsWrapper<IcsOptions>(ToOptions());
        }

        /// <summary>
        /// 隐式转换为Options
        /// </summary>
        /// <param name="configurationSection"></param>
        public static implicit operator IcsOptions(IcsConfigurationSection configurationSection)
        {
            return configurationSection.ToOptions();
        }

        /// <summary>
        /// 隐式转换为OptionsWrapper
        /// </summary>
        /// <param name="configurationSection"></param>
        public static implicit operator OptionsWrapper<IcsOptions>(IcsConfigurationSection configurationSection)
        {
            return configurationSection.ToOptionsWrapper();
        }
    }
}
