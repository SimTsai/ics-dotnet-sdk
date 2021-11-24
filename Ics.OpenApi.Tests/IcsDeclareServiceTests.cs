#if NETFRAMEWORK
using System.Threading.Tasks;
using Ics.OpenApi.Implements;
using Ics.OpenApi.Interfaces;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IcsDeclareServiceTests : TestBase.LegacyConfigTestBase
    {
        private readonly IIcsDeclareService icsDeclareService;

        public IcsDeclareServiceTests()
        {
            var serviceFactory = IcsServiceFactory.CreateIcsService(IcsOptions);
            icsDeclareService = serviceFactory.IcsDeclareService;
        }

        [Fact]
        async public Task GetDelegateAsyncTest()
        {
            var reply = await icsDeclareService
                .GetDelegateAsync(new Models.Declare.GetDelegateRequest
                {
                    BusinessSerial = "2021112300006"
                })
                .ConfigureAwait(false);
            Assert.NotNull(reply);
        }
    }
}
#endif
