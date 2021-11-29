using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 发送报关单及申报明细
    /// </summary>
    internal record IcsTransferDelegateRequest
    {
        /// <summary>
        /// 报关单
        /// </summary>
        public IcsDeclare Declare { get; init; }
        /// <summary>
        /// 申报明细
        /// </summary>
        public List<IcsDDetail> DDetailList { get; init; }
    }
}
