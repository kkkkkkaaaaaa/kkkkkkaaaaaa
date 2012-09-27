using System;
using System.Data;
using System.Data.Common;
using Xunit;
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
                
                command.Parameters.Add(this._factory.CreateParameter("@id", 1));
                command.Parameters.Add(this._factory.CreateParameter("@name", @"neme"));
                command.Parameters.Add(this._factory.CreateParameter("@password", @"password"));
                command.Parameters.Add(this._factory.CreateParameter("@enabled", true));
                command.Parameters.Add(this._factory.CreateParameter("@createdOn", DateTime.Now));

                var result = this._factory.CreateParameter("@result", DBNull.Value, ParameterDirection.ReturnValue);
                command.Parameters.Add(result);

                var affected = command.ExecuteNonQuery();
                Assert.Equal(0, result.Value);
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

                command.CommandText = @"usp_UpdateMemberships";

                command.Parameters.Add(this._factory.CreateParameter("@id", 1));
                command.Parameters.Add(this._factory.CreateParameter("@name", @"neme"));
                command.Parameters.Add(this._factory.CreateParameter("@password", @"password"));
                command.Parameters.Add(this._factory.CreateParameter("@enabled", true));
                command.Parameters.Add(this._factory.CreateParameter("@createdOn", DateTime.Now));

                var result = this._factory.CreateParameter("@result", DBNull.Value, ParameterDirection.ReturnValue);
                command.Parameters.Add(result);

                var affected = command.ExecuteNonQuery();
                Assert.Equal(0, result.Value);
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