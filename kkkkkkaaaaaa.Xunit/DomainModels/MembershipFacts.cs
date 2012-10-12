using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipFacts
    {
        [Fact()]
        public void FindByIDFact()
        {
            var membership = default(Membership);

            try
            {
                membership = new Membership(new MembershipEntity() { Name = @"", Password = @"", Enabled = true, });
                membership.Create();
                Assert.True(0 < membership.ID);

                MembershipEntity found;
                Assert.True(0 < membership.Find(out found).ID);
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void FindByNameAndPasswordFact()
        {
            var membership = default(Membership);

            try
            {
                membership = new Membership(new MembershipEntity() { Name = @"name", Password = @"pppp", Enabled = true, });
                membership.Create();
                Assert.True(0 < membership.ID);

                membership = new Membership(new MembershipEntity() { Name = @"name", Password = @"pppp", Enabled = true, });
                MembershipEntity found;
                membership.Find(out found);
                Assert.True(0 < membership.ID);
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void ValidateFact()
        {
            //
        }

        [Fact()]
        public void CreateFact()
        {
            var membership = default(Membership);

            try
            {
                membership = new Membership(new MembershipEntity() { Name = @"name", Password = @"password", Enabled = true, });
                membership.Users.Add(new User(new UserEntity() { FamilyName = @"MembershipFacts", GivenName = @"1" }));
                membership.Users.Add(new User(new UserEntity() { FamilyName = @"MembershipFacts", GivenName = @"2" }));

                membership.Create();

                Assert.True(0 < membership.ID);
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void DeleteFact()
        {
            var membership = new Membership(new MembershipEntity() { Name = @"name", Password = @"password", Enabled = true, }).Create();
            membership = membership.Delete();
            Assert.False(0 < membership.ID);
        }
    }
}