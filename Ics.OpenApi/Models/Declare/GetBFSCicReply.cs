using System.Collections.Generic;

namespace Ics.OpenApi.Models.Declare
{
    /// <summary>
    /// 获取随附单证 响应
    /// </summary>
    public record GetBFSCicReply : ReplyBase
    {
        /// <summary>
        /// 随附单证
        /// </summary>
        public List<BFSCic> CicList { get; init; }
    }
}
