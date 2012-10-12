using System.Collections.Generic;
using System.Collections.ObjectModel;
using kkkkkkaaaaaa.DataTransferObjects;

namespace kkkkkkaaaaaa.Data.Repositories
{
    public class MembershipUsersRepository
    {
        public IEnumerable<MembershipUserEntity> Search(MembershipsCriteria criteria)
        {
            return new Collection<MembershipUserEntity>();
        }

        public bool Create()
        {
            return true;
        }

        public bool Udpate()
        {
            return true;
        }
    }
}