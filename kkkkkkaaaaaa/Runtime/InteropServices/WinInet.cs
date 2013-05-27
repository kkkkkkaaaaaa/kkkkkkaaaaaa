using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class WinInet
    {
        public const int INTERNET_CONNECTION_MODEM = 0x01;
        public const int INTERNET_CONNECTION_LAN = 0x02;
        public const int INTERNET_CONNECTION_PROXY = 0x04;
        public const int INTERNET_CONNECTION_MODEM_BUSY = 0x08;     /* no longer used */
        public const int INTERNET_RAS_INSTALLED = 0x10;
        public const int INTERNET_CONNECTION_OFFLINE = 0x20;
        public const int INTERNET_CONNECTION_CONFIGURED = 0x40;

        /// <summary>
        /// INTERNETAPI_(BOOL) InternetGetConnectedState(
        ///     __out  LPDWORD  lpdwFlags,
        ///     __reserved DWORD    dwReserved);
        /// </summary>
        /// <param name="lpdwFlags"></param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        public static extern bool InternetGetConnectedState(int lpdwFlags, int dwReserved);

        /// <summary>
        /// INTERNETAPI_(BOOL)
        /// InternetGetConnectedStateExW(
        ///     __out_opt LPDWORD lpdwFlags,
        ///     __out_ecount_opt(dwBufLen) LPWSTR lpszConnectionName,
        ///     __in DWORD dwBufLen,
        ///     __reserved DWORD dwReserved
        ///     );
        /// </summary>
        /// <returns></returns>
        public static extern bool InternetGetConnectedStateEx(int lpdwFlags, StringBuilder lpszConnectionName, int dwBufLen, int dwReserved);

        /*
        INTERNETAPI_(BOOL)
        InternetGetConnectedStateExA(
            __out_opt LPDWORD lpdwFlags,
            __out_ecount_opt(dwBufLen) LPSTR lpszConnectionName,
            __in DWORD dwBufLen,
            __reserved DWORD dwReserved
            );

        INTERNETAPI_(BOOL)
        InternetGetConnectedStateExW(
            __out_opt LPDWORD lpdwFlags,
            __out_ecount_opt(dwBufLen) LPWSTR lpszConnectionName,
            __in DWORD dwBufLen,
            __reserved DWORD dwReserved
            );
        INTERNETAPI_(BOOL) InternetGetConnectedStateEx(
            __out LPDWORD lpdwFlags,
            __out_ecount_opt(dwNameLen) LPSTR lpszConnectionName,
            __in DWORD dwNameLen,
            __in DWORD dwReserved
            );

        // Flags for InternetGetConnectedState and Ex
        #define INTERNET_CONNECTION_MODEM           0x01
        #define INTERNET_CONNECTION_LAN             0x02
        #define INTERNET_CONNECTION_PROXY           0x04
        #define INTERNET_CONNECTION_MODEM_BUSY      0x08  /* no longer used *//*
        #define INTERNET_RAS_INSTALLED              0x10
        #define INTERNET_CONNECTION_OFFLINE         0x20
        #define INTERNET_CONNECTION_CONFIGURED      0x40
         */
    }
}
