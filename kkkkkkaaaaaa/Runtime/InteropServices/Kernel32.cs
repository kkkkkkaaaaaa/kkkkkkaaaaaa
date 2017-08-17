using System;
using System.Runtime.InteropServices;
using System.Text;

namespace kkkkkkaaaaaa.Runtime.InteropServices
{
	/// <summary>
	/// 
	/// </summary>
	public static class Kernel32
	{
		/// <summary>
		/// #define TIME_ZONE_ID_INVALID ((DWORD)0xFFFFFFFF)
		/// </summary>
		public const uint TIME_ZONE_ID_INVALID = 0xFFFFFFFF;

        /// <summary>
        /// Windows �̃V�X�e���f�B���N�g���̃p�X���擾���܂��B�V�X�e���f�B���N�g���ɂ́AWindows ���C�u�����A�h���C�o�Ȃǂ̃t�@�C�����u����Ă��܂��B
        /// 
        /// �uGetSystemDirectory�v
        /// https://msdn.microsoft.com/ja-jp/library/cc429803.aspx
        /// </summary>
        /// <param name="lpBuffer">
        /// 1 �̃o�b�t�@�ւ̃|�C���^���w�肵�܂��B
        /// �֐����琧�䂪�Ԃ�ƁA���̃o�b�t�@�ɁA�V�X�e���f�B���N�g���̃p�X����\���ANULL �ŏI��镶���񂪊i�[����܂��B
        /// ���Ƃ��΃V�X�e���f�B���N�g�����h���C�u C �� WINDOWS\SYSTEM �Ɩ�������Ă���ꍇ�A���̊֐����擾����V�X�e���f�B���N�g���̃p�X�́AC:\WINDOWS\SYSTEM �ł��B
        /// </param>
        /// <param name="uSize">
        /// �o�b�t�@�̃T�C�Y�� TCHAR �P�ʂŎw�肵�܂��B
        /// MAX_PATH �ȏ�̒l���w�肵�Ă��������B 
        /// </param>
        /// <returns>
        /// �֐�����������ƁAlpBuffer �o�b�t�@�ɏ������܂ꂽ�������i�I�[�� NULL �����������j�� TCHAR �P�ʂŕԂ�܂��B
        /// �p�X�����o�b�t�@�̃T�C�Y���������ꍇ�A�p�X���i�[���邽�߂ɕK�v�ȃo�b�t�@�̃T�C�Y�i�I�[�� NULL �������܂ށj���Ԃ�܂��B
        /// 
        /// �֐������s����ƁA0 ���Ԃ�܂��B�g���G���[�����擾����ɂ́A �֐����g���܂��B
        /// </returns>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true)]
        public static extern uint GetSystemDirectory([Out]StringBuilder lpBuffer, [In]int uSize);
        
        /// <summary>
        /// Windows �f�B���N�g���̃p�X���擾���܂��B
        /// Windows �f�B���N�g���ɂ́A�u�A�N�Z�T���v�̃A�v���P�[�V�����A.ini �t�@�C���A�w���v�t�@�C���Ȃǂ��z�u����Ă��܂��B
        /// 
        /// �uGetWindowsDirectory�v
        /// https://msdn.microsoft.com/ja-jp/library/cc429838.aspx
        /// </summary>
        /// <param name="lpBuffer">
        /// 1 �̃o�b�t�@�ւ̃|�C���^���w�肵�܂��B
        /// �֐����琧�䂪�Ԃ�ƁA���̃o�b�t�@�ɁAWindows �f�B���N�g���̃p�X����\���ANULL �ŏI��镶���񂪊i�[����܂��B
        /// Windows �f�B���N�g�����h���C�u�̃��[�g�f�B���N�g���łȂ�����A�~�L���i\�j�ŏI��邱�Ƃ͂���܂���B
        /// ���Ƃ��΁AWindows �f�B���N�g�����h���C�u C �� WINDOWS �Ɩ�������Ă���ꍇ�A���̊֐����擾���� Windows �f�B���N�g���̃p�X�́AC:\WINDOWS �ł��B
        /// �V�X�e�����h���C�u C �̃��[�g�f�B���N�g���ɃC���X�g�[������Ă���ꍇ�A���̊֐����擾����p�X�� C:\ �ł��B
        /// </param>
        /// <param name="uSize">
        /// lpBuffer �p�����[�^���w���o�b�t�@�̃T�C�Y�� TCHAR �P�ʂŎw�肵�܂��B
        /// �p�X���i�[���邽�߂̏\���ȃT�C�Y���m�ۂ��邽�߂� MAX_PATH ���w�肵�Ă��������B
        /// </param>
        /// <returns>
        /// �֐�����������ƁAlpBuffer �o�b�t�@�ɏ������܂ꂽ�������i�I�[�� NULL �����������j�� TCHAR �P�ʂŕԂ�܂��B
        /// �o�b�t�@�̃T�C�Y���s�����āA�p�X���̈ꕔ���i�[�ł��Ȃ������ꍇ�A�K�v�ȃo�b�t�@�̃T�C�Y�i�I�[�� NULL �������܂ށj���Ԃ�܂��B
        /// �֐������s����ƁA0 ���Ԃ�܂��B�g���G���[�����擾����ɂ́A �֐����g���܂��B
        /// </returns>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true)]
        public static extern uint GetWindowsDirectory([Out]StringBuilder lpBuffer, [In]uint uSize);

        /// <summary>
        /// WINBASEAPI VOID WINAPI GetSystemInfo(__out LPSYSTEM_INFO lpSystemInfo);
        /// </summary>
        /// <param name="lpSystemInfo"></param>
        [DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
		public static extern void GetSystemInfo(out _SYSTEM_INFO lpSystemInfo);

		/// <summary>
		/// #if _WIN32_WINNT >= 0x0501
		/// WINBASEAPI VOID WINAPI GetNativeSystemInfo(__out LPSYSTEM_INFO lpSystemInfo);
		/// #endif
		/// </summary>
		/// <param name="lpSystemInfo"></param>
		[DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
		public static extern void GetNativeSystemInfo(out _SYSTEM_INFO lpSystemInfo);

		/// <summary>
		/// WINBASEAPI BOOL WINAPI GetLogicalProcessorInformation(__out_bcount_part_opt(*ReturnedLength, *ReturnedLength) PSYSTEM_LOGICAL_PROCESSOR_INFORMATION Buffer, __inout PDWORD ReturnedLength);
		/// </summary>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME, SetLastError = true, BestFitMapping = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
        public static extern uint GetLogicalProcessorInfomatiuon([Out()]out _SYSTEM_LOGICAL_PROCESSOR_INFORMATION Buffer, out uint ReturnedLength);

		/// <summary>
		/// #if _WIN32_WINNT >= 0x0501
		/// WINBASEAPI BOOL WINAPI IsWow64Process(__in  HANDLE hProcess, __out PBOOL Wow64Process);
		/// #endif // (_WIN32_WINNT >= 0x0501)
		/// </summary>
		/// <param name="hProcess"></param>
		/// <param name="Wow64Process"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWow64Process([In()]IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)]out bool Wow64Process);

        /// <summary>
        /// �w�肳�ꂽ���s�\���W���[�����A�Ăяo�����v���Z�X�̃A�h���X��ԓ��Ƀ}�b�v���܂��B
        /// 
	    /// HMODULE LoadLibrary(
	    ///     LPCTSTR lpFileName   // ���W���[���̃t�@�C����
	    /// );
        /// </summary>
        /// <param name="lpLibFileName"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
		public static extern IntPtr LoadLibrary(string lpLibFileName);

		/// <summary>
		/// WINBASEAPI __out_opt HMODULE WINAPI LoadLibraryExW(__in LPCWSTR lpLibFileName, __reserved HANDLE hFile, __in DWORD dwFlags);
		/// </summary>
		/// <param name="lpLibFileName"></param>
		/// <param name="hFile"></param>
		/// <param name="dwFlags"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME, CharSet = CharSet.Auto)]
		public static extern IntPtr LoadLibraryEx(string lpLibFileName, IntPtr hFile, uint dwFlags);

		/// <summary>
		/// WINBASEAPI __out_opt HMODULE WINAPI GetModuleHandleW(__in_opt LPCWSTR lpModuleName);
		/// </summary>
		/// <param name="lpModuleName"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		/// <summary>
		/// WINBASEAPI DWORD WINAPI GetModuleFileNameW(__in_opt HMODULE hModule, __out_ecount_part(nSize, return + 1) LPWSTR lpFilename, __in DWORD nSize);
		/// </summary>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern uint GetModuleFileName(IntPtr hModule, StringBuilder lpFilename, uint nSize);

	    /// <summary>
	    /// �J���Ă���I�u�W�F�N�g�n���h������܂��B
	    /// 
	    /// 
	    /// WINBASEAPI
	    ///   BOOL
	    /// WINAPI
	    ///   CloseHandle(
	    ///     _In_ HANDLE hObject
	    /// );
	    /// </summary>
	    /// <param name="hObject">�I�u�W�F�N�g�̃n���h���B</param>
	    /// <returns>
	    /// �֐�����������ƁA0 �ȊO�̒l���Ԃ�܂��B
	    /// 
	    /// �֐������s����ƁA0 ���Ԃ�܂��B�g���G���[�����擾����ɂ́A �֐����g���܂��B
	    /// </returns>
	    [DllImport(Kernel32.DLL_NAME)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    public static extern bool CloseHandle([In()] IntPtr hObject);

        /// <summary>
        /// WINBASEAPI BOOL WINAPI FreeLibrary (__in HMODULE hLibModule);
        /// </summary>
        /// <param name="hLibModule"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
		[return : MarshalAs(UnmanagedType.Bool)]
		public static extern bool FreeLibrary(IntPtr hLibModule);

		/// <summary>
		/// WINBASEAPI DECLSPEC_NORETURN VOID WINAPI ExitThread(__in DWORD dwExitCode);
		/// </summary>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern void ExitThread(uint dwExitCode);

		/// <summary>
		/// WINBASEAPI __success(return != 0) BOOL WINAPI GetExitCodeThread(__in  HANDLE hThread, __out LPDWORD lpExitCode);
		/// </summary>
		/// <param name="hThread"></param>
		/// <param name="lpExitCode"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

		/// <summary>
		/// WINBASEAPI BOOL WINAPI TerminateThread(__in HANDLE hThread, __in DWORD dwExitCode);
		/// </summary>
		/// <param name="hThread"></param>
		/// <param name="dwExitCode"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool TerminateThread(IntPtr hThread, uint dwExitCode);

		/// <summary>
		/// WINBASEAPI DECLSPEC_NORETURN VOID WINAPI FreeLibraryAndExitThread (__in HMODULE hLibModule, __in DWORD dwExitCode);
		/// </summary>
		/// <param name="hLibModule"></param>
		/// <param name="dwExitCode"></param>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern void FreeLibraryAndExitThread(IntPtr hLibModule, uint dwExitCode);

		/// <summary>
		/// WINBASEAPI FARPROC WINAPI GetProcAddress (__in HMODULE hModule, __in LPCSTR lpProcName);
		/// </summary>
		/// <param name="hModule"></param>
		/// <param name="lpProcName"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

		/// <summary>
		/// WINBASEAPI VOID WINAPI SetLastError(__in DWORD dwErrCode);
		/// </summary>
		/// <param name="dwErrCode"></param>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern void SetLastError(uint dwErrCode);

		/// <summary>
		/// #ifdef _M_CEE_PURE
		/// #define GetLastError System::Runtime::InteropServices::Marshal::GetLastWin32Error
		/// #else
		/// WINBASEAPI __checkReturn DWORD WINAPI GetLastError(VOID);
		/// #endif
		/// </summary>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME, SetLastError = false)]
		public static extern uint GetLastError();

		/// <summary>
		/// WINBASEAPI DWORD WINAPI FormatMessageW(__in DWORD dwFlags, __in_opt LPCVOID lpSource, __in DWORD dwMessageId, __in DWORD dwLanguageId, __out LPWSTR lpBuffer, __in DWORD nSize, __in_opt va_list *Arguments);
		/// </summary>
		/// <param name="dwFlags"></param>
		/// <param name="lpSource"></param>
		/// <param name="dwMessageId"></param>
		/// <param name="dwLanguageId"></param>
		/// <param name="lpBuffer"></param>
		/// <param name="nSize"></param>
		/// <param name="Arguments"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern uint FormatMessage(uint dwFlags, IntPtr lpSource, uint dwMessageId, uint dwLanguageId, out IntPtr lpBuffer, uint nSize, string[] Arguments);

		/// <summary>
		/// WINBASEAPI _Success_(return != FALSE) BOOL WINAPI SystemTimeToTzSpecificLocalTime(_In_opt_ CONST TIME_ZONE_INFORMATION * lpTimeZoneInformation, _In_ CONST SYSTEMTIME * lpUniversalTime, _Out_ LPSYSTEMTIME lpLocalTime);
		/// </summary>
		/// <param name="lpTimeZoneInformation"></param>
		/// <param name="lpUniversalTime"></param>
		/// <param name="lpLocalTime"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		[return : MarshalAs(UnmanagedType.Bool)]
		public static extern bool SystemTimeToTzSpecificLocalTime(_TIME_ZONE_INFORMATION lpTimeZoneInformation, _SYSTEMTIME lpUniversalTime, out _SYSTEMTIME lpLocalTime);

        /*
		WINBASEAPI
		_Success_(return != FALSE)
		BOOL
		WINAPI
		TzSpecificLocalTimeToSystemTime(
			_In_opt_ CONST TIME_ZONE_INFORMATION * lpTimeZoneInformation,
			_In_ CONST SYSTEMTIME * lpLocalTime,
			_Out_ LPSYSTEMTIME lpUniversalTime
			);
		*/

        /// <summary>
        /// WINBASEAPI _Success_(return != FALSE) BOOL WINAPI FileTimeToSystemTime(_In_ CONST FILETIME * lpFileTime, _Out_ LPSYSTEMTIME lpSystemTime);
        /// </summary>
        /// <param name="lpFileTime"></param>
        /// <param name="lpSystemTime"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileTimeToSystemTime([In()]ref _FILETIME lpFileTime, [Out()]out _SYSTEMTIME lpSystemTime);

        /// <summary>
        /// WINBASEAPI _Success_(return != FALSE) BOOL WINAPI SystemTimeToFileTime(_In_ CONST SYSTEMTIME * lpSystemTime);
        /// </summary>
        /// <param name="lpSystemTime"></param>
        /// <param name="lpFileTime"></param>
        /// <returns></returns>
	    [DllImport(Kernel32.DLL_NAME)]
	    [return: MarshalAs(UnmanagedType.Bool)]
	    public static extern bool SystemTimeToFileTime([In()]_SYSTEMTIME lpSystemTime, [Out()] _FILETIME lpFileTime);

        /*
		WINBASEAPI
		_Success_(return != TIME_ZONE_ID_INVALID)
		DWORD
		WINAPI
		GetTimeZoneInformation(
			_Out_ LPTIME_ZONE_INFORMATION lpTimeZoneInformation
			);
		*/

        /*
		WINBASEAPI
		BOOL
		WINAPI
		SetTimeZoneInformation(
			_In_ CONST TIME_ZONE_INFORMATION * lpTimeZoneInformation
			);
		*/


        /*
		// <expr> indicates whether normal post conditions apply to a function

		#define _Null_terminated_                 _SAL2_Source_(_Null_terminated_, (), _Null_terminated_impl_)
		#define _Success_(expr)                  _SAL2_Source_(_Success_, (expr), _Success_impl_(expr))

		#define _SAL2_Source_(Name, args, annotes) _SA_annotes3(SAL_name, #Name, "", "2") _GrouP_(annotes _SAL_nop_impl_)
		#define _SA_annotes3(n,pp1,pp2,pp3)    [SAL_annotes(Name=#n, p1=_SA_SPECSTRIZE(pp1), p2=_SA_SPECSTRIZE(pp2), p3=_SA_SPECSTRIZE(pp3))]

		#define _Success_impl_(expr)          [SA_Success(Condition=#expr)]
		#define _SA_SPECSTRIZE( x ) #x
		*/


        /// <summary>
        /// WINBASEAPI BOOL WINAPI SetDynamicTimeZoneInformation(_In_ CONST DYNAMIC_TIME_ZONE_INFORMATION * lpTimeZoneInformation);
        /// </summary>
        /// <param name="lpTimeZoneInformation"></param>
        /// <returns></returns>
        [DllImport(Kernel32.DLL_NAME)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDynamicTimeZoneInformation(_TIME_DYNAMIC_ZONE_INFORMATION lpTimeZoneInformation);

		/// <summary>
		/// WINBASEAPI _Success_(return != TIME_ZONE_ID_INVALID) DWORD WINAPI GetDynamicTimeZoneInformation(_Out_ PDYNAMIC_TIME_ZONE_INFORMATION pTimeZoneInformation);
		/// </summary>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		public static extern uint GetDynamicTimeZoneInformation(out _TIME_DYNAMIC_ZONE_INFORMATION pTimeZoneInformation);

		/// <summary>
		/// _Success_(return != FALSE) BOOL WINAPI GetTimeZoneInformationForYear(_In_ USHORT wYear, _In_opt_ PDYNAMIC_TIME_ZONE_INFORMATION pdtzi, _Out_ LPTIME_ZONE_INFORMATION ptzi);
		/// </summary>
		/// <param name="wYear"></param>
		/// <param name="pdtzi"></param>
		/// <param name="ptzi"></param>
		/// <returns></returns>
		[DllImport(Kernel32.DLL_NAME)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetTimeZoneInformationForYear(ushort wYear, _TIME_DYNAMIC_ZONE_INFORMATION pdtzi, out _TIME_ZONE_INFORMATION ptzi);


		/*
		WINBASEAPI
		_Success_(return == ERROR_SUCCESS)
		DWORD
		WINAPI
		GetDynamicTimeZoneInformationEffectiveYears(
			_In_ CONST PDYNAMIC_TIME_ZONE_INFORMATION lpTimeZoneInformation,
			_Out_ LPDWORD FirstYear,
			_Out_ LPDWORD LastYear
			);
		*/

		/*
		WINBASEAPI
		_Success_(return != FALSE)
		BOOL
		WINAPI
		SystemTimeToTzSpecificLocalTimeEx(
			_In_opt_ CONST DYNAMIC_TIME_ZONE_INFORMATION * lpTimeZoneInformation,
			_In_ CONST SYSTEMTIME * lpUniversalTime,
			_Out_ LPSYSTEMTIME lpLocalTime
			);
		*/

		/*
		WINBASEAPI
		_Success_(return != FALSE)
		BOOL
		WINAPI
		TzSpecificLocalTimeToSystemTimeEx(
			_In_opt_ CONST DYNAMIC_TIME_ZONE_INFORMATION * lpTimeZoneInformation,
			_In_ CONST SYSTEMTIME * lpLocalTime,
			_Out_ LPSYSTEMTIME lpUniversalTime
			);
		*/

		// http://support.microsoft.com/kb/175030/ja
		/* �ȉ��̃T���v�� �R�[�h�ł� PSAPI �֐��� ToolHelp32 �֐��� EnumProcs() �Ƃ��� 1 �̊֐��ɃJ�v�Z�������܂��B���̊֐��̓���́A�֐��ւ̃|�C���^���p�����[�^�Ƃ��Ďg�p���A�V�X�e�����̊e�v���Z�X�ɑ΂��� 1 �񂸂֐����J��Ԃ��Ăяo���Ƃ����_�ɂ����āAEnumWindows() �Ɏ��Ă��܂��B���̊֐��̐錾�͎��̂Ƃ���ł��B
		BOOL EnumProcesses( DWORD *lpidProcess, DWORD cb, DWORD *cbNeeded );
				
BOOL WINAPI EnumProcs( PROCENUMPROC lpProc, LPARAM lParam );
				

���̊֐����g�p����ꍇ�A���̂悤�ɃR�[���o�b�N�֐���錾���܂��B

BOOL CALLBACK Proc( DWORD dw, WORD w16, LPCSTR lpstr, LPARAM lParam );
				
		 */

        /*
        https://msdn.microsoft.com/ja-jp/library/windows/desktop/aa364991.aspx
        http://blogs.msdn.com/b/japan_platform_sdkwindows_sdk_support_team_blog/archive/2013/11/07/gettemppathname.aspx
        WINBASEAPI
        UINT
        WINAPI
        GetTempFileNameA(
            _In_ LPCSTR lpPathName,
            _In_ LPCSTR lpPrefixString,
            _In_ UINT uUnique,
            _Out_writes_(MAX_PATH) LPSTR lpTempFileName
            );
               
        WINBASEAPI
        UINT
        WINAPI
        GetTempFileNameW(
            _In_ LPCWSTR lpPathName,
            _In_ LPCWSTR lpPrefixString,
            _In_ UINT uUnique,
            _Out_writes_(MAX_PATH) LPWSTR lpTempFileName
            );
         */

        #region Private members...

        /// <summary>�A���}�l�[�W���\�b�h���i�[���� DLL �̖��O�B</summary>
		private const string DLL_NAME = @"kernel32.dll";

		#endregion
	}
}
