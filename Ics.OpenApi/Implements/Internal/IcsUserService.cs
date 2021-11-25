using System.Threading.Tasks;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Models.Internal.User;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements.Internal
{
    internal class IcsUserService : IIcsUserService
    {
        private readonly IIcsHttpClient _iscHttpClient;
        private readonly IOptions<IcsOptions> _iscOptions;

        public IcsUserService(
            IIcsHttpClient iscHttpClient,
            IOptions<IcsOptions> iscOptions
            )
        {
            _iscHttpClient = iscHttpClient;
            _iscOptions = iscOptions;
        }

        async public Task<IcsGetTokenReply> GetTokenAsync(IcsGetTokenRequest request)
        {
            var apiUri = _iscOptions.Value.Apis["获取令牌"];
            return await _iscHttpClient
                .PostAsync<IcsGetTokenRequest, IcsGetTokenReply>(request, apiUri)
                .ConfigureAwait(false);
        }
    }
}
