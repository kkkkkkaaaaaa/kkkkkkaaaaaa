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
                user = user.Create();

                Assert.True(user.Exists);
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
                user = user.Create();

                Assert.True(user.Exists);
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
                user = user.Create();

                user = user.Delete();
                Assert.False(user.Exists);
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }
    }
}