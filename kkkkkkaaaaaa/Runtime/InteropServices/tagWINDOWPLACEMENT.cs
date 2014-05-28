using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct tagWINDOWPLACEMENT {
    ///     UINT  length;
    ///     UINT  flags;
    ///     UINT  showCmd;
    ///     POINT ptMinPosition;
    ///     POINT ptMaxPosition;
    ///     RECT  rcNormalPosition;
    /// } WINDOWPLACEMENT, *LPWINDOWPLACEMENT;
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct tagWINDOWPLACEMENT
    {
        public uint length;
        public uint flags;
        public uint showCmd;
        public tagPOINT ptMinPosition;
        public tagPOINT ptMaxPosition;
        public tagRECT  rcNormalPosition;
    }
}
