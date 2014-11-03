using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.CallbackStructures
{
    using u8 = Byte;
    using s8 = SByte;
    using u16 = UInt16;
    using s16 = Int16;
    using u32 = UInt32;
    using s32 = Int32;
    using u64 = UInt64;
    using s64 = Int64;
    using f32 = Single;
    using f64 = Double;

    using Enum = Int32;

    #region Cloud
    /// <summary>
    /// Wrapper for the \a RemoteStorageFileShareResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct CloudFileShareResult
    {
        private Result result;
        private UGCHandle handle;

        internal static CloudFileShareResult Create(IntPtr dataPointer, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudFileShareResult>(dataPointer, dataSize);
        }

        public Result Result { get { return result; } }
        public UGCHandle Handle { get { return handle; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageDownloadUGCResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudDownloadUGCResult
    {
        private Result result;
        private u64 handle;
        private u32 appID;
        private s32 size;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.FileNameMax)]
        private string name;
        private u64 creatorID;


        internal static CloudDownloadUGCResult Create(IntPtr dataPointer, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudDownloadUGCResult>(dataPointer, dataSize);
        }

        public Result Result { get { return result; } }
        public UGCHandle Handle { get { return new UGCHandle(handle); } }
        public SteamTypes.AppID AppID { get { return new AppID(appID); } }
        public int Size { get { return size; } }
        /// <summary>
        /// The name of the shared file
        /// </summary>
        public string FileName { get { return name; } }
        public SteamID CreatorID { get { return new SteamID(creatorID); } }
    };

    /// <summary>
    /// Wrapper for the \a RemoteStoragePublishFileResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishFileResult
    {
        private Result result;
        private PublishedFileId publishedFileId;
        private bool userNeedsToAcceptWorkshopLegalAgreement;

        internal static CloudPublishFileResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishFileResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public bool UserNeedsToAcceptWorkshopLegalAgreement { get { return userNeedsToAcceptWorkshopLegalAgreement; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageUpdatePublishedFileResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudUpdatePublishedFileResult
    {
        Result result;
        PublishedFileId publishedFileId;
        bool userNeedsToAcceptWorkshopLegalAgreement;

        internal static CloudUpdatePublishedFileResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudUpdatePublishedFileResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public bool UserNeedsToAcceptWorkshopLegalAgreement { get { return userNeedsToAcceptWorkshopLegalAgreement; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageGetPublishedFileDetailsResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudGetPublishedFileDetailsResult
    {
        Result result;
        PublishedFileId publishedFileId;
        AppID creatorAppID;
        AppID consumerAppID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.PublishedDocumentTitleMax)]
        string title;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.PublishedDocumentDescriptionMax)]
        string description;
        UGCHandle file;
        UGCHandle previewFile;
        SteamID steamIDOwner;
        u32 timeCreated;
        u32 timeUpdated;
        RemoteStoragePublishedFileVisibility visibility;
        [MarshalAs(UnmanagedType.I1)]
        bool banned;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.TagListMax)]
        string tags;
        [MarshalAs(UnmanagedType.I1)]
        bool tagsTruncated;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.FileNameMax)]
        string fileName;
        s32 fileSize;
        s32 previewFileSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Cloud.PublishedFileURLMax)]
        string url;
        WorkshopFileType fileType;
        [MarshalAs(UnmanagedType.I1)]
        bool acceptedForUse;

        internal static CloudGetPublishedFileDetailsResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudGetPublishedFileDetailsResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public AppID CreatorAppID { get { return creatorAppID; } }
        public AppID ConsumerAppID { get { return consumerAppID; } }
        public string Title { get { return title; } }
        public string Description { get { return description; } }
        public UGCHandle File { get { return file; } }
        public UGCHandle PreviewFile { get { return previewFile; } }
        public SteamID SteamIDOwner { get { return steamIDOwner; } }
        public uint TimeCreated { get { return timeCreated; } }
        public uint TimeUpdated { get { return timeUpdated; } }
        public RemoteStoragePublishedFileVisibility Visibility { get { return visibility; } }
        public bool Banned { get { return banned; } }
        public string Tags { get { return tags; } }
        public bool TagsTruncated { get { return tagsTruncated; } }
        public string FileName { get { return fileName; } }
        public int FileSize { get { return fileSize; } }
        public int PreviewFileSize { get { return previewFileSize; } }
        public string Url { get { return url; } }
        public WorkshopFileType FileType { get { return fileType; } }
        public bool AcceptedForUse { get { return acceptedForUse; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageDeletePublishedFileResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudDeletePublishedFileResult
    {
        Result result;
        PublishedFileId publishedFileId;

        internal static CloudDeletePublishedFileResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudDeletePublishedFileResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageEnumerateUserPublishedFilesResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudEnumerateUserPublishedFilesResult
    {
        Result result;
        s32 resultsReturned;
        s32 totalResultCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        PublishedFileId[] publishedFileId;

        internal static CloudEnumerateUserPublishedFilesResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudEnumerateUserPublishedFilesResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public int ResultsReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
        public PublishedFileId[] PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageSubscribePublishedFileResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudSubscribePublishedFileResult
    {
        Result result;
        PublishedFileId publishedFileId;

        internal static CloudSubscribePublishedFileResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudSubscribePublishedFileResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageEnumerateUserSubscribedFilesResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudEnumerateUserSubscribedFilesResult
    {
        Result result;
        s32 resultsReturned;
        s32 totalResultCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        PublishedFileId[] publishedFileId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        u32[] timeSubscribed;

        internal static CloudEnumerateUserSubscribedFilesResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudEnumerateUserSubscribedFilesResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public int ResultsReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
        public PublishedFileId[] PublishedFileId { get { return publishedFileId; } }
        public uint[] TimeSubscribed { get { return timeSubscribed; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageUnsubscribePublishedFileResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudUnsubscribePublishedFileResult
    {
        Result result;
        PublishedFileId publishedFileId;

        internal static CloudUnsubscribePublishedFileResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudUnsubscribePublishedFileResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageGetPublishedItemVoteDetailsResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudGetPublishedItemVoteDetailsResult
    {
        Result result;
        PublishedFileId publishedFileId;
        s32 votesFor;
        s32 votesAgainst;
        s32 reports;
        f32 score;

        internal static CloudGetPublishedItemVoteDetailsResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudGetPublishedItemVoteDetailsResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public int VotesFor { get { return votesFor; } }
        public int VotesAgainst { get { return votesAgainst; } }
        public int Reports { get { return reports; } }
        public float Score { get { return score; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageUpdateUserPublishedItemVoteResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudUpdateUserPublishedItemVoteResult
    {
        Result result;
        PublishedFileId publishedFileId;

        internal static CloudUpdateUserPublishedItemVoteResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudUpdateUserPublishedItemVoteResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageUserVoteDetails_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudUserVoteDetails
    {
        Result result;
        PublishedFileId publishedFileId;
        WorkshopVote vote;

        internal static CloudUserVoteDetails Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudUserVoteDetails>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public WorkshopVote Vote { get { return vote; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageEnumerateUserSharedWorkshopFilesResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudEnumerateUserSharedWorkshopFilesResult
    {
        Result result;
        s32 resultsReturned;
        s32 totalResultCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        PublishedFileId[] publishedFileId;

        internal static CloudEnumerateUserSharedWorkshopFilesResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudEnumerateUserSharedWorkshopFilesResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public int ResultsReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
        public PublishedFileId[] PublishedFileId { get { return publishedFileId; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageSetUserPublishedFileActionResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudSetUserPublishedFileActionResult
    {
        Result result;
        PublishedFileId publishedFileId;
        WorkshopFileAction action;

        internal static CloudSetUserPublishedFileActionResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudSetUserPublishedFileActionResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public WorkshopFileAction Action { get { return action; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageEnumeratePublishedFilesByUserActionResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudEnumeratePublishedFilesByUserActionResult
    {
        Result result;
        WorkshopFileAction action;
        s32 resultsReturned;
        s32 totalResultCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        PublishedFileId[] publishedFileId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        u32[] timeUpdated;

        internal static CloudEnumeratePublishedFilesByUserActionResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudEnumeratePublishedFilesByUserActionResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public WorkshopFileAction Action { get { return action; } }
        public int ResultsReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
        public PublishedFileId[] PublishedFileId { get { return publishedFileId; } }
        public uint[] TimeUpdated { get { return timeUpdated; } }
    }

    /// <summary>
    /// Wrapper for the \a RemoteStorageEnumerateWorkshopFilesResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudEnumerateWorkshopFilesResult
    {
        Result result;
        s32 resultsReturned;
        s32 totalResultCount;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        PublishedFileId[] publishedFileId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Cloud.EnumeratePublishedFilesMaxResults)]
        f32[] score;

        AppID appId;
        u32 startIndex;

        internal static CloudEnumerateWorkshopFilesResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudEnumerateWorkshopFilesResult>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public int ResultsReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
        public PublishedFileId[] PublishedFileId { get { return publishedFileId; } }
        public float[] Score { get { return score; } }
        public AppID AppID { get { return appId; } }
        public u32 StartIndex { get { return startIndex; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishFileProgress
    {
        double percentFile;
        bool preview;

        internal static CloudPublishFileProgress Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishFileProgress>(data, dataSize);
        }

        public double PercentFile { get { return percentFile; } }
        public bool Preview { get { return preview; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishedFileUpdated
    {
        PublishedFileId publishedFileId;
        AppID appId;
        UGCHandle ugcHandle;

        internal static CloudPublishedFileUpdated Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishedFileUpdated>(data, dataSize);
        }

        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public AppID AppId { get { return appId; } }
        public UGCHandle UGCHandle { get { return ugcHandle; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishedFileSubscribed
    {
        PublishedFileId publishedFileId;
        AppID appId;

        internal static CloudPublishedFileSubscribed Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishedFileSubscribed>(data, dataSize);
        }

        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public AppID AppId { get { return appId; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishedFileUnsubscribed
    {
        PublishedFileId publishedFileId;
        AppID appId;

        internal static CloudPublishedFileUnsubscribed Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishedFileUnsubscribed>(data, dataSize);
        }

        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public AppID AppId { get { return appId; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct CloudPublishedFileDeleted
    {
        PublishedFileId publishedFileId;
        AppID appId;

        internal static CloudPublishedFileDeleted Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CloudPublishedFileDeleted>(data, dataSize);
        }

        public PublishedFileId PublishedFileId { get { return publishedFileId; } }
        public AppID AppId { get { return appId; } }
    }

    #endregion


}
