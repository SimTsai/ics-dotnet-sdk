using System.Collections.Generic;
using System.Threading.Tasks;
using Ics.OpenApi.Models;
using Ics.OpenApi.Models.User;

namespace Ics.OpenApi.Interfaces
{
    internal interface IIcsOutRequestService : IIcsTokenService
    {
        Task<IcsOutReplyWrapper<TReply>> RequestAsync<TRequest, TReply>(TRequest request, string apiName);
        Task<IcsGetTokenOutReply> GetTokenRequestAsync();
    }
}
