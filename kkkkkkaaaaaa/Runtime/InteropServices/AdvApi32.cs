using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary></summary>
    public static class Advapi32
    {
        /// <summary>
        /// WINADVAPI BOOL WINAPI IsTextUnicode(__in_bcount(iSize) CONST VOID* lpv, __in int iSize, __inout_opt LPINT lpiResult);
        /// </summary>
        /// <param name="lpv"></param>
        /// <param name="iSize"></param>
        /// <param name="lpiResult"></param>
        /// <returns>
        /// バッファ内のデータが指定したテストにパスすると、0 以外の値が返ります。
        /// バッファ内のデータが指定したテストにパスしないと、0 が返ります。
        /// どちらの場合も、lpi パラメータが指す int に、判定に使った個々のテスト結果が格納されます。
        /// </returns>
        [DllImport(Advapi32.DLL_NAME)]
        [return : MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsTextUnicode(IntPtr lpv, int iSize, ref int lpiResult);

        /// <summary>
        /// WINBASEAPI _Success_(return == ERROR_SUCCESS) DWORD WINAPI EnumDynamicTimeZoneInformation(_In_ CONST DWORD dwIndex, _Out_ PDYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation);
        /// </summary>
        /// <param name="dwIndex"></param>
        /// <param name="lpTimeZoneInformation"></param>
        /// <returns></returns>
        [DllImport(Advapi32.DLL_NAME)]
        public static extern uint EnumDynamicTimeZoneInformation([In()]uint dwIndex, out _TIME_DYNAMIC_ZONE_INFORMATION lpTimeZoneInformation);
        
        /// <summary>
        /// WINADVAPI 
        ///   BOOL
        /// WINAPI 
        ///   LogonUserW(
        ///     _In_ LPCWSTR lpszUsername,
        ///     _In_opt_ LPCWSTR lpszDomain,
        ///     _In_opt_ LPCWSTR lpszPassword,
        ///     _In_ DWORD dwLogonType,
        ///     _In_ DWORD dwLogonProvider,
        ///     _Outptr_ PHANDLE phToken
        /// );
        /// 
        /// 「LogonUser」
        /// https://msdn.microsoft.com/ja-jp/library/cc447468.aspx
        /// </summary>
        /// <param name="lpszUsername">ユーザー名を指定する文字列。</param>
        /// <param name="lpszDomain">ドメインまたはサーバーを指定する文字列。</param>
        /// <param name="lpszPassword">パスワードを指定する文字列。</param>
        /// <param name="dwLogonType">ログオン動作のタイプを指定する。</param>
        /// <param name="dwLogonProvider">ログオンプロバイダを指定する。</param>
        /// <param name="phToken">トークンハンドルを受け取る変数へのポインタ。</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。
        /// 
        /// 拡張エラー情報を取得するには、GetLastError 関数を使います。
        /// </returns>
        [DllImport(Advapi32.DLL_NAME)]
        public static extern int LogonUser([In()] string lpszUsername
            , [In()] string lpszDomain
            , [In()] string lpszPassword
            , [In()] uint dwLogonType
            , [In()] uint dwLogonProvider
            , [Out()] out IntPtr phToken);

        #region Private members...

        /// <summary></summary>
        private const string DLL_NAME = "advapi32.dll";

        #endregion
    }
}