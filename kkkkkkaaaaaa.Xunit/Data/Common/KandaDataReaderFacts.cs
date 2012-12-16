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
            var reader = default(KandaDbDataReader);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                reader = this._factory.CreateReader(connection);

                reader.CommandText = @"usp_StoredProcedure";

                reader.ExecuteReader();
                Assert.True(true);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void GetSchemaTableFact()
        {
            var connection = default(DbConnection);
            var reader = default(KandaDbDataReader);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                reader = this._factory.CreateReader(connection);

                reader.CommandText = @"usp_StoredProcedure";

                reader.ExecuteReader();

                var schema = reader.GetSchemaTable();
                Assert.NotNull(schema);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}