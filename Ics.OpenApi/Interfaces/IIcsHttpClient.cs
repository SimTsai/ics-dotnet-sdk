using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ics.OpenApi.Interfaces
{
    internal interface IIcsHttpClient : System.IDisposable
    {
        IIcsHttpClient SetToken(string token);
        Task<TReply> PostFormAsync<TRequest, TReply>(TRequest request, string apiUri);
        Task<TReply> PostFormAsync<TReply>(Dictionary<string, string> dict, string apiUri);
        Task<TReply> PostAsync<TRequest, TReply>(TRequest request, string apiUri);
    }
}
