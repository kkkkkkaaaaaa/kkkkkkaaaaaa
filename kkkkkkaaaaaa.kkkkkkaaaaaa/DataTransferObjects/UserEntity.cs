using System;
using System.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class UserEntity : KandaEntity
    {
        public readonly static UserEntity Empty = new UserEntity();

        public UserEntity()
        {
            this.ID = -1;
            this.FamilyName = @"";
            this.GivenName = @"";
            this.AdditionalName = @"";
            this.Description = @"";
            this.Enabled = true;
        }

        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@familyName")]
        public string FamilyName { get; set; }

        [KandaDbParameterMapping("@givenName")]
        public string GivenName { get; set; }

        [KandaDbParameterMapping("@additionalName")]
        public string AdditionalName { get; set; }

        [KandaDbParameterMapping("@description")]
        public string Description { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }

        [KandaDbParameterMapping("@createdOn")]//, DbType = DbType.DateTime2)]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn")]//, DbType = DbType.DateTime2)]
        public DateTime UpdatedOn { get; set; }
    }
}