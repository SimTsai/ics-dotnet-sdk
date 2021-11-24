using Ics.OpenApi.Extensions;
using Ics.OpenApi.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Ics.OpenApi.Options;
using System;
#if NET5_0_OR_GREATER
using System.Net.Http.Json;
#else
using System.IO;
using System.Text;
using System.Text.Json;
#endif

namespace Ics.OpenApi.Implements
{
    internal class IcsHttpClient : IIcsHttpClient, IDisposable
    {
        private readonly HttpClient httpClient;

        public IcsHttpClient(
            IHttpClientFactory httpClientFactory,
            IOptions<IcsOptions> icsOptions
            )
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sdk", "ics-dotnet-sdk");
            this.httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sdkver", typeof(IcsHttpClient).Assembly.GetName().Version.ToString(3));
            this.httpClient.BaseAddress = new Uri(icsOptions.Value.BaseUri);
        }

        public void Dispose()
        {
            this.httpClient?.Dispose();
        }

        async public Task<TReply> PostFormAsync<TRequest, TReply>(TRequest request, string apiUri)
            => await this.PostFormAsync<TReply>(request.ToStringDictionary<TRequest>(), apiUri).ConfigureAwait(false);

        async public Task<TReply> PostFormAsync<TReply>(Dictionary<string, string> dict, string apiUri)
        {
            var formUrlEncodedContent = new FormUrlEncodedContent(dict);
            var responseMessage = await httpClient
                .PostAsync(apiUri, formUrlEncodedContent)
                .ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();
            TReply reply;
#if NET5_0_OR_GREATER
            reply = await responseMessage.Content.ReadFromJsonAsync<TReply>(IcsOutReplyJsonSerializerOptions.Default).ConfigureAwait(false);
#else
            var json = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json), false);
            reply = await JsonSerializer.DeserializeAsync<TReply>(ms, IcsOutReplyJsonSerializerOptions.Default).ConfigureAwait(false);
#endif
            return reply;
        }

        async public Task<TReply> PostAsync<TRequest, TReply>(TRequest request, string apiUri)
        {
            HttpContent httpContent;
#if NET5_0_OR_GREATER
            httpContent = JsonContent.Create(request, options: IcsOutReplyJsonSerializerOptions.Default);
#else
            using var stream = new MemoryStream();
            await JsonSerializer.SerializeAsync(stream, request, IcsOutReplyJsonSerializerOptions.Default).ConfigureAwait(false);
            stream.Seek(0, SeekOrigin.Begin);
            httpContent = new StreamContent(stream);
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
#endif
            var responseMessage = await httpClient
                .PostAsync(apiUri, httpContent)
                .ConfigureAwait(false);
            responseMessage.EnsureSuccessStatusCode();

            TReply reply;
#if NET5_0_OR_GREATER
            reply = await responseMessage.Content.ReadFromJsonAsync<TReply>(IcsOutReplyJsonSerializerOptions.Default).ConfigureAwait(false);
#else
            var json = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
            using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json), false);
            reply = await JsonSerializer.DeserializeAsync<TReply>(ms, IcsOutReplyJsonSerializerOptions.Default).ConfigureAwait(false);
#endif
            return reply;
        }

        public IIcsHttpClient SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return this;
        }
    }
}
