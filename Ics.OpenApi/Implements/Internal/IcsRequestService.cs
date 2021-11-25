using System;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Models.Internal;
using Ics.OpenApi.Models.Internal.User;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements.Internal
{
    internal class IcsRequestService : IIcsRequestService
    {
        private readonly IcsOptions icsOptions;
        private readonly IIcsHttpClient icsHttpClient;
        private readonly ITokenStorageService icsTokenStorageService;
        private readonly IIcsUserService _icsUserService;

        public IcsRequestService(
            IOptions<IcsOptions> iscOptions,
            IIcsHttpClient iscHttpClient,
            ITokenStorageService tokenStorageService,
            IIcsUserService icsUserService
            )
        {
            this.icsOptions = iscOptions.Value;
            this.icsHttpClient = iscHttpClient;
            this.icsTokenStorageService = tokenStorageService;
            _icsUserService = icsUserService;
        }

        async public Task<TReply> RequestAsync<TRequest, TReply>(TRequest request, string apiName)
        {
            try
            {
                var token = await GetTokenAsync();
                var apiUri = icsOptions.Apis[apiName];
                var reply = await icsHttpClient
                    .SetToken(token)
                    .PostAsync<TRequest, TReply>(request, apiUri)
                    .ConfigureAwait(false);
                return reply;
            }
            catch (Exception)
            {
                throw;
            }
        }

        async private Task<string> GetTokenAsync()
        {
            var token = await icsTokenStorageService.LoadTokenAsync().ConfigureAwait(false);
            if (token is null or { Length: 0 })
            {
                var loginReply = await GetTokenRequestAsync().ConfigureAwait(false);
                await icsTokenStorageService.SaveTokenAsync(loginReply.Token).ConfigureAwait(false);
                return loginReply.Token;
            }
            return token;
        }

        async private Task<IcsGetTokenReply> GetTokenRequestAsync()
        {
            var request = new IcsGetTokenRequest
            {
                pwd = this.icsOptions.Account.Password,
                userName = this.icsOptions.Account.User,
            };
            return await _icsUserService.GetTokenAsync(request).ConfigureAwait(false);
        }
    }
}
