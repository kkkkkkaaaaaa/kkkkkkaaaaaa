using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class UserAttributeEntity
    {
        [KandaDbParameterMapping("@userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("@itemId")]
        public int ItemID { get; set; }

        [KandaDbParameterMapping("@value")]
        public string Value { get; set; }
    }
}