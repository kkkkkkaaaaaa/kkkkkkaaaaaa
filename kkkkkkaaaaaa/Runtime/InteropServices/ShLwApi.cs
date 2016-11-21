using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public class ShLwApi
    {
        // #define LWSTDAPI_(type)   EXTERN_C DECLSPEC_IMPORT type STDAPICALLTYPE

        /// <summary>
        /// 「StrCmpLogicalW function」
        /// https://msdn.microsoft.com/ja-jp/library/windows/desktop/bb759947.aspx
        /// </summary>
        // LWSTDAPI_(int) StrCmpLogicalW(_In_ PCWSTR psz1, _In_ PCWSTR psz2);
        [DllImport(ShLwApi.DLL_NAME)]
        public static extern int StrCmpLogicalW([In]string psz1, [In]string psz2);

        #region Private members...
        
        /// <summary></summary>
        private const string DLL_NAME = @"shlwapi.dll";

        #endregion
    }
}