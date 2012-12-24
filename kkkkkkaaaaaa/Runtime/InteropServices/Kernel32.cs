using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public class Kernel32
    {
        /// <summary>
        /// 「GetSystemInfo function (Windows)」
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724381.aspx
        /// 
        /// 「SYSTEM_INFO structure (Windows)」
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724958.aspx
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(@"kernel32.dll", SetLastError = true, BestFitMapping = true)]
        public static extern void GetSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// 「GetNativeSystemInfo function (Windows)」
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724340.aspx
        /// void WINAPI GetNativeSystemInfo(_Out_  LPSYSTEM_INFO lpSystemInfo);
        /// 
        /// #if _WIN32_WINNT >= 0x0501
        /// WINBASEAPI VOID WINAPI GetNativeSystemInfo(__out LPSYSTEM_INFO lpSystemInfo);
        /// #endif
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(@"kernel32.dll", SetLastError = true, BestFitMapping = true)]
        public static extern void GetNativeSystemInfo(ref SYSTEM_INFO lpSystemInfo);

        //[DllImport(@"kernel32.dll", SetLastError = true, BestFitMapping = true)]
        //public static extern uint GetLogicalProcessorInfomatiuon();

        /// <summary>
        /// 「IsWow64Process function (Windows)」
        /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms684139.aspx
        /// 
        /// BOOL WINAPI IsWow64Process(
        ///     _In_    HANDLE hProcess,
        ///     _Out_   PBOOL Wow64Process
        /// );
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Wow64Process"></param>
        /// <returns></returns>
        [DllImport(@"kernel32.dll", SetLastError = true)]
        public static extern int IsWow64Process(IntPtr hProcess, out IntPtr Wow64Process);
    }
}