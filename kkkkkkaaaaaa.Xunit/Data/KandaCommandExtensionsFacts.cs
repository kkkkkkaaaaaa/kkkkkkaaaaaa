using System.Data;
using System.Data.Common;
using kkkkkkaaaaaa.Data;
using Xunit;

namespace kkkkkkaaaaaa.Xunit.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class KandaCommandExtensionsFacts : KandaXunitFacts
    {
        /// <summary></summary>
        [Fact()]
        public void DeriveParametersFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this.Provider.CreateConnection();
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var command = this.Provider.CreateCommand(connection, transaction)
                        .SetCommandType(CommandType.StoredProcedure)
                        .SetCommandText(@"uspGetBillOfMaterials")
                        .DeriveParameters()
                    ;
                
                Assert.True(true);
            }
            finally
            {
                transaction?.Rollback();
                connection?.Close();
            }
        }

        /// <summary></summary>
        [Fact()]
        public void ExecuteStoredProcedureFact()
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
                        .SetCommandType(CommandType.StoredProcedure)
                        .SetCommandText(@"uspGetBillOfMaterials")
                        .DeriveParameters()
                    // .MapToParmeters(dto)
                    ;
                Assert.True(true);

                // var reader = command.ExecuteReader()
                //    .AsObjectEnumerable<>();

                // var affected = command.ExecuteNonQuery()
            }
            finally
            {
                reader?.Close();
                transaction?.Rollback();
                connection?.Close();
            }
        }
    }
}
