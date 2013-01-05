namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    // http://msdn.microsoft.com/en-us/library/aa383745%28v=vs.85%29.aspx
    // https://docs.google.com/spreadsheet/ccc?key=0ArV2XEi4eBdpcEs1Q0VjZEc5R1lHZU83SzJkbUVjQmc#gid=0
    // http://msdn.microsoft.com/ja-jp/library/0t2cwe11.aspx#cpcondefaultmarshalingforvaluetypesanchor2
    // http://msdn.microsoft.com/ja-jp/library/windows/desktop/ms724340%28v=vs.85%29.aspx
    // http://msdn.microsoft.com/ja-jp/library/windows/desktop/ms724958%28v=vs.85%29.aspx
    // http://msdn.microsoft.com/en-us/library/cc953fe1.aspx
    // http://msdn.microsoft.com/en-us/library/2e6a4at9.aspx
    // http://msdn.microsoft.com/en-us/library/s3f49ktz.aspx
    // http://msdn.microsoft.com/en-us/library/aa383710
    // http://msdn.microsoft.com/ja-jp/library/0t2cwe11.aspx#cpcondefaultmarshalingforvaluetypesanchor2
    // http://msdn.microsoft.com/en-us/library/aa383745%28v=vs.85%29.aspx
    // 

    // http://msdn.microsoft.com/en-us/library/aa383751
    // http://msdn.microsoft.com/ja-jp/library/ac7ay120.aspx


    // http://msdn.microsoft.com/ja-jp/library/26thfadc%28v=vs.90%29.aspx
    // 
    // 
    // 「Win32 APIやDLL関数を呼び出すには？」
    // http://www.atmarkit.co.jp/fdotnet/dotnettips/024w32api/w32api.html
    // 
    // 「Win32 APIやDLL関数に構造体を渡すには？」
    // http://www.atmarkit.co.jp/fdotnet/dotnettips/026w32struct/w32struct.html
    // 
    // 「型」
    // http://wiki.sh4e.net/?%B7%BF
    // 
    // 「Win32APIを呼び出す」
    // http://www.orangemaker.sakura.ne.jp/labo/memo/CSharp-DotNet/win32Api.html
    // http://msdn.microsoft.com/ja-jp/library/ms172270%28v=vs.90%29.aspx
    // http://msdn.microsoft.com/ja-jp/library/e765dyyy%28v=vs.90%29.aspx
    public static class WinNT
    {
        public const ushort PROCESSOR_ARCHITECTURE_INTEL            = 0;
        public const ushort PROCESSOR_ARCHITECTURE_MIPS             = 1;
        public const ushort PROCESSOR_ARCHITECTURE_ALPHA            = 2;
        public const ushort PROCESSOR_ARCHITECTURE_PPC              = 3;
        public const ushort PROCESSOR_ARCHITECTURE_SHX              = 4;
        public const ushort PROCESSOR_ARCHITECTURE_ARM              = 5;
        public const ushort PROCESSOR_ARCHITECTURE_IA64             = 6;
        public const ushort PROCESSOR_ARCHITECTURE_ALPHA64          = 7;
        public const ushort PROCESSOR_ARCHITECTURE_MSIL             = 8;
        public const ushort PROCESSOR_ARCHITECTURE_AMD64            = 9;
        public const ushort PROCESSOR_ARCHITECTURE_IA32_ON_WIN64    = 10;
        public const ushort PROCESSOR_ARCHITECTURE_UNKNOWN          = 0xFFFF;

        public const uint PROCESSOR_INTEL_386       = 386;
        public const uint PROCESSOR_INTEL_486       = 486;
        public const uint PROCESSOR_INTEL_PENTIUM   = 586;
        public const uint PROCESSOR_INTEL_IA64      = 2200;
        public const uint PROCESSOR_AMD_X8664       = 8664;
        public const uint PROCESSOR_MIPS_R4000      = 4000;    // incl R4101 & R3910 for Windows CE
        public const uint PROCESSOR_ALPHA_21064     = 21064;
        public const uint PROCESSOR_PPC_601         = 601;
        public const uint PROCESSOR_PPC_603         = 603;
        public const uint PROCESSOR_PPC_604         = 604;
        public const uint PROCESSOR_PPC_620         = 620;
        public const uint PROCESSOR_HITACHI_SH3     = 10003;   // Windows CE
        public const uint PROCESSOR_HITACHI_SH3E    = 10004;   // Windows CE
        public const uint PROCESSOR_HITACHI_SH4     = 10005;   // Windows CE
        public const uint PROCESSOR_MOTOROLA_821    = 821;     // Windows CE
        public const uint PROCESSOR_SHx_SH3         = 103;     // Windows CE
        public const uint PROCESSOR_SHx_SH4         = 104;     // Windows CE
        public const uint PROCESSOR_STRONGARM       = 2577;    // Windows CE - 0xA11
        public const uint PROCESSOR_ARM720          = 1824;    // Windows CE - 0x720
        public const uint PROCESSOR_ARM820          = 2080;    // Windows CE - 0x820
        public const uint PROCESSOR_ARM920          = 2336;    // Windows CE - 0x920
        public const uint PROCESSOR_ARM_7TDMI       = 70001;   // Windows CE
        public const uint PROCESSOR_OPTIL           = 0x494f;  // MSIL

        public const uint FILE_ATTRIBUTE_READONLY               = 0x00000001;
        public const uint FILE_ATTRIBUTE_HIDDEN                 = 0x00000002;
        public const uint FILE_ATTRIBUTE_SYSTEM                 = 0x00000004;
        public const uint FILE_ATTRIBUTE_DIRECTORY              = 0x00000010;
        public const uint FILE_ATTRIBUTE_ARCHIVE                = 0x00000020;
        public const uint FILE_ATTRIBUTE_DEVICE                 = 0x00000040;
        public const uint FILE_ATTRIBUTE_NORMAL                 = 0x00000080;
        public const uint FILE_ATTRIBUTE_TEMPORARY              = 0x00000100;
        public const uint FILE_ATTRIBUTE_SPARSE_FILE            = 0x00000200;
        public const uint FILE_ATTRIBUTE_REPARSE_POINT          = 0x00000400;
        public const uint FILE_ATTRIBUTE_COMPRESSED             = 0x00000800;
        public const uint FILE_ATTRIBUTE_OFFLINE                = 0x00001000;
        public const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED    = 0x00002000;
        public const uint FILE_ATTRIBUTE_ENCRYPTED              = 0x00004000;
        public const uint FILE_ATTRIBUTE_VIRTUAL                = 0x00010000;
    }
}