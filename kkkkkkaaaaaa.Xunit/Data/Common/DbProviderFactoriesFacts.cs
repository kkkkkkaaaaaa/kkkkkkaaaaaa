﻿using System.Data.Common;
using System.Data.SqlClient;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class DbProviderFactoriesFacts : KandaXunitFacts
    {
        [Fact()]
        public void GetProvidersFact()
        {
            var classes = DbProviderFactories.GetFactoryClasses();
            Assert.NotNull(classes);
        }
    }
}