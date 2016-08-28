using System;
using System.Runtime.InteropServices;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public class WinUser
    {
        #region #if(WINVER >= 0x0601)

        public const uint WM_DPICHANGED = 0x02E0;

        #endregion

        #region ShowWindow() Commands

        public const uint SW_HIDE = 0;
        public const uint SW_SHOWNORMAL = 1;
        public const uint SW_NORMAL = 1;
        public const uint SW_SHOWMINIMIZED = 2;
        public const uint SW_SHOWMAXIMIZED = 3;
        public const uint SW_MAXIMIZE = 3;
        public const uint SW_SHOWNOACTIVATE = 4;
        public const uint SW_SHOW = 5;
        public const uint SW_MINIMIZE = 6;
        public const uint SW_SHOWMINNOACTIVE = 7;
        public const uint SW_SHOWNA = 8;
        public const uint SW_RESTORE = 9;
        public const uint SW_SHOWDEFAULT = 10;
        public const uint SW_FORCEMINIMIZE = 11;
        public const uint SW_MAX = 11;
        
        #endregion

        #region Multimonitor API.

        public const uint MONITOR_DEFAULTTONULL = 0x00000000;
        public const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001;
        public const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

        #endregion

        #region Gesture flags - GESTUREINFO.dwFlags

        /// <summary>
        /// #define GF_BEGIN                        0x00000001
        /// </summary>
        public const uint GF_BEGIN = 0x00000001;
        /// <summary>
        /// #define GF_INERTIA                      0x00000002
        /// </summary>
        public const uint GF_INERTIA = 0x00000002;
        /// <summary>
        /// #define GF_END                          0x00000004
        /// </summary>
        public const uint GF_END = 0x00000004;

        #endregion

        #region Gesture IDs

        /// <summary>
        /// #define GID_BEGIN                       1
        /// </summary>
        public const uint GID_BEGIN = 1;
        /// <summary>
        /// #define GID_END                         2
        /// </summary>
        public const uint GID_END = 2;
        /// <summary>
        /// #define GID_ZOOM                        3
        /// </summary>
        public const uint GID_ZOOM = 3;
        /// <summary>
        /// #define GID_PAN                         4
        /// </summary>
        public const uint GID_PAN = 4;
        /// <summary>
        /// #define GID_ROTATE                      5
        /// </summary>
        public const uint GID_ROTATE = 5;
        /// <summary>
        /// #define GID_TWOFINGERTAP                6
        /// </summary>
        public const uint GID_TWOFINGERTAP = 6;
        /// <summary>
        /// #define GID_PRESSANDTAP                 7
        /// </summary>
        public const uint GID_PRESSANDTAP = 7;
        /// <summary>
        /// #define GID_ROLLOVER                    GID_PRESSANDTAP
        /// </summary>
        public const uint GID_ROLLOVER = GID_PRESSANDTAP;

        #endregion

        #region PressAndTap gesture configuration flags - set GESTURECONFIG.dwID to GID_PRESSANDTAP

        /// <summary>
        /// #define GC_PRESSANDTAP                              0x00000001
        /// </summary>
        public const uint GC_PRESSANDTAP = 0x00000001;
        /// <summary>
        /// #define GC_ROLLOVER                                 GC_PRESSANDTAP
        /// </summary>
        public const uint GC_ROLLOVER = GC_PRESSANDTAP;

        #endregion


        /// <summary>
        /// #define GESTURECONFIGMAXCOUNT           256
        /// 
        /// // Maximum number of gestures that can be included
        /// // in a single call to SetGestureConfig / GetGestureConfig</summary>
        public const uint GESTURECONFIGMAXCOUNT = 256;

        /// <summary>
        /// WINUSERAPI
        /// BOOL
        /// WINAPI
        /// SetGestureConfig(
        ///     _In_ HWND hwnd,                                     // window for which configuration is specified
        ///     _In_ DWORD dwReserved,                              // reserved, must be 0
        ///     _In_ UINT cIDs,                                     // count of GESTURECONFIG structures
        ///     _In_reads_(cIDs) PGESTURECONFIG pGestureConfig,    // array of GESTURECONFIG structures, dwIDs will be processed in the
        ///                                                         // order specified and repeated occurances will overwrite previous ones
        ///     _In_ UINT cbSize);                                  // sizeof(GESTURECONFIG)
        /// </summary>
        /// <param name="hwnd">window for which configuration is specified</param>
        /// <param name="dwReserved">reserved, must be 0</param>
        /// <param name="cIDs">count of GESTURECONFIG structures</param>
        /// <param name="pGestureConfig">
        /// array of GESTURECONFIG structures, dwIDs will be processed in the
        ///  order specified and repeated occurances will overwrite previous ones
        /// </param>
        /// <param name="cbSize">sizeof(GESTURECONFIG)</param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        public static extern bool SetGestureConfig(IntPtr hwnd, uint dwReserved, uint cIDs, tagGESTURECONFIG pGestureConfig, uint cbSize);

        /// <summary>
        /// #define GCF_INCLUDE_ANCESTORS           0x00000001
        /// // If specified, GetGestureConfig returns consolidated configuration
        /// // for the specified window and it's parent window chain
        /// </summary>
        public const uint GCF_INCLUDE_ANCESTORS = 0x00000001;

        /// <summary>
        /// WINUSERAPI
        /// BOOL
        /// WINAPI
        /// GetGestureConfig(
        ///     _In_ HWND hwnd,                                     // window for which configuration is required
        ///     _In_ DWORD dwReserved,                              // reserved, must be 0
        ///     _In_ DWORD dwFlags,                                 // see GCF_* flags
        ///     _In_ PUINT pcIDs,                                   // *pcIDs contains the size, in number of GESTURECONFIG structures,
        ///                                                         // of the buffer pointed to by pGestureConfig
        ///     _Inout_updates_(*pcIDs) PGESTURECONFIG pGestureConfig,
        ///                                                         // pointer to buffer to receive the returned array of GESTURECONFIG structures
        ///     _In_ UINT cbSize);                                  // sizeof(GESTURECONFIG)
        /// 
        /// https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd353234%28v=vs.85%29.aspx
        /// </summary>
        /// <param name="hwnd">window for which configuration is required</param>
        /// <param name="dwReserved">reserved, must be 0</param>
        /// <param name="dwFlags">see GCF_* flags</param>
        /// <param name="pcIDs">
        /// *pcIDs contains the size, in number of GESTURECONFIG structures, 
        /// of the buffer pointed to by pGestureConfig
        /// </param>
        /// <param name="pGestureConfig">pointer to buffer to receive the returned array of GESTURECONFIG structures</param>
        /// <param name="cbSize">sizeof(GESTURECONFIG)</param>
        /// <returns></returns>
        [DllImport(User32.DLL_NAME)]
        public static extern bool GetGestureConfig(IntPtr hwnd, uint dwReserved, uint dwFlags, UIntPtr pcIDs, tagGESTURECONFIG pGestureConfig, uint cbSize);

        // DefWindowProc
        // https://msdn.microsoft.com/en-us/library/ms633572.aspx
        
//#if(WINVER >= 0x0601)

        ///*
// * Gesture defines and functions
// */

//#pragma region Desktop Family
//#if WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP)

        ///*
// * Gesture information handle
// */
//DECLARE_HANDLE(HGESTUREINFO);

//#endif /* WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP) */
//#pragma endregion


        //#pragma region Desktop Family
//#if WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP)



        ///*
// * Gesture notification structure
// *   - The WM_GESTURENOTIFY message lParam contains a pointer to this structure.
// *   - The WM_GESTURENOTIFY message notifies a window that gesture recognition is
// *     in progress and a gesture will be generated if one is recognized under the
// *     current gesture settings.
// */
//typedef struct tagGESTURENOTIFYSTRUCT {
//    UINT cbSize;                    // size, in bytes, of this structure
//    DWORD dwFlags;                  // unused
//    HWND hwndTarget;                // handle to window targeted by the gesture
//    POINTS ptsLocation;             // starting location
//    DWORD dwInstanceID;             // internally used
//} GESTURENOTIFYSTRUCT, *PGESTURENOTIFYSTRUCT;

        ///*
// * Gesture argument helpers
// *   - Angle should be a double in the range of -2pi to +2pi
// *   - Argument should be an unsigned 16-bit value
// */
//#define GID_ROTATE_ANGLE_TO_ARGUMENT(_arg_)     ((USHORT)((((_arg_) + 2.0 * 3.14159265) / (4.0 * 3.14159265)) * 65535.0))
//#define GID_ROTATE_ANGLE_FROM_ARGUMENT(_arg_)   ((((double)(_arg_) / 65535.0) * 4.0 * 3.14159265) - 2.0 * 3.14159265)

        ///*
// * Gesture information retrieval
// *   - HGESTUREINFO is received by a window in the lParam of a WM_GESTURE message.
// */
//WINUSERAPI
//BOOL
//WINAPI
//GetGestureInfo(
//    _In_ HGESTUREINFO hGestureInfo,
//    _Out_ PGESTUREINFO pGestureInfo);

        ///*
// * Gesture extra arguments retrieval
// *   - HGESTUREINFO is received by a window in the lParam of a WM_GESTURE message.
// *   - Size, in bytes, of the extra argument data is available in the cbExtraArgs
// *     field of the GESTUREINFO structure retrieved using the GetGestureInfo function.
// */
//WINUSERAPI
//BOOL
//WINAPI
//GetGestureExtraArgs(
//    _In_ HGESTUREINFO hGestureInfo,
//    _In_ UINT cbExtraArgs,
//    _Out_writes_bytes_(cbExtraArgs) PBYTE pExtraArgs);

        ///*
// * Gesture information handle management
// *   - If an application processes the WM_GESTURE message, then once it is done
// *     with the associated HGESTUREINFO, the application is responsible for
// *     closing the handle using this function. Failure to do so may result in
// *     process memory leaks.
// *   - If the message is instead passed to DefWindowProc, or is forwarded using
// *     one of the PostMessage or SendMessage class of API functions, the handle
// *     is transfered with the message and need not be closed by the application.
// */
//WINUSERAPI
//BOOL
//WINAPI
//CloseGestureInfoHandle(
//    _In_ HGESTUREINFO hGestureInfo);



//#endif /* WINAPI_FAMILY_PARTITION(WINAPI_PARTITION_DESKTOP) */
//#pragma endregion

        ///*
// * Gesture configuration flags - GESTURECONFIG.dwWant or GESTURECONFIG.dwBlock
// */

        ///*
// * Common gesture configuration flags - set GESTURECONFIG.dwID to zero
// */
//#define GC_ALLGESTURES                              0x00000001

        ///*
// * Zoom gesture configuration flags - set GESTURECONFIG.dwID to GID_ZOOM
// */
//#define GC_ZOOM                                     0x00000001

        ///*
// * Pan gesture configuration flags - set GESTURECONFIG.dwID to GID_PAN
// */
//#define GC_PAN                                      0x00000001
//#define GC_PAN_WITH_SINGLE_FINGER_VERTICALLY        0x00000002
//#define GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY      0x00000004
//#define GC_PAN_WITH_GUTTER                          0x00000008
//#define GC_PAN_WITH_INERTIA                         0x00000010

        ///*
// * Rotate gesture configuration flags - set GESTURECONFIG.dwID to GID_ROTATE
// */
//#define GC_ROTATE                                   0x00000001

        ///*
// * Two finger tap gesture configuration flags - set GESTURECONFIG.dwID to GID_TWOFINGERTAP
// */
//#define GC_TWOFINGERTAP                             0x00000001


    }
}