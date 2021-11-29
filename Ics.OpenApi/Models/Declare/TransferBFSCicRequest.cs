using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 发送随附单证 请求
    /// </summary>
    public class TransferBFSCicRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 随附单证表体
        /// </summary>
        public List<BFSCic> CICList { get; init; }
    }
}
