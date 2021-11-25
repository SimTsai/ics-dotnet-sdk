using System;
using System.Net.Http;

namespace Ics.OpenApi.Implements.Internal
{
    internal class IcsHttpClientFactory : IHttpClientFactory
    {
        static Lazy<HttpMessageHandler> HttpMessageHandler = new Lazy<HttpMessageHandler>(() =>
        {
#if NET5_0_OR_GREATER
            if (SocketsHttpHandler.IsSupported)
            {
                return new SocketsHttpHandler();
            }
            else
            {
                return new HttpClientHandler();
            }
#else
            return new HttpClientHandler();
#endif
        });
        public HttpClient CreateClient(string name) => new HttpClient(HttpMessageHandler.Value, false);
    }
}
