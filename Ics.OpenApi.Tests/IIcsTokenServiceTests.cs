using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IIcsTokenServiceTests : TestBase.DITestBase
    {
        private readonly IIcsTokenService tokenService;
        public IIcsTokenServiceTests()
        {
            tokenService = ServiceProvider.Value.GetRequiredService<IIcsTokenService>();
        }

        [Fact]
        async public Task GetTokenAsyncTest()
        {
            var token = await tokenService.GetTokenAsync().ConfigureAwait(false);
            Assert.NotNull(token);
        }
    }
}
