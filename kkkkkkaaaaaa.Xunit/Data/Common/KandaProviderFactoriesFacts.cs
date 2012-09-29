using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaProviderFactoriesFacts
    {
        [Fact()]
        public void GetFactoryClassesFact()
        {
            var classes = KandaDbProviderFactories.GetFactoryClasses();

            Assert.True(classes.Rows.Count > 0);
        }

        [Fact()]
        public void GetFactoryByClassFact()
        {
            var classes = KandaDbProviderFactories.GetFactoryClasses();

            foreach (DataRow c in classes.Rows)
            {
                var factory = KandaDbProviderFactories.GetFactory(c);
                Assert.True(factory is KandaDbProviderFactory);
            }
        }

        [Fact()]
        public void GetFactoryByClassThrowsExceptionFact()
        {
            var factory = default(DbProviderFactory);
            var classes = KandaDbProviderFactories.GetFactoryClasses();

            Assert.Throws<ArgumentNullException>(() => { factory = KandaDbProviderFactories.GetFactory(default(DataRow)); });
            Assert.Throws<ConfigurationErrorsException>(() => { factory = KandaDbProviderFactories.GetFactory(classes.NewRow()); });
            Assert.Throws<ConfigurationErrorsException>(() => { factory = KandaDbProviderFactories.GetFactory(new DataTable().NewRow()); });
            Assert.True(factory == default(DbProviderFactory));
        }

        [Fact()]
        public void GetFactoryByNameFact()
        {
            const string NAME = @"System.Data.SqlClient";
            var factory = KandaDbProviderFactories.GetFactory(NAME);

            Assert.True(factory is KandaDbProviderFactory);
        }

        [Fact()]
        public void GetFactoryByNameThrowsExceptionFact()
        {
            Assert.Throws<ArgumentNullException>(() => { var factory = KandaDbProviderFactories.GetFactory(default(DataRow)); });
            Assert.Throws<ArgumentException>(() => { var factory = KandaDbProviderFactories.GetFactory(@"Not exist provider name."); });
        }
    }
}
