using System;
using System.Data;
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
            var reader = default (KandaDbDataReader);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                reader = this._factory.CreateReader(connection);

                var result = this._factory.CreateParameter(@"ReturnValue", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
                reader.Parameters.Add(result);

                reader.CommandText = @"usp_StoredProcedure";

                Assert.True(reader.ExecuteReader().HasRows);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}