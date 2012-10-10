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
                membership = new Membership(new MembershipEntity() { Name = @"", Password = @"", Enabled = true });
                membership.Create();
                Assert.True(membership.Exists);

                MembershipEntity found;
                Assert.True(membership.Find(out found).Exists);
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
                Assert.True(membership.Exists);

                membership = new Membership(new MembershipEntity() { Name = @"name", Password = @"pppp", Enabled = true, });
                MembershipEntity found;
                membership.Find(out found);
                Assert.True(membership.Exists);
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
                membership.Create();
                Assert.True(membership.Exists);
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
            Assert.False(membership.Exists);
        }
    }
}