using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct RoleAuthorizationsCriteria
    {
        [KandaDbParameterMapping("@roleId")]
        public long RoleID { get; set; }

        [KandaDbParameterMapping("@authorizationId")]
        public long AuthorizationID { get; set; }
    }
}