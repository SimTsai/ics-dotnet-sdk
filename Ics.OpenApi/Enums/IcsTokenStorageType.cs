using System.ComponentModel;

namespace Ics.OpenApi.Enums
{
    /// <summary>
    /// ICSToken存储位置
    /// </summary>
    public enum IcsTokenStorageType
    {
        /// <summary>
        /// 进程内
        /// </summary>
        [Description("进程内")] InMemory,
        /// <summary>
        /// Redis
        /// </summary>
        [Description("Redis")] Redis,
        /// <summary>
        /// 自定义， 需要传入IIcsTokenStorageService
        /// </summary>
        [Description("Custom")] Custom,
    }
}
