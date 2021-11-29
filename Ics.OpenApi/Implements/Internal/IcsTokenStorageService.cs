using System;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements.Internal
{
    internal class IcsTokenStorageService : ITokenStorageService
    {
        private readonly IDistributedCache distributedCache;
        private readonly IcsOptions icsOptions;

        public IcsTokenStorageService(
            IIcsCacheProviderFactory icsCacheProviderFactory,
            IOptions<IcsOptions> icsOptions
            )
        {
            distributedCache = icsCacheProviderFactory.GetProvider();
            this.icsOptions = icsOptions?.Value;
        }

        public void Dispose()
        {
            if (distributedCache is not null && distributedCache is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        async public Task<string> LoadTokenAsync()
        {
            var token = await distributedCache
                 .GetStringAsync(this.icsOptions.TokenKey)
                 .ConfigureAwait(false);
            return token;
        }

        async public Task SaveTokenAsync(string token)
        {
            await distributedCache
                .SetStringAsync(this.icsOptions.TokenKey, token, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(50) })
                .ConfigureAwait(false);
        }
    }
}
