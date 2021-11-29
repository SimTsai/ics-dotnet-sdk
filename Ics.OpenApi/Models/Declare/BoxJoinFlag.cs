using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 拼箱标识
    /// </summary>
    public enum BoxJoinFlag
    {
        /// <summary>
        /// 未拼
        /// </summary>
        [Description("未拼")] 未拼 = 0,
        /// <summary>
        /// 拼箱
        /// </summary>
        [Description("拼箱")] 拼箱 = 1
    }
}
