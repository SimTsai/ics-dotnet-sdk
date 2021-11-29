using System.Configuration;
using Ics.OpenApi.ConfigurationSection;
using Ics.OpenApi.Options;
using Microsoft.Extensions.Options;

namespace Ics.OpenApi.Tests.TestBase
{
    public class LegacyConfigTestBase
    {
        protected IOptions<IcsOptions> IcsOptions { get; init; }

        public LegacyConfigTestBase()
        {
            var section = ConfigurationManager.GetSection(IcsConfigurationSection.DefaultConfigurationSectionName);
            if (section is IcsConfigurationSection iscConfigurationSection)
            {
                IcsOptions = iscConfigurationSection.ToOptionsWrapper();
            }
        }
    }
}
