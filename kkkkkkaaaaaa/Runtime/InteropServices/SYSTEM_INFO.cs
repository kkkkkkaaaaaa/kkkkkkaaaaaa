using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 「SYSTEM_INFO structure (Windows)」
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/ms724958.aspx
    /// 
    /// typedef struct _SYSTEM_INFO {
    ///     union {
    ///         DWORD dwOemId;                      // Obsolete field...do not use
    ///         struct {
    ///             WORD wProcessorArchitecture;
    ///             WORD wReserved;
    ///         };
    ///     };
    ///     DWORD dwPageSize;
    ///     LPVOID lpMinimumApplicationAddress;
    ///     LPVOID lpMaximumApplicationAddress;
    ///     DWORD_PTR dwActiveProcessorMask;
    ///     DWORD dwNumberOfProcessors;
    ///     DWORD dwProcessorType;
    ///     DWORD dwAllocationGranularity;
    ///     WORD wProcessorLevel;
    ///     WORD wProcessorRevision;
    /// } SYSTEM_INFO, *LPSYSTEM_INFO;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        //public uint dwOemId;
        public ushort wProcessorArchitecture;
        public ushort wReserved;
        public uint dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public IntPtr dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dsAllocationGranularity;
        public ushort wProcessorLevel;
        public ushort wProcessorRevision;
    }
}