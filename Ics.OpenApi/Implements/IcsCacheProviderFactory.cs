using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Ics.OpenApi.Enums;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.Implements
{
    internal class IcsCacheProviderFactory : IIcsCacheProviderFactory
    {
        private readonly IcsOptions icsOptions;

        public IcsCacheProviderFactory(
            IOptions<IcsOptions> icsOptions
            )
        {
            this.icsOptions = icsOptions.Value;
        }

        public IDistributedCache GetProvider()
        {
            IDistributedCache distributedCache =
                icsOptions.TokenStorageIn switch
                {
                    IcsTokenStorageType.InMemory => new MemoryDistributedCache(new OptionsWrapper<MemoryDistributedCacheOptions>(icsOptions.InMemoryOptions ?? new MemoryDistributedCacheOptions())),
                    IcsTokenStorageType.Redis => new RedisCache(new OptionsWrapper<RedisCacheOptions>(icsOptions.RedisOptions ?? new RedisCacheOptions())),
                    _ => throw new NotSupportedException()
                };
            return distributedCache;
        }
    }
}
