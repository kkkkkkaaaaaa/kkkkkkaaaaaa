using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class UserAttributesFacts
    {
        [Fact()]
        public void DeleteFact()
        {
            var user = new User(new UserEntity());

            user.Attributes.Add(new UserAttributeEntity() { ItemID = 1, Value = @""});
            user.Create();

            user.Delete();
        }
    }
}