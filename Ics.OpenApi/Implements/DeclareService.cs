using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Models.Declare;
using Ics.OpenApi.Models.Internal.Declare;
using Microsoft.Extensions.DependencyInjection;

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

        #region 2.1	获取报关单及制单明细
        /// <summary>
        /// 2.1	获取报关单及制单明细
        /// </summary>
        async public Task<GetDelegateReply> GetDelegateAsync(GetDelegateRequest request)
        {
            var reply = await ((IIcsDeclareService)this)
                .IcsGetDelegateAsync(_mapper.Map<IcsGetDelegateRequest>(request))
                .ConfigureAwait(false);

            return new GetDelegateReply
            {
                Success = reply.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = reply.ErrorMessage ?? reply.Message,
                Delegates = reply.State == Enums.Internal.IcsReplyStatus.Succeed ? _mapper.Map<List<Models.Declare.Delegate>>(reply.Result) : null
            };
        }

        async Task<IcsGetDelegateReply> IIcsDeclareService.IcsGetDelegateAsync(IcsGetDelegateRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsGetDelegateRequest, IcsGetDelegateReply>(request, "获取报关单及制单明细")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.2	发送报关单及申报明细
        /// <summary>
        /// 2.2	发送报关单及申报明细
        /// </summary>
        async public Task<TransferDelegateReply> TransferDelegateAsync(TransferDelegateRequest request)
        {
            var replay = await ((IIcsDeclareService)this)
                .IcsTransferDelegateAsync(_mapper.Map<IcsTransferDelegateRequest>(request))
                .ConfigureAwait(false);
            return new TransferDelegateReply
            {
                Success = replay.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = replay.ErrorMessage ?? replay.Message,
            };
        }

        async Task<IcsTransferDelegateReply> IIcsDeclareService.IcsTransferDelegateAsync(IcsTransferDelegateRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsTransferDelegateRequest, IcsTransferDelegateReply>(request, "发送报关单及申报明细")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.4	发送审核状态
        /// <summary>
        /// 2.4	发送审核状态
        /// </summary>
        async public Task<TransferStatusReply> TransferStatusAsync(TransferStatusRequest request)
        {
            var reply = await ((IIcsDeclareService)this)
                .IcsTransferStatusAsync(_mapper.Map<IcsTransferStatusRequest>(request))
                .ConfigureAwait(false);
            return new TransferStatusReply
            {
                Success = reply.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = reply.ErrorMessage ?? reply.Message,
            };
        }

        async Task<IcsTransferStatusReply> IIcsDeclareService.IcsTransferStatusAsync(IcsTransferStatusRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsTransferStatusRequest, IcsTransferStatusReply>(request, "发送审核状态")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.5	获取报关单集装箱明细
        /// <summary>
        /// 获取报关单集装箱明细
        /// </summary>
        async public Task<GetDelegateBoxReply> GetDelegateBoxAsync(GetDelegateBoxRequest request)
        {
            var reply = await ((IIcsDeclareService)this)
                .IcsGetDelegateBoxAsync(_mapper.Map<IcsGetDelegateBoxRequest>(request))
                .ConfigureAwait(false);

            return new GetDelegateBoxReply
            {
                Success = reply.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = reply.ErrorMessage ?? reply.Message,
                //Delegates = reply.State == Enums.Internal.IcsReplyStatus.Succeed ? _mapper.Map<List<Models.Declare.Delegate>>(reply.Result) : null
            };
        }

        async Task<IcsGetDelegateBoxReply> IIcsDeclareService.IcsGetDelegateBoxAsync(IcsGetDelegateBoxRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsGetDelegateBoxRequest, IcsGetDelegateBoxReply>(request, "获取报关单集装箱明细")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.6	发送报关单集装箱明细 TransferDelegateBox
        /// <summary>
        /// 2.6	发送报关单集装箱明细 TransferDelegateBox
        /// </summary>
        async public Task<TransferDelegateBoxReply> TransferDelegateBoxAsync(TransferDelegateBoxRequest request)
        {
            var replay = await ((IIcsDeclareService)this)
                .IcsTransferDelegateBoxAsync(_mapper.Map<IcsTransferDelegateBoxRequest>(request))
                .ConfigureAwait(false);
            return new TransferDelegateBoxReply
            {
                Success = replay.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = replay.ErrorMessage ?? replay.Message,
            };
        }

        async Task<IcsTransferDelegateBoxReply> IIcsDeclareService.IcsTransferDelegateBoxAsync(IcsTransferDelegateBoxRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsTransferDelegateBoxRequest, IcsTransferDelegateBoxReply>(request, "发送报关单集装箱明细")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.7	获取随附单证 GetBFSCic
        /// <summary>
        /// 2.7	获取随附单证 GetBFSCic
        /// </summary>
        async public Task<GetBFSCicReply> GetBFSCicAsync(GetBFSCicRequest request)
        {
            var reply = await ((IIcsDeclareService)this)
                .IcsGetBFSCicAsync(_mapper.Map<IcsGetBFSCicRequest>(request))
                .ConfigureAwait(false);

            return new GetBFSCicReply
            {
                Success = reply.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = reply.ErrorMessage ?? reply.Message,
                //Delegates = reply.State == Enums.Internal.IcsReplyStatus.Succeed ? _mapper.Map<List<Models.Declare.Delegate>>(reply.Result) : null
            };
        }

        async Task<IcsGetBFSCicReply> IIcsDeclareService.IcsGetBFSCicAsync(IcsGetBFSCicRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsGetBFSCicRequest, IcsGetBFSCicReply>(request, "获取随附单证")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion

        #region 2.8	发送随附单证 TransferBFSCic
        /// <summary>
        /// 2.8	发送随附单证 TransferBFSCic
        /// </summary>
        async public Task<TransferBFSCicReply> TransferBFSCicAsync(TransferBFSCicRequest request)
        {
            var replay = await ((IIcsDeclareService)this)
                .IcsTransferBFSCicAsync(_mapper.Map<IcsTransferBFSCicRequest>(request))
                .ConfigureAwait(false);
            return new TransferBFSCicReply
            {
                Success = replay.State == Enums.Internal.IcsReplyStatus.Succeed,
                Message = replay.ErrorMessage ?? replay.Message,
            };
        }

        async Task<IcsTransferBFSCicReply> IIcsDeclareService.IcsTransferBFSCicAsync(IcsTransferBFSCicRequest request)
        {
            var reply = await icsRequestService
                .RequestAsync<IcsTransferBFSCicRequest, IcsTransferBFSCicReply>(request, "发送随附单证")
                .ConfigureAwait(false);
            return reply;
        }
        #endregion
    }
}
