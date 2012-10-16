using System;
using System.Globalization;
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
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", Enabled = true, });
                membership.Found += (sender, e) => Assert.True(0 < e.ID);

                membership.Users.Add(new User(new UserEntity() { GivenName = name }).Create().ID);
                membership.Roles.Add(new Role(new RoleEntity() { Name = name, }).Create().ID);
                membership.Authorizations.Add(new Authorization(new AuthorizationEntity() { Name = name, }).Create().ID);

                membership.Create();
                Assert.True(0 < membership.ID);

                membership.Find();
                Assert.True(0 < membership.Find().ID);
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
                Assert.True(0 < membership.Find().ID);
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
                //membership.Users.Add(new User(new UserEntity() { FamilyName = @"MembershipFacts", GivenName = @"1" }));
                //membership.Users.Add(new User(new UserEntity() { FamilyName = @"MembershipFacts", GivenName = @"2" }));

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