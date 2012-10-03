using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class UserAttributeHistoryEntity
    {
        [KandaDbParameterMapping("@userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("@revision")]
        public int Revision { get; set; }
    }
}