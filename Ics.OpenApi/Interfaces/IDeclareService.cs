using System.Threading.Tasks;
using Ics.OpenApi.Models.Declare;

namespace Ics.OpenApi.Interfaces
{
    /// <summary>
    /// 报关行接口
    /// </summary>
    public interface IDeclareService
    {
        /// <summary>
        /// 2.1	获取报关单及制单明细
        /// </summary>
        Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request);
        /// <summary>
        /// 2.2	发送报关单及申报明细
        /// </summary>
        Task<TransferDelegateReply> TransferDelegateAsync(TransferDelegateRequest request);
        /// <summary>
        /// 2.4	发送审核状态
        /// </summary>
        Task<TransferStatusReply> TransferStatusAsync(TransferStatusRequest request);
        /// <summary>
        /// 2.5 获取报关单集装箱明细
        /// </summary>
        Task<GetDelegateBoxReply> GetDelegateBoxAsync(GetDelegateBoxRequest request);
        /// <summary>
        /// 2.6 发送报关单集装箱明细
        /// </summary>
        Task<TransferDelegateBoxReply> TransferDelegateBoxAsync(TransferDelegateBoxRequest request);
        /// <summary>
        /// 2.7 获取随附单证
        /// </summary>
        Task<GetBFSCicReply> GetBFSCicAsync(GetBFSCicRequest request);
        /// <summary>
        /// 2.8 发送随附单证
        /// </summary>
        Task<TransferBFSCicReply> TransferBFSCicAsync(TransferBFSCicRequest request);

    }
}

