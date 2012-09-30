using System;

namespace kkkkkkaaaaaa.Data.Common
{
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public class KandaMappingAttribute : Attribute
    {
        public KandaMappingAttribute(string mappingName)
        {
            this.MappingName = mappingName;
            this.Description = this.MappingName;
        }

        public string MappingName { get; protected set; }

        public bool Ignore { get; set; }

        public string Description { get; set; }
    }
}