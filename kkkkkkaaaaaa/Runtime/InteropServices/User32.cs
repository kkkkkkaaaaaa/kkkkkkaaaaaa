using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// user32.dll。
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// WINUSERAPI BOOL WINAPI GetWindowPlacement(_In_ HWND hWnd, _Inout_ WINDOWPLACEMENT *lpwndpl);
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref tagWINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// WINUSERAPI BOOL WINAPI SetWindowPlacement(_In_ HWND hWnd, _In_ CONST WINDOWPLACEMENT *lpwndpl);
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement(IntPtr hWnd, tagWINDOWPLACEMENT lpwndpl);

        /*
        WINUSERAPI
        HMONITOR
        WINAPI
        MonitorFromPoint(
            _In_ POINT pt,
            _In_ DWORD dwFlags);

        WINUSERAPI
        HMONITOR
        WINAPI
        MonitorFromRect(
            _In_ LPCRECT lprc,
            _In_ DWORD dwFlags);

        WINUSERAPI
        HMONITOR
        WINAPI
        MonitorFromWindow(
            _In_ HWND hwnd,
            _In_ DWORD dwFlags);
        */

        #region Private members...

        /// <summary></summary>
        private const string DLL_NAME = @"User32.dll";

        #endregion
    }
}
