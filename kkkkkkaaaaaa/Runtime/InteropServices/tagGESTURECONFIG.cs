namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// /*
    ///  * Gesture configuration structure
    ///  *   - Used in SetGestureConfig and GetGestureConfig
    ///  *   - Note that any setting not included in either GESTURECONFIG.dwWant or
    ///  *     GESTURECONFIG.dwBlock will use the parent window's preferences or
    ///  *     system defaults.
    ///  */
    /// typedef struct tagGESTURECONFIG {
    ///     DWORD dwID;                     // gesture ID
    ///     DWORD dwWant;                   // settings related to gesture ID that are to be turned on
    ///     DWORD dwBlock;                  // settings related to gesture ID that are to be turned off
    /// } GESTURECONFIG, *PGESTURECONFIG;
    /// 
    /// https://msdn.microsoft.com/ja-jp/library/windows/desktop/dd353231%28v=vs.85%29.aspx
    /// </summary>
    public struct tagGESTURECONFIG
    {
        public uint dwID;       // gesture ID
        public uint dwWant;     // settings related to gesture ID that are to be turned on
        public uint dwBlock;    // settings related to gesture ID that are to be turned off
    }
}
