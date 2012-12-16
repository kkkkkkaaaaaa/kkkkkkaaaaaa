using System;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class UserAttributeItemEntity
    {
        public readonly static UserAttributeItemEntity Empty = new UserAttributeItemEntity() { ID = -1, };


        [KandaDbParameterMapping("@id")]
        public int ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@description")]
        public string Description { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }

        [KandaDbParameterMapping("@createdOn", Ignore = true)]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn", Ignore = true)]
        public DateTime UpdatedOn { get; set; }
    }
}
