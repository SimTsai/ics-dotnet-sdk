using System;
using Ics.OpenApi.Enums;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements.Internal
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
