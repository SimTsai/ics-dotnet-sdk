namespace Ics.OpenApi.Models.Internal.User
{
    /// <summary>
    /// 获取令牌 请求
    /// </summary>
    internal partial record IcsGetTokenRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string userName { get; init; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string pwd { get; init; }
    }
}
