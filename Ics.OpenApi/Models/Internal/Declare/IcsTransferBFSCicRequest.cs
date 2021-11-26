using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 发送随附单证 请求
    /// </summary>
    internal record IcsTransferBFSCicRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 随附单证表体
        /// </summary>
        public List<IcsBFSCic> CICList { get; init; }
    }
}
