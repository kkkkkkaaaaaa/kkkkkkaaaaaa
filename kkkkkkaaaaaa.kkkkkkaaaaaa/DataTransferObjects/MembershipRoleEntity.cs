using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class MembershipRoleEntity
    {
        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@roleId")]
        public long RoleID { get; set; }
    }
}
