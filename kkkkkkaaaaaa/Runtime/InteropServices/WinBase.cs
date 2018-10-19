using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class WinBase
    {
        public const int MAX_PATH = 260;

        public const uint DONT_RESOLVE_DLL_REFERENCES           = 0x00000001;
        public const uint LOAD_LIBRARY_AS_DATAFILE              = 0x00000002;
        public const uint LOAD_WITH_ALTERED_SEARCH_PATH         = 0x00000008;
        public const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL          = 0x00000010;
        public const uint LOAD_LIBRARY_AS_IMAGE_RESOURCE        = 0x00000020;
        public const uint LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE    = 0x00000040;
        public const uint LOAD_LIBRARY_REQUIRE_SIGNED_TARGET    = 0x00000080;

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER    = 0x00000100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS     = 0x00000200;
        public const uint FORMAT_MESSAGE_FROM_STRING        = 0x00000400;
        public const uint FORMAT_MESSAGE_FROM_HMODULE       = 0x00000800;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM        = 0x00001000;
        public const uint FORMAT_MESSAGE_ARGUMENT_ARRAY     = 0x00002000;
        public const uint FORMAT_MESSAGE_MAX_WIDTH_MASK     = 0x000000FF;
        
        /// <summary>
        /// #define INVALID_FILE_ATTRIBUTES ((DWORD)-1)
        /// </summary>
        public const int INVALID_FILE_ATTRIBUTES = -1;

        /// <summary>
        /// WINBASEAPI DWORD WINAPI GetFileAttributesW(__in LPCWSTR lpFileName);
        /// </summary>
        [DllImport(WinBase.DLL_NAME)]
        public static extern uint GetFileAttributes(string lpFileName);

        #region Private members...
        
        /// <summary>DLL 名。</summary>
        private const string DLL_NAME = @"kernel32.dll";

        #endregion

        /*
        パラメータ
        lpFileName
            ファイル名またはディレクトリ名を保持している、NULL で終わる文字列へのポインタを指定します。
            Windows NT/2000：この関数の ANSI 版では、名前は最大 MAX_PATH 文字に制限されています。この制限をほぼ 32,000 ワイド文字へ拡張するには、この関数の Unicode 版を呼び出し、パスの前に "\\?\" という接頭辞を追加してください。詳細については、MSDN ライブラリの「」（ファイル名の規則）を参照してください。
            Windows 95/98：文字列の長さは、最大 MAX_PATH 文字です。 

        戻り値
        関数が成功すると、指定したファイルまたはディレクトリの属性が返ります。
        関数が失敗すると、-1 が返ります。拡張エラー情報を取得するには、 関数を使います。
        
        WINBASEAPI
        DWORD
        WINAPI
        GetFileAttributesA(
            __in LPCSTR lpFileName
            );
        WINBASEAPI
        DWORD
        WINAPI
        GetFileAttributesW(
            __in LPCWSTR lpFileName
            );
        #ifdef UNICODE
        #define GetFileAttributes  GetFileAttributesW
        #else
        #define GetFileAttributes  GetFileAttributesA
        #endif // !UNICODE
        */
    }
}