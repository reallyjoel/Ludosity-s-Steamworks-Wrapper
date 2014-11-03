using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{

    /// <summary>
    /// Does all cloud communication.
    /// Wraps ISteamRemoteStorage.
    /// </summary>
    public interface ICloud
    {
        /// <summary>
        /// Invoked by Share()
        /// </summary>
        event ResultEvent<CloudFileShareResult> CloudFileShareResult;
        /// <summary>
        /// Invoked by UGCDownload()
        /// </summary>
        event ResultEvent<CloudDownloadUGCResult> CloudDownloadUGCResult;
        event ResultEvent<CloudPublishFileResult> CloudPublishFileResult;
        event ResultEvent<CloudUpdatePublishedFileResult> CloudUpdatePublishedFileResult;
        event ResultEvent<CloudGetPublishedFileDetailsResult> CloudGetPublishedFileDetailsResult;
        event ResultEvent<CloudDeletePublishedFileResult> CloudDeletePublishedFileResult;
        event ResultEvent<CloudEnumerateUserPublishedFilesResult> CloudEnumerateUserPublishedFilesResult;
        event ResultEvent<CloudSubscribePublishedFileResult> CloudSubscribePublishedFileResult;
        event ResultEvent<CloudEnumerateUserSubscribedFilesResult> CloudEnumerateUserSubscribedFilesResult;
        event ResultEvent<CloudUnsubscribePublishedFileResult> CloudUnsubscribePublishedFileResult;
        event ResultEvent<CloudGetPublishedItemVoteDetailsResult> CloudGetPublishedItemVoteDetailsResult;
        event ResultEvent<CloudUpdateUserPublishedItemVoteResult> CloudUpdateUserPublishedItemVoteResult;
        event ResultEvent<CloudUserVoteDetails> CloudUserVoteDetailsResult;
        event ResultEvent<CloudEnumerateUserSharedWorkshopFilesResult> CloudEnumerateUserSharedWorkshopFilesResult;
        event ResultEvent<CloudSetUserPublishedFileActionResult> CloudSetUserPublishedFileActionResult;
        event ResultEvent<CloudEnumeratePublishedFilesByUserActionResult> CloudEnumeratePublishedFilesByUserActionResult;
        event ResultEvent<CloudEnumerateWorkshopFilesResult> CloudEnumerateWorkshopFilesResult;
        
        event CallbackEvent<CloudPublishFileProgress> CloudPublishFileProgress;
        event CallbackEvent<CloudPublishedFileUpdated> CloudPublishedFileUpdated;
        event CallbackEvent<CloudPublishedFileSubscribed> CloudPublishedFileSubscribed;
        event CallbackEvent<CloudPublishedFileUnsubscribed> CloudPublishedFileUnsubscribed;
        event CallbackEvent<CloudPublishedFileDeleted> CloudPublishedFileDeleted;

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.bar" then
        /// iterate the files, the filename returned will be "foo.bar".
        ///
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Write(string fileName, IntPtr data, int dataSize);

        /// <summary>
        /// Will read data from the file and place it in the IntPtr. Will try to read \c dataToRead 
		/// number of bytes and place them in the array.
        /// 
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.bar" then
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
		int Read(string fileName, IntPtr data, int dataToRead);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.bar" then
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool Forget(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool Delete(string fileName);

        /// <summary>
        /// Invokes CloudFileShareResult
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        void Share(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="remoteStoragePlatform"></param>
        /// <returns></returns>
        bool SetSyncPlatforms(string fileName, RemoteStoragePlatform remoteStoragePlatform);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool Exists(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        bool Persisted(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        int GetSize(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        long Timestamp(string fileName);

        /// <summary>
        /// NOTE
        ///
        /// Filenames are case-insensitive, and will be converted to lowercase automatically.
        /// So "foo.bar" and "Foo.bar" are the same file, and if you write "Foo.b
        /// iterate the files, the filename returned will be "foo.bar".
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        RemoteStoragePlatform GetSyncPlatforms(string fileName);


        int GetFileCount();

        string GetFileNameAndSize(int fileID, out int fileSize);

        CloudGetFileNameAndSizeResult GetFileNameAndSize(int fileID);

        bool GetQuota(out int totalBytes, out int availableBytes);

        CloudGetQuotaResult GetQuota();

        bool IsEnabledForAccount();

        bool IsEnabledForApplication();

        void SetEnabledForApplication(bool enabled);


        /// <summary>
        /// Invokes CloudDownloadUGCResult
        /// </summary>
        /// <param name="handle"></param>
        void UGCDownload(UGCHandle handle, uint unPriority);

        /// <summary>
        /// Gets the amount of data downloaded so far for a piece of content. pnBytesExpected can be 0 if function returns false
        /// or if the transfer hasn't started yet, so be careful to check for that before dividing to get a percentage
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="bytesDownloaded"></param>
        /// <param name="bytesExpected"></param>
        /// <returns></returns>
        bool GetUGCDownloadProgress(UGCHandle handle, out int bytesDownloaded, out int bytesExpected);


        /// <summary>
        /// Gets the amount of data downloaded so far for a piece of content. pnBytesExpected can be 0 if function returns false
        /// or if the transfer hasn't started yet, so be careful to check for that before dividing to get a percentage
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="bytesDownloaded"></param>
        /// <param name="bytesExpected"></param>
        /// <returns></returns>
        CloudGetUGCDownloadProgressResult GetUGCDownloadProgress(UGCHandle handle);

        /// <summary>
        /// Gets metadata for a file after it has been downloaded. This is the same metadata given in the RemoteStorageDownloadUGCResult_t call result
        /// </summary>
        bool GetUGCDetails(UGCHandle handle, out AppID appID, out string name, out int fileSize,
            out SteamID creator);

        /// <summary>
        /// Gets metadata for a file after it has been downloaded. This is the same metadata given in the RemoteStorageDownloadUGCResult_t call result
        /// </summary>
        CloudGetUGCDetailsResult GetUGCDetails(UGCHandle handle);

        /// <summary>
        /// After download, gets the content of the file
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        int UGCRead(UGCHandle handle, byte[] data, uint offset, UGCReadAction action);

        /// <summary>
        /// Functions to iterate through UGC that has finished downloading but has not yet been read via UGCRead(
        /// </summary>
        /// <returns></returns>
        int GetCachedUGCCount();


        UGCHandle GetUGCHandle(int handleID);


        void PublishWorkshopFile(string fileName, string previewFile, AppID consumerAppId,
            string title, string description, RemoteStoragePublishedFileVisibility visibility,
            IList<string> tags, WorkshopFileType workshopFileType);

        PublishedFileUpdateHandle CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId);
        bool UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, string fileName);
        bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, string previewFile);
        bool UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, string title);
        bool UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, string description);
        bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, RemoteStoragePublishedFileVisibility visibility);
        bool UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle, IList<string> tags);

        void CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle);
        void GetPublishedFileDetails(PublishedFileId publishedFileId, uint maxSecondsOld);
        void DeletePublishedFile(PublishedFileId publishedFileId);
        void EnumerateUserPublishedFiles(int startIndex);
        void SubscribePublishedFile(PublishedFileId publishedFileId);
        void EnumerateUserSubscribedFiles(int startIndex);
        void UnsubscribePublishedFile(PublishedFileId publishedFileId);
        bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, string changeDescription);
        void GetPublishedItemVoteDetails(PublishedFileId publishedFileId);
        void UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp);
        void GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId);
        void EnumerateUserSharedWorkshopFiles(SteamID steamId, int startIndex, IList<string> requiredTags, IList<string> excludedTags);
        void PublishVideo(WorkshopVideoProviders videoProviders, string videoAccount, string videoIdentifier, string previewFile, AppID comsumerAppId, string title, string description, RemoteStoragePublishedFileVisibility visibility, IList<string> tags);
        void SetUserPublishedFileAction(PublishedFileId publishedFileId, WorkshopFileAction action);
        void EnumeratePublishedFilesByUserAction(WorkshopFileAction action, int startIndex);
        void EnumeratePublishedWorkshopFiles(WorkshopFileAction enumerationType, int startIndex, int count, int days, IList<string> tags, IList<string> userTags);

        void UGCDownloadToLocation( ulong content, string location, uint priority );
    }



    public struct CloudGetFileNameAndSizeResult
    {
        public string result;
        public int sender;

    }


    public struct CloudGetQuotaResult
    {

        public bool result;
        public int totalBytesSender;
        public int availableBytesSender;


    }


    public struct CloudGetUGCDownloadProgressResult
    {
        public bool result;
        public int bytesDownloadedSender;
        public int bytesExpectedSender;

    }


    public struct CloudGetUGCDetailsResult
    {
        public bool result;
        public AppID appIDSender;
        public string nameSender;
        public int fileSizeSender;
        public SteamID creatorSender;
    }
}
