using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data.Common;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaDataRecordExtensionsFacts : KandaXunitFacts
    {
        private KandaDbDataReader getReader(DbConnection connection, string statement)
        {
            var reader = this.Provider.CreateReader(connection);
            reader.CommandType = CommandType.Text;
            reader.CommandText = statement;

            return reader;
        }

        /// <summary></summary>
        [Fact()]
        public void GetInt32Fact()
        {
            var connection = default(DbConnection);
            var reader = default(KandaDbDataReader);

            try
            {
                connection = this.Provider.CreateConnection();
                reader = this.getReader(connection, @"SELECT 1 AS I");
                connection.Open();

                reader.ExecuteReader();
                if (reader.Read())
                {
                    var o = reader.GetInt32(0);
                    Assert.True(o == 1);

                    var n = reader.GetInt32("I");
                    Assert.True(n == 1);

                }
                else { Assert.False(true); }
            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }

        /// <summary></summary>
        [Fact()]
        public void GetStringFact()
        {
            var connection = default(DbConnection);
            var reader = default(KandaDbDataReader);

            try
            {
                connection = this.Provider.CreateConnection();
                reader = this.getReader(connection, @"SELECT N's' AS S");
                connection.Open();

                reader.ExecuteReader();
                if (reader.Read())
                {
                    var o = reader.GetString(0);
                    Assert.True(o == @"s");

                    var n = reader.GetString("S");
                    Assert.True(n == @"s");

                }
                else { Assert.False(true); }
            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }
    }
}