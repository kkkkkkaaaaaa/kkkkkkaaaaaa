using System.Data;
using System.Data.Common;
using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class MembershipUsersFacts : KandaXunitDomainModelFacts
    {
        [Fact()]
        public void CreateFact()
        {
            var connection = default(DbConnection);
            var transaction = default(DbTransaction);
            var membership = default(Membership);

            try
            {
                connection = this._factory.CreateConnection();
                connection.Open();

                /*
                transaction = connection.BeginTransaction(IsolationLevel.Serializable);

                var user = new User(new UserEntity()
                {
                    FamilyName = @"CreateFactFamilyName",
                    GivenName = @"CreateFactGivenName",
                    AdditionalName = @"CreateFactAdditionalName",
                    Description = @"CreateFactDescription",
                }).Create();

                membership = new Membership(new MembershipEntity() { Name = @"CreateFactName", Password = @"CreateFactPassword", }).Create();
                membership.Users.Add(user);
                membership.Update();
                */

                Assert.True(0 < membership.Find().ID);
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
                if (transaction != null) { transaction.Rollback(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}