namespace Ics.OpenApi.Models.User
{
    internal partial record IcsGetTokenOutRequest
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string userName { get; init; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; init; }
    }
}
