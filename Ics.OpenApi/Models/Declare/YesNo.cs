using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 是否
    /// </summary>
    public enum YesNo
    {
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
