using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ics.OpenApi.Extensions;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Models;
using Ics.OpenApi.Models.User;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.Implements
{
    internal class IcsOutRequestService : IIcsOutRequestService
    {
        private readonly IcsOptions icsOptions;
        private readonly IIcsHttpClient icsHttpClient;
        private readonly IIcsTokenStorageService icsTokenStorageService;

        public IcsOutRequestService(
            IOptions<IcsOptions> iscOptions,
            IIcsHttpClient iscHttpClient,
            IIcsTokenStorageService icsTokenStorageService
            )
        {
            this.icsOptions = iscOptions.Value;
            this.icsHttpClient = iscHttpClient;
            this.icsTokenStorageService = icsTokenStorageService;
        }

        async public Task<IcsOutReplyWrapper<TReply>> RequestAsync<TRequest, TReply>(TRequest request, string apiName)
        {
            try
            {
                var token = await GetTokenAsync();
                var apiUri = icsOptions.Apis[apiName];
                var reply = await icsHttpClient
                    .SetToken(token)
                    .PostAsync<TRequest, IcsOutReplyWrapper<TReply>>(request, apiUri)
                    .ConfigureAwait(false);
                return reply;
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<string> GetTokenAsync()
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

        async public Task<IcsGetTokenOutReply> GetTokenRequestAsync()
        {
            var apiUri = icsOptions.Apis["获取令牌"];

            var request = new IcsGetTokenOutRequest
            {
                pwd = this.icsOptions.Account.Password,
                userName = this.icsOptions.Account.User,
            };

            var reply = await icsHttpClient
                .PostAsync<IcsGetTokenOutRequest, IcsGetTokenOutReply>((IcsGetTokenOutRequest)request, apiUri)
                .ConfigureAwait(false);

            return reply;
        }
    }
}
