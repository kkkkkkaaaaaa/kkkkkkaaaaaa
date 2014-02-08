using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class User32
    {
        /// <summary>
        /// FailOnFalse [gle] SetWindowPlacement(HWND hWnd, LPWINDOWPLACEMENT lpwndpl);
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        public static extern bool SetWindowPlacement(IntPtr hWnd, tagWINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// FailOnFalse [gle] GetWindowPlacement(HWND hWnd, [out] LPWINDOWPLACEMENT lpwndpl);
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, [In()] ref tagWINDOWPLACEMENT lpwndpl);

        #region Private members...

        /// <summary></summary>
        private const string DLL_NAME = @"User32.dll";

        #endregion
    }
}
