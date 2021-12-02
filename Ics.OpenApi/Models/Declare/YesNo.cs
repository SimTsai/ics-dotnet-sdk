using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 是否
    /// </summary>
    public enum YesNo
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown = -1,
        /// <summary>
        /// 否
        /// </summary>
        [Description("否")] No = 0,
        /// <summary>
        /// 是
        /// </summary>
        [Description("是")] Yes = 1
    }
}
