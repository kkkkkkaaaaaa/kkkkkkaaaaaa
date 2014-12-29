namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class WinError
    {
        /// <summary>
        /// // The operation completed successfully.
        /// #define ERROR_SUCCESS                    0L
        /// </summary>
        public const int ERROR_SUCCESS = 0;

        /// <summary>
        /// // The specified procedure could not be found.;
        /// #define ERROR_PROC_NOT_FOUND             127L
        /// </summary>
        public const int ERROR_PROC_NOT_FOUND = 127;

        #region HRESULT
        // http://msdn.microsoft.com/en-us/library/windows/desktop/aa378137.aspx

        /// <summary>
        /// #define S_OK                                   ((HRESULT)0L)
        /// </summary>
        public const int S_OK = 0;

        /// <summary>
        /// #define S_FALSE                                ((HRESULT)1L)
        /// </summary>
        public const uint S_FALSE = 1;

        /// <summary>
        /// // One or more arguments are invalid
        /// #define E_INVALIDARG                     _HRESULT_TYPEDEF_(0x80070057L)
        /// </summary>
        public const uint E_INVALIDARG = 0x80070057;

        /*
        //
        // MessageId: E_NOTIMPL
        //
        // MessageText:
        //
        // Not implemented
        //
        #define E_NOTIMPL                        _HRESULT_TYPEDEF_(0x80004001L)

        //
        // MessageId: E_OUTOFMEMORY
        //
        // MessageText:
        //
        // Ran out of memory
        //
        #define E_OUTOFMEMORY                    _HRESULT_TYPEDEF_(0x8007000EL)

        //
        // MessageId: E_INVALIDARG
        //
        // MessageText:
        //
        // One or more arguments are invalid
        //
        #define E_INVALIDARG                     _HRESULT_TYPEDEF_(0x80070057L)

        //
        // MessageId: E_NOINTERFACE
        //
        // MessageText:
        //
        // No such interface supported
        //
        #define E_NOINTERFACE                    _HRESULT_TYPEDEF_(0x80004002L)

        //
        // MessageId: E_POINTER
        //
        // MessageText:
        //
        // Invalid pointer
        //
        #define E_POINTER                        _HRESULT_TYPEDEF_(0x80004003L)

        //
        // MessageId: E_HANDLE
        //
        // MessageText:
        //
        // Invalid handle
        //
        #define E_HANDLE                         _HRESULT_TYPEDEF_(0x80070006L)

        //
        // MessageId: E_ABORT
        //
        // MessageText:
        //
        // Operation aborted
        //
        #define E_ABORT                          _HRESULT_TYPEDEF_(0x80004004L)

        //
        // MessageId: E_FAIL
        //
        // MessageText:
        //
        // Unspecified error
        //
        #define E_FAIL                           _HRESULT_TYPEDEF_(0x80004005L)

        //
        // MessageId: E_ACCESSDENIED
        //
        // MessageText:
        //
        // General access denied error
        //
        #define E_ACCESSDENIED                   _HRESULT_TYPEDEF_(0x80070005L)
         */

        #endregion
    }
}