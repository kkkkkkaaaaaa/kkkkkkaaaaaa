//using System.Security;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct MembershipsCriteria
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@password")]
        public object Password { get; set; }
        //public string Password { get; set; }
        //public SecureString Password { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool? Enabled { get; set; }
    }
}