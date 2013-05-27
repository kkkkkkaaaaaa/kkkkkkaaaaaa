using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
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
            var membership = default(Membership);
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Create();

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, });
                membership.Users.Add(user.ID);
                membership.Create();
                membership.Find();

                user.Find();

                Assert.Equal(membership.ID, user.MembershipID);
                Assert.Contains(user.ID, membership.Users);
            }
            finally
            {
                if (user != null) { user.Delete(); }
                if (membership != null) { membership.Delete(); }
            }
        }
    }
}