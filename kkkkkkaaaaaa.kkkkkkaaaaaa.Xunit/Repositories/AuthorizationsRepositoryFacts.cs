using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    public class AuthorizationsRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void DeleteFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new AuthorizationsRepository();
                //repository.Create(new AuthorizationEntity() { ID = -1, Name = "aa", CreatedOn = DateTime.Now, }, connection, transaction);
                //repository.Create(new AuthorizationEntity() { ID = -2, Name = "aa", CreatedOn = DateTime.Now, }, connection, transaction);
                repository.Delete(connection, transaction);
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}