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
        /// <summary>
        /// 
        /// </summary>
        public _DUMMYUNIONNAME DUMMYUNIONNAME;
        /// <summary>
        /// 
        /// </summary>
        public uint dwPageSize;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr lpMinimumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public IntPtr lpMaximumApplicationAddress;
        /// <summary>
        /// 
        /// </summary>
        public uint dwActiveProcessorMask;
        /// <summary>
        /// 
        /// </summary>
        public uint dwNumberOfProcessors;
        /// <summary>
        /// 
        /// </summary>
        public uint dwProcessorType;
        /// <summary>
        /// 
        /// </summary>
        public uint dsAllocationGranularity;
        /// <summary>
        /// 
        /// </summary>
        public ushort wProcessorLevel;
        /// <summary>
        /// 
        /// </summary>
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
            /// <summary>
            /// 
            /// </summary>
            [Obsolete(@"Obsolete field...do not use")]
            [FieldOffset(0)]
            public uint dwOemId;
            /// <summary>
            /// 
            /// </summary>
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
                /// <summary>
                /// 
                /// </summary>
                public ushort wProcessorArchitecture;
                /// <summary>
                /// 
                /// </summary>
                public ushort wReserved;
            }
        }
    }
}