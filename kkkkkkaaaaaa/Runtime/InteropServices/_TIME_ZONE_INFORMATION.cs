using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct _TIME_ZONE_INFORMATION {
    ///     LONG Bias;
    ///     WCHAR StandardName[ 32 ];
    ///     SYSTEMTIME StandardDate;
    ///     LONG StandardBias;
    ///     WCHAR DaylightName[ 32 ];
    ///     SYSTEMTIME DaylightDate;
    ///     LONG DaylightBias;
    /// } TIME_ZONE_INFORMATION, *PTIME_ZONE_INFORMATION, *LPTIME_ZONE_INFORMATION;
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct _TIME_ZONE_INFORMATION
    {
        public int Bias;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string StandardName;
        public _SYSTEMTIME StandardDate;
        public int StandardBias;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DaylightName;
        public _SYSTEMTIME DaylightDate;
        public int DaylightBias;
    }
}
