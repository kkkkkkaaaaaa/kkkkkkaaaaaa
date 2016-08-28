namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct tagPOINTS {
    ///     SHORT x;
    ///     SHORT y;
    /// } POINTS, *PPOINTS, *LPPOINTS;
    /// 
    /// https://msdn.microsoft.com/en-us/library/windows/desktop/dd162808%28v=vs.85%29.aspx
    /// </summary>
    public struct tagPOINTS
    {
        public short x;
        public short y;
    }
}