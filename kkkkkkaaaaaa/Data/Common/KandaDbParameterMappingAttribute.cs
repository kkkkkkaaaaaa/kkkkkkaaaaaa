using System;
using System.Data;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary></summary>
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


        /// <summary></summary>
        public string MappingName
        {
            get { return this._mappingName; }
        }


        /// <summary></summary>
        public DbType DbType = default(DbType);

        /// <summary></summary>
        public int Size = 0;

        /// <summary></summary>
        public ParameterDirection Direction = ParameterDirection.Input;

        //public bool IsNullable = true;

        /// <summary></summary>
        public object DefaultValue = DBNull.Value;

        /// <summary></summary>
        public bool Ignore = false;

        /// <summary></summary>
        public string Description = string.Empty;

        #region Private members...

        /// <summary>MappingName のバッキングフィールド。</summary>
        private readonly string _mappingName;

        #endregion

    }
}
