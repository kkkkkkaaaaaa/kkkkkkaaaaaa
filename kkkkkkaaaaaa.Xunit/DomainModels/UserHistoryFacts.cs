using System.Linq;
using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class UserHistoryFacts : KandaDomainModelFacts
    {
        [Fact()]
        public void FindFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Found += (sender, e) => Assert.True(user.Histories.Any());
                user.Create();
                user.Find();
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Create();
                user.Find();

                Assert.True(user.Histories.Any());
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