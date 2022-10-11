using System;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = true)]
    public class KandaDataMappingAttribute : Attribute
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="mappingName"></param>
        public KandaDataMappingAttribute(string mappingName)
        {
            MappingName = mappingName;
            Description = MappingName;
        }

        /// <summary>
        /// マッピングするメンバーの名前を取得します。
        /// </summary>
        public string MappingName { get; protected set; }

        /// <summary>
        /// メンバーにマッピングするかどうかを表わす値です。
        /// </summary>
        public bool Ignore = false;

        /// <summary>
        /// このマッピングの説明です。
        /// </summary>
        public string Description = null;

        /// <summary>
        /// 規定値の値です。
        /// </summary>
        public object DefaultValue = null;
    }
}