using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class MembershipFacts
    {
        [Fact()]
        public void CreateFact()
        {
            var entity = new MembershipEntity() { Name = @"name", Password = @"password", Enabled = true, };
            var membership = new Membership(entity).Create();

            Assert.NotNull(membership);

            //Assert.Equal(entity.Name, membership.Name);
            //Assert.Equal(entity.Password, membership.Password);
            //Assert.Equal(true, membership.Enabled);
        }
    }
}