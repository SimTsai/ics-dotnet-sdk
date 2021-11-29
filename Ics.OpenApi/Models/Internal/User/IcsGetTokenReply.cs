namespace Ics.OpenApi.Models.Internal.User
{
    /// <summary>
    /// 获取令牌 响应
    /// </summary>
    internal partial record IcsGetTokenReply : IcsReplyWrapper<object>
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public virtual string Token { get; init; }
    }
}
