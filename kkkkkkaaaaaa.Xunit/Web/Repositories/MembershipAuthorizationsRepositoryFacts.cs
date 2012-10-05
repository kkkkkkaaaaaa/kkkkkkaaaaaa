using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipAuthorizationsRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact()]
        public void GetFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipAuthorizationsRepository();

                var id = long.MaxValue;
                Assert.NotNull(repository.Get(new MembershipAuthorizationEntity() { ID = id, MembershipID = 1, AuthorizationID = 1, Enabled = true, }, connection, transaction));
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

                var repository = new MembershipAuthorizationsRepository();

                var id = int.MaxValue;
                Assert.True(repository.Create(new MembershipAuthorizationEntity() { ID = id, MembershipID = 1, AuthorizationID = 1, Enabled = true, }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void UpdateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipAuthorizationsRepository();

                var id = int.MaxValue;
                Assert.True(repository.Create(new MembershipAuthorizationEntity() { ID = id, MembershipID = 1, AuthorizationID = 1, Enabled = true, }, connection, transaction));

                Assert.True(repository.Update(new MembershipAuthorizationEntity() { ID = id, MembershipID = 1, AuthorizationID = 1, Enabled = false, }, connection, transaction));
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

                var repository = new MembershipAuthorizationsRepository();
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