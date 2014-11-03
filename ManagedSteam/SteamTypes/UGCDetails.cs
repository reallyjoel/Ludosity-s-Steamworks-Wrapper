using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Wrapper for the \a SteamUGCDetails_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UGCDetails // SteamUGCDetails_t
    {
        PublishedFileId publishedFileId;
        Result result;
        WorkshopFileType workshopFileType;
        AppID creatorAppID;
        AppID consumerAppID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.UGC.PublishedDocumentTitleMax)]
        string title;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.UGC.PublishedDocumentDescriptionMax)]
        string description;
        SteamID steamIDOwner;
        uint timeCreated;
        uint timeUpdated;
        uint timeAddedToUserList;
        RemoteStoragePublishedFileVisibility visibility;
        [MarshalAs(UnmanagedType.I1)]
        bool banned;
        [MarshalAs(UnmanagedType.I1)]
        bool acceptedForUse;
        [MarshalAs(UnmanagedType.I1)]
        bool tagsTruncated;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.UGC.TagListMax)]
        string tags;

        // file/url information
        UGCHandle file;
        UGCHandle previewFile;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.UGC.FilenameMax)]
        string fileName;
        int fileSize;
        int previewFileSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.UGC.PublishedFileURLMax)]
        string url;

        // voting information
        uint votesUp;
        uint votesDown;
        float score;

        internal static UGCDetails Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UGCDetails>(data, dataSize);
        }

        public PublishedFileId PublishedFileId { get { return publishedFileId; } }

        /// <summary>
        /// The result of the operation.
        /// </summary>
        public Result Result { get { return result; } }
        /// <summary>
        /// Type of the file
        /// </summary>
        WorkshopFileType WorkshopFileType { get { return workshopFileType; } }
        /// <summary>
        /// ID of the app that created this file.
        /// </summary>
        AppID CreatorAppID { get { return creatorAppID; } }
        /// <summary>
        /// ID of the app that will consume this file.
        /// </summary>
        AppID ConsumerAppID { get { return ConsumerAppID; } }
        /// <summary>
        /// title of document
        /// </summary>
        string Title { get { return title; } }
        /// <summary>
        /// description of document
        /// </summary>
        string Description { get { return description; } }
        /// <summary>
        /// Steam ID of the user who created this content.
        /// </summary>
        SteamID SteamIDOwner { get { return steamIDOwner; } }
        /// <summary>
        /// time when the published file was created
        /// </summary>
        uint TimeCreated { get { return timeCreated; } }
        /// <summary>
        /// time when the published file was last updated
        /// </summary>
        uint TimeUpdated { get { return timeUpdated; } }
        /// <summary>
        /// time when the user added the published file to their list (not always applicable)
        /// </summary>
        uint TimeAddedToUserList { get { return timeAddedToUserList; } }
        /// <summary>
        /// visibility
        /// </summary>
        RemoteStoragePublishedFileVisibility Visibility { get { return visibility; } }
        /// <summary>
        /// whether the file was banned
        /// </summary>
        bool Banned { get { return banned; } }
        /// <summary>
        /// developer has specifically flagged this item as accepted in the Workshop
        /// </summary>
        bool AcceptedForUse { get { return acceptedForUse; } }
        /// <summary>
        /// whether the list of tags was too long to be returned in the provided buffer
        /// </summary>
        bool TagsTruncated { get { return tagsTruncated; } }
        /// <summary>
        /// comma separated list of all tags associated with this file
        /// </summary>
        string Tags { get { return tags; } }

        // file/url information
        /// <summary>
        /// The handle of the primary file
        /// </summary>
        UGCHandle File { get { return file; } }
        /// <summary>
        /// The handle of the preview file
        /// </summary>
        UGCHandle PreviewFile { get { return previewFile; } }
        /// <summary>
        /// The cloud filename of the primary file
        /// </summary>
        string FileName { get { return fileName; } }
        /// <summary>
        /// Size of the primary file
        /// </summary>
        int FileSize { get { return fileSize; } }
        /// <summary>
        /// Size of the preview file
        /// </summary>
        int PreviewFileSize { get { return previewFileSize; } }
        /// <summary>
        /// URL (for a video or a website)
        /// </summary>
        string URL { get { return url; } }

        // voting information
        /// <summary>
        /// number of votes up
        /// </summary>
        uint VotesUp { get { return votesUp; } }
        /// <summary>
        /// number of votes down
        /// </summary>
        uint VotesDown { get { return votesDown; } }
        /// <summary>
        /// calculated score
        /// </summary>
        float Score { get { return score; } }
    }
}