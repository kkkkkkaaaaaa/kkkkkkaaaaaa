using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct MembershipRolesCriteria
    {
        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@roleId")]
        public long RoleID { get; set; }
    }
}