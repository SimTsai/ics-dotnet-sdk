using System.Threading.Tasks;
using Ics.OpenApi.Models.Internal.Declare;

namespace Ics.OpenApi.Interfaces.Internal
{
    /// <summary>
    /// 报关行接口
    /// </summary>
    internal interface IIcsDeclareService
    {
        /// <summary>
        /// 获取报关单及制单明细
        /// </summary>
        Task<IcsGetDelegateReply> IcsGetDelegateAsync(IcsGetDelegateRequest request);
        /// <summary>
        /// 发送报关单及申报明细
        /// </summary>
        Task<IcsTransferDelegateReply> IcsTransferDelegateAsync(IcsTransferDelegateRequest request);
        /// <summary>
        /// 发送审核状态
        /// </summary>
        Task<IcsTransferStatusReply> IcsTransferStatusAsync(IcsTransferStatusRequest request);
        /// <summary>
        /// 获取报关单集装箱明细
        /// </summary>
        Task<IcsGetDelegateBoxReply> IcsGetDelegateBoxAsync(IcsGetDelegateBoxRequest request);
        /// <summary>
        /// 发送报关单集装箱明细
        /// </summary>
        Task<IcsTransferDelegateBoxReply> IcsTransferDelegateBoxAsync(IcsTransferDelegateBoxRequest request);
        /// <summary>
        /// 获取随附单证
        /// </summary>
        Task<IcsGetBFSCicReply> IcsGetBFSCicAsync(IcsGetBFSCicRequest request);
        /// <summary>
        /// 发送随附单证
        /// </summary>
        Task<IcsTransferBFSCicReply> IcsTransferBFSCicAsync(IcsTransferBFSCicRequest request);
    }
}
