using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class UserHistoryFacts : KandaDomainModelFacts
    {
        [Fact()]
        public void CreateFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity(){ });
                user.Create();

                Assert.True(0 < user.ID);
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

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

                Assert.True(0 < user.ID);
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        [Fact()]
        public void DeleteFact()
        {
            var user = new User(new UserEntity() {});
            user.Found += (sender, e) => Assert.False(0 < e.ID);

            user.Create();
            user.Delete();
            user.Find();

            Assert.False(0 < user.ID);
        }
    }
}