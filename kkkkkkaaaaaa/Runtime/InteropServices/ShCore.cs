using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public class ShCore
    {
        /// <summary>
        /// STDAPI GetDpiForMonitor(_In_ HMONITOR hmonitor, _In_ MONITOR_DPI_TYPE dpiType, _Out_ UINT *dpiX, _Out_ UINT *dpiY);
        /// </summary>
        [DllImport(ShCore.DLL_NAME)]
        public static extern uint GetDpiForMonitor(IntPtr hmonitor, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY);

        #region Private members...

        /// <summary>アンマネージメソッドを格納する DLL の名前。</summary>
        private const string DLL_NAME = @"SHCore.dll";

        #endregion
    }
}