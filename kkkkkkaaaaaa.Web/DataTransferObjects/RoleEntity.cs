using System;
using System.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class RoleEntity
    {
        public RoleEntity()
        {
            this.Name = @"";
            this.Description = @"";
            this.Enabled = true;
        }

        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@description")]
        public string Description { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }

        [KandaDbParameterMapping("@createdOn", DbType = DbType.DateTime2)]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn", DbType = DbType.DateTime2)]
        public DateTime UpdatedOn { get; set; }
    }
}