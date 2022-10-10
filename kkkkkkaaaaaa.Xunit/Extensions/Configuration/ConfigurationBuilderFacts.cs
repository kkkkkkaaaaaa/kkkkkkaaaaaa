using Microsoft.Extensions.Configuration;
using System.Reflection;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Extensions.Configuration
{
    /// <summary></summary>
    public class ConfigurationBuilderFacts
    {

        /// <summary></summary>
        [Fact()]
        public void Fact()
        {
            var path = Directory.GetParent(
                    Assembly.GetEntryAssembly().Location
                ).FullName;

            Assert.True(Directory.Exists(path));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(@"appSettings.2022.json")
                ;
            Assert.NotNull(builder);

            var root = builder.Build();
            Assert.NotNull(root);

            var s = root[@"connectionStrings"];
            Assert.Null(s);

            var d = root[@"connectionStrings:DefaultConnection"];
            Assert.NotNull(d);
        }
    }
}
