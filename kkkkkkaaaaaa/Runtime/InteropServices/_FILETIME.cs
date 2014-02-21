namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct _FILETIME {
    ///     DWORD dwLowDateTime;
    ///     DWORD dwHighDateTime;
    /// } FILETIME, *PFILETIME, *LPFILETIME;
    /// </summary>
    public struct _FILETIME
    {
        public uint dwLowDateTime;
        public uint dwHighDateTime;
    }
}
