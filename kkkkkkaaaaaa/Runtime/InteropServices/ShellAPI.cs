﻿namespace kkkkkkaaaaaa.Runtime.InteropServices
{
    public class ShellAPI
    {
        /*
        // Shell File Operations
        #define FO_MOVE                    0x0001
        #define FO_COPY                    0x0002
        #define FO_DELETE                  0x0003
        #define FO_RENAME                  0x0004

        // SHFILEOPSTRUCT.fFlags and IFileOperation::SetOperationFlags() flag values
        #define FOF_MULTIDESTFILES         0x0001
        #define FOF_CONFIRMMOUSE           0x0002
        #define FOF_SILENT                 0x0004  // don't display progress UI (confirm prompts may be displayed still)
        #define FOF_RENAMEONCOLLISION      0x0008  // automatically rename the source files to avoid the collisions
        #define FOF_NOCONFIRMATION         0x0010  // don't display confirmation UI, assume "yes" for cases that can be bypassed, "no" for those that can not
        #define FOF_WANTMAPPINGHANDLE      0x0020  // Fill in SHFILEOPSTRUCT.hNameMappings
                                                   // Must be freed using SHFreeNameMappings
        #define FOF_ALLOWUNDO              0x0040  // enable undo including Recycle behavior for IFileOperation::Delete()
        #define FOF_FILESONLY              0x0080  // only operate on the files (non folders), both files and folders are assumed without this
        #define FOF_SIMPLEPROGRESS         0x0100  // means don't show names of files
        #define FOF_NOCONFIRMMKDIR         0x0200  // don't dispplay confirmatino UI before making any needed directories, assume "Yes" in these cases
        #define FOF_NOERRORUI              0x0400  // don't put up error UI, other UI may be displayed, progress, confirmations
        #if (_WIN32_IE >= 0x0500)
        #define FOF_NOCOPYSECURITYATTRIBS  0x0800  // dont copy file security attributes (ACLs)
        #define FOF_NORECURSION            0x1000  // don't recurse into directories for operations that would recurse
        #define FOF_NO_CONNECTED_ELEMENTS  0x2000  // don't operate on connected elements ("xxx_files" folders that go with .htm files)
        #define FOF_WANTNUKEWARNING        0x4000  // during delete operation, warn if nuking instead of recycling (partially overrides FOF_NOCONFIRMATION)
        #endif // (_WIN32_IE >= 0x500)
        #if (_WIN32_WINNT >= 0x0501)
        #define FOF_NORECURSEREPARSE       0x8000  // deprecated; the operations engine always does the right thing on FolderLink objects (symlinks, reparse points, folder shortcuts)
        #endif // (_WIN32_WINNT >= 0x501)
        #define FOF_NO_UI                   (FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR) // don't display any UI at all
        */
    }
}