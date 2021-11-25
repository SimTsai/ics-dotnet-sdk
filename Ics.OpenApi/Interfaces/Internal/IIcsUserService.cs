using System.Threading.Tasks;
using Ics.OpenApi.Models.Internal.User;

namespace Ics.OpenApi.Interfaces.Internal
{
    internal interface IIcsUserService
    {
        Task<IcsGetTokenReply> GetTokenAsync(IcsGetTokenRequest request);
    }
}
