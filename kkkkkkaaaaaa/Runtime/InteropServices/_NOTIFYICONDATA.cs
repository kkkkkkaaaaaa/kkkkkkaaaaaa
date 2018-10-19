namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public class _NOTIFYICONDATA
    {
        /*
        
         https://msdn.microsoft.com/ja-jp/library/windows/desktop/bb773352(v=vs.85).aspx
         typedef struct _NOTIFYICONDATAA {
            DWORD cbSize;
            HWND hWnd;
            UINT uID;
            UINT uFlags;
            UINT uCallbackMessage;
            HICON hIcon;
        #if (NTDDI_VERSION < NTDDI_WIN2K)
            CHAR   szTip[64];
        #endif
        #if (NTDDI_VERSION >= NTDDI_WIN2K)
            CHAR   szTip[128];
            DWORD dwState;
            DWORD dwStateMask;
            CHAR   szInfo[256];
        #ifndef _SHELL_EXPORTS_INTERNALAPI_H_
            union {
                UINT  uTimeout;
                UINT  uVersion;  // used with NIM_SETVERSION, values 0, 3 and 4
            } DUMMYUNIONNAME;
        #endif
            CHAR   szInfoTitle[64];
            DWORD dwInfoFlags;
        #endif
        #if (NTDDI_VERSION >= NTDDI_WINXP)
            GUID guidItem;
        #endif
        #if (NTDDI_VERSION >= NTDDI_VISTA)
            HICON hBalloonIcon;
        #endif
        } NOTIFYICONDATAA, *PNOTIFYICONDATAA;
        typedef struct _NOTIFYICONDATAW {
            DWORD cbSize;
            HWND hWnd;
            UINT uID;
            UINT uFlags;
            UINT uCallbackMessage;
            HICON hIcon;
        #if (NTDDI_VERSION < NTDDI_WIN2K)
            WCHAR  szTip[64];
        #endif
        #if (NTDDI_VERSION >= NTDDI_WIN2K)
            WCHAR  szTip[128];
            DWORD dwState;
            DWORD dwStateMask;
            WCHAR  szInfo[256];
        #ifndef _SHELL_EXPORTS_INTERNALAPI_H_
            union {
                UINT  uTimeout;
                UINT  uVersion;  // used with NIM_SETVERSION, values 0, 3 and 4
            } DUMMYUNIONNAME;
        #endif
            WCHAR  szInfoTitle[64];
            DWORD dwInfoFlags;
        #endif
        #if (NTDDI_VERSION >= NTDDI_WINXP)
            GUID guidItem;
        #endif
        #if (NTDDI_VERSION >= NTDDI_VISTA)
            HICON hBalloonIcon;
        #endif
        } NOTIFYICONDATAW, *PNOTIFYICONDATAW;
        #ifdef UNICODE
        typedef NOTIFYICONDATAW NOTIFYICONDATA;
        typedef PNOTIFYICONDATAW PNOTIFYICONDATA;
        #else
        typedef NOTIFYICONDATAA NOTIFYICONDATA;
        typedef PNOTIFYICONDATAA PNOTIFYICONDATA;
        #endif // UNICODE

         */
    }
}