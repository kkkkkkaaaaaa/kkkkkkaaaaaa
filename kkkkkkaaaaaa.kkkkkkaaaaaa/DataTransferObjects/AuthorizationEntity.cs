using System;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class AuthorizationEntity
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@", Ignore = true)]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@", Ignore = true)]
        public DateTime UpdatedOn { get; set; }
    }
}