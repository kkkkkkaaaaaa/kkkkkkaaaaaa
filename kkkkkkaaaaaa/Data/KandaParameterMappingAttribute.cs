using System;

namespace kkkkkkaaaaaa.Data
{
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public class KandaParameterMappingAttribute : Attribute
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="mappingName"></param>
        public KandaParameterMappingAttribute(string mappingName)
        {
            this._mappingName = mappingName;
        }

        public string MappingName
        {
            get { return this._mappingName; }
        }

        /// <summary></summary>
        protected readonly string _mappingName = @"";
    }
}