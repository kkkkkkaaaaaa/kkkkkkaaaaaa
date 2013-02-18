using System.Data;
using kkkkkkaaaaaa.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.DataTransferObjects
{
    public class TableEntity
    {
        [KandaDbParameterMapping("@id")]
        public long ID { get; set; }

        [KandaDbParameterMapping("@identitiy", Direction = ParameterDirection.Output, DbType = DbType.Decimal, Size = sizeof(decimal), Ignore = false, DefaultValue = -1D)]
        public decimal Identity { get; set; }
    }
}