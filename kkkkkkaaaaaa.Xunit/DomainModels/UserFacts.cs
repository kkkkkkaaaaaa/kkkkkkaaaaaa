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
    public class UserFacts
    {
        /// <summary>
        /// 
        /// </summary>
        [Fact()]
        public void FindFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Found += (sender, e) => Assert.True(0 < e.ID);

                user.Create();
                user.Find();
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact()]
        public void CreateFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity() { FamilyName = @"", GivenName = @"", AdditionalName = @"", Enabled = true, });
                user.Found += (sender, e) => Assert.True(0 < e.ID);

                user = user.Create();
                user.Find();
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact()]
        public void UpdateFact()
        {
            var created = default(User);

            try
            {
                var familyName = new Random().Next().ToString(CultureInfo.InvariantCulture);

                created = new User(new UserEntity() { FamilyName = familyName, });
                created.Create();
                Assert.True(0 < created.ID);

                var updated = new User(new UserEntity() {ID = created.ID});
                updated.Found += (sernder, e) => Assert.True(new DateTime() < e.UpdateOn);
                updated.Update();
                updated.Find();

                Assert.Equal(created.ID, updated.ID);

            }
            finally
            {
                if (created != null) { created.Delete(); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact()]
        public void DeleteFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Found += (sender, e) => Assert.True(e.ID == 0);

                user = user.Create();
                user = user.Delete();
                user.Find();
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }
    }
}