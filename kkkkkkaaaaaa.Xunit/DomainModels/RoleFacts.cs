using System;
using System.Globalization;
using System.Threading;
using Xunit;
using kkkkkkaaaaaa.DataTransferObjects;
using kkkkkkaaaaaa.DomainModels;

namespace kkkkkkaaaaaa.Xunit.DomainModels
{
    public class RoleFacts
    {
        [Fact()]
        public void FindFact()
        {
            var role = default(Role);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                role = new Role(new RoleEntity() { Name = name, });
                role.Found += (sender, e) => Assert.True(0 < e.ID);

                role.Create();
                role.Find();
                Assert.True(0 < role.ID);
            }
            finally
            {
                if (role != null) { role.Delete(); }
            }
        }

        [Fact()]
        public void CreateFact()
        {
            var role = default(Role);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                role = new Role(new RoleEntity(){ Name = name, });
                role.Found += (sender, e) => Assert.True(0 < e.ID);

                role.Create();
                role.Find();
            }
            finally
            {
                if (role != null) { role.Delete(); }
            }
        }

        [Fact()]
        public void UpdateFact()
        {
            var role = default(Role);

            try
            {
                var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
                role = new Role(new RoleEntity() { Name = name, });
                role.Found += (sender, e) =>
                    {
                        var updated = new Role(e);
                        updated.Found += (sender2, e2) => Assert.True(e2.CreatedOn < e2.UpdatedOn);

                        Thread.Sleep(1000);
                        updated.Update();
                        updated.Find();
                    };

                role.Create();
                role.Find();
            }
            finally
            {
                if (role != null) { role.Delete(); }
            }
        }

        [Fact()]
        public void DeleteFact()
        {
            var role = default(Role);

            var name = new Random().Next().ToString(CultureInfo.InvariantCulture);
            role = new Role(new RoleEntity() { Name = name, });
            role.Found += (sender, e) => Assert.False(0 < e.ID);

            role.Create();
            role.Delete();
            role.Find();
        }
    }
}