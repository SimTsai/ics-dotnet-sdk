using System.Threading.Tasks;
using Ics.OpenApi.Models.Declare;

namespace Ics.OpenApi.Interfaces
{
    /// <summary>
    /// 报关行接口
    /// </summary>
    public interface IIcsDeclareService
    {
        /// <summary>
        /// 2.1	获取报关单及制单明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request);
    }
}
