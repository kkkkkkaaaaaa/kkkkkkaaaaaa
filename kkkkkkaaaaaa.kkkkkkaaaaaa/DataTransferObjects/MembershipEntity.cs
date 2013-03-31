using System;
using System.Security;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public partial class MembershipEntity
    {
        public readonly static MembershipEntity Empty = new MembershipEntity() { ID = -1L, };

        public readonly static MembershipEntity System = new MembershipEntity { ID = 1L, Name = @"System", Password = new SecureString(), CreatedOn = new DateTime(1753, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) };

        /// <summary>
        /// コンストラクター。
        /// </summary>
        public MembershipEntity()
        {
            this.Enabled = true;
        }

        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public virtual string Name { get; set; }

        /*
        [KandaDbParameterMapping("@password")]
        public String Password { get; set; }
        */

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }

        [KandaDbParameterMapping("@createdOn")]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn")]
        public DateTime UpdatedOn { get; set; }

        public string Email { get; set; }
    }
}