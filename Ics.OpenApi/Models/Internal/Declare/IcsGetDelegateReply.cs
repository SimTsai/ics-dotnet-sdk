using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取报关单及制单明细 响应
    /// </summary>
    internal record IcsGetDelegateReply : IcsReplyWrapper<List<IcsDelegate>>
    {
    }
}
