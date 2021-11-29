using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 委托单
    /// </summary>
    internal record IcsDelegate
    {
        /// <summary>
        /// 报关单
        /// </summary>
        public IcsDeclare Declare { get; init; }
        /// <summary>
        /// 制单明细
        /// </summary>
        public List<IcsMKDetail> MKDetailList { get; init; }
    }
}
