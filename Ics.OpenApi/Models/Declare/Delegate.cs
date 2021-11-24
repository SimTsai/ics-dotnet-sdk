using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 报关单
    /// </summary>
    public class @Delegate
    {
        /// <summary>
        /// 报关单 表头
        /// </summary>
        public DelegateDeclare Declare { get; init; }
        /// <summary>
        /// 报关单 商品明细
        /// </summary>
        public List<DelegateMKDetail> MKDetailList { get; init; }
    }
}
