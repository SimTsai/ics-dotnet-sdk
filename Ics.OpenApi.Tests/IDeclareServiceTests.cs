
using System;
using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IIcsDeclareServiceTests : TestBase.DITestBase
    {
        private readonly IDeclareService declareService;

        public IIcsDeclareServiceTests()
        {
            declareService = ServiceProvider.Value.GetRequiredService<IDeclareService>();
        }

        async Task<TDemoData> GetDemoDataAsync<TDemoData>(string name)
        {
            using var json_fs = System.IO.File.OpenRead(System.IO.Path.Combine(".", "Demo", name));
            var jso = new System.Text.Json.JsonSerializerOptions();
            jso.PropertyNameCaseInsensitive = true;
            jso.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
            jso.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
            jso.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            var demoData = await System.Text.Json.JsonSerializer.DeserializeAsync<TDemoData>(json_fs, jso);
            return demoData;
        }

        [Fact]
        async public Task GetDelegateAsyncTest()
        {
            var delegates = await declareService
                .GetDelegateAsync(new Models.Declare.GetDelegateRequest
                {
                    BusinessSerial = "2021112300006"
                })
                .ConfigureAwait(false);
            Assert.NotNull(delegates);
        }

        [Fact]
        async public Task TransferDelegateAsyncTest()
        {
            var request = await GetDemoDataAsync<Models.Declare.TransferDelegateRequest>("TransferDelegate.json");
            var reply = await declareService
                .TransferDelegateAsync(request)
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }

        [Fact]
        async public Task TransferStatusAsyncTest()
        {
            var reply = await declareService
                .TransferStatusAsync(new Models.Declare.TransferStatusRequest
                {
                    BusinessSerial = "2021112300006",
                    StatusTime = DateTime.Now,
                    Status = Models.Declare.TransferStatus.FirstAuditComplete
                })
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }

        [Fact]
        async public Task GetDelegateBoxAsyncTest()
        {
            var reply = await declareService
                .GetDelegateBoxAsync(new Models.Declare.GetDelegateBoxRequest
                {
                    BusinessSerial = "2021112300006"
                })
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }

        [Fact]
        async public Task TransferDelegateBoxAsyncTest()
        {
            var request = await GetDemoDataAsync<Models.Declare.TransferDelegateBoxRequest>("TransferDelegateBox.json");
            var reply = await declareService
                .TransferDelegateBoxAsync(request)
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }

        [Fact]
        async public Task GetBFSCicAsyncTest()
        {
            var reply = await declareService
                .GetBFSCicAsync(new Models.Declare.GetBFSCicRequest
                {
                    BusinessSerial = "2021112300006"
                })
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }

        [Fact]
        async public Task TransferBFSCicAsyncTest()
        {
            var request = await GetDemoDataAsync<Models.Declare.TransferBFSCicRequest>("TransferBFSCic.json");
            var reply = await declareService
                .TransferBFSCicAsync(request)
                .ConfigureAwait(false);
            Assert.NotNull(reply);
            Assert.True(reply.Success);
        }
    }
}
