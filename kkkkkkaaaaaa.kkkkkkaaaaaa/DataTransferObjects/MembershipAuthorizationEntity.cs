using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipAuthorizationEntity
    {
        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@authorizationId")]
        public long AuthorizationID { get; set; }
    }
}