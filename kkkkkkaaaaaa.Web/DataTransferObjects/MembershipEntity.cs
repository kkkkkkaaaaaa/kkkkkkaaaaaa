using System;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class MembershipEntity
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public object Password { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}