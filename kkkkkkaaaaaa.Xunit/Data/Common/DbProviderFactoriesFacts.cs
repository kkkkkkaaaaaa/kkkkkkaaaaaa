using System.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DbProviderFactoriesFacts : KandaXunitFacts
    {
        /// <summary></summary>
        [Fact()]
        public void GetFactoryClasses()
        {
            var classes = DbProviderFactories.GetFactoryClasses();
            Assert.NotNull(classes);
        }
    }
}