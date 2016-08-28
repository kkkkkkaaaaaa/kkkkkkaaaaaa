using System;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// /*
    ///  * Gesture information structure
    ///  *   - Pass the HGESTUREINFO received in the WM_GESTURE message lParam into the
    ///  *     GetGestureInfo function to retrieve this information.
    ///  *   - If cbExtraArgs is non-zero, pass the HGESTUREINFO received in the WM_GESTURE
    ///  *     message lParam into the GetGestureExtraArgs function to retrieve extended
    ///  *     argument information.
    ///  */
    /// typedef struct tagGESTUREINFO {
    ///     UINT cbSize;                    // size, in bytes, of this structure (including variable length Args field)
    ///     DWORD dwFlags;                  // see GF_* flags
    ///     DWORD dwID;                     // gesture ID, see GID_* defines
    ///     HWND hwndTarget;                // handle to window targeted by this gesture
    ///     POINTS ptsLocation;             // current location of this gesture
    ///     DWORD dwInstanceID;             // internally used
    ///     DWORD dwSequenceID;             // internally used
    ///     ULONGLONG ullArguments;         // arguments for gestures whose arguments fit in 8 BYTES
    ///     UINT cbExtraArgs;               // size, in bytes, of extra arguments, if any, that accompany this gesture
    /// } GESTUREINFO, *PGESTUREINFO;
    /// typedef GESTUREINFO const * PCGESTUREINFO;
    /// 
    /// https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd353232%28v=vs.85%29.aspx
    /// </summary>
    public struct tagGESTUREINFO
    {
        public uint cbSize;             // size, in bytes, of this structure (including variable length Args field)
        public uint dwFlags;            // see GF_* flags
        public uint dwID;               // gesture ID, see GID_* defines
        public IntPtr hwndTarget;       // handle to window targeted by this gesture
        public tagPOINTS ptsLocation;   // current location of this gesture
        public uint dwInstanceID;       // internally used
        public uint dwSequenceID;       // internally used
        public ulong ullArguments;      // arguments for gestures whose arguments fit in 8 BYTES
        public uint cbExtraArgs;        // size, in bytes, of extra arguments, if any, that accompany this gesture
    }
}