using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using Xunit;
using kkkkkkaaaaaa.Web.DataTransferObjects;
using kkkkkkaaaaaa.Web.Repositories;

namespace kkkkkkaaaaaa.Xunit.Web.Repositories
{
    public class MembershipRolesRepositoryFacts : KandaXunitRepositoryFacts
    {
        [Fact(Skip = @"Not implemented.")]
        public void SearchFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                //var repository = new
                //Assert.NotNull(repository.Search(, connection, transaction))
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

                var repository = new MembershipRolesRepository();

                var id = long.MaxValue;
                Assert.True(repository.Create(new MembershipRoleEntity(){ ID = id, MembershipID = 1, RoleID = 1, Enabled = true, }, connection, transaction));
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

                var repository = new MembershipRolesRepository();

                var id = long.MaxValue;
                Assert.True(repository.Create(new MembershipRoleEntity() { ID = id, MembershipID = 1, RoleID = 1, Enabled = true, }, connection, transaction));
                Assert.True(repository.Update(new MembershipRoleEntity(){ ID = id, MembershipID = 2, RoleID = 2, Enabled = false, }, connection, transaction));
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

                var repository = new MembershipRolesRepository();

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