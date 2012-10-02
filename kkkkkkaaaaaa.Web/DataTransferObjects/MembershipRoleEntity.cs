using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class MembershipRoleEntity
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@roleId")]
        public long RoleID { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }
    }
}
