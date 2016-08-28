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
        /// <summary>
<<<<<<< HEAD
=======
        /// 検索するフィールドの名前を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// フィールドの名前。返される値がない場合は空の文字列 ("")。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
        /// <param name="name">検索するフィールドのインデックス。</param>
        public static string GetName(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetName(ordinal);
        }

        /// <summary>
>>>>>>> remotes/origin/0.0.11
        /// 指定したフィールドのデータ型情報を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドのデータ型情報。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
=======
        /// <param name="name">検索するフィールドのインデックス。</param>
>>>>>>> remotes/origin/0.0.11
        public static string GetDataTypeName(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// <see cref="M:System.Data.IDataRecord.GetValue(System.Int32)"/> から返される <see cref="T:System.Object"/> の型に対応する <see cref="T:System.Type"/> 情報を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// <see cref="M:System.Data.IDataRecord.GetValue(System.Int32)"/> から返される <see cref="T:System.Object"/> の型に対応する <see cref="T:System.Type"/> 情報。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static Type GetFieldType(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetFieldType(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの値を返します。
        /// </summary>
<<<<<<< HEAD
=======
        /// 
>>>>>>> remotes/origin/0.0.11
        /// <returns>
        /// フィールドの値が返されたときにその値を格納する <see cref="T:System.Object"/>。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
=======
        /// <param name="name">検索するフィールドのインデックス。</param>
>>>>>>> remotes/origin/0.0.11
        public static object GetValue(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetValue(ordinal);
        }

        /// <summary>
        /// 指定した列の値をブール値として取得します。
        /// </summary>
<<<<<<< HEAD
=======
        /// 
>>>>>>> remotes/origin/0.0.11
        /// <returns>
        /// 列の値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
        /// <exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">インデックス番号が 0 から始まる列序数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static bool GetBoolean(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetBoolean(ordinal);
        }

        /// <summary>
        /// 指定した列の 8 ビット符号なし整数値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定した列の 8 ビット符号なし整数値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">インデックス番号が 0 から始まる列序数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static byte GetByte(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetByte(ordinal);
        }

        /// <summary>
        /// 指定したバッファー オフセットを開始位置として、指定した列オフセットからバッファーに、バイトのストリームを配列として読み込みます。
        /// </summary>
        /// 
        /// <returns>
        /// 実際に読み取られたバイト数を返します。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><param name="fieldOffset">読み取り操作を開始するフィールド内のインデックス。</param><param name="buffer">読み取ったバイトのストリームを格納するバッファー。</param><param name="bufferoffset">読み取り操作を開始する <paramref name="buffer"/> のインデックス。</param><param name="length">読み取るバイト数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">インデックス番号が 0 から始まる列序数。</param><param name="fieldOffset">読み取り操作を開始するフィールド内のインデックス。</param><param name="buffer">読み取ったバイトのストリームを格納するバッファー。</param><param name="bufferoffset">読み取り操作を開始する <paramref name="buffer"/> のインデックス。</param><param name="length">読み取るバイト数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static long GetBytes(this IDataRecord record, string name, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetBytes(ordinal, fieldOffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// 指定した列の文字値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定した列の文字値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">インデックス番号が 0 から始まる列序数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static char GetChar(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetChar(ordinal);
        }

        /// <summary>
        /// 指定したバッファー オフセットを開始位置として、指定した列オフセットからバッファーに、文字のストリームを配列として読み込みます。
        /// </summary>
        /// 
        /// <returns>
        /// 実際に読み込まれた文字数を返します。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><param name="fieldoffset">読み取り操作を開始する行内のインデックス。</param><param name="buffer">読み取ったバイトのストリームを格納するバッファー。</param><param name="bufferoffset">読み取り操作を開始する <paramref name="buffer"/> のインデックス。</param><param name="length">読み取るバイト数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">インデックス番号が 0 から始まる列序数。</param><param name="fieldoffset">読み取り操作を開始する行内のインデックス。</param><param name="buffer">読み取ったバイトのストリームを格納するバッファー。</param><param name="bufferoffset">読み取り操作を開始する <paramref name="buffer"/> のインデックス。</param><param name="length">読み取るバイト数。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static long GetChars(this IDataRecord record, string name, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetChars(ordinal, fieldoffset, buffer, bufferoffset, length);
        }

        /// <summary>
        /// 指定したフィールドの GUID 値を返します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの GUID 値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static Guid GetGuid(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetGuid(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの 16 ビット符号付き整数値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの 16 ビット符号付き整数値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static short GetInt16(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetInt16(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの 32 ビット符号付き整数値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの 32 ビット符号付き整数値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static int GetInt32(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetInt32(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの 64 ビット符号付き整数値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの 64 ビット符号付き整数値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static long GetInt64(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetInt64(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの単精度浮動小数点数を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの単精度浮動小数点数。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static float GetFloat(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetFloat(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの倍精度浮動小数点数を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの倍精度浮動小数点数。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static double GetDouble(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetDouble(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの文字列値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの文字列値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static string GetString(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetString(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの固定位置数値を取得します。
        /// </summary>
        /// 
        /// <returns>
        /// 指定したフィールドの固定位置数値。
        /// </returns>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
=======
        /// <param name="name">検索するフィールドのインデックス。</param><exception cref="T:System.IndexOutOfRangeException">渡されたインデックスが 0 から <see cref="P:System.Data.IDataRecord.FieldCount"/> の範囲にありません。</exception><filterpriority>2</filterpriority>
>>>>>>> remotes/origin/0.0.11
        public static Decimal GetDecimal(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetDecimal(ordinal);
        }

        /// <summary>
        /// 指定したフィールドの日時のデータ値を取得または設定します。
        /// </summary>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
=======
        /// <param name="name">検索するフィールドのインデックス。</param>
>>>>>>> remotes/origin/0.0.11
        /// <returns>指定したフィールドの日時のデータ値。</returns>
        public static DateTime GetDateTime(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetDateTime(ordinal);
        }

        /// <summary>
        /// 指定した列序数の <see cref="T:System.Data.IDataReader"/> を返します。
        /// </summary>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
=======
        /// <param name="name">検索するフィールドのインデックス。</param>
>>>>>>> remotes/origin/0.0.11
        /// <returns>指定した列の序数の IDataReader。</returns>
        public static IDataReader GetData(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.GetData(ordinal);
        }

        /// <summary>
        /// 指定したフィールドが null に設定されているかどうかを示す値を返します。
        /// </summary>
        /// <param name="record">IDataRecord。</param>
<<<<<<< HEAD
        /// <param name="name">検索するフィールドの名前。</param>
=======
        /// <param name="name">検索するフィールドのインデックス。</param>
>>>>>>> remotes/origin/0.0.11
        /// <returns></returns>
        /// <returns>
        /// 指定したフィールドが null に設定されている場合は true。それ以外の場合は false。
        /// </returns>
        public static bool IsDBNull(this IDataRecord record, string name)
        {
            var ordinal = record.GetOrdinal(name);

            return record.IsDBNull(ordinal);
        }
    }
}
