using System.ComponentModel;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 状态代码
    /// </summary>
    public enum TransferStatus
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown = 0,
        /// <summary>
        /// 初审通过
        /// </summary>
        [Description("初审通过")] FirstAuditComplete,
        /// <summary>
        /// 复审通过
        /// </summary>
        [Description("复审通过")] ReviewAuditComplete,
        /// <summary>
        /// 付税完成
        /// </summary>
        [Description("付税完成")] TaxComplete,
        /// <summary>
        /// 担保验放
        /// </summary>
        [Description("担保验放")] AssureCheck,
        /// <summary>
        /// 海关查验
        /// </summary>
        [Description("海关查验")] CheckComplete,
        /// <summary>
        /// 商检查验
        /// </summary>
        [Description("商检查验")] CIQInspect,
        /// <summary>
        /// 放行
        /// </summary>
        [Description("放行")] DischargedComplete
    }
}
