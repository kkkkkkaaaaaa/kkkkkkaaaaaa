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

        public KandaDbParameterMappingAttribute(bool ignore) : this(null)
        {
            this.Ignore = ignore;
        }

        public string MappingName
        {
            get { return this._mappingName; }
        }

        public DbType DbType = default(DbType);

        public int Size = 0;

        public ParameterDirection Direction = ParameterDirection.Input;

        //public bool IsNullable = true;

        public object DefaultValue = DBNull.Value;

        public bool Ignore = false;

        public string Description = @"";


        #region Protected members...

        protected readonly string _mappingName;

        #endregion

    }
}