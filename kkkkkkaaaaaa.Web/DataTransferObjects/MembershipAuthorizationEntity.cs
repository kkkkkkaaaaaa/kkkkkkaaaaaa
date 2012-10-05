using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class MembershipAuthorizationEntity
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@membershipId")]
        public long MembershipID { get; set; }

        [KandaDbParameterMapping("@authorizationId")]
        public long AuthorizationID { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }
    }
}