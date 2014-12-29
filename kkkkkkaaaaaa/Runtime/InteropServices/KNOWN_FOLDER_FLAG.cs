namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    /// <summary>
    /// typedef enum
    /// {
    ///     KF_FLAG_DEFAULT         = 0x00000000,
    ///     
    ///     #if (NTDDI_VERSION >= NTDDI_WIN7)
    ///     // When running inside an AppContainer, or when poviding an AppContainer token, specifying this flag will prevent redirection to AppContainer 
    ///     // folders and instead return the path that would be returned when not running inside an AppContainer
    ///     KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,
    ///     #endif //NTDDI_WIN7
    ///     
    ///     // Make sure that the folder already exists or create it and apply security specified in folder definition
    ///     // If folder can not be created then function will return failure and no folder path (IDList) will be returned
    ///     // If folder is located on the network the function may take long time to execute
    ///     KF_FLAG_CREATE          = 0x00008000,
    ///     
    ///     // If this flag is specified then the folder path is returned and no verification is performed
    ///     // Use this flag is you want to get folder's path (IDList) and do not need to verify folder's existence
    ///     //
    ///     // If this flag is NOT specified then Known Folder API will try to verify that the folder exists
    ///     //     If folder does not exist or can not be accessed then function will return failure and no folder path (IDList) will be returned
    ///     //     If folder is located on the network the function may take long time to execute
    ///     KF_FLAG_DONT_VERIFY     = 0x00004000,
    ///     
    ///     // Set folder path as is and do not try to substitute parts of the path with environments variables.
    ///     // If flag is not specified then Known Folder will try to replace parts of the path with some
    ///     // known environment variables (%USERPROFILE%, %APPDATA% etc.)
    ///     KF_FLAG_DONT_UNEXPAND   = 0x00002000,
    ///     
    ///     // Get file system based IDList if available. If the flag is not specified the Known Folder API
    ///     // will try to return aliased IDList by default. Example for FOLDERID_Documents -
    ///     // Aliased - [desktop]\[user]\[Documents] - exact location is determined by shell namespace layout and might change
    ///     // Non aliased - [desktop]\[computer]\[disk_c]\[users]\[user]\[Documents] - location is determined by folder location in the file system
    ///     KF_FLAG_NO_ALIAS        = 0x00001000,
    ///     
    ///     // Initialize the folder with desktop.ini settings
    ///     // If folder can not be initialized then function will return failure and no folder path will be returned
    ///     // If folder is located on the network the function may take long time to execute
    ///     KF_FLAG_INIT            = 0x00000800,
    ///     
    ///     // Get the default path, will also verify folder existence unless KF_FLAG_DONT_VERIFY is also specified
    ///     KF_FLAG_DEFAULT_PATH    = 0x00000400,
    ///     
    ///     // Get the not-parent-relative default path. Only valid with KF_FLAG_DEFAULT_PATH
    ///     KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,
    ///     
    ///     // Build simple IDList
    ///     KF_FLAG_SIMPLE_IDLIST   = 0x00000100,
    ///     
    ///     // only return the aliased IDLists, don't fallback to file system path
    ///     KF_FLAG_ALIAS_ONLY      = 0x80000000,
    /// } KNOWN_FOLDER_FLAG;
    /// http://msdn.microsoft.com/ja-jp/library/windows/desktop/dd378447.aspx
    /// </summary>
    public enum KNOWN_FOLDER_FLAG : uint
    {
        KF_FLAG_DEFAULT = 0x00000000,

        /// <summary>
        /// #if (NTDDI_VERSION >= NTDDI_WIN7)
        /// When running inside an AppContainer, or when poviding an AppContainer token, specifying this flag will prevent redirection to AppContainer 
        /// folders and instead return the path that would be returned when not running inside an AppContainer
        /// #endif //NTDDI_WIN7
        /// </summary>
        KF_FLAG_NO_APPCONTAINER_REDIRECTION = 0x00010000,

        // Make sure that the folder already exists or create it and apply security specified in folder definition
        // If folder can not be created then function will return failure and no folder path (IDList) will be returned
        // If folder is located on the network the function may take long time to execute
        KF_FLAG_CREATE = 0x00008000,

        /// <summary>
        /// If this flag is specified then the folder path is returned and no verification is performed
        /// Use this flag is you want to get folder's path (IDList) and do not need to verify folder's existence
        ///
        /// If this flag is NOT specified then Known Folder API will try to verify that the folder exists
        ///     If folder does not exist or can not be accessed then function will return failure and no folder path (IDList) will be returned
        ///     If folder is located on the network the function may take long time to execute
        /// </summary>
        KF_FLAG_DONT_VERIFY = 0x00004000,

        // Set folder path as is and do not try to substitute parts of the path with environments variables.
        // If flag is not specified then Known Folder will try to replace parts of the path with some
        // known environment variables (%USERPROFILE%, %APPDATA% etc.)
        KF_FLAG_DONT_UNEXPAND = 0x00002000,

        // Get file system based IDList if available. If the flag is not specified the Known Folder API
        // will try to return aliased IDList by default. Example for FOLDERID_Documents -
        // Aliased - [desktop]\[user]\[Documents] - exact location is determined by shell namespace layout and might change
        // Non aliased - [desktop]\[computer]\[disk_c]\[users]\[user]\[Documents] - location is determined by folder location in the file system
        KF_FLAG_NO_ALIAS = 0x00001000,

        // Initialize the folder with desktop.ini settings
        // If folder can not be initialized then function will return failure and no folder path will be returned
        // If folder is located on the network the function may take long time to execute
        KF_FLAG_INIT = 0x00000800,

        // Get the default path, will also verify folder existence unless KF_FLAG_DONT_VERIFY is also specified
        KF_FLAG_DEFAULT_PATH = 0x00000400,

        // Get the not-parent-relative default path. Only valid with KF_FLAG_DEFAULT_PATH
        KF_FLAG_NOT_PARENT_RELATIVE = 0x00000200,

        // Build simple IDList

        KF_FLAG_SIMPLE_IDLIST = 0x00000100,

        /// <summary>
        /// only return the aliased IDLists, don't fallback to file system path
        /// </summary>
        KF_FLAG_ALIAS_ONLY = 0x80000000,
    }
}
