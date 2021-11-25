using System.Threading.Tasks;
using Ics.OpenApi.Interfaces;
using Ics.OpenApi.Interfaces.Internal;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ics.OpenApi.Tests
{
    public class IIcsUserServiceTests : TestBase.DITestBase
    {
        private readonly IIcsUserService icsUserService;
        public IIcsUserServiceTests()
        {
            icsUserService = ServiceProvider.Value.GetRequiredService<IIcsUserService>();
        }

        [Fact]
        async public Task GetTokenAsyncTest()
        {
            var token = await icsUserService.GetTokenAsync(new Models.Internal.User.IcsGetTokenRequest
            {
                userName = "",
                pwd = ""
            }).ConfigureAwait(false);
            Assert.NotNull(token);
        }
    }
}
