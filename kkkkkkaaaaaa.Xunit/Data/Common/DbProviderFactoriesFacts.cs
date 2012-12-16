using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class DbProviderFactoriesFacts
    {
        [Fact()]
        public void GetProvidersFact()
        {
            var classes = DbProviderFactories.GetFactoryClasses();
            Assert.NotNull(classes);
        }
    }
}