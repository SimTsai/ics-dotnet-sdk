using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 发送报关单集装箱明细 请求
    /// </summary>
    public class TransferDelegateBoxRequest
    {
        /// <summary>
        /// 业务流水号
        /// </summary>
        public string BusinessSerial { get; init; }
        /// <summary>
        /// 集装箱明细记录
        /// </summary>
        public List<DelegateBox> BoxList { get; init; }
    }
}
