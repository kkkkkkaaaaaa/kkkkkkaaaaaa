using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class WinBase
    {
        public const int MAX_PATH = 260;

        public const uint DONT_RESOLVE_DLL_REFERENCES = 0x00000001;
        public const uint LOAD_LIBRARY_AS_DATAFILE = 0x00000002;
        public const uint LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008;
        public const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010;
        public const uint LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020;
        public const uint LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040;
        public const uint LOAD_LIBRARY_REQUIRE_SIGNED_TARGET = 0x00000080;

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        public const uint FORMAT_MESSAGE_FROM_STRING = 0x00000400;
        public const uint FORMAT_MESSAGE_FROM_HMODULE = 0x00000800;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
        public const uint FORMAT_MESSAGE_ARGUMENT_ARRAY = 0x00002000;
        public const uint FORMAT_MESSAGE_MAX_WIDTH_MASK = 0x000000FF;

        #region Logon types...

        #endregion

        /// <summary>
        /// このログオンタイプは、コンピュータを対話形式で使うユーザーを想定しています。
        /// ターミナルサーバー、リモートシェル、または同様のプロセスを使ってログオンを行うユーザーが、これに該当します。
        /// 切断された動作に関係するログオン情報をキャッシュに入れる作業が増えるので、メールサーバーといった特定のクライアント／サーバーアプリケーションには適していません。
        /// </summary>
        public const uint LOGON32_LOGON_INTERACTIVE = 2;

        /// <summary>
        /// このログオンタイプは、平文パスワード認証する高性能サーバーを想定しています。
        /// LogonUser 関数は、このログオンタイプのアカウント情報をキャッシュに入れません。
        /// これは最も高速なログオンパスですが、２つの制約があります。
        /// 
        /// 第一に、この関数はプライマリトークンではなく偽装トークンを返します。
        /// CreateProcessAsUser 関数内では、このトークンを直接利用できません。
        /// 代わりに、DuplicateTokenEx 関数を呼び出してこのトークンをプライマリトークンへ変換し、次に CreateProcessAsUser 関数でそのトークンを利用できます。
        /// 
        /// 第二に、偽装トークンをプライマリトークンへ変換して CreateProcessAsUser 関数で利用してプロセスを開始すると、新しいプロセスはリダイレクタ経由でリモートサーバーやリモートプリンタなどの他のネットワーク資源を利用できません。
        /// </summary>
        public const uint LOGON32_LOGON_NETWORK = 3;

        /// <summary>
        /// このログオンタイプは、ユーザーが直接操作する代わりにプロセスが処理を行うバッチサーバー、またはメールサーバーや Web サーバーのように平文認証を一度に数多く処理する高性能サーバーを想定しています。
        /// LogonUser 関数はこのログオンタイプのアカウント情報（認証証明）をキャッシュに入れません。
        /// </summary>
        public const uint LOGON32_LOGON_BATCH = 4;

        /// <summary>
        /// サービスタイプのログオンを示します。
        /// 提供されるアカウントでは、サービス特権を有効にしておかなければなりません。
        /// </summary>
        public const uint LOGON32_LOGON_SERVICE = 5;

        /// <summary>
        /// GINAs are no longer supported.
        /// Windows Server 2003 and Windows XP:  This logon type is for GINA DLLs that log on users who will be interactively using the computer.
        /// This logon type can generate a unique audit record that shows when the workstation was unlocked.
        /// </summary>
        public const uint LOGON32_LOGON_UNLOCK = 7;

        /// <summary>
        /// This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client.
        /// A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers.
        /// </summary>
        public const uint LOGON32_LOGON_NETWORK_CLEARTEXT = 8;

        /// <summary>
        /// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
        /// The new logon session has the same local identifier but uses different credentials for other network connections.
        /// This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
        /// </summary>
        public const uint LOGON32_LOGON_NEW_CREDENTIALS = 9;


        #region Login providers...

        #endregion

        /// <summary>
        /// システム標準のログオンプロバイダを使います。
        /// これは、dwLogonProvider パラメータの推奨値です。
        /// Windows NT、Windows 2000 の現在、および将来のリリースに対する最大の互換性を提供します。
        /// </summary>
        public const uint LOGON32_PROVIDER_DEFAULT = 0;

        /// <summary>
        /// Windows NT 3.5 のログオンプロバイダを使います。
        /// </summary>
        public const uint LOGON32_PROVIDER_WINNT35 = 1;

        /// <summary>
        /// Windows NT 4.0 のログオンプロバイダを使います。
        /// </summary>
        public const uint LOGON32_PROVIDER_WINNT40 = 2;

        /// <summary>
        /// Windows 2000 のログオンプロバイダを使います。
        /// </summary>
        public const uint LOGON32_PROVIDER_WINNT50 = 3;

        /// <summary></summary>
        public const uint LOGON32_PROVIDER_VIRTUAL = 4;

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
