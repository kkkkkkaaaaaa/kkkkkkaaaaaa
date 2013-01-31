using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class AdvApi32
    {
        /// <summary>
        /// WINADVAPI BOOL WINAPI IsTextUnicode(__in_bcount(iSize) CONST VOID* lpv, __in int iSize, __inout_opt LPINT lpiResult);
        /// </summary>
        /// <param name="lpv"></param>
        /// <param name="iSize"></param>
        /// <param name="lpiResult"></param>
        /// <returns></returns>
        [DllImport(AdvApi32.DLL_NAME)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsTextUnicode(IntPtr lpv, int iSize, ref int lpiResult);

        /*
戻り値

バッファ内のデータが指定したテストにパスすると、0 以外の値が返ります。
バッファ内のデータが指定したテストにパスしないと、0 が返ります。
どちらの場合も、lpi パラメータが指す int に、判定に使った個々のテスト結果が格納されます。
         */

        /*

WINADVAPI
BOOL
WINAPI
IsTextUnicode(
    __in_bcount(iSize) CONST VOID* lpv,
    __in        int iSize,
    __inout_opt LPINT lpiResult
    );*/

        #region Private members...

        /// <summary></summary>
        private const string DLL_NAME = "AdvApi32.dll";

        #endregion
        
    }
}