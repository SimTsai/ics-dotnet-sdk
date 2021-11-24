namespace Ics.OpenApi.Models.User
{
    internal partial record IcsGetTokenOutReply : IcsOutReplyWrapper<string>
    {
        public virtual string Token { get; init; }
    }
}
