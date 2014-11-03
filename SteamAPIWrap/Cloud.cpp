#include "Precompiled.hpp"
#include "Cloud.hpp"

#include "Services.hpp"
#include "Helper.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CCloud *CSingleton<CCloud>::instance = nullptr;

	CCloud::CCloud()
		: nativeCloudPublishFileProgressCallback(this, &CCloud::OnCloudPublishFileProgress)
		, nativeCloudPublishedFileUpdatedCallback(this, &CCloud::OnCloudPublishedFileUpdated)
		, nativeCloudPublishedFileSubscribedCallback(this, &CCloud::OnCloudPublishedFileSubscribed)
		, nativeCloudPublishedFileUnsubscribedCallback(this, &CCloud::OnCloudPublishedFileUnsubscribed)
		, nativeCloudPublishedFileDeletedCallback(this, &CCloud::OnCloudPublishedFileDeleted)
		, cloud(nullptr)
	{

	}

	void CCloud::RunCallbackSizeCheck()
	{
        RemoteStoragePublishFileProgress_t* remoteStoragePublishFileProgress = new RemoteStoragePublishFileProgress_t();
		OnCloudPublishFileProgress(remoteStoragePublishFileProgress);
		delete remoteStoragePublishFileProgress;

		RemoteStoragePublishedFileUpdated_t* remoteStoragePublishedFileUpdated = new RemoteStoragePublishedFileUpdated_t();
		OnCloudPublishedFileUpdated(remoteStoragePublishedFileUpdated);
		delete remoteStoragePublishedFileUpdated;

		RemoteStorageFileShareResult_t* remoteStorageFileShareResult = new RemoteStorageFileShareResult_t();
		OnCloudFileShareResult(remoteStorageFileShareResult, false);
		delete remoteStorageFileShareResult;
		
		RemoteStorageDownloadUGCResult_t* remoteStorageDownloadUGCResult = new RemoteStorageDownloadUGCResult_t();
		OnCloudDownloadUGCResult(remoteStorageDownloadUGCResult, false);
		delete remoteStorageDownloadUGCResult;
		
		RemoteStoragePublishFileResult_t* remoteStoragePublishFileResult = new RemoteStoragePublishFileResult_t();
		OnCloudPublishFileResult(remoteStoragePublishFileResult, false);
		delete remoteStoragePublishFileResult;
		
		RemoteStorageUpdatePublishedFileResult_t* remoteStorageUpdatePublishedFileResult = new RemoteStorageUpdatePublishedFileResult_t();
		OnCloudUpdatePublishedFileResult(remoteStorageUpdatePublishedFileResult, false);
		delete remoteStorageUpdatePublishedFileResult;
		
		RemoteStorageGetPublishedFileDetailsResult_t* remoteStorageGetPublishedFileDetailsResult = new RemoteStorageGetPublishedFileDetailsResult_t();
		OnCloudGetPublishedFileDetailsResult(remoteStorageGetPublishedFileDetailsResult, false);
		delete remoteStorageGetPublishedFileDetailsResult;
		
		RemoteStorageDeletePublishedFileResult_t* remoteStorageDeletePublishedFileResult = new RemoteStorageDeletePublishedFileResult_t();
		OnCloudDeletePublishedFileResult(remoteStorageDeletePublishedFileResult, false);
		delete remoteStorageDeletePublishedFileResult;
		
		RemoteStorageEnumerateUserPublishedFilesResult_t* remoteStorageEnumerateUserPublishedFilesResult = new RemoteStorageEnumerateUserPublishedFilesResult_t();
		OnCloudEnumerateUserPublishedFilesResult(remoteStorageEnumerateUserPublishedFilesResult, false);
		delete remoteStorageEnumerateUserPublishedFilesResult;
		
		RemoteStorageSubscribePublishedFileResult_t* remoteStorageSubscribePublishedFileResult = new RemoteStorageSubscribePublishedFileResult_t();
		OnCloudSubscribePublishedFileResult(remoteStorageSubscribePublishedFileResult, false);
		delete remoteStorageSubscribePublishedFileResult;
		
		RemoteStorageEnumerateUserSubscribedFilesResult_t* remoteStorageEnumerateUserSubscribedFilesResult = new RemoteStorageEnumerateUserSubscribedFilesResult_t();
		OnCloudEnumerateUserSubscribedFilesResult(remoteStorageEnumerateUserSubscribedFilesResult, false);
		delete remoteStorageEnumerateUserSubscribedFilesResult;
		
		RemoteStorageUnsubscribePublishedFileResult_t* remoteStorageUnsubscribePublishedFileResult = new RemoteStorageUnsubscribePublishedFileResult_t();
		OnCloudUnsubscribePublishedFileResult(remoteStorageUnsubscribePublishedFileResult, false);
		delete remoteStorageUnsubscribePublishedFileResult;
		
		RemoteStorageGetPublishedItemVoteDetailsResult_t* remoteStorageGetPublishedItemVoteDetailsResult = new RemoteStorageGetPublishedItemVoteDetailsResult_t();
		OnCloudGetPublishedItemVoteDetailsResult(remoteStorageGetPublishedItemVoteDetailsResult, false);
		delete remoteStorageGetPublishedItemVoteDetailsResult;
		
		RemoteStorageUpdateUserPublishedItemVoteResult_t* remoteStorageUpdateUserPublishedItemVoteResult = new RemoteStorageUpdateUserPublishedItemVoteResult_t();
		OnCloudUpdateUserPublishedItemVoteResult(remoteStorageUpdateUserPublishedItemVoteResult, false);
		delete remoteStorageUpdateUserPublishedItemVoteResult;
		
		RemoteStorageUserVoteDetails_t* remoteStorageUserVoteDetails = new RemoteStorageUserVoteDetails_t();
		OnCloudUserVoteDetails(remoteStorageUserVoteDetails, false);
		delete remoteStorageUserVoteDetails;
		
		RemoteStorageEnumerateUserSharedWorkshopFilesResult_t* remoteStorageEnumerateUserSharedWorkshopFilesResult = new RemoteStorageEnumerateUserSharedWorkshopFilesResult_t();
		OnCloudEnumerateUserSharedWorkshopFilesResult(remoteStorageEnumerateUserSharedWorkshopFilesResult, false);
		delete remoteStorageEnumerateUserSharedWorkshopFilesResult;
		
		RemoteStorageSetUserPublishedFileActionResult_t* remoteStorageSetUserPublishedFileActionResult = new RemoteStorageSetUserPublishedFileActionResult_t();
		OnCloudSetUserPublishedFileActionResult(remoteStorageSetUserPublishedFileActionResult, false);
		delete remoteStorageSetUserPublishedFileActionResult;
		
		RemoteStorageEnumeratePublishedFilesByUserActionResult_t* remoteStorageEnumeratePublishedFilesByUserActionResult = new RemoteStorageEnumeratePublishedFilesByUserActionResult_t();
		OnCloudEnumeratePublishedFilesByUserActionResult(remoteStorageEnumeratePublishedFilesByUserActionResult, false);
		delete remoteStorageEnumeratePublishedFilesByUserActionResult;
		
		RemoteStorageEnumerateWorkshopFilesResult_t* remoteStorageEnumerateWorkshopFilesResult = new RemoteStorageEnumerateWorkshopFilesResult_t();
		OnCloudEnumerateWorkshopFilesResult(remoteStorageEnumerateWorkshopFilesResult, false);
		delete remoteStorageEnumerateWorkshopFilesResult;

		RemoteStoragePublishedFileSubscribed_t* remoteStoragePublishedFileSubscribed = new RemoteStoragePublishedFileSubscribed_t();
		OnCloudPublishedFileSubscribed(remoteStoragePublishedFileSubscribed);
		delete remoteStoragePublishedFileSubscribed;

		RemoteStoragePublishedFileUnsubscribed_t* remoteStoragePublishedFileUnsubscribed = new RemoteStoragePublishedFileUnsubscribed_t();
		OnCloudPublishedFileUnsubscribed(remoteStoragePublishedFileUnsubscribed);
		delete remoteStoragePublishedFileUnsubscribed;

		RemoteStoragePublishedFileDeleted_t* remoteStoragePublishedFileDeleted = new RemoteStoragePublishedFileDeleted_t();
		OnCloudPublishedFileDeleted(remoteStoragePublishedFileDeleted);
		delete remoteStoragePublishedFileDeleted;
	}

	void CCloud::SetSteamInterface(ISteamRemoteStorage *cloud)
	{
		this->cloud = cloud;
	}

	bool CCloud::Write(PConstantString fileName, PConstantDataPointer buffer, s32 bufferLength)
	{
		return cloud->FileWrite(fileName, buffer, bufferLength);
	}

	s32 CCloud::Read(PConstantString fileName, PDataPointer buffer, s32 bufferLength)
	{
		s32 bytesRead = cloud->FileRead(fileName, buffer, bufferLength);
		return bytesRead;
	}

	bool CCloud::Forget(PConstantString fileName)
	{
		return cloud->FileForget(fileName);
	}

	bool CCloud::Delete(PConstantString fileName)
	{
		return cloud->FileDelete(fileName);
	}

	void CCloud::Share(PConstantString fileName)
	{
		resultCloudFileShareResult.Set(cloud->FileShare(fileName), this, &CCloud::OnCloudFileShareResult);
	}

	bool CCloud::SetSyncPlatforms(PConstantString fileName, Enum remoteStoragePlatform)
	{
		return cloud->SetSyncPlatforms(fileName, static_cast<ERemoteStoragePlatform>(remoteStoragePlatform));
	}

	bool CCloud::Exists(PConstantString fileName)
	{
		return cloud->FileExists(fileName);
	}

	bool CCloud::Persisted(PConstantString fileName)
	{
		return cloud->FilePersisted(fileName);
	}

	s32 CCloud::GetSize(PConstantString fileName)
	{
		return cloud->GetFileSize(fileName);
	}

	s64 CCloud::Timestamp(PConstantString fileName)
	{
		return cloud->GetFileTimestamp(fileName);
	}

	Enum CCloud::GetSyncPlatforms(PConstantString fileName)
	{
		return cloud->GetSyncPlatforms(fileName);
	}

	s32 CCloud::GetFileCount()
	{
		return cloud->GetFileCount();
	}

	PConstantString CCloud::GetFileNameAndSize(s32 fileID, s32 *fileSize)
	{
		return cloud->GetFileNameAndSize(fileID, fileSize);
	}

	bool CCloud::GetQuota(s32 *totalBytes, s32 *availableBytes)
	{
		return cloud->GetQuota(totalBytes, availableBytes);
	}

	bool CCloud::IsEnabledForAccount()
	{
		return cloud->IsCloudEnabledForAccount();
	}

	bool CCloud::IsEnabledForApplication()
	{
		return cloud->IsCloudEnabledForApp();
	}

	void CCloud::SetEnabledForApplication(bool enabled)
	{
		cloud->SetCloudEnabledForApp(enabled);
	}

	void CCloud::UGCDownload(UGCHandle handle, u32 unPriority)
	{
		resultCloudDownloadUGCResult.Set(cloud->UGCDownload(handle, unPriority), this, &CCloud::OnCloudDownloadUGCResult);
	}

	bool CCloud::GetUGCDownloadProgress(UGCHandle handle, s32 *bytesDownloaded, s32 *bytesExpected)
	{
		return cloud->GetUGCDownloadProgress(handle, bytesDownloaded, bytesExpected);
	}

	bool CCloud::GetUGCDetails(UGCHandle handle, u32 *appID, char **name, s32 *fileSize, SteamID *creator)
	{
		CSteamID id;
		bool result = cloud->GetUGCDetails(handle, appID, name, fileSize, &id);
		*creator = id.ConvertToUint64();

		return result;
	}

	s32 CCloud::UGCRead(UGCHandle handle, PDataPointer buffer, s32 bufferLength, u32 offset, Enum action)
	{
		s32 bytesRead = cloud->UGCRead(handle, buffer, bufferLength, offset, static_cast<EUGCReadAction>(action));
		return bytesRead;
	}

	s32 CCloud::GetCachedUGCCount()
	{
		return cloud->GetCachedUGCCount();
	}

	UGCHandle CCloud::GetUGCHandle(s32 handleID)
	{
		return cloud->GetCachedUGCHandle(handleID);
	}


	void CCloud::PublishWorkshopFile(PConstantString fileName, PConstantString previewFile, u32 consumerAppId, 
		PConstantString title, PConstantString description, Enum visibility, PDataPointer tags, 
		Enum workshopFileType)
	{
		resultCloudPublishFileResult.Set(cloud->PublishWorkshopFile(fileName, previewFile, consumerAppId,
			title, description, static_cast<ERemoteStoragePublishedFileVisibility>(visibility),
			reinterpret_cast<SteamParamStringArray_t *>(tags), static_cast<EWorkshopFileType>(workshopFileType)),
			this, &CCloud::OnCloudPublishFileResult);
	}

	PublishedFileUpdateHandle CCloud::CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId)
	{
		return cloud->CreatePublishedFileUpdateRequest(publishedFileId);
	}

	bool CCloud::UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, PConstantString file)
	{
		return cloud->UpdatePublishedFileFile(updateHandle, file);
	}

	bool CCloud::UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, PConstantString previewFile)
	{
		return cloud->UpdatePublishedFilePreviewFile(updateHandle, previewFile);
	}

	bool CCloud::UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, PConstantString title)
	{
		return cloud->UpdatePublishedFileTitle(updateHandle, title);
	}

	bool CCloud::UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, PConstantString description)
	{
		return cloud->UpdatePublishedFileDescription(updateHandle, description);
	}

	bool CCloud::UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Enum visibility)
	{
		return cloud->UpdatePublishedFileVisibility(updateHandle, static_cast<ERemoteStoragePublishedFileVisibility>(visibility));
	}

	bool CCloud::UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle, PDataPointer tags)
	{
		return cloud->UpdatePublishedFileTags(updateHandle, reinterpret_cast<SteamParamStringArray_t *>(tags));
	}

	void CCloud::CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle)
	{
		resultCloudUpdatePublishedFileResult.Set(cloud->CommitPublishedFileUpdate(updateHandle), this, 
			&CCloud::OnCloudUpdatePublishedFileResult);
	}

	void CCloud::GetPublishedFileDetails(PublishedFileId publishedFileId, u32 maxSecondsOld)
	{
		resultCloudGetPublishedFileDetailsResult.Set(cloud->GetPublishedFileDetails(publishedFileId, maxSecondsOld), this, 
			&CCloud::OnCloudGetPublishedFileDetailsResult);
	}

	void CCloud::DeletePublishedFile(PublishedFileId publishedFileId)
	{
		resultCloudDeletePublishedFileResult.Set(cloud->DeletePublishedFile(publishedFileId), this,
			&CCloud::OnCloudDeletePublishedFileResult);
	}

	void CCloud::EnumerateUserPublishedFiles(u32 startIndex)
	{
		resultCloudEnumerateUserPublishedFilesResult.Set(cloud->EnumerateUserPublishedFiles(startIndex), this,
			&CCloud::OnCloudEnumerateUserPublishedFilesResult);
	}

	void CCloud::SubscribePublishedFile(PublishedFileId publishedFileId)
	{
		resultCloudSubscribePublishedFileResult.Set(cloud->SubscribePublishedFile(publishedFileId), this,
			&CCloud::OnCloudSubscribePublishedFileResult);
	}

	void CCloud::EnumerateUserSubscribedFiles(u32 startIndex)
	{
		resultCloudEnumerateUserSubscribedFilesResult.Set(cloud->EnumerateUserSubscribedFiles(startIndex), this,
			&CCloud::OnCloudEnumerateUserSubscribedFilesResult);
	}

	void CCloud::UnsubscribePublishedFile(PublishedFileId publishedFileId)
	{
		resultCloudUnsubscribePublishedFileResult.Set(cloud->UnsubscribePublishedFile(publishedFileId), this,
			&CCloud::OnCloudUnsubscribePublishedFileResult);
	}

	bool CCloud::UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, PConstantString changeDescription)
	{
		return cloud->UpdatePublishedFileSetChangeDescription(updateHandle, changeDescription);
	}

	void CCloud::GetPublishedItemVoteDetails(PublishedFileId publishedFileId)
	{
		resultCloudGetPublishedItemVoteDetailsResult.Set(cloud->GetPublishedItemVoteDetails(publishedFileId), this,
			&CCloud::OnCloudGetPublishedItemVoteDetailsResult);
	}

	void CCloud::UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp)
	{
		resultCloudUpdateUserPublishedItemVoteResult.Set(cloud->UpdateUserPublishedItemVote(publishedFileId, voteUp),
			this, &CCloud::OnCloudUpdateUserPublishedItemVoteResult);
	}

	void CCloud::GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId)
	{
		resultCloudUserVoteDetails.Set(cloud->GetUserPublishedItemVoteDetails(publishedFileId), this,
			&CCloud::OnCloudUserVoteDetails);
	}

	void CCloud::EnumerateUserSharedWorkshopFiles(SteamID steamId, u32 startIndex, PDataPointer requiredTags, PDataPointer excludedTags)
	{
		CSteamID id(steamId);
		resultCloudEnumerateUserSharedWorkshopFilesResult.Set(cloud->EnumerateUserSharedWorkshopFiles(id, startIndex,
			reinterpret_cast<SteamParamStringArray_t *>(requiredTags), 
			reinterpret_cast<SteamParamStringArray_t *>(excludedTags)),
			this, &CCloud::OnCloudEnumerateUserSharedWorkshopFilesResult);
	}

	void CCloud::PublishVideo(EWorkshopVideoProvider eVideoProvider,PConstantString pchVideoAccount, PConstantString pchVideoIdentifier, PConstantString pchPreviewFile, AppID nConsumerAppId, PConstantString pchTitle, PConstantString pchDescription, ERemoteStoragePublishedFileVisibility visibility, PDataPointer tags)
	{
		// TODO Assign this callback to something
		cloud->PublishVideo(eVideoProvider, pchVideoAccount, pchVideoIdentifier, pchPreviewFile, 
			nConsumerAppId, pchTitle, pchDescription, visibility,
			reinterpret_cast<SteamParamStringArray_t *>(tags));
	}

	void CCloud::SetUserPublishedFileAction(PublishedFileId publishedFileId, Enum action)
	{
		resultCloudSetUserPublishedFileActionResult.Set(cloud->SetUserPublishedFileAction(publishedFileId,
			static_cast<EWorkshopFileAction>(action)), this, &CCloud::OnCloudSetUserPublishedFileActionResult);
	}

	void CCloud::EnumeratePublishedFilesByUserAction(Enum action, u32 startIndex)
	{
		resultCloudEnumeratePublishedFilesByUserActionResult.Set(cloud->EnumeratePublishedFilesByUserAction(
			static_cast<EWorkshopFileAction>(action), startIndex), this, 
			&CCloud::OnCloudEnumeratePublishedFilesByUserActionResult);
	}

	void CCloud::EnumeratePublishedWorkshopFiles(Enum enumerationType, u32 startIndex, u32 count, u32 days, PDataPointer tags, PDataPointer userTags)
	{
		resultCloudEnumerateWorkshopFilesResult.Set(cloud->EnumeratePublishedWorkshopFiles(
			static_cast<EWorkshopEnumerationType>(enumerationType), startIndex, count, days,
			reinterpret_cast<SteamParamStringArray_t *>(tags),
			reinterpret_cast<SteamParamStringArray_t *>(userTags)),
			this, &CCloud::OnCloudEnumerateWorkshopFilesResult);
	}

	void CCloud::UGCDownloadToLocation( UGCHandle content, PConstantString location, u32 priority )
	{
		cloud->UGCDownloadToLocation( content, location, priority );
	}
}

ManagedSteam_API bool Cloud_Write(PConstantString fileName, PConstantDataPointer buffer, s32 bufferLength)
{
	return CCloud::Instance().Write(fileName, buffer, bufferLength);
}

ManagedSteam_API s32 Cloud_Read(PConstantString fileName, PDataPointer buffer, s32 bufferLength)
{
	return CCloud::Instance().Read(fileName, buffer, bufferLength);
}

ManagedSteam_API bool Cloud_Forget(PConstantString fileName)
{
	return CCloud::Instance().Forget(fileName);
}

ManagedSteam_API bool Cloud_Delete(PConstantString fileName)
{
	return CCloud::Instance().Delete(fileName);
}

ManagedSteam_API void Cloud_Share(PConstantString fileName)
{
	CCloud::Instance().Share(fileName);
}

ManagedSteam_API bool Cloud_SetSyncPlatforms(PConstantString fileName, Enum remoteStoragePlatform)
{
	return CCloud::Instance().SetSyncPlatforms(fileName, remoteStoragePlatform);
}

ManagedSteam_API bool Cloud_Exists(PConstantString fileName)
{
	return CCloud::Instance().Exists(fileName);
}

ManagedSteam_API bool Cloud_Persisted(PConstantString fileName)
{
	return CCloud::Instance().Persisted(fileName);
}

ManagedSteam_API s32 Cloud_GetSize(PConstantString fileName)
{
	return CCloud::Instance().GetSize(fileName);
}

ManagedSteam_API s64 Cloud_Timestamp(PConstantString fileName)
{
	return CCloud::Instance().Timestamp(fileName);
}

ManagedSteam_API Enum Cloud_GetSyncPlatforms(PConstantString fileName)
{
	return CCloud::Instance().GetSyncPlatforms(fileName);
}

ManagedSteam_API s32 Cloud_GetFileCount()
{
	return CCloud::Instance().GetFileCount();
}

ManagedSteam_API PConstantString Cloud_GetFileNameAndSize(s32 fileID, s32 *fileSize)
{
	return CCloud::Instance().GetFileNameAndSize(fileID, fileSize);
}

ManagedSteam_API bool Cloud_GetQuota(s32 *totalBytes, s32 *availableBytes)
{
	return CCloud::Instance().GetQuota(totalBytes, availableBytes);
}

ManagedSteam_API bool Cloud_IsEnabledForAccount()
{
	return CCloud::Instance().IsEnabledForAccount();
}

ManagedSteam_API bool Cloud_IsEnabledForApplication()
{
	return CCloud::Instance().IsEnabledForApplication();
}

ManagedSteam_API void Cloud_SetEnabledForApplication(bool enabled)
{
	return CCloud::Instance().SetEnabledForApplication(enabled);
}

ManagedSteam_API void Cloud_UGCDownload(UGCHandle handle, u32 unPriority)
{
	CCloud::Instance().UGCDownload(handle, unPriority);
}

ManagedSteam_API bool Cloud_GetUGCDownloadProgress(UGCHandle handle, s32 *bytesDownloaded, s32 *bytesExpected)
{
	return CCloud::Instance().GetUGCDownloadProgress(handle, bytesDownloaded, bytesExpected);
}

ManagedSteam_API bool Cloud_GetUGCDetails(UGCHandle handle, u32 *appID, char **name, s32 *fileSize, SteamID *creator)
{
	return CCloud::Instance().GetUGCDetails(handle, appID, name, fileSize, creator);
}

ManagedSteam_API s32 Cloud_UGCRead(UGCHandle handle, PDataPointer buffer, s32 bufferSize, u32 offset, Enum action)
{
	return CCloud::Instance().UGCRead(handle, buffer, bufferSize, offset, action);
}

ManagedSteam_API s32 Cloud_GetCachedUGCCount()
{
	return CCloud::Instance().GetCachedUGCCount();
}

ManagedSteam_API UGCHandle Cloud_GetUGCHandle(s32 handleID)
{
	return CCloud::Instance().GetUGCHandle(handleID);
}


ManagedSteam_API void Cloud_PublishWorkshopFile(PConstantString fileName, PConstantString previewFile, 
	u32 consumerAppId, PConstantString title, PConstantString description, Enum visibility, 
	PDataPointer tags, Enum workshopFileType)
{
	CCloud::Instance().PublishWorkshopFile(fileName, previewFile, consumerAppId, title, description, visibility, tags, workshopFileType);
}

ManagedSteam_API PublishedFileUpdateHandle Cloud_CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId)
{
	return CCloud::Instance().CreatePublishedFileUpdateRequest(publishedFileId);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, PConstantString file)
{
	return CCloud::Instance().UpdatePublishedFileFile(updateHandle, file);
}

ManagedSteam_API bool Cloud_UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, PConstantString previewFile)
{
	return CCloud::Instance().UpdatePublishedFilePreviewFile(updateHandle, previewFile);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, PConstantString title)
{
	return CCloud::Instance().UpdatePublishedFileTitle(updateHandle, title);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, PConstantString description)
{
	return CCloud::Instance().UpdatePublishedFileDescription(updateHandle, description);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Enum visibility)
{
	return CCloud::Instance().UpdatePublishedFileVisibility(updateHandle, visibility);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle, PDataPointer tags)
{
	return CCloud::Instance().UpdatePublishedFileTags(updateHandle, tags);
}

ManagedSteam_API void Cloud_CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle)
{
	return CCloud::Instance().CommitPublishedFileUpdate(updateHandle);
}

ManagedSteam_API void Cloud_GetPublishedFileDetails(PublishedFileId publishedFileId, u32 maxSecondsOld)
{
	CCloud::Instance().GetPublishedFileDetails(publishedFileId, maxSecondsOld);
}

ManagedSteam_API void Cloud_DeletePublishedFile(PublishedFileId publishedFileId)
{
	CCloud::Instance().DeletePublishedFile(publishedFileId);
}

ManagedSteam_API void Cloud_EnumerateUserPublishedFiles(u32 startIndex)
{
	CCloud::Instance().EnumerateUserPublishedFiles(startIndex);
}

ManagedSteam_API void Cloud_SubscribePublishedFile(PublishedFileId publishedFileId)
{
	CCloud::Instance().SubscribePublishedFile(publishedFileId);
}

ManagedSteam_API void Cloud_EnumerateUserSubscribedFiles(u32 startIndex)
{
	CCloud::Instance().EnumerateUserSubscribedFiles(startIndex);
}

ManagedSteam_API void Cloud_UnsubscribePublishedFile(PublishedFileId publishedFileId)
{
	CCloud::Instance().UnsubscribePublishedFile(publishedFileId);
}

ManagedSteam_API bool Cloud_UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, PConstantString changeDescription)
{
	return CCloud::Instance().UpdatePublishedFileSetChangeDescription(updateHandle, changeDescription);
}

ManagedSteam_API void Cloud_GetPublishedItemVoteDetails(PublishedFileId publishedFileId)
{
	CCloud::Instance().GetPublishedItemVoteDetails(publishedFileId);
}

ManagedSteam_API void Cloud_UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp)
{
	CCloud::Instance().UpdateUserPublishedItemVote(publishedFileId, voteUp);
}

ManagedSteam_API void Cloud_GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId)
{
	CCloud::Instance().GetUserPublishedItemVoteDetails(publishedFileId);
}

ManagedSteam_API void Cloud_EnumerateUserSharedWorkshopFiles(SteamID steamId, u32 startIndex, PDataPointer requiredTags, PDataPointer excludedTags)
{
	CCloud::Instance().EnumerateUserSharedWorkshopFiles(steamId, startIndex, requiredTags, excludedTags);
}

ManagedSteam_API void Cloud_PublishVideo(EWorkshopVideoProvider eVideoProvider,PConstantString pchVideoAccount, PConstantString pchVideoIdentifier, PConstantString pchPreviewFile, AppID nConsumerAppId, PConstantString pchTitle, PConstantString pchDescription, ERemoteStoragePublishedFileVisibility visibility, PDataPointer tags)
{
	CCloud::Instance().PublishVideo(eVideoProvider, pchVideoAccount, pchVideoIdentifier, pchPreviewFile, nConsumerAppId, pchTitle, pchDescription, visibility, reinterpret_cast<SteamParamStringArray_t *>(tags));
}

ManagedSteam_API void Cloud_SetUserPublishedFileAction(PublishedFileId publishedFileId, Enum action)
{
	CCloud::Instance().SetUserPublishedFileAction(publishedFileId, action);
}

ManagedSteam_API void Cloud_EnumeratePublishedFilesByUserAction(Enum action, u32 startIndex)
{
	CCloud::Instance().EnumeratePublishedFilesByUserAction(action, startIndex);
}

ManagedSteam_API void Cloud_EnumeratePublishedWorkshopFiles(Enum enumerationType, u32 startIndex, u32 count, u32 days, PDataPointer tags, PDataPointer userTags)
{
	CCloud::Instance().EnumeratePublishedWorkshopFiles(enumerationType, startIndex, count, days, tags, userTags);
}

ManagedSteam_API void Cloud_UGCDownloadToLocation( UGCHandle content, PConstantString location, u32 priority )
{
	CCloud::Instance().UGCDownloadToLocation( content, location, priority );
}