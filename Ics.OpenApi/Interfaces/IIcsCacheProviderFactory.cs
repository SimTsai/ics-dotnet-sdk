using Microsoft.Extensions.Caching.Distributed;

namespace Ics.OpenApi.Interfaces
{
    internal interface IIcsCacheProviderFactory
    {
        IDistributedCache GetProvider();
    }
}
