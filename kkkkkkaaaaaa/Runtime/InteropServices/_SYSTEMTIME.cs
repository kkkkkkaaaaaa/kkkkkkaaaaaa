using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct _SYSTEMTIME {
    ///     WORD wYear;
    ///     WORD wMonth;
    ///     WORD wDayOfWeek;
    ///     WORD wDay;
    ///     WORD wHour;
    ///     WORD wMinute;
    ///     WORD wSecond;
    ///     WORD wMilliseconds;
    /// } SYSTEMTIME, *PSYSTEMTIME, *LPSYSTEMTIME;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct _SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }
}
