using System;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Xunit.Data.Common
{
    public class KandaDataReaderFacts : KandaXunitDataFacts
    {
        [Fact()]
        public void ExecuteReaderFact()
        {
            var connection = default(DbConnection);
            var reader = default (KandaDataReader);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                reader = this._factory.CreateReader(connection);

                reader.Parameters.Add(this._factory.CreateParameter("@id", 1L));
                reader.Parameters.Add(this._factory.CreateParameter(@"enabled", DBNull.Value));

                reader.CommandText = @"usp_SelectUsers";

                reader.ExecuteReader();

                Assert.True(reader.Read());
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}