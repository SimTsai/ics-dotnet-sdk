using System.Text.Json;

namespace Ics.OpenApi.Options.Internal
{
    internal static class IcsReplyJsonSerializerOptions
    {
        internal static JsonSerializerOptions Default => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
}
