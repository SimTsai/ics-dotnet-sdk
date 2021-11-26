using System;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 发送审核状态 请求
    /// </summary>
    public class TransferStatusRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 状态代码
        /// </summary>
        public TransferStatus Status { get; init; }
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
