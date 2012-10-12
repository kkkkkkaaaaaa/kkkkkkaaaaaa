using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct MembershipUsersCriteria
    {
        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        public long UserID { get; set; }
    }
}