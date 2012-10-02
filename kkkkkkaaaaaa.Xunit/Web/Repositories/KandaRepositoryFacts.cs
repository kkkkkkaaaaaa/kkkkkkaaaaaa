using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.Repositories;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class KandaRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void GetUtcDateTimeFact()
        {
            var connection = default(DbConnection);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                var result = KandaRepository.GetUtcDateTime(connection);
                Assert.True(default(DateTime) < result);

            }
            finally
            {
                if (connection != null) { connection.Close(); }
            }
        }
    }
}