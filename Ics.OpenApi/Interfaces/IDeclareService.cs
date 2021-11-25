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
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request);
#if false
        /// <summary>
        /// 2.2	发送报关单及申报明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TransferDelegateReply> TransferDelegateAsync(TransferDelegateRequest request);
        /// <summary>
        /// 2.4	发送审核状态
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TransferStatusReply> TransferStatusAsync(TransferStatusRequest request);
#endif
    }
}

