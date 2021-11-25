using System.Threading.Tasks;

namespace Ics.OpenApi.Interfaces.Internal
{
    internal interface IIcsRequestService
    {
        Task<TReply> RequestAsync<TRequest, TReply>(TRequest request, string apiName);
    }
}
