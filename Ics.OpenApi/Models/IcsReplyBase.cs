namespace Ics.OpenApi.Models
{
    /// <summary>
    /// ICS响应基类
    /// </summary>
    public abstract record IcsReplyBase
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; init; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; init; }
    }
}
