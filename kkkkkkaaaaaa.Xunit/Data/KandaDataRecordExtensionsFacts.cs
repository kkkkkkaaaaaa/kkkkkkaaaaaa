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
        [Fact()]
        public void GetInt32Fact()
        {
            var connection = default(DbConnection);
            var reader = default(KandaDbDataReader);

            try
            {
                connection = this.Provider.CreateConnection();

                reader = this.Provider.CreateReader(connection);
                reader.CommandType = CommandType.Text;
                reader.CommandText = @"
SELECT
    1   AS I
";
                
                connection.Open();
                reader.ExecuteReader();

                if (reader.Read())
                {
                    var o = reader.GetInt32(0);
                    Assert.True(o == 1);

                    var n = reader.GetInt32("I");
                    Assert.True(n == 1);

                }
                else { Assert.True(true); }
            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }
        }
    }
}