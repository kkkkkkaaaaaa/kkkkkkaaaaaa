namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef enum MONITOR_DPI_TYPE {
    ///     MDT_EFFECTIVE_DPI = 0,
    ///     MDT_ANGULAR_DPI = 1,
    ///     MDT_RAW_DPI = 2,
    ///     MDT_DEFAULT = MDT_EFFECTIVE_DPI
    /// } MONITOR_DPI_TYPE;
    /// </summary>
    public enum MONITOR_DPI_TYPE : int
    {
        MDT_EFFECTIVE_DPI = 0,
        MDT_ANGULAR_DPI = 1,
        MDT_RAW_DPI = 2,
        MDT_DEFAULT = MDT_EFFECTIVE_DPI,
    }
}
