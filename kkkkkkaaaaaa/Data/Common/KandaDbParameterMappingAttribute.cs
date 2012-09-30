using System;
using System.Data;

namespace kkkkkkaaaaaa.Data.Common
{
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public class KandaDbParameterMappingAttribute : Attribute
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="mappintName"></param>
        public KandaDbParameterMappingAttribute(string mappintName)
        {
            this._mappingName = mappintName;
            this.Description = this.MappingName;
        }

        public string MappingName
        {
            get { return this._mappingName; }
        }

        public ParameterDirection Direction = ParameterDirection.Input;

        public DbType DbType = default(DbType);

        public string Description = @"";


        #region Protected members...

        protected readonly string _mappingName;

        #endregion

    }
}