using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    /// <summary>
    /// 
    /// </summary>
    public class RoleAuthorizationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [KandaDbParameterMapping("@roleId")]
        public long RoleID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [KandaDbParameterMapping("@authorizationId")]
        public long AuthorizationID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }
    }
}