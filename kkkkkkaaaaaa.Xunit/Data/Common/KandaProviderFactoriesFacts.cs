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
            var classes = KandaProviderFactories.GetFactoryClasses();

            Assert.True(classes.Rows.Count > 0);
        }

        [Fact()]
        public void GetFactoryByClassFact()
        {
            var classes = KandaProviderFactories.GetFactoryClasses();

            foreach (DataRow c in classes.Rows)
            {
                var factory = KandaProviderFactories.GetFactory(c);
                Assert.True(factory is KandaProviderFactory);
            }
        }

        [Fact()]
        public void GetFactoryByClassThrowsExceptionFact()
        {
            var factory = default(DbProviderFactory);
            var classes = KandaProviderFactories.GetFactoryClasses();

            Assert.Throws<ArgumentNullException>(() => { factory = KandaProviderFactories.GetFactory(default(DataRow)); });
            Assert.Throws<ConfigurationErrorsException>(() => { factory = KandaProviderFactories.GetFactory(classes.NewRow()); });
            Assert.Throws<ConfigurationErrorsException>(() => { factory = KandaProviderFactories.GetFactory(new DataTable().NewRow()); });
            Assert.True(factory == default(DbProviderFactory));
        }

        [Fact()]
        public void GetFactoryByNameFact()
        {
            const string NAME = @"System.Data.SqlClient";
            var factory = KandaProviderFactories.GetFactory(NAME);

            Assert.True(factory is KandaProviderFactory);
        }

        [Fact()]
        public void GetFactoryByNameThrowsExceptionFact()
        {
            Assert.Throws<ArgumentNullException>(() => { var factory = KandaProviderFactories.GetFactory(default(DataRow)); });
            Assert.Throws<ArgumentException>(() => { var factory = KandaProviderFactories.GetFactory(@"Not exist provider name."); });
        }
    }
}
