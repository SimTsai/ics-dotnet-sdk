using System;

namespace Ics.OpenApi.Models.Internal.Declare
{
    internal record IcsTransferStatusRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 状态代码
        /// 初审通过FirstAuditComplete
        /// 复审通过ReviewAuditComplete
        /// 付税完成 TaxComplete
        /// 担保验放 AssureCheck
        /// 海关查验 CheckComplete
        /// 商检查验 CIQInspect
        /// 放行 DischargedComplete
        /// </summary>
        public string Status { get; init; }
        /// <summary>
        /// 状态时间
        /// </summary>
        public DateTime? StatusTime { get; init; }
        /// <summary>
        /// 操作人
        /// </summary>
        public string Operator { get; init; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; init; }
    }
}
