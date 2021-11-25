using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 值类型
    /// </summary>
    public enum ValueNType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown = 0,
        /// <summary>
        /// 费率
        /// </summary>
        [Description("费率")] Rate = 1,
        /// <summary>
        /// 单价
        /// </summary>
        [Description("单价")] Price = 2,
        /// <summary>
        /// 总价
        /// </summary>
        [Description("总价")] Amount = 3,
    }
}
