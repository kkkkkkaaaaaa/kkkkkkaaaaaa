using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class MembershipUserEntity
    {
        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@userId")]
        public long UserID { get; set; }
    }
}