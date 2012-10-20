using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct UserAttributesCriteria
    {
        [KandaDbParameterMapping("userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("itemId")]
        public int ItemID { get; set; }

        public string Value { get; set; }
    }
}