#ifndef RemoteStorage_h_interop_
#define RemoteStorage_h_interop_


ManagedSteam_API bool Cloud_Write(PConstantString fileName, PConstantDataPointer buffer, s32 bufferLength);

ManagedSteam_API s32 Cloud_Read(PConstantString fileName, PDataPointer buffer, s32 bufferLength);

ManagedSteam_API bool Cloud_Forget(PConstantString fileName);

ManagedSteam_API bool Cloud_Delete(PConstantString fileName);

ManagedSteam_API void Cloud_Share(PConstantString fileName);

ManagedSteam_API bool Cloud_SetSyncPlatforms(PConstantString fileName, Enum remoteStoragePlatform);


ManagedSteam_API bool Cloud_Exists(PConstantString fileName);

ManagedSteam_API bool Cloud_Persisted(PConstantString fileName);

ManagedSteam_API s32 Cloud_GetSize(PConstantString fileName);

ManagedSteam_API s64 Cloud_Timestamp(PConstantString fileName);

ManagedSteam_API Enum Cloud_GetSyncPlatforms(PConstantString fileName);


ManagedSteam_API s32 Cloud_GetFileCount();

ManagedSteam_API PConstantString Cloud_GetFileNameAndSize(s32 fileID, s32 *fileSize);


ManagedSteam_API bool Cloud_GetQuota(s32 *totalBytes, s32 *availableBytes);

ManagedSteam_API bool Cloud_IsEnabledForAccount();

ManagedSteam_API bool Cloud_IsEnabledForApplication();

ManagedSteam_API void Cloud_SetEnabledForApplication(bool enabled);


ManagedSteam_API void Cloud_UGCDownload(UGCHandle handle, u32 unPriority);

ManagedSteam_API bool Cloud_GetUGCDownloadProgress(UGCHandle handle, s32 *bytesDownloaded, s32 *bytesExpected);

ManagedSteam_API bool Cloud_GetUGCDetails(UGCHandle handle, u32 *appID, char **name, s32 *fileSize, SteamID *creator);

ManagedSteam_API s32 Cloud_UGCRead(UGCHandle handle, PDataPointer buffer, s32 bufferLength, u32 offset, Enum action);

ManagedSteam_API s32 Cloud_GetCachedUGCCount();

ManagedSteam_API UGCHandle Cloud_GetUGCHandle(s32 handleID);


// publishing UGC
ManagedSteam_API void Cloud_PublishWorkshopFile(PConstantString fileName, PConstantString previewFile, u32 consumerAppId, PConstantString title, PConstantString description, Enum visibility, PDataPointer tags, Enum workshopFileType);
ManagedSteam_API PublishedFileUpdateHandle Cloud_CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId);
ManagedSteam_API bool Cloud_UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, PConstantString file);
ManagedSteam_API bool Cloud_UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, PConstantString previewFile);
ManagedSteam_API bool Cloud_UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, PConstantString title);
ManagedSteam_API bool Cloud_UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, PConstantString description );
ManagedSteam_API bool Cloud_UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Enum visibility);
ManagedSteam_API bool Cloud_UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle,  PDataPointer tags);

ManagedSteam_API void Cloud_CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle);
ManagedSteam_API void Cloud_GetPublishedFileDetails(PublishedFileId publishedFileId, u32 maxSecondsOld);
ManagedSteam_API void Cloud_DeletePublishedFile(PublishedFileId publishedFileId);
ManagedSteam_API void Cloud_EnumerateUserPublishedFiles(u32 startIndex);
ManagedSteam_API void Cloud_SubscribePublishedFile(PublishedFileId publishedFileId);
ManagedSteam_API void Cloud_EnumerateUserSubscribedFiles(u32 startIndex);
ManagedSteam_API void Cloud_UnsubscribePublishedFile(PublishedFileId publishedFileId);
ManagedSteam_API bool Cloud_UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, PConstantString changeDescription);
ManagedSteam_API void Cloud_GetPublishedItemVoteDetails(PublishedFileId publishedFileId);
ManagedSteam_API void Cloud_UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp);
ManagedSteam_API void Cloud_GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId);
ManagedSteam_API void Cloud_EnumerateUserSharedWorkshopFiles(SteamID steamId, u32 startIndex, PDataPointer requiredTags, PDataPointer excludedTags);
ManagedSteam_API void Cloud_PublishVideo(EWorkshopVideoProvider eVideoProvider,PConstantString pchVideoAccount, PConstantString pchVideoIdentifier, PConstantString pchPreviewFile, AppID nConsumerAppId, PConstantString pchTitle, PConstantString pchDescription, ERemoteStoragePublishedFileVisibility visibility, PDataPointer tags);
ManagedSteam_API void Cloud_SetUserPublishedFileAction(PublishedFileId publishedFileId, Enum action);
ManagedSteam_API void Cloud_EnumeratePublishedFilesByUserAction(Enum action, u32 startIndex);
ManagedSteam_API void Cloud_EnumeratePublishedWorkshopFiles(Enum enumerationType, u32 startIndex, u32 count, u32 days, PDataPointer tags, PDataPointer userTags);

ManagedSteam_API void Cloud_UGCDownloadToLocation( UGCHandle content, PConstantString location, u32 priority );
#endif // RemoteStorage_h_interop_