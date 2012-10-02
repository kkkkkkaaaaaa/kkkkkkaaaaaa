using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class UserAttributeEntity
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("@itemId")]
        public int ItemID { get; set; }

        [KandaDbParameterMapping("@value")]
        public string Value { get; set; }
    }
}