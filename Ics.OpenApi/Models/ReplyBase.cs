namespace Ics.OpenApi.Models
{
    /// <summary>
    /// 响应基类
    /// </summary>
    public abstract record ReplyBase
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
