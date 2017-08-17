namespace HQ.Runtime.InteropServices
{
    /// <summary>typedef enum _SECURITY_IMPERSONATION_LEVEL {
    ///     SecurityAnonymous,
    ///     SecurityIdentification,
    ///     SecurityImpersonation,
    ///     SecurityDelegation
    /// }
    /// SECURITY_IMPERSONATION_LEVEL, * PSECURITY_IMPERSONATION_LEVEL;
    /// 
    /// 「SECURITY_IMPERSONATION_LEVEL enumeration」
    /// https://msdn.microsoft.com/ja-jp/library/windows/desktop/aa379572(v=vs.85).aspx
    /// </summary>
    public enum _SECURITY_IMPERSONATION_LEVEL
    {
        /// <summary>
        /// 
        /// </summary>
        SecurityAnonymous = 0,

        /// <summary>
        /// 
        /// </summary>
        SecurityIdentification = 1,

        /// <summary>
        /// 
        /// </summary>
        SecurityImpersonation = 2,

        /// <summary>
        /// 
        /// </summary>
        SecurityDelegation = 3,
    }
}
