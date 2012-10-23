using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct UserHistoryAttributesCriteria
    {
        [KandaDbParameterMapping("@userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("@revision")]
        public int Revision { get; set; }

        [KandaDbParameterMapping("@itemId")]
        public int ItemID { get; set; }
    }
}
