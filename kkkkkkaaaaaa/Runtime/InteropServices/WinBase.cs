namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public static class WinBase
    {
        public const uint DONT_RESOLVE_DLL_REFERENCES           = 0x00000001;
        public const uint LOAD_LIBRARY_AS_DATAFILE              = 0x00000002;
        public const uint LOAD_WITH_ALTERED_SEARCH_PATH         = 0x00000008;
        public const uint LOAD_IGNORE_CODE_AUTHZ_LEVEL          = 0x00000010;
        public const uint LOAD_LIBRARY_AS_IMAGE_RESOURCE        = 0x00000020;
        public const uint LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE    = 0x00000040;
        public const uint LOAD_LIBRARY_REQUIRE_SIGNED_TARGET    = 0x00000080;

        public const uint FORMAT_MESSAGE_ALLOCATE_BUFFER    = 0x00000100;
        public const uint FORMAT_MESSAGE_IGNORE_INSERTS     = 0x00000200;
        public const uint FORMAT_MESSAGE_FROM_STRING        = 0x00000400;
        public const uint FORMAT_MESSAGE_FROM_HMODULE       = 0x00000800;
        public const uint FORMAT_MESSAGE_FROM_SYSTEM        = 0x00001000;
        public const uint FORMAT_MESSAGE_ARGUMENT_ARRAY     = 0x00002000;
        public const uint FORMAT_MESSAGE_MAX_WIDTH_MASK     = 0x000000FF;
    }
}