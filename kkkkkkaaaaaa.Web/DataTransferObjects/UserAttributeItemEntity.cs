using System.Data;
using kkkkkkaaaaaa.Data.Common;

namespace kkkkkkaaaaaa.Web.DataTransferObjects
{
    public class UserAttributeItemEntity
    {
        [KandaDbParameterMapping("@id")]
        public int ID { get; set; }

        [KandaDbParameterMapping("@name")]
        public string Name { get; set; }

        [KandaDbParameterMapping("@description")]
        public string Description { get; set; }

        [KandaDbParameterMapping("@enabled")]
        public bool Enabled { get; set; }
}
}