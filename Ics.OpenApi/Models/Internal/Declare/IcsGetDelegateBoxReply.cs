using System.Collections.Generic;

namespace Ics.OpenApi.Models.Internal.Declare
{
    /// <summary>
    /// 获取报关单集装箱明细 响应
    /// </summary>
    internal record IcsGetDelegateBoxReply : IcsReplyWrapper<List<IcsDelegateBox>>
    {
    }
}
