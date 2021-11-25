using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Models.Declare;
using Ics.OpenApi.Models.Internal;
using Ics.OpenApi.Models.Internal.Declare;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using AutoMapper;

namespace Ics.OpenApi.Implements
{
    /// <summary>
    /// 报关行接口
    /// </summary>
    public class DeclareService : IDeclareService, IIcsDeclareService
    {
        private readonly IIcsRequestService icsRequestService;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="serviceProvider"></param>
        public DeclareService(IServiceProvider serviceProvider)
            : this(serviceProvider.GetRequiredService<IIcsRequestService>(), serviceProvider.GetRequiredService<IMapper>())
        {

        }

        internal DeclareService(
            IIcsRequestService icsRequestService,
            IMapper mapper
            )
        {
            this.icsRequestService = icsRequestService;
            _mapper = mapper;
        }

        /// <summary>
        /// 2.1	获取报关单及制单明细
        /// </summary>
        async public Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request)
        {
            var reply = await ((IIcsDeclareService)this)
                .IcsGetDelegateAsync(new IcsGetDelegateRequest { BusinessSerial = request.BusinessSerial })
                .ConfigureAwait(false);

            return new GetDelegateReply
            {
                Success = reply.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = reply.ErrorMessage ?? reply.Message,
                Delegates = _mapper.Map<List<Models.Declare.Delegate>>(reply.Result)
            };
        }

        async Task<IcsGetDelegateReply> IIcsDeclareService.IcsGetDelegateAsync(IcsGetDelegateRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsGetDelegateRequest, IcsGetDelegateReply>(request, "获取报关单及制单明细")
                .ConfigureAwait(false);
            return reply;
        }




#if false
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
                Success = outReply.State == Enums.IcsReplyStatus.Succeed,
                Message = outReply.ErrorMessage ?? outReply.Message,
                Delegates = outReply.Result
            };

            if (result.Success)
            {

            }

            return result;
        }

        /// <summary>
        /// 2.2	发送报关单及申报明细
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        async public Task<TransferDelegateReply> TransferDelegateAsync(TransferDelegateRequest request)
        {
            var outReply = await TransferDelegateOutAsync(request).ConfigureAwait(false);
            TransferDelegateReply result = new TransferDelegateReply
            {
                Success = outReply.State == Enums.IcsReplyStatus.Succeed,
                Message = outReply.ErrorMessage ?? outReply.Message
            };
            if (result.Success)
            {

            }
            return result;
        }

        async private Task<IcsOutReplyWrapper<GetDelegateOutReply>> GetDelegateOutAsync(GetDelegateRequest request)
        {

            var outReply = await icsRequestService
                .RequestAsync<GetDelegateRequest, GetDelegateOutReply>(request, "获取报关单及制单明细")
                .ConfigureAwait(false);
            return outReply;
        }

        async private Task<IcsOutReplyWrapper<object>> TransferDelegateOutAsync(TransferDelegateRequest request)
        {
            var outReply = await icsRequestService
                .RequestAsync<TransferDelegateRequest, object>(request, "发送报关单及申报明细")
                .ConfigureAwait(false);
            return outReply;
        }
#endif
    }
}
