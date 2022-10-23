using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using kkkkkkaaaaaa.Data;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDbDataReader : DbDataReader
    {
        /// <summary>
        /// コンストラクター。
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        public KandaDbDataReader(DbConnection connection, DbTransaction? transaction = default(DbTransaction))
        {
            this._command = connection.CreateCommand();
            this._command.Transaction = transaction;
        }

        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="command"></param>
        [DebuggerStepThrough()]
        public KandaDbDataReader(DbCommand command)
        {
            this._command = command;
        }
        

        /// <summary>
        /// 指定した列の値を Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override object this[int ordinal]
        {
            [DebuggerStepThrough()]
            get { return this._reader[ordinal]; }
        }

        /// <summary>
        /// 指定した列の値を Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object this[string name]
        {
            [DebuggerStepThrough()]
            get { return this._reader[name]; }
        }

        /// <summary>
        /// DbDataReader に 1 行以上の行が格納されているか銅貨を示す値を取得します。
        /// </summary>
        public override bool HasRows
        {
            [DebuggerStepThrough()]
            get { return this._reader.HasRows; }
        }

        /// <summary>
        /// SQL ステートメントの実行によって変更、挿入、または削除された行の数を取得します。
        /// </summary>
        public override int RecordsAffected
        {
            [DebuggerStepThrough()]
            get { return this._reader.RecordsAffected; }
        }

        /// <summary>
        /// 現在の行の列数を取得します。
        /// </summary>
        public override int FieldCount
        {
            [DebuggerStepThrough()]
            get { return this._reader.FieldCount; }
        }

        /// <summary>
        /// 現在の行の入れ子の深さを示す値を取得します。
        /// </summary>
        public override int Depth
        {
            [DebuggerStepThrough()]
            get { return this._reader.Depth; ; }
        }

        /// <summary>
        /// DbDataReader が閉じているかどうかを示す値を取得します。
        /// </summary>
        public override bool IsClosed
        {
            [DebuggerStepThrough()]
            get { return this._reader.IsClosed; }
        }


        /// <summary>
        /// データリーダーの行の反復に使用できる IEnumarator を返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override IEnumerator GetEnumerator()
        {
            return this._reader.GetEnumerator();
        }

        /// <summary>
        /// DbDataReader の列メタデータを記述する DataTable を返します。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DataTable? GetSchemaTable()
        {
            return this._reader?.GetSchemaTable();
        }

        /// <summary>
        /// リーダーを結果セットの次のレコードに進めます。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool Read()
        {
            return this._reader.Read();
        }

        /// <summary>
        /// バッチステートメントの結果を読み取るときに、リーダーを次の結果に進めます。
        /// </summary>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool NextResult()
        {
            return this._reader.NextResult();
        }

        /// <summary>
        /// DbDataReader オブジェクトを閉じます。
        /// </summary>
        [DebuggerStepThrough()]
        public override void Close()
        {
            if (this._reader != null) { this._reader.Close(); }
        }

        /// <summary>
        /// 列の名前を指定して、列の序数を取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override int GetOrdinal(string name)
        {
            return this._reader.GetOrdinal(name);
        }

        /// <summary>
        /// 0 から始まる列の序数を指定して、列の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetName(int ordinal)
        {
            return this._reader.GetName(ordinal);
        }

        /// <summary>
        /// 列に格納されている値が存在しない値または欠損値かどうかを表す値を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool IsDBNull(int ordinal)
        {
            return this._reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override Type GetFieldType(int ordinal)
        {
            return this._reader.GetFieldType(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetDataTypeName(int ordinal)
        {
            return this._reader.GetDataTypeName(ordinal);
        }

        /// <summary>
        /// 指定した列の値を String のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override string GetString(int ordinal)
        {
            return this._reader.GetString(ordinal);
        }

        /// <summary>
        /// 指定した列の値を Int32 のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override int GetInt32(int ordinal)
        {
            return this._reader.GetInt32(ordinal);
        }

        /// <summary>
        /// 指定した列の値を 64 ビット符号付き整数として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override long GetInt64(int ordinal)
        {
            return this._reader.GetInt64(ordinal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override decimal GetDecimal(int ordinal)
        {
            return this._reader.GetDecimal(ordinal);
        }

        /// <summary>
        /// 指定した列の値をブール値として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override bool GetBoolean(int ordinal)
        {
            return this._reader.GetBoolean(ordinal);
        }

        /// <summary>
        /// 指定した列の値を DateTime オブジェクトとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override DateTime GetDateTime(int ordinal)
        {
            return this._reader.GetDateTime(ordinal);
        }

        /// <summary>
        /// 指定した列の値をバイトとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override byte GetByte(int ordinal)
        {
            return this._reader.GetByte(ordinal);
        }

        /// <summary>
        /// 指定した列の dataOffset で指定された位置から開始されるバイトストリームを、バッファーの bufferOffset で指定された開始位置に読み込みます。
        /// </summary>
        /// <returns>
        /// 実際に読み取られたバイト数を返します。
        /// </returns>
        /// <param name="ordinal">インデックス番号が 0 から始まる列序数。</param>
        /// <param name="dataOffset">読み取り操作を開始する行内のインデックス。</param>
        /// <param name="buffer">データのコピー先のバッファー。</param>
        /// <param name="bufferOffset">データのコピー先となるバッファーのインデックス。</param>
        /// <param name="length">読み取り対象の最大文字数。</param>
        [DebuggerStepThrough()]
        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            return this._reader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        /// 指定した列の値を単一の文字として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override char GetChar(int ordinal)
        {
            return this._reader.GetChar(ordinal);
        }

        /// <summary>
        /// 指定した列の dataOffset で指定された位置から開始される文字ストリームを、バッファーの bufferOffset で指定された開始位置に読み込みます。
        /// </summary>
        /// <returns>
        /// 実際に読み込まれた文字数を返します。
        /// </returns>
        /// <param name="ordinal">インデックス番号が 0 から始まる列序数。</param>
        /// <param name="dataOffset">読み取り操作を開始する行内のインデックス。</param>
        /// <param name="buffer">データのコピー先のバッファー。</param>
        /// <param name="bufferOffset">データのコピー先となるバッファーのインデックス。</param>
        /// <param name="length">読み取り対象の最大文字数。</param>
        [DebuggerStepThrough()]
        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            return this._reader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);
        }

        /// <summary>
        ///  指定した列の値をグローバル一意識別子（GUID）として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override Guid GetGuid(int ordinal)
        {
            return this._reader.GetGuid(ordinal);
        }

        /// <summary>
        /// 指定した列の値を 16 ビット符号付き整数として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override short GetInt16(int ordinal)
        {
            return this._reader.GetInt16(ordinal);
        }

        /// <summary>
        /// 指定した列の値を System.Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override object GetValue(int ordinal)
        {
            return this._reader.GetValue(ordinal);
        }

        /// <summary>
        /// オブジェクトの配列に現在行の列値を設定します。
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override int GetValues(object[] values)
        {
            return this._reader.GetValues(values);
        }

        /// <summary>
        /// 指定した列の値を倍精度浮動小数点数として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override double GetDouble(int ordinal)
        {
            return this._reader.GetDouble(ordinal);
        }

        /// <summary>
        /// 指定した列の値を単精度浮動小数点数として取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        [DebuggerStepThrough()]
        public override float GetFloat(int ordinal)
        {
            return this._reader.GetFloat(ordinal);
        }


        #region Internal members...

        /// <summary>
        /// データソースに対して実行する SQL ステートメントまたはストアドプロシージャを取得します。
        /// </summary>
        internal DbCommand InnerCommand
        {
            [DebuggerStepThrough()]
            get { return this._command; }
        }

        #endregion

        #region Protected members...

        /// <summary>
        /// DbDataReader によって使用されているマネージリソースを解放し、オプションでアンマネージリソースも解放します。
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._command != null) { this._command.Dispose(); }
                if (this._reader != null) { this._reader.Dispose(); }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// 何もしません。
        /// </summary>
        [DebuggerStepThrough()]
        protected void DoNothing()
        {
            // 何もしない
        }

        #endregion

        #region Private mebers..

        /// <summary>データソースに対して実行する SQL ステートメントまたはストアドプロシージャを表わします。</summary>
        private readonly DbCommand _command;
        /// <summary>データソースから行の前方向ストリームを読み取ります。</summary>
        private DbDataReader? _reader;

        #endregion
    }
}
