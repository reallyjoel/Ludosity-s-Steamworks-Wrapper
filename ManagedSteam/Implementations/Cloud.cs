using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;
using ManagedSteam.CallbackStructures;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Cloud : SteamService, ICloud
    {
        private List<Result<CloudFileShareResult>> listCloudFileShareResult;
        private List<Result<CloudDownloadUGCResult>> listCloudDownloadUGCResult;
        private List<Result<CloudPublishFileResult>> listCloudPublishFileResult;
        private List<Result<CloudUpdatePublishedFileResult>> listCloudUpdatePublishedFileResult;
        private List<Result<CloudGetPublishedFileDetailsResult>> listCloudGetPublishedFileDetailsResult;
        private List<Result<CloudDeletePublishedFileResult>> listCloudDeletePublishedFileResult;
        private List<Result<CloudEnumerateUserPublishedFilesResult>> listCloudEnumerateUserPublishedFilesResult;
        private List<Result<CloudSubscribePublishedFileResult>> listCloudSubscribePublishedFileResult;
        private List<Result<CloudEnumerateUserSubscribedFilesResult>> listCloudEnumerateUserSubscribedFilesResult;
        private List<Result<CloudUnsubscribePublishedFileResult>> listCloudUnsubscribePublishedFileResult;
        private List<Result<CloudGetPublishedItemVoteDetailsResult>> listCloudGetPublishedItemVoteDetailsResult;
        private List<Result<CloudUpdateUserPublishedItemVoteResult>> listCloudUpdateUserPublishedItemVoteResult;
        private List<Result<CloudUserVoteDetails>> listCloudUserVoteDetailsResult;
        private List<Result<CloudEnumerateUserSharedWorkshopFilesResult>> listCloudEnumerateUserSharedWorkshopFilesResult;
        private List<Result<CloudSetUserPublishedFileActionResult>> listCloudSetUserPublishedFileActionResult;
        private List<Result<CloudEnumeratePublishedFilesByUserActionResult>> listCloudEnumeratePublishedFilesByUserActionResult;
        private List<Result<CloudEnumerateWorkshopFilesResult>> listCloudEnumerateWorkshopFilesResult;
        
        private List<CloudPublishFileProgress> listCloudPublishFileProgress;
        private List<CloudPublishedFileUpdated> listCloudPublishedFileUpdated;
        private List<CloudPublishedFileSubscribed> listCloudPublishedFileSubscribed;
        private List<CloudPublishedFileUnsubscribed> listCloudPublishedFileUnsubscribed;
        private List<CloudPublishedFileDeleted> listCloudPublishedFileDeleted;


        internal Cloud()
        {
            listCloudFileShareResult = new List<Result<CloudFileShareResult>>();
            listCloudDownloadUGCResult = new List<Result<CloudDownloadUGCResult>>();
            listCloudPublishFileResult = new List<Result<CloudPublishFileResult>>();
            listCloudUpdatePublishedFileResult = new List<Result<CallbackStructures.CloudUpdatePublishedFileResult>>();
            listCloudGetPublishedFileDetailsResult = new List<Result<CloudGetPublishedFileDetailsResult>>();
            listCloudDeletePublishedFileResult = new List<Result<CloudDeletePublishedFileResult>>();
            listCloudEnumerateUserPublishedFilesResult = new List<Result<CloudEnumerateUserPublishedFilesResult>>();
            listCloudSubscribePublishedFileResult = new List<Result<CloudSubscribePublishedFileResult>>();
            listCloudEnumerateUserSubscribedFilesResult = new List<Result<CloudEnumerateUserSubscribedFilesResult>>();
            listCloudUnsubscribePublishedFileResult = new List<Result<CloudUnsubscribePublishedFileResult>>();
            listCloudGetPublishedItemVoteDetailsResult = new List<Result<CloudGetPublishedItemVoteDetailsResult>>();
            listCloudUpdateUserPublishedItemVoteResult = new List<Result<CloudUpdateUserPublishedItemVoteResult>>();
            listCloudUserVoteDetailsResult = new List<Result<CloudUserVoteDetails>>();
            listCloudEnumerateUserSharedWorkshopFilesResult = new List<Result<CloudEnumerateUserSharedWorkshopFilesResult>>();
            listCloudSetUserPublishedFileActionResult = new List<Result<CloudSetUserPublishedFileActionResult>>();
            listCloudEnumeratePublishedFilesByUserActionResult = new List<Result<CloudEnumeratePublishedFilesByUserActionResult>>();
            listCloudEnumerateWorkshopFilesResult = new List<Result<CloudEnumerateWorkshopFilesResult>>();
            
            listCloudPublishFileProgress = new List<CloudPublishFileProgress>();
            listCloudPublishedFileUpdated = new List<CloudPublishedFileUpdated>();
            listCloudPublishedFileSubscribed = new List<CloudPublishedFileSubscribed>();
            listCloudPublishedFileUnsubscribed = new List<CloudPublishedFileUnsubscribed>();
            listCloudPublishedFileDeleted = new List<CloudPublishedFileDeleted>();



            Results[ResultID.CloudFileShareResult] = (data, size, flag) =>
                listCloudFileShareResult.Add(new Result<CloudFileShareResult>(CallbackStructures.CloudFileShareResult.Create(data, size), flag));
            Results[ResultID.CloudDownloadUGCResult] = (data, size, flag) =>
                listCloudDownloadUGCResult.Add(new Result<CloudDownloadUGCResult>(CallbackStructures.CloudDownloadUGCResult.Create(data, size), flag));
            Results[ResultID.CloudPublishFileResult] = (data, size, flag) =>
                listCloudPublishFileResult.Add(new Result<CloudPublishFileResult>(CallbackStructures.CloudPublishFileResult.Create(data, size), flag));
            Results[ResultID.CloudUpdatePublishedFileResult] = (data, size, flag) =>
                listCloudUpdatePublishedFileResult.Add(new Result<CloudUpdatePublishedFileResult>(CallbackStructures.CloudUpdatePublishedFileResult.Create(data, size), flag));
            Results[ResultID.CloudGetPublishedFileDetailsResult] = (data, size, flag) =>
                listCloudGetPublishedFileDetailsResult.Add(new Result<CloudGetPublishedFileDetailsResult>(CallbackStructures.CloudGetPublishedFileDetailsResult.Create(data, size), flag));
            Results[ResultID.CloudDeletePublishedFileResult] = (data, size, flag) =>
                listCloudDeletePublishedFileResult.Add(new Result<CloudDeletePublishedFileResult>(CallbackStructures.CloudDeletePublishedFileResult.Create(data, size), flag));
            Results[ResultID.CloudEnumerateUserPublishedFilesResult] = (data, size, flag) =>
                listCloudEnumerateUserPublishedFilesResult.Add(new Result<CloudEnumerateUserPublishedFilesResult>(CallbackStructures.CloudEnumerateUserPublishedFilesResult.Create(data, size), flag));
            Results[ResultID.CloudSubscribePublishedFileResult] = (data, size, flag) =>
                listCloudSubscribePublishedFileResult.Add(new Result<CloudSubscribePublishedFileResult>(CallbackStructures.CloudSubscribePublishedFileResult.Create(data, size), flag));
            Results[ResultID.CloudEnumerateUserSubscribedFilesResult] = (data, size, flag) =>
                listCloudEnumerateUserSubscribedFilesResult.Add(new Result<CloudEnumerateUserSubscribedFilesResult>(CallbackStructures.CloudEnumerateUserSubscribedFilesResult.Create(data, size), flag));
            Results[ResultID.CloudUnsubscribePublishedFileResult] = (data, size, flag) =>
                listCloudUnsubscribePublishedFileResult.Add(new Result<CloudUnsubscribePublishedFileResult>(CallbackStructures.CloudUnsubscribePublishedFileResult.Create(data, size), flag));
            Results[ResultID.CloudGetPublishedItemVoteDetailsResult] = (data, size, flag) =>
                listCloudGetPublishedItemVoteDetailsResult.Add(new Result<CloudGetPublishedItemVoteDetailsResult>(CallbackStructures.CloudGetPublishedItemVoteDetailsResult.Create(data, size), flag));
            Results[ResultID.CloudUpdateUserPublishedItemVoteResult] = (data, size, flag) =>
                listCloudUpdateUserPublishedItemVoteResult.Add(new Result<CloudUpdateUserPublishedItemVoteResult>(CallbackStructures.CloudUpdateUserPublishedItemVoteResult.Create(data, size), flag));
            Results[ResultID.CloudUserVoteDetails] = (data, size, flag) =>
                listCloudUserVoteDetailsResult.Add(new Result<CloudUserVoteDetails>(CallbackStructures.CloudUserVoteDetails.Create(data, size), flag));
            Results[ResultID.CloudEnumerateUserSharedWorkshopFilesResult] = (data, size, flag) =>
                listCloudEnumerateUserSharedWorkshopFilesResult.Add(new Result<CloudEnumerateUserSharedWorkshopFilesResult>(CallbackStructures.CloudEnumerateUserSharedWorkshopFilesResult.Create(data, size), flag));
            Results[ResultID.CloudSetUserPublishedFileActionResult] = (data, size, flag) =>
                listCloudSetUserPublishedFileActionResult.Add(new Result<CloudSetUserPublishedFileActionResult>(CallbackStructures.CloudSetUserPublishedFileActionResult.Create(data, size), flag));
            Results[ResultID.CloudEnumeratePublishedFilesByUserActionResult] = (data, size, flag) =>
                listCloudEnumeratePublishedFilesByUserActionResult.Add(new Result<CloudEnumeratePublishedFilesByUserActionResult>(CallbackStructures.CloudEnumeratePublishedFilesByUserActionResult.Create(data, size), flag));
            Results[ResultID.CloudEnumerateWorkshopFilesResult] = (data, size, flag) =>
                listCloudEnumerateWorkshopFilesResult.Add(new Result<CloudEnumerateWorkshopFilesResult>(CallbackStructures.CloudEnumerateWorkshopFilesResult.Create(data, size), flag));

            Callbacks[CallbackID.CloudPublishFileProgress] = (data, size) => listCloudPublishFileProgress.Add(CallbackStructures.CloudPublishFileProgress.Create(data, size));
            Callbacks[CallbackID.CloudPublishedFileUpdated] = (data, size) => listCloudPublishedFileUpdated.Add(CallbackStructures.CloudPublishedFileUpdated.Create(data, size));
            Callbacks[CallbackID.CloudPublishedFileSubscribed] = (data, size) => listCloudPublishedFileSubscribed.Add(CallbackStructures.CloudPublishedFileSubscribed.Create(data, size));
            Callbacks[CallbackID.CloudPublishedFileUnsubscribed] = (data, size) => listCloudPublishedFileUnsubscribed.Add(CallbackStructures.CloudPublishedFileUnsubscribed.Create(data, size));
            Callbacks[CallbackID.CloudPublishedFileDeleted] = (data, size) => listCloudPublishedFileDeleted.Add(CallbackStructures.CloudPublishedFileDeleted.Create(data, size));
        }

        /// <summary>
        /// Invoked by Share()
        /// </summary>
        public event ResultEvent<CloudFileShareResult> CloudFileShareResult;
        /// <summary>
        /// Invoked by UGCDownload()
        /// </summary>
        public event ResultEvent<CloudDownloadUGCResult> CloudDownloadUGCResult;
        public event ResultEvent<CloudPublishFileResult> CloudPublishFileResult;
        public event ResultEvent<CloudUpdatePublishedFileResult> CloudUpdatePublishedFileResult;
        public event ResultEvent<CloudGetPublishedFileDetailsResult> CloudGetPublishedFileDetailsResult;
        public event ResultEvent<CloudDeletePublishedFileResult> CloudDeletePublishedFileResult;
        public event ResultEvent<CloudEnumerateUserPublishedFilesResult> CloudEnumerateUserPublishedFilesResult;
        public event ResultEvent<CloudSubscribePublishedFileResult> CloudSubscribePublishedFileResult;
        public event ResultEvent<CloudEnumerateUserSubscribedFilesResult> CloudEnumerateUserSubscribedFilesResult;
        public event ResultEvent<CloudUnsubscribePublishedFileResult> CloudUnsubscribePublishedFileResult;
        public event ResultEvent<CloudGetPublishedItemVoteDetailsResult> CloudGetPublishedItemVoteDetailsResult;
        public event ResultEvent<CloudUpdateUserPublishedItemVoteResult> CloudUpdateUserPublishedItemVoteResult;
        public event ResultEvent<CloudUserVoteDetails> CloudUserVoteDetailsResult;
        public event ResultEvent<CloudEnumerateUserSharedWorkshopFilesResult> CloudEnumerateUserSharedWorkshopFilesResult;
        public event ResultEvent<CloudSetUserPublishedFileActionResult> CloudSetUserPublishedFileActionResult;
        public event ResultEvent<CloudEnumeratePublishedFilesByUserActionResult> CloudEnumeratePublishedFilesByUserActionResult;
        public event ResultEvent<CloudEnumerateWorkshopFilesResult> CloudEnumerateWorkshopFilesResult;

        public event CallbackEvent<CloudPublishFileProgress> CloudPublishFileProgress;
        public event CallbackEvent<CloudPublishedFileUpdated> CloudPublishedFileUpdated;
        public event CallbackEvent<CloudPublishedFileSubscribed> CloudPublishedFileSubscribed;
        public event CallbackEvent<CloudPublishedFileUnsubscribed> CloudPublishedFileUnsubscribed;
        public event CallbackEvent<CloudPublishedFileDeleted> CloudPublishedFileDeleted;

        internal override void CheckIfUsableInternal()
        {

        }

        internal override void InvokeEvents()
        {
            InvokeEvents(listCloudFileShareResult, CloudFileShareResult);
            InvokeEvents(listCloudDownloadUGCResult, CloudDownloadUGCResult);
            InvokeEvents(listCloudPublishFileResult, CloudPublishFileResult);
            InvokeEvents(listCloudUpdatePublishedFileResult, CloudUpdatePublishedFileResult);
            InvokeEvents(listCloudGetPublishedFileDetailsResult, CloudGetPublishedFileDetailsResult);
            InvokeEvents(listCloudDeletePublishedFileResult, CloudDeletePublishedFileResult);
            InvokeEvents(listCloudEnumerateUserPublishedFilesResult, CloudEnumerateUserPublishedFilesResult);
            InvokeEvents(listCloudSubscribePublishedFileResult, CloudSubscribePublishedFileResult);
            InvokeEvents(listCloudEnumerateUserSubscribedFilesResult, CloudEnumerateUserSubscribedFilesResult);
            InvokeEvents(listCloudUnsubscribePublishedFileResult, CloudUnsubscribePublishedFileResult);
            InvokeEvents(listCloudGetPublishedItemVoteDetailsResult, CloudGetPublishedItemVoteDetailsResult);
            InvokeEvents(listCloudUpdateUserPublishedItemVoteResult, CloudUpdateUserPublishedItemVoteResult);
            InvokeEvents(listCloudUserVoteDetailsResult, CloudUserVoteDetailsResult);
            InvokeEvents(listCloudEnumerateUserSharedWorkshopFilesResult, CloudEnumerateUserSharedWorkshopFilesResult);
            InvokeEvents(listCloudSetUserPublishedFileActionResult, CloudSetUserPublishedFileActionResult);
            InvokeEvents(listCloudEnumeratePublishedFilesByUserActionResult, CloudEnumeratePublishedFilesByUserActionResult);
            InvokeEvents(listCloudEnumerateWorkshopFilesResult, CloudEnumerateWorkshopFilesResult);
            InvokeEvents(listCloudPublishFileProgress, CloudPublishFileProgress);
            InvokeEvents(listCloudPublishedFileUpdated, CloudPublishedFileUpdated);
            InvokeEvents(listCloudPublishedFileSubscribed, CloudPublishedFileSubscribed);
            InvokeEvents(listCloudPublishedFileUnsubscribed, CloudPublishedFileUnsubscribed);
            InvokeEvents(listCloudPublishedFileDeleted, CloudPublishedFileDeleted);
        }

        internal override void ReleaseManagedResources()
        {
            listCloudFileShareResult = null;
            listCloudDownloadUGCResult = null;
            listCloudPublishFileResult = null;
            listCloudUpdatePublishedFileResult = null;
            listCloudGetPublishedFileDetailsResult = null;
            listCloudDeletePublishedFileResult = null;
            listCloudEnumerateUserPublishedFilesResult = null;
            listCloudSubscribePublishedFileResult = null;
            listCloudEnumerateUserSubscribedFilesResult = null;
            listCloudUnsubscribePublishedFileResult = null;
            listCloudGetPublishedItemVoteDetailsResult = null;
            listCloudUpdateUserPublishedItemVoteResult = null;
            listCloudUserVoteDetailsResult = null;
            listCloudEnumerateUserSharedWorkshopFilesResult = null;
            listCloudSetUserPublishedFileActionResult = null;
            listCloudEnumeratePublishedFilesByUserActionResult = null;
            listCloudEnumerateWorkshopFilesResult = null;
            listCloudPublishFileProgress = null;
            listCloudPublishedFileUpdated = null;
            listCloudPublishedFileSubscribed = null;
            listCloudPublishedFileUnsubscribed = null;
            listCloudPublishedFileDeleted = null;

            CloudFileShareResult = null;
            CloudDownloadUGCResult = null;
            CloudPublishFileResult = null;
            CloudUpdatePublishedFileResult = null;
            CloudGetPublishedFileDetailsResult = null;
            CloudDeletePublishedFileResult = null;
            CloudEnumerateUserPublishedFilesResult = null;
            CloudSubscribePublishedFileResult = null;
            CloudEnumerateUserSubscribedFilesResult = null;
            CloudUnsubscribePublishedFileResult = null;
            CloudGetPublishedItemVoteDetailsResult = null;
            CloudUpdateUserPublishedItemVoteResult = null;
            CloudUserVoteDetailsResult = null;
            CloudEnumerateUserSharedWorkshopFilesResult = null;
            CloudSetUserPublishedFileActionResult = null;
            CloudEnumeratePublishedFilesByUserActionResult = null;
            CloudEnumerateWorkshopFilesResult = null;
            CloudPublishFileProgress = null;
            CloudPublishedFileUpdated = null;
            CloudPublishedFileSubscribed = null;
            CloudPublishedFileUnsubscribed = null;
            CloudPublishedFileDeleted = null;
        }

        public bool Write(string fileName, IntPtr data, int dataSize)
        {
            CheckIfUsable();

			return NativeMethods.Cloud_Write(fileName, data, dataSize);
		}

        public int Read(string fileName, IntPtr data, int dataToRead)
        {
            CheckIfUsable();

			return NativeMethods.Cloud_Read(fileName, data, dataToRead);
        }

        public bool Forget(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_Forget(fileName);
        }

        public bool Delete(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_Delete(fileName);
        }

        /// <summary>
        /// Invokes CloudFileShareResult
        /// </summary>
        /// <param name="fileName"></param>
        public void Share(string fileName)
        {
            CheckIfUsable();
            NativeMethods.Cloud_Share(fileName);
        }

        public bool SetSyncPlatforms(string fileName, RemoteStoragePlatform remoteStoragePlatform)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_SetSyncPlatforms(fileName, (int)remoteStoragePlatform);
        }

        public bool Exists(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_Exists(fileName);
        }

        public bool Persisted(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_Persisted(fileName);
        }

        public int GetSize(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_GetSize(fileName);
        }

        public long Timestamp(string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_Timestamp(fileName);
        }

        public RemoteStoragePlatform GetSyncPlatforms(string fileName)
        {
            CheckIfUsable();
            return (RemoteStoragePlatform)NativeMethods.Cloud_GetSyncPlatforms(fileName);
        }

        public int GetFileCount()
        {
            CheckIfUsable();
            return NativeMethods.Cloud_GetFileCount();
        }

        public string GetFileNameAndSize(int fileID, out int fileSize)
        {
            CheckIfUsable();
            fileSize = 0;
            IntPtr stringPointer = NativeMethods.Cloud_GetFileNameAndSize(fileID, ref fileSize);
            return NativeHelpers.ToStringAnsi(stringPointer);
        }


        public CloudGetFileNameAndSizeResult GetFileNameAndSize(int fileID)
        {
            CloudGetFileNameAndSizeResult result = new CloudGetFileNameAndSizeResult();

            result.result = GetFileNameAndSize(fileID, out result.sender);

            return result;


        }

        public bool GetQuota(out int totalBytes, out int availableBytes)
        {
            CheckIfUsable();
            totalBytes = 0;
            availableBytes = 0;
            return NativeMethods.Cloud_GetQuota(ref totalBytes, ref availableBytes);
        }



        public CloudGetQuotaResult GetQuota()
        {
            CloudGetQuotaResult result = new CloudGetQuotaResult();

            result.result = GetQuota(out result.totalBytesSender, out result.availableBytesSender);

            return result;

        }

        public bool IsEnabledForAccount()
        {
            CheckIfUsable();
            return NativeMethods.Cloud_IsEnabledForAccount();
        }

        public bool IsEnabledForApplication()
        {
            CheckIfUsable();
            return NativeMethods.Cloud_IsEnabledForApplication();
        }

        public void SetEnabledForApplication(bool enabled)
        {
            CheckIfUsable();
            NativeMethods.Cloud_SetEnabledForApplication(enabled);
        }

        /// <summary>
        /// Invokes CloudDownloadUGCResult
        /// </summary>
        /// <param name="handle"></param>
        public void UGCDownload(SteamTypes.UGCHandle handle, uint unPriority)
        {
            CheckIfUsable();
            NativeMethods.Cloud_UGCDownload(handle.AsUInt64, unPriority);
        }

        public bool GetUGCDownloadProgress(UGCHandle handle, out int bytesDownloaded, out int bytesExpected)
        {
            CheckIfUsable();
            bytesDownloaded = 0;
            bytesExpected = 0;
            return NativeMethods.Cloud_GetUGCDownloadProgress(handle.AsUInt64, ref bytesDownloaded, ref bytesExpected);
        }

        public CloudGetUGCDownloadProgressResult GetUGCDownloadProgress(UGCHandle handle)
        {
            CloudGetUGCDownloadProgressResult result = new CloudGetUGCDownloadProgressResult();

            result.result = GetUGCDownloadProgress(handle, out result.bytesDownloadedSender, out result.bytesExpectedSender);

            return result;


        }

        /// <summary>
        /// 
        /// </summary>
        public bool GetUGCDetails(UGCHandle handle, out AppID appID, out string name,
            out int fileSize, out SteamID creator)
        {
            CheckIfUsable();

            IntPtr stringPointer = IntPtr.Zero;
            uint rawAppID = 0;
            ulong rawCreator = 0;

            fileSize = 0;

            bool result = NativeMethods.Cloud_GetUGCDetails(handle.AsUInt64, ref rawAppID, ref stringPointer,
                ref fileSize, ref rawCreator);

            appID = new AppID(rawAppID);
            name = NativeHelpers.ToStringAnsi(stringPointer);
            creator = new SteamID(rawCreator);

            return result;
        }


        public CloudGetUGCDetailsResult GetUGCDetails(UGCHandle handle)
        {
            CloudGetUGCDetailsResult result = new CloudGetUGCDetailsResult();
            result.result = GetUGCDetails(handle, out result.appIDSender, out result.nameSender, out result.fileSizeSender, out result.creatorSender);
            return result;

        }

        public int UGCRead(SteamTypes.UGCHandle handle, byte[] data, uint offset, UGCReadAction action)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(data))
            {
                int bytesRead = NativeMethods.Cloud_UGCRead(handle.AsUInt64, buffer.UnmanagedMemory,
                    buffer.UnmanagedSize, offset, (int)action);
                buffer.ReadFromUnmanagedMemory(bytesRead);
                return bytesRead;
            }
        }

        public int GetCachedUGCCount()
        {
            CheckIfUsable();
            return NativeMethods.Cloud_GetCachedUGCCount();
        }

        public SteamTypes.UGCHandle GetUGCHandle(int handleID)
        {
            CheckIfUsable();
            return new SteamTypes.UGCHandle(NativeMethods.Cloud_GetUGCHandle(handleID));
        }

        #region Publishing UGC
        public void PublishWorkshopFile(string fileName, string previewFile, AppID consumerAppId,
            string title, string description, RemoteStoragePublishedFileVisibility visibility,
            IList<string> tags, WorkshopFileType workshopFileType)
        {
            CheckIfUsable();
            using (SteamParamStringArray tagsArray = new SteamParamStringArray(tags))
            {
                NativeMethods.Cloud_PublishWorkshopFile(fileName, previewFile, consumerAppId.AsUInt32,
                    title, description, (int)visibility, tagsArray.UnmanagedMemory, (int)workshopFileType);
            }
        }

        public PublishedFileUpdateHandle CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            return new PublishedFileUpdateHandle(NativeMethods.Cloud_CreatePublishedFileUpdateRequest(publishedFileId.AsUInt64));
        }

        public bool UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, string fileName)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFileFile(updateHandle.AsUInt64, fileName);
        }

        public bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, string previewFile)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFilePreviewFile(updateHandle.AsUInt64, previewFile);
        }

        public bool UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, string title)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFileTitle(updateHandle.AsUInt64, title);
        }

        public bool UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, string description)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFileDescription(updateHandle.AsUInt64, description);
        }

        public bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, RemoteStoragePublishedFileVisibility visibility)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFileVisibility(updateHandle.AsUInt64, (int)visibility);
        }

        public bool UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle, IList<string> tags)
        {
            CheckIfUsable();
            using (SteamParamStringArray tagsArray = new SteamParamStringArray(tags))
            {
                return NativeMethods.Cloud_UpdatePublishedFileTags(updateHandle.AsUInt64, tagsArray.UnmanagedMemory);
            }
        }


        public void CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle)
        {
            CheckIfUsable();
            NativeMethods.Cloud_CommitPublishedFileUpdate(updateHandle.AsUInt64);
        }

        public void GetPublishedFileDetails(PublishedFileId publishedFileId, uint maxSecondsOld)
        {
            CheckIfUsable();
            NativeMethods.Cloud_GetPublishedFileDetails(publishedFileId.AsUInt64, maxSecondsOld);
        }

        public void DeletePublishedFile(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            NativeMethods.Cloud_DeletePublishedFile(publishedFileId.AsUInt64);
        }

        public void EnumerateUserPublishedFiles(int startIndex)
        {
            CheckIfUsable();
            NativeMethods.Cloud_EnumerateUserPublishedFiles((uint)startIndex);
        }

        public void SubscribePublishedFile(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            NativeMethods.Cloud_SubscribePublishedFile(publishedFileId.AsUInt64);
        }

        public void EnumerateUserSubscribedFiles(int startIndex)
        {
            CheckIfUsable();
            NativeMethods.Cloud_EnumerateUserSubscribedFiles((uint)startIndex);
        }

        public void UnsubscribePublishedFile(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            NativeMethods.Cloud_UnsubscribePublishedFile(publishedFileId.AsUInt64);
        }

        public bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle,
            string changeDescription)
        {
            CheckIfUsable();
            return NativeMethods.Cloud_UpdatePublishedFileSetChangeDescription(updateHandle.AsUInt64,
                changeDescription);
        }

        public void GetPublishedItemVoteDetails(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            NativeMethods.Cloud_GetPublishedItemVoteDetails(publishedFileId.AsUInt64);
        }

        public void UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp)
        {
            CheckIfUsable();
            NativeMethods.Cloud_UpdateUserPublishedItemVote(publishedFileId.AsUInt64, voteUp);
        }

        public void GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId)
        {
            CheckIfUsable();
            NativeMethods.Cloud_GetUserPublishedItemVoteDetails(publishedFileId.AsUInt64);
        }

        public void EnumerateUserSharedWorkshopFiles(SteamID steamId, int startIndex,
            IList<string> requiredTags, IList<string> excludedTags)
        {
            CheckIfUsable();
            using (SteamParamStringArray requiredTagsArray = new SteamParamStringArray(requiredTags))
            {
                using (SteamParamStringArray excludeTagsArray = new SteamParamStringArray(excludedTags))
                {
                    NativeMethods.Cloud_EnumerateUserSharedWorkshopFiles(steamId.AsUInt64, (uint)startIndex,
                        requiredTagsArray.UnmanagedMemory, excludeTagsArray.UnmanagedMemory);
                }
            }
        }

        public void PublishVideo(WorkshopVideoProviders videoProviders, string videoAccount, string videoIdentifier, 
            string previewFile, AppID consumerAppId, string title, string description, 
            RemoteStoragePublishedFileVisibility visibility, IList<string> tags)
        {
            CheckIfUsable();
            using (SteamParamStringArray tagArray = new SteamParamStringArray(tags))
            {
                NativeMethods.Cloud_PublishVideo((int)videoProviders, videoAccount, videoIdentifier, previewFile, consumerAppId.AsUInt32, title,
                    description, (int)visibility, tagArray.UnmanagedMemory);
            }
        }

        public void SetUserPublishedFileAction(PublishedFileId publishedFileId, WorkshopFileAction action)
        {
            CheckIfUsable();
            NativeMethods.Cloud_SetUserPublishedFileAction(publishedFileId.AsUInt64, (int)action);
        }

        public void EnumeratePublishedFilesByUserAction(WorkshopFileAction action, int startIndex)
        {
            CheckIfUsable();
            NativeMethods.Cloud_EnumeratePublishedFilesByUserAction((int)action, (uint)startIndex);
        }

        public void EnumeratePublishedWorkshopFiles(WorkshopFileAction enumerationType, int startIndex,
            int count, int days, IList<string> tags, IList<string> userTags)
        {
            CheckIfUsable();
            using (SteamParamStringArray tagArray = new SteamParamStringArray(tags))
            {
                using (SteamParamStringArray userTagArray = new SteamParamStringArray(userTags))
                {
                    NativeMethods.Cloud_EnumeratePublishedWorkshopFiles((int)enumerationType, (uint)startIndex,
                        (uint)count, (uint)days, tagArray.UnmanagedMemory, userTagArray.UnmanagedMemory);
                }
            }
        }
        #endregion

        public void UGCDownloadToLocation( ulong content, string location, uint priority )
        {
            CheckIfUsable();
            NativeMethods.Cloud_UGCDownloadToLocation( content, location, priority );
        }




    }
}
