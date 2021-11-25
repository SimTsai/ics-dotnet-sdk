using System;

namespace Ics.OpenApi.Interfaces
{
    /// <summary>
    /// 跨境无忧ICS服务接口
    /// </summary>
    public interface IIcsService : IDisposable
    {
        /// <summary>
        ///  报关行接口
        /// </summary>
        IDeclareService DeclareService { get; }
    }
}
