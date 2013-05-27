using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.Data.TableDataGateways;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.Xunit.Data;

namespace kkkkkkaaaaaa.Xunit.Database
{
    public class MembershipsFacts : KandaXunitDataFacts
    {
        [Fact()]
        public void InsertMembershipsFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);
            var command = default(DbCommand);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                command = this._factory.CreateCommand(connection, transaction);

                command.CommandText = @"usp_InsertMemberships";

                var entity = new MembershipEntity { Name = new Random().Next().ToString(), Password = @"sadasfsa", CreatedOn = DateTime.Now, Enabled = true, };

                KandaDbDataMapper.MapToParameters(command, entity);

                var identity = this._factory.CreateParameter("@identity", DbType.Decimal, sizeof(decimal), ParameterDirection.Output, DBNull.Value);
                command.Parameters.Add(identity);

                var result = this._factory.CreateParameter(KandaTableDataGateway.RETURN_VALUE, DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
                command.Parameters.Add(result);

                var affected = command.ExecuteNonQuery();
                Assert.Equal(KandaTableDataGateway.NO_ERRORS, result.Value);
                Assert.Equal(1, affected);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void UpdateMembershipsFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);
            var command = default(DbCommand);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                command = this._factory.CreateCommand(connection, transaction);
                command.CommandText = @"usp_InsertMemberships";
                command.Parameters.Add(this._factory.CreateParameter("@id", 1));
                command.Parameters.Add(this._factory.CreateParameter("@name", @"neme"));
                command.Parameters.Add(this._factory.CreateParameter("@password", @"password"));
                command.Parameters.Add(this._factory.CreateParameter("@enabled", true));
                command.Parameters.Add(this._factory.CreateParameter("@createdOn", DateTime.Now));
                command.Parameters.Add(this._factory.CreateParameter("@updatedOn", DBNull.Value));
                command.Parameters.Add(this._factory.CreateParameter("@identity", DbType.Decimal, sizeof(decimal), ParameterDirection.Output, DBNull.Value));
                command.ExecuteNonQuery();

                command = this._factory.CreateCommand(connection, transaction);
                command.CommandText = @"usp_UpdateMemberships";
                command.Parameters.Add(this._factory.CreateParameter("@id", 1));
                command.Parameters.Add(this._factory.CreateParameter("@name", @"neme"));
                command.Parameters.Add(this._factory.CreateParameter("@password", @"password"));
                command.Parameters.Add(this._factory.CreateParameter("@enabled", true));
                command.Parameters.Add(this._factory.CreateParameter("@createdOn", DBNull.Value));
                command.Parameters.Add(this._factory.CreateParameter("@updatedOn", DateTime.Now));
                var result = this._factory.CreateParameter("@result", DbType.Int32, sizeof(int), ParameterDirection.ReturnValue, DBNull.Value);
                command.Parameters.Add(result);

                var affected = command.ExecuteNonQuery();

                Assert.Equal(1, result.Value);
                Assert.Equal(1, affected);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        } 
    }
}