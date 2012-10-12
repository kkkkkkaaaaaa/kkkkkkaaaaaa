using System;
using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;
using kkkkkkaaaaaa.Xunit.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class UserHistoriesRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void GetFact()
        {
            var connection = default(DbConnection);
            var transaction = default (DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new UserHistoriesRepository();

                var userId = long.MaxValue;
                Assert.NotNull(repository.Get(new UserHistoryEntity() { UserID = userId, }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var id = long.MaxValue;
                var createdOn = DateTime.MinValue;

                var users = new UsersRepository();
                Assert.True(users.Create(new UserEntity() { ID = id, CreatedOn = createdOn, }, connection, transaction));

                var histories = new UserHistoriesRepository();
                Assert.True(histories.Create(new UserHistoryEntity { UserID = 1, Revision = 1, CreatedOn = createdOn }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void TruncateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new UserHistoriesRepository();

                Assert.True(repository.Truncate(connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}
