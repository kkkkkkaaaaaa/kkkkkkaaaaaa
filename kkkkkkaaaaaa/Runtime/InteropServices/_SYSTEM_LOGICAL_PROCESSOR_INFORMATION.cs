namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef struct _SYSTEM_LOGICAL_PROCESSOR_INFORMATION {
    ///     ULONG_PTR   ProcessorMask;
    ///     LOGICAL_PROCESSOR_RELATIONSHIP Relationship;
    ///     union {
    ///         struct {
    ///             BYTE  Flags;
    ///         } ProcessorCore;
    ///         struct {
    ///             DWORD NodeNumber;
    ///         } NumaNode;
    ///         CACHE_DESCRIPTOR Cache;
    ///         ULONGLONG  Reserved[2];
    ///     };
    /// } SYSTEM_LOGICAL_PROCESSOR_INFORMATION, *PSYSTEM_LOGICAL_PROCESSOR_INFORMATION;
    /// </summary>
    public struct _SYSTEM_LOGICAL_PROCESSOR_INFORMATION
    {
        public uint ProcessorMask;
        //public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;
    }
}