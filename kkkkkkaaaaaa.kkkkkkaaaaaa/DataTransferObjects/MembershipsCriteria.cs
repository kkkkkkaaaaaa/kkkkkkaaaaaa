using System;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct MembershipsCriteria
    {
        public MembershipsCriteria(long id) : this()
        {
            this.ID = id;
            this.Name = @"";
            this.Password = @"";
            this.Enabled = true;
        }

        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@password")]
        public object Password { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool? Enabled { get; set; }

        /*
        [KandaDbParameterMapping("@createdOn")]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn")]
        public DateTime UpdatedOn { get; set; }
        */
    }
}