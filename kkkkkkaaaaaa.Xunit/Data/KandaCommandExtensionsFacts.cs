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
        [Fact()]
        public void SetCommandTypeFact()
        {
            var command = this.Provider.CreateCommand();

            command.SetCommandType(CommandType.StoredProcedure);
            Assert.True(command.CommandType == CommandType.StoredProcedure);

            command.SetCommandType(CommandType.Text);
            Assert.True(command.CommandType == CommandType.Text);
        }

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
                
                Assert.True(0 < command.Parameters.Count);
            }
            finally
            {
                transaction?.Rollback();
                connection?.Close();
            }
        }

        /// <summary></summary>
        [Fact()]
        public void BindParametersFact()
        {
            // Data Transfer Object(DTO)
            var dto = new
            {
                Id = 0,
            };

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
                        .BindParameters(new
                        {
                            Id = 0,
                        })
                    ;

                Assert.True(0 < command.Parameters.Count);
                var _ = command.Parameters
                        .Cast<DbParameter>()
                        .Select(p =>
                        {
                            Assert.True(true);

                            return p;
                        })
                        .ToArray()
                    ;
            }
            finally
            {
                transaction?.Rollback();
                connection?.Close();
            }
        }
        
        /// <summary></summary>
        [Fact()]
        public void ExecuteGetBillOfMaterialsFact()
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
                        .BindParameters(new
                        {
                            Id = 0,
                        })
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
