using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public struct UserHistoriesCriteria
    {
        [KandaDbParameterMapping("userId")]
        public long UserID { get; set; }

        [KandaDbParameterMapping("revision")]
        public int Revision { get; set; }
    }
}