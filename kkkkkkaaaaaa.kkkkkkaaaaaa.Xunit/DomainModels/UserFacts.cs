using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class UserFacts
    {
        [Fact()]
        public void FindFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity() {  });
                user.Found += (sender, e) => Assert.Equal(sender.ID, e.ID);
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
        public void CreateFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Create();

                Assert.True(0 < user.ID);
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        [Fact()]
        public void UpdateFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Found += (sernder, e) => Assert.True(e.CreatedOn <= e.UpdatedOn);

                user.Create();
                user.Update();
                user.Find();

                Assert.Equal(user.ID, user.ID);

            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        [Fact()]
        public void DeleteFact()
        {
            var user = new User(new UserEntity());
            user.Found += (sender, e) => Assert.True(e.ID < 1);

            user = user.Create();
            user = user.Delete();
            user.Find();
        }
    }
}
