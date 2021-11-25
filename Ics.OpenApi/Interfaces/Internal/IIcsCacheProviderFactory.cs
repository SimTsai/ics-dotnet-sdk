using Microsoft.Extensions.Caching.Distributed;

namespace Ics.OpenApi.Interfaces.Internal
{
    internal interface IIcsCacheProviderFactory
    {
        IDistributedCache GetProvider();
    }
}
