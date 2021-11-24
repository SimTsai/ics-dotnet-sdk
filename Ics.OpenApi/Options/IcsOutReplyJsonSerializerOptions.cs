using System.Text.Json;

namespace Ics.OpenApi.Options
{
    internal static class IcsOutReplyJsonSerializerOptions
    {
        internal static JsonSerializerOptions Default => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
}
