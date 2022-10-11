using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    public class KandaCommandExtensionsFacts : KandaXunitFacts
    {
        [Fact()]
        public void Fact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);
            var reader = default(DbDataReader);
            try
            {
                connection = this.Provider.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var command = this.Provider.CreateCommand(connection, transaction)
                        // .SetCommadType(CommandType.StoredProcedure)
                        .SetCommandText(@"uspGetBillOfMaterials")
                        .DeriveParameters()
                        // .MapToParmeters(dto)
                    ;

                // var reader = command.ExecuteReader()
                //    .AsObjectEnumerable<>();

                // var affected = command.ExecuteNonQuery()
            }
            finally
            {
                reader.Close();
                transaction?.Rollback();
                connection?.Close();
            }
        }
    }
}
