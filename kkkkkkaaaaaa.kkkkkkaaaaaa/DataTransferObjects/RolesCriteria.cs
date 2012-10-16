using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct RolesCriteria
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }
    }
}