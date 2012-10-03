using System;
using System.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class UserHistoryEntity
    {
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

        [KandaDbParameterMapping("@revision")]
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
