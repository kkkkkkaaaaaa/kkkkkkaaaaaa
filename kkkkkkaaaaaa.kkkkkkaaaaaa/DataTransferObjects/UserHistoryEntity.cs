using System;
using System.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class UserHistoryEntity
    {
        public readonly static UserHistoryEntity Empty = new UserHistoryEntity() { UserID = -1, Revision = -1, };

        public UserHistoryEntity()
        {
            this.FamilyName = @"";
            this.GivenName = @"";
            this.AdditionalName = @"";
            this.Description = @"";
            this.Enabled = true;
        }

        [KandaDbParameterMapping("@userId")]
        public virtual long UserID { get; set; }

        [KandaDbParameterMapping("@revision", DbType = DbType.Int32, Size = sizeof(int), Direction = ParameterDirection.InputOutput)]
        public int Revision { get; set; }

        public string FamilyName { get; set; }

        public string GivenName { get; set; }

        public string AdditionalName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdateOn { get; set; }
    }
}
