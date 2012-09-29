using System;

namespace kkkkkkaaaaaa.Data.Common
{
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public class KandaMappingAttribute : Attribute
    {
        public KandaMappingAttribute(string mappingName)
        {
            this.MappingName = mappingName;
        }

        public string MappingName { get; protected set; }

        public bool Ignore = false;

        internal string Description = @"";
    }
}