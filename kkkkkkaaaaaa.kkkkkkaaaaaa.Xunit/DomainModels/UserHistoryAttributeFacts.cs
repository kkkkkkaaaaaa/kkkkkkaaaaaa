using System.Linq;
using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class UserHistoryAttributeFacts
    {
        [Fact()]
        public void FindFact()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Found += (sender, e) => Assert.Equal(1, sender.Attributes.Count);
                user.Attributes.Add(new UserAttributeEntity() { ItemID = 99, });
                user.Create();
                user.Find();

                var history = new UserHistory(user.Histories.First()).Find();
                Assert.Equal(1, history.Attributes.Count());
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
                user.Attributes.Add(new UserAttributeEntity() { ItemID = 99, });
                user.Create();
                user.Find();

                Assert.Equal(1, user.Attributes.Count);
            }
            finally
            {
                if (user != null) { user.Delete(); }
            }
        }

        [Fact()]
        public void Update()
        {
            var user = default(User);

            try
            {
                user = new User(new UserEntity());
                user.Attributes.Add(new UserAttributeEntity() { ItemID = 99, });
                user.Create();

                var item = new UserAttributeEntity() { ItemID = 199, Value = @"Item : 199", };
                user.Attributes.Add(item);
                user.Update();
                user.Attributes.Remove(item);
                user.Update();
                user.Find();

                Assert.Equal(1, user.Attributes.Count);
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
            user.Attributes.Add(new UserAttributeEntity() { ItemID = 1, Value = @"ItemID : 1", });
            user.Create();
            user.Delete();
            user.Find();

            Assert.Equal(0, user.Attributes.Count);
        }
    }
}