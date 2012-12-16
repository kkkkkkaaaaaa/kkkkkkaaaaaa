using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct UserAttributeItemsCriteria
    {
        [KandaDbParameterMapping(@"id")]
        public long ID { get; set; }

        [KandaDbParameterMapping(@"enabled")]
        public bool? Enabled { get; set; }
    }
}