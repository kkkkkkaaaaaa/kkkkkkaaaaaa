using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.Data.Repositories;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipUsersRepositoryFacts : KandaXunitRepositoryFacts
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

                var repository = new MembershipUsersRepository();

                var membershipId = long.MaxValue;
                var userId = long.MaxValue;
                if (!repository.Create(new MembershipUserEntity() { MembershipID = membershipId, UserID = userId, }, connection, transaction)) { Assert.True(false); }
                else
                {
                    /*
                    var gotten = repository.Get(new MembershipUsersCriteria() { MembershipID = membershipId, }, connection, transaction);
                    foreach (var entity in gotten)
                    {
                        var user = new User(new UserEntity() { ID = entity.UserID, });

                        var found = default(UserEntity);
                        user.Find(out found);
                        Assert.True(0 < found.ID);
                    }
                    */
                }
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

                var repository = new MembershipUsersRepository();

                long membershipId = long.MaxValue;
                long userId = long.MaxValue;
                Assert.True(repository.Create(new MembershipUserEntity() { MembershipID = membershipId, UserID = userId, }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

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

                var repository = new MembershipUsersRepository();

                long membershipId = long.MaxValue;
                long userId = long.MaxValue;
                if (!repository.Create(new MembershipUserEntity() { MembershipID = membershipId, UserID = userId, }, connection, transaction)) { Assert.True(false); }

                Assert.True(repository.Delete(new MembershipUsersCriteria() { MembershipID = membershipId, }, connection, transaction));
                //Assert.True(repository.Delete(new MembershipUserEntity() { MembershipID = membershipId, UserID = userId, }, connection, transaction));
            }
            finally
            {
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void TrucnateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var repository = new MembershipUsersRepository();

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