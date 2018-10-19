using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class Shell32
    {
        // http://msdn.microsoft.com/ja-jp/library/windows/desktop/bb776911.aspx
        // http://msdn.microsoft.com/ja-jp/library/windows/desktop/bb762188.aspx
        // http://msdn.microsoft.com/ja-jp/library/windows/desktop/dd378457.aspx
        // http://msdn.microsoft.com/ja-jp/library/0t2cwe11.aspx
        
        /// <summary>
        /// STDAPI SHGetKnownFolderPath(_In_ REFKNOWNFOLDERID rfid, _In_ DWORD /* KNOWN_FOLDER_FLAG */ dwFlags, _In_opt_ HANDLE hToken, _Outptr_ PWSTR *ppszPath); // free *ppszPath with CoTaskMemFree
        /// </summary>
        /// <param name="rfid"></param>
        /// <param name="dwFlags"></param>
        /// <param name="hToken"></param>
        /// <param name="ppszPath"></param>
        [DllImport(DLL_NAME, PreserveSig = true)]
        // public static extern int SHGetKnownFolderPath(Guid rfid, KNOWN_FOLDER_FLAG dwFlags, IntPtr hToken, StringBuilder ppszPath);
        // public static extern int SHGetKnownFolderPath(Guid rfid, KNOWN_FOLDER_FLAG dwFlags, IntPtr hToken, out string ppszPath);
        public static extern int SHGetKnownFolderPath(Guid rfid, KNOWN_FOLDER_FLAG dwFlags, IntPtr hToken, out IntPtr ppszPath);

        // http://msdn.microsoft.com/ja-jp/library/windows/desktop/bb762181.aspx
        /*
        SHFOLDERAPI SHGetFolderPathW(
            _Reserved_ HWND hwnd,
            _In_ int csidl,
            _In_opt_ HANDLE hToken,
            _In_ DWORD dwFlags,
            _Out_writes_(MAX_PATH) LPWSTR pszPath
            );
        #define SHGetFolderPath  SHGetFolderPathW
         
        HRESULT SHGetFolderPath(
              _In_   HWND hwndOwner,
              _In_   int nFolder,
              _In_   HANDLE hToken,
              _In_   DWORD dwFlags,
              _Out_  LPTSTR pszPath
            );
         */

        /*
        SHSTDAPI_(BOOL) Shell_NotifyIconA(DWORD dwMessage, _In_ PNOTIFYICONDATAA lpData);
        SHSTDAPI_(BOOL) Shell_NotifyIconW(DWORD dwMessage, _In_ PNOTIFYICONDATAW lpData);
        #ifdef UNICODE
        #define Shell_NotifyIcon  Shell_NotifyIconW
        #else
        #define Shell_NotifyIcon  Shell_NotifyIconA
        #endif // !UNICODE
         */

        #region Private members...

        /// <summary>
        /// #ifdef INITGUID&lt;br /&gt;
        /// #define DEFINE_KNOWN_FOLDER(name, l, w1, w2, b1, b2, b3, b4, b5, b6, b7, b8) \&lt;br /&gt;
        ///         EXTERN_C const GUID DECLSPEC_SELECTANY name \&lt;br /&gt;
        ///                 = { l, w1, w2, { b1, b2,  b3,  b4,  b5,  b6,  b7,  b8 } }&lt;br /&gt;
        /// #else&lt;br /&gt;
        /// #define DEFINE_KNOWN_FOLDER(name, l, w1, w2, b1, b2, b3, b4, b5, b6, b7, b8) \&lt;br /&gt;
        ///         EXTERN_C const GUID name&lt;br /&gt;
        /// #endif // INITGUID
        /// </summary>
        /// <returns>FOLDERID_name</returns>
        private static Guid DEFINE_KNOWN_FOLDER(uint l, ushort w1, ushort w2, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7, byte b8)
        {
            return new Guid(l, w1, w2, b1, b2, b3, b4, b5, b6, b7, b8);
        }

        /// <summary>アンマネージメソッドを格納する DLL の名前。</summary>
        private const string DLL_NAME = @"shell32.dll";

        #endregion
    }
}
