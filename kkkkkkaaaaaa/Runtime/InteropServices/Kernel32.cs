using System;
using System.Runtime.InteropServices;
using System.Text;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public static class Kernel32
    {
        /// <summary>
        /// WINBASEAPI VOID WINAPI GetSystemInfo(__out LPSYSTEM_INFO lpSystemInfo);
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
        public static extern void GetSystemInfo(out _SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// #if _WIN32_WINNT >= 0x0501
        /// WINBASEAPI VOID WINAPI GetNativeSystemInfo(__out LPSYSTEM_INFO lpSystemInfo);
        /// #endif
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
        public static extern void GetNativeSystemInfo(out _SYSTEM_INFO lpSystemInfo);

        /// <summary>
        /// WINBASEAPI BOOL WINAPI GetLogicalProcessorInformation(__out_bcount_part_opt(*ReturnedLength, *ReturnedLength) PSYSTEM_LOGICAL_PROCESSOR_INFORMATION Buffer, __inout PDWORD ReturnedLength);
        /// </summary>
        /// <returns></returns>
        //[DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
        //public static extern uint GetLogicalProcessorInfomatiuon();

        /// <summary>
        /// #if _WIN32_WINNT >= 0x0501
        /// WINBASEAPI BOOL WINAPI IsWow64Process(__in  HANDLE hProcess, __out PBOOL Wow64Process);
        /// #endif // (_WIN32_WINNT >= 0x0501)
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Wow64Process"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true)]
        public static extern int IsWow64Process(IntPtr hProcess, out IntPtr Wow64Process);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpLibFileName"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern IntPtr LoadLibrary(string lpLibFileName);

        /// <summary>
        /// WINBASEAPI __out_opt HMODULE WINAPI LoadLibraryExW(__in LPCWSTR lpLibFileName, __reserved HANDLE hFile, __in DWORD dwFlags);
        /// </summary>
        /// <param name="lpLibFileName"></param>
        /// <param name="hFile"></param>
        /// <param name="dwFlags"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadLibraryEx(string lpLibFileName, IntPtr hFile, uint dwFlags);

        /// <summary>
        /// WINBASEAPI __out_opt HMODULE WINAPI GetModuleHandleW(__in_opt LPCWSTR lpModuleName);
        /// </summary>
        /// <param name="lpModuleName"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// WINBASEAPI DWORD WINAPI GetModuleFileNameW(__in_opt HMODULE hModule, __out_ecount_part(nSize, return + 1) LPWSTR lpFilename, __in DWORD nSize);
        /// </summary>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern uint GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, uint nSize);

        /// <summary>
        /// WINBASEAPI BOOL WINAPI FreeLibrary (__in HMODULE hLibModule);
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern int FreeLibrary(IntPtr hLibModule);

        /// <summary>
        /// WINBASEAPI DECLSPEC_NORETURN VOID WINAPI ExitThread(__in DWORD dwExitCode);
        /// </summary>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern void ExitThread(uint dwExitCode);

        /*
        WINBASEAPI
        BOOL
        WINAPI
        TerminateThread(
            __in HANDLE hThread,
            __in DWORD dwExitCode
            );

        WINBASEAPI
        __success(return != 0)
        BOOL
        WINAPI
        GetExitCodeThread(
            __in  HANDLE hThread,
            __out LPDWORD lpExitCode
            );
         */

        /// <summary>
        /// WINBASEAPI DECLSPEC_NORETURN VOID WINAPI FreeLibraryAndExitThread (__in HMODULE hLibModule, __in DWORD dwExitCode);
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <param name="dwExitCode"></param>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern void FreeLibraryAndExitThread(IntPtr hLibModule, uint dwExitCode);

        /// <summary>
        /// WINBASEAPI FARPROC WINAPI GetProcAddress (__in HMODULE hModule, __in LPCSTR lpProcName);
        /// </summary>
        /// <param name="hModule"></param>
        /// <param name="lpProcName"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        /// <summary>
        /// WINBASEAPI VOID WINAPI SetLastError(__in DWORD dwErrCode);
        /// </summary>
        /// <param name="dwErrCode"></param>
        [DllImport(Kernel32.DLL_NAME)]
        public static extern void SetLastError(uint dwErrCode);

        /// <summary>
        /// #ifdef _M_CEE_PURE
        /// #define GetLastError System::Runtime::InteropServices::Marshal::GetLastWin32Error
        /// #else
        /// WINBASEAPI __checkReturn DWORD WINAPI GetLastError(VOID);
        /// #endif
        /// </summary>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME, SetLastError = false)]
        public static extern uint GetLastError();

        #region Private members...

        /// <summary>アンマネージメソッドを格納する DLL の名前。</summary>
        private const string DLL_NAME = @"kernel32.dll";

        #endregion
    }
}