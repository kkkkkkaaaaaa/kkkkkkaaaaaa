namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct tagRECT
    /// {
    ///     LONG    left;
    ///     LONG    top;
    ///     LONG    right;
    ///     LONG    bottom;
    /// } RECT, *PRECT, NEAR *NPRECT, FAR *LPRECT;
    /// </summary>
    public struct tagRECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
}
