using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct _SYSTEM_INFO {
    ///     union {
    ///         DWORD dwOemId;          // Obsolete field...do not use
    ///         struct {
    ///             WORD wProcessorArchitecture;
    ///             WORD wReserved;
    ///         } DUMMYSTRUCTNAME;
    ///     } DUMMYUNIONNAME;
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
    public struct _SYSTEM_INFO
    {
        public _DUMMYUNIONNAME DUMMYUNIONNAME;
        public uint dwPageSize;
        public IntPtr lpMinimumApplicationAddress;
        public IntPtr lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;
        public uint dwNumberOfProcessors;
        public uint dwProcessorType;
        public uint dsAllocationGranularity;
        public ushort wProcessorLevel;
        public ushort wProcessorRevision;

        /// <summary>
        /// union {
        ///     DWORD dwOemId;          // Obsolete field...do not use
        ///     struct {
        ///         WORD wProcessorArchitecture;
        ///         WORD wReserved;
        ///     } DUMMYSTRUCTNAME;
        /// } DUMMYUNIONNAME;
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct _DUMMYUNIONNAME
        {
            [Obsolete(@"Obsolete field...do not use")]
            [FieldOffset(0)]
            public uint dwOemId;
            [FieldOffset(0)]
            public _DUMMYSTRUCTNAME DUMMYSTRUCTNAME;

            /// <summary>
            /// struct {
            ///     WORD wProcessorArchitecture;
            ///     WORD wReserved;
            /// } DUMMYSTRUCTNAME;
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct _DUMMYSTRUCTNAME
            {
                public ushort wProcessorArchitecture;
                public ushort wReserved;
            }
        }
    }
}