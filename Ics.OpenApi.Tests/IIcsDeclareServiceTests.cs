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
        private readonly IIcsDeclareService icsDeclareService;

        public IIcsDeclareServiceTests()
        {
            icsDeclareService = ServiceProvider.Value.GetRequiredService<IIcsDeclareService>();
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
    }
}
