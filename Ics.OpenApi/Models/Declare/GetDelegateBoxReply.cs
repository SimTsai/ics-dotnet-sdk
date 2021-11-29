using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 获取报关单集装箱明细 响应
    /// </summary>
    public record GetDelegateBoxReply : ReplyBase
    {
        /// <summary>
        /// 集装箱明细
        /// </summary>
        public List<DelegateBox> Boxes { get; init; }
    }
}
