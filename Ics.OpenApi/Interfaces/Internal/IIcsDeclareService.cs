using System.Threading.Tasks;
using Ics.OpenApi.Models.Internal.Declare;

namespace Ics.OpenApi.Interfaces.Internal
{
    internal interface IIcsDeclareService
    {
        Task<IcsGetDelegateReply> IcsGetDelegateAsync(IcsGetDelegateRequest request);
    }
}
