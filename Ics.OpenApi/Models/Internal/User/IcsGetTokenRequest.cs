namespace Ics.OpenApi.Models.Internal.User
{
    internal partial record IcsGetTokenRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public virtual string userName { get; init; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string pwd { get; init; }
    }
}
