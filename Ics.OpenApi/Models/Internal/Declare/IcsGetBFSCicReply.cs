using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取随附单证 响应
    /// </summary>
    internal record IcsGetBFSCicReply : IcsReplyWrapper<List<IcsBFSCic>>
    {
    }
}
