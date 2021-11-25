using System;
using System.Net.Http;
using AutoMapper;
using AutoMapper.Configuration;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Implements.Internal
{
    internal class IcsService : IIcsService
    {
        private readonly IOptions<IcsOptions> icsOptions;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IIcsHttpClient icsHttpClient;
        private readonly IIcsCacheProviderFactory icsCacheProviderFactory;
        private readonly ITokenStorageService icsTokenStorageService;
        private readonly IIcsRequestService icsRequestService;
        private readonly IIcsUserService icsUserService;
        private readonly IMapper mapper;

        public IcsService(
            IOptions<IcsOptions> icsOptions,
            ITokenStorageService customsIcsTokenStorageService = null
            )
        {
            this.icsOptions = icsOptions;
            this.httpClientFactory = new IcsHttpClientFactory();
            this.icsHttpClient = new IcsHttpClient(httpClientFactory, icsOptions);
            if (icsOptions.Value.TokenStorageIn == Enums.IcsTokenStorageType.Custom)
            {
                if (customsIcsTokenStorageService is null)
                {
                    throw new ArgumentException("未指定自定义Token存储服务 IIcsTokenStorageService");
                }
                else
                {
                    this.icsTokenStorageService = customsIcsTokenStorageService;
                }
            }
            else
            {
                this.icsCacheProviderFactory = new IcsCacheProviderFactory(icsOptions);
                this.icsTokenStorageService = new IcsTokenStorageService(icsCacheProviderFactory, icsOptions);
            }

            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddMaps(this.GetType().Assembly);
            var mapperConfiguration = new MapperConfiguration(mapperConfigurationExpression);
            this.mapper = mapperConfiguration.CreateMapper();
            this.icsUserService = new IcsUserService(this.icsHttpClient, this.icsOptions);
            this.icsRequestService = new IcsRequestService(icsOptions, icsHttpClient, icsTokenStorageService, icsUserService);
        }

        public void Dispose()
        {
            icsHttpClient?.Dispose();
            icsTokenStorageService?.Dispose();
        }

        //public IIcsTokenService IcsTokenService => icsRequestService;

        private IDeclareService declareService;
        public IDeclareService DeclareService => declareService ??= new DeclareService(icsRequestService, mapper);
    }
}
