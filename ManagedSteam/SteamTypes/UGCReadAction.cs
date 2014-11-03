using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref EUGCReadAction enum
    /// </summary>
    public enum UGCReadAction
    {
        /// <summary>
        /// Keeps the file handle open unless the last byte is read.  You can use this when reading large files (over 100MB) in sequential chunks.
        /// If the last byte is read, this will behave the same as k_EUGCRead_Close.  Otherwise, it behaves the same as k_EUGCRead_ContinueReading
        /// This value maintains the same behavior as before the EUGCReadAction parameter was introduced.
        /// </summary>
        ContinueReadingUntilFinished = 0,
        /// <summary>
        /// Keeps the file handle open.  Use this when using UGCRead to seek to different parts of the file.
        /// When you are done seeking around the file, make a final call with k_EUGCRead_Close to close it.
        /// </summary>
        ContinueReading = 1,

        /// <summary>
        /// Frees the file handle.  Use this when you're done reading the content.  
        /// To read the file from Steam again you will need to call UGCDownload again. 
        /// </summary>
        Close = 2,
    }
}
