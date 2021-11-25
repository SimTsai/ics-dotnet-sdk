using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 进出口标志
    /// </summary>
    public enum IeFlag
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown = 0,
        /// <summary>
        /// 进口
        /// </summary>
        [Description("进口")] Import = 1,
        /// <summary>
        /// 进境
        /// </summary>
        [Description("进境")] Enter = 2,
        /// <summary>
        /// 出口
        /// </summary>
        [Description("出口")] Export = 3,
        /// <summary>
        /// 出境
        /// </summary>
        [Description("出境")] Exit = 4,
    }
}
