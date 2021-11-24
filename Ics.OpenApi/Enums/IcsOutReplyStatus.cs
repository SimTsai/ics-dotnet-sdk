namespace Ics.OpenApi.Enums
{
    /// <summary>
    /// ICS接口返回状态
    /// </summary>
    public enum IcsOutReplyStatus
    {
        /// <summary>
        /// 失败
        /// </summary>
        Failed = 0,
        /// <summary>
        /// 成功
        /// </summary>
        Succeed = 1,
        /// <summary>
        /// 异常
        /// </summary>
        Exception = -1,
    }
}
