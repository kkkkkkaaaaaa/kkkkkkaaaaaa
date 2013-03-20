using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public partial class MembershipEntity
    {
        [KandaDbParameterMapping("@password")]
        public dynamic Password { get; set; }
    }
}