namespace Ics.OpenApi.Models.Internal.User
{
    internal partial record IcsGetTokenReply : IcsReplyWrapper<object>
    {
        public virtual string Token { get; init; }
    }
}
