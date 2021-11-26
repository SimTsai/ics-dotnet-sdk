using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 获取报关单及制单明细 响应
    /// </summary>
    public record GetDelegateReply : ReplyBase
    {
        /// <summary>
        /// 委托单
        /// </summary>
        public List<Delegate> Delegates { get; init; }
    }
}
