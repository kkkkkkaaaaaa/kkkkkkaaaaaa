using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct AuthorizationsCriteria
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; } 
    }
}