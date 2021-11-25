﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IIcsDeclareServiceTests : TestBase.DITestBase
    {
        private readonly IDeclareService icsDeclareService;

        public IIcsDeclareServiceTests()
        {
            icsDeclareService = ServiceProvider.Value.GetRequiredService<IDeclareService>();
        }

        [Fact]
        async public Task GetDelegateAsyncTest()
        {
            var delegates = await icsDeclareService
                .GetDelegateAsync(new Models.Declare.GetDelegateRequest
                {
                    BusinessSerial = "2021112300006"
                })
                .ConfigureAwait(false);
            Assert.NotNull(delegates);
        }

        //[Fact]
        //async public Task TransferDelegateAsyncTest()
        //{
        //    using var json_fs = System.IO.File.OpenRead(System.IO.Path.Combine(".", "Demo", "TransferDelegate.json"));
        //    var request = await System.Text.Json.JsonSerializer.DeserializeAsync<Models.Declare.TransferDelegateRequest>(json_fs);
        //    var reply = await icsDeclareService
        //        .TransferDelegateAsync(request)
        //        .ConfigureAwait(false);
        //    Assert.NotNull(reply);
        //    Assert.True(reply.Success);
        //}
    }
}