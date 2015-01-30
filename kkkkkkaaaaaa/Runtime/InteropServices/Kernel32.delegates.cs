namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="info"></param>
    public delegate void GetNativeSystemInfo(out _SYSTEM_INFO info);

    // http://support.microsoft.com/kb/175030/ja
    /*
この関数を使用する場合、次のようにコールバック関数を宣言します。

BOOL CALLBACK Proc( DWORD dw, WORD w16, LPCSTR lpstr, LPARAM lParam );
     */
}