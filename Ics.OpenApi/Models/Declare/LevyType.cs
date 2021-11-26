using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 征免性质
    /// </summary>
    public enum LevyType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown = 0,
        /// <summary>
        /// 照章征税
        /// </summary>
        [Description("照章征税")] 照章征税 = 1,
        /// <summary>
        /// 折半征税
        /// </summary>
        [Description("折半征税")] 折半征税 = 2,
        /// <summary>
        /// 全免
        /// </summary>
        [Description("全免")] 全免 = 3,
        /// <summary>
        /// 特案
        /// </summary>
        [Description("特案")] 特案 = 4,
        /// <summary>
        /// 征免性质
        /// </summary>
        [Description("征免性质")] 征免性质 = 5,
        /// <summary>
        /// 保证金
        /// </summary>
        [Description("保证金")] 保证金 = 6,
        /// <summary>
        /// 保函
        /// </summary>
        [Description("保函")] 保函 = 7,
        /// <summary>
        /// 折半补税
        /// </summary>
        [Description("折半补税")] 折半补税 = 8,
        /// <summary>
        /// 全额退税
        /// </summary>
        [Description("全额退税")] 全额退税 = 9
    }
}
