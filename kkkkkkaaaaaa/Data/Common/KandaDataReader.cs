﻿using System;
using System.Collections;
using System.Data;
using System.Data.Common;

namespace kkkkkkaaaaaa.Data.Common
{
    /// <summary>
    /// データソースから行の前方向ストリームを読み取ります。
    /// </summary>
    public partial class KandaDataReader : DbDataReader
    {
        /// <summary>
        /// コンストラクタ―。
        /// </summary>
        /// <param name="command"></param>
        public KandaDataReader(DbCommand command)
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
            get { return this._reader[ordinal]; }
        }

        /// <summary>
        /// 指定した列の値を Object のインスタンスとして取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override object this[string name]
        {
            get { return this._reader[name]; }
        }

        /// <summary>
        /// DbParameter オブジェクトのコレクションを返します。
        /// </summary>
        public DbParameterCollection Parameters
        {
            get { return this._command.Parameters; }
        }

        /// <summary>
        /// データソースに対して実行するテキストコマンドを取得または設定します。
        /// </summary>
        public string CommandText
        {
            get { return this._command.CommandText; }
            set { this._command.CommandText = value; }
        }

        /// <summary>
        /// DbCommand.CommandText の解釈方法を指示または指定します。
        /// </summary>
        public CommandType CommandType
        {
            get { return this._command.CommandType; }
            set { this._command.CommandType = value; }
        }


        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        /// <param name="behavior"></param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(CommandBehavior behavior)
        {
            this._reader = this._command.ExecuteReader(behavior);

            return this;
        }

        /// <summary>
        /// DbCommand.Connection に対して DbCommand.CommandText を実行し、CommandBehavior の値の 1 つを使用して DbDataReader を実行します。
        /// </summary>
        public DbDataReader ExecuteReader()
        {
            return this.ExecuteReader(CommandBehavior.Default);
        }

        /// <summary>
        /// データリーダーの行の反復に使用できる IEnumarator を返します。
        /// </summary>
        /// <returns></returns>
        public override IEnumerator GetEnumerator()
        {
            return this._reader.GetEnumerator();
        }

        /// <summary>
        /// DbDataReader の列メタデータを記述する DataTable を返します。
        /// </summary>
        /// <returns></returns>
        public override DataTable GetSchemaTable()
        {
            return this._reader.GetSchemaTable();
        }

        /// <summary>
        /// リーダーを結果セットの次のレコードに進めます。
        /// </summary>
        /// <returns></returns>
        public override bool Read()
        {
            return this._reader.Read();
        }

        /// <summary>
        /// DbDataReader オブジェクトを閉じます。
        /// </summary>
        public override void Close()
        {
            if (this._reader != null) { this._reader.Close(); }
        }

        /// <summary>
        /// 列の名前を指定して、列の序数を取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override int GetOrdinal(string name)
        {
            return this._reader.GetOrdinal(name);
        }

        /// <summary>
        /// 0 から始まる列の序数を指定して、列の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override string GetName(int ordinal)
        {
            return this._reader.GetName(ordinal);
        }

        /// <summary>
        /// 列に格納されている値が存在しない値または欠損値かどうかを表す値を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override bool IsDBNull(int ordinal)
        {
            return this._reader.IsDBNull(ordinal);
        }

        /// <summary>
        /// 列に格納されている値が存在しない値または欠損値かどうかを表す値を取得します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsDBNull(string name)
        {
            var ordinal = this.GetOrdinal(name);

            return this.IsDBNull(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override Type GetFieldType(int ordinal)
        {
            return this._reader.GetFieldType(ordinal);
        }

        /// <summary>
        /// 指定した列のデータ型の名前を取得します。
        /// </summary>
        /// <param name="ordinal"></param>
        /// <returns></returns>
        public override string GetDataTypeName(int ordinal)
        {
            return this._reader.GetDataTypeName(ordinal);
        }

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


        public override bool HasRows
        {
            get { throw new NotImplementedException(); }
        }

        public override int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }

        public override int FieldCount
        {
            get { throw new NotImplementedException(); }
        }

        public override int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }


        public override bool NextResult()
        {
            throw new NotImplementedException();
        }

        public override bool GetBoolean(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override byte GetByte(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override char GetChar(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
        {
            throw new NotImplementedException();
        }

        public override Guid GetGuid(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override short GetInt16(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetInt32(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override long GetInt64(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override DateTime GetDateTime(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override string GetString(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override object GetValue(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public override decimal GetDecimal(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override double GetDouble(int ordinal)
        {
            throw new NotImplementedException();
        }

        public override float GetFloat(int ordinal)
        {
            throw new NotImplementedException();
        }
        

        #region Private mebers..

        /// <summary>データソースに対して実行する SQL ステートメントまたはストアドプロシージャを表わします。</summary>
        private readonly DbCommand _command;
        /// <summary>データソースから行の前方向ストリームを読み取ります。</summary>
        private DbDataReader _reader;

        #endregion
    }
}
