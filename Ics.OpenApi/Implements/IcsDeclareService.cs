using System;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Models;
using Ics.OpenApi.Models.Declare;
using Microsoft.Extensions.DependencyInjection;

namespace Ics.OpenApi.Implements
{
    /// <summary>
    /// 报关行接口
    /// </summary>
    public class IcsDeclareService : IIcsDeclareService
    {
        private readonly IIcsOutRequestService icsOutRequestService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public IcsDeclareService(IServiceProvider serviceProvider)
            : this(serviceProvider.GetRequiredService<IIcsOutRequestService>())
        {

        }

        internal IcsDeclareService(IIcsOutRequestService icsOutRequestService)
        {
            this.icsOutRequestService = icsOutRequestService;
        }

        /// <summary>
        /// 2.1	获取报关单及制单明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        async public Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request)
        {
            var outReply = await GetDelegateOutAsync(request).ConfigureAwait(false);
            //var @delegate = new List<Models.Declare.Delegate>();
            GetDelegateReply result = new GetDelegateReply
            {
                Success = outReply.State == Enums.IcsOutReplyStatus.Succeed,
                Message = outReply.ErrorMessage ?? outReply.Message,
                Delegates = outReply.Result
            };

            if (result.Success)
            {

            }

            return result;
        }

        async private Task<IcsOutReplyWrapper<GetDelegateOutReply>> GetDelegateOutAsync(GetDelegateRequest request)
        {

            var outReply = await icsOutRequestService
                .RequestAsync<GetDelegateRequest, GetDelegateOutReply>(request, "获取报关单及制单明细")
                .ConfigureAwait(false);
            return outReply;
        }
    }
}
