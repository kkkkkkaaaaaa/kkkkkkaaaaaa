using System;
using System.Data;

namespace kkkkkkaaaaaa.Data
{
    /// <summary>
    /// 
    /// DataReader から各行内の列値にアクセスできるようにします。リレーショナル データベースにアクセスする .NET Framework データ プロバイダーによって実装されます。
    /// </summary>
    public static partial class KandaDataRecordExtensions
    {
        public static string GetName(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static string GetDataTypeName(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static Type GetFieldType(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static object GetValue(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static int GetValues(this IDataRecord record, object[] values)
        {
            throw new NotImplementedException();
        }

        public static int GetOrdinal(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static bool GetBoolean(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static byte GetByte(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static long GetBytes(this IDataRecord record, string name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public static char GetChar(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static long GetChars(this IDataRecord record, string name, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public static Guid GetGuid(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static short GetInt16(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static int GetInt32(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static long GetInt64(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static float GetFloat(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static double GetDouble(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static string GetString(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static decimal GetDecimal(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static DateTime GetDateTime(this IDataRecord record, string name)
        {
            throw new NotImplementedException();
        }

        public static IDataReader GetData(this IDataRecord record, string name)
        {
            return record.GetData(
                record.GetOrdinal(name));
        }

        public static bool IsDBNull(this IDataRecord record, string name)
        {
            return record.IsDBNull(
                record.GetOrdinal(name));
        }
    }
}
