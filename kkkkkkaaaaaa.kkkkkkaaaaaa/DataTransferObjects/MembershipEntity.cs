using System;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class MembershipEntity
    {
        public readonly static MembershipEntity Empty = new MembershipEntity() { ID = -1, };

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
        public string Name { get; set; }

        [KandaDbParameterMapping("@password")]
        public string Password { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }

        [KandaDbParameterMapping("@createdOn")]
        public DateTime CreatedOn { get; set; }

        [KandaDbParameterMapping("@updatedOn")]
        public DateTime UpdatedOn { get; set; }
    }
}