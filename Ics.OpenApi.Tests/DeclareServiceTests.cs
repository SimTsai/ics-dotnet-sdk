#if NETFRAMEWORK
using System.Threading.Tasks;
using Ics.OpenApi.Implements;
using Ics.OpenApi.Interfaces;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IcsDeclareServiceTests : TestBase.LegacyConfigTestBase
    {
        private readonly IDeclareService declareService;

        public IcsDeclareServiceTests()
        {
            var serviceFactory = IcsServiceFactory.CreateIcsService(IcsOptions);
            declareService = serviceFactory.DeclareService;
        }

        [Fact]
        async public Task GetDelegateAsyncTest()
        {
            var reply = await declareService
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
