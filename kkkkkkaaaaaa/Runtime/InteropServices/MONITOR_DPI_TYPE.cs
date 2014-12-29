namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef enum MONITOR_DPI_TYPE {
    ///     MDT_EFFECTIVE_DPI = 0,
    ///     MDT_ANGULAR_DPI = 1,
    ///     MDT_RAW_DPI = 2,
    ///     MDT_DEFAULT = MDT_EFFECTIVE_DPI
    /// } MONITOR_DPI_TYPE;
    /// http://msdn.microsoft.com/en-us/library/windows/desktop/dn280511.aspx
    /// </summary>
    public enum MONITOR_DPI_TYPE : int
    {
        /// <summary>
        /// 
        /// </summary>
        MDT_EFFECTIVE_DPI = 0,

        /// <summary>
        /// 
        /// </summary>
        MDT_ANGULAR_DPI = 1,

        /// <summary>
        /// 
        /// </summary>
        MDT_RAW_DPI = 2,

        /// <summary>
        /// 
        /// </summary>
        MDT_DEFAULT = MDT_EFFECTIVE_DPI,
    }
}
