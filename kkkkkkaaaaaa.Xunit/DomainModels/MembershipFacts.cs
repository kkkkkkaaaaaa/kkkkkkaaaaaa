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
        public void ExistsFact()
        {
            var membership = default(Membership);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", });
                membership.Create();

                Assert.True(Membership.Exists(name));
                Assert.True(membership.Exists());
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void FindByNameFact()
        {
            var membership = default(Membership);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", });
                membership.Found += (sender, e) =>
                                        {
                                            var actual = new Membership(new MembershipEntity() { Name = e.Name, Password = null, })
                                                    .Find();
                                            Assert.True(0 < actual.ID);
                                        };
                membership.Create();
                membership.Find();
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void FindByIDFact()
        {
            var membership = default(Membership);

            try
            {
                membership = new Membership(new MembershipEntity());

                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", });
                membership.Found += (sender, e) => Assert.NotEqual(MembershipEntity.Empty, e);
                membership.Create();
                Assert.True(0 < membership.ID);

                membership.Find();
                Assert.True(membership.Exists());
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
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                var password = new Random().Next().ToString(CultureInfo.InvariantCulture);
                new Membership(new MembershipEntity() { Name = name, Password = password, }).Create();

                membership = new Membership(new MembershipEntity() { Name = name, Password = password, });
                membership.Found += (sender, e) => Assert.NotEqual(MembershipEntity.Empty, e);
                membership.Find();
                Assert.True(membership.Exists());
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var membership = default(Membership);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", });
                membership.Found += (_, __) =>
                                        {
                                            Assert.Equal(membership.ID, __.ID);
                                        };
                membership.Create();
                Assert.True(0 < membership.ID);

                Assert.True(membership.Exists());
                membership.Find();
            }
            finally
            {
                if (membership != null) { membership.Delete(); }
            }
        }

        [Fact()]
        public void UpdateFact()
        {
            var membership = default(Membership);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                membership = new Membership(new MembershipEntity() { Name = name, Password = @"", })
                    .Create();
                membership.Found += (sender, e) =>
                                        {
                                            e.Enabled = false;
                                            var updated = new Membership(e);
                                            updated.Found += (_, __) => Assert.False(__.Enabled);
                                            updated.Update();
                                            updated.Find();
                                        };
                membership.Find();
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