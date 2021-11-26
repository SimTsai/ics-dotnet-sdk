using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 发送报关单及申报明细 请求
    /// </summary>
    public class TransferDelegateRequest
    {
        /// <summary>
        /// 报关单
        /// </summary>
        public Declare Declare { get; init; }
        /// <summary>
        /// 申报明细
        /// </summary>
        public List<DDetail> DDetailList { get; init; }
    }
}
