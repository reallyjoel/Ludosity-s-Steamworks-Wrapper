#ifndef RemoteStorage_h_
#define RemoteStorage_h_

#include "Cloud.h"
#include "Singleton.hpp"
#include "Services.hpp"

// Types
#include "ConvertedStructures.hpp"
#include "ResultID.hpp"

#include "Helper.hpp"

using namespace SteamAPIWrap;


namespace SteamAPIWrap
{
	class CCloud : public CSingleton<CCloud>
	{
		SW_ASYNC_RESULT(CCloud, RemoteStorageFileShareResult_t, CloudFileShareResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageDownloadUGCResult_t, CloudDownloadUGCResult);
		SW_ASYNC_RESULT(CCloud, RemoteStoragePublishFileResult_t, CloudPublishFileResult);

		SW_ASYNC_RESULT(CCloud, RemoteStorageUpdatePublishedFileResult_t, CloudUpdatePublishedFileResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageGetPublishedFileDetailsResult_t, CloudGetPublishedFileDetailsResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageDeletePublishedFileResult_t, CloudDeletePublishedFileResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageEnumerateUserPublishedFilesResult_t, CloudEnumerateUserPublishedFilesResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageSubscribePublishedFileResult_t, CloudSubscribePublishedFileResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageEnumerateUserSubscribedFilesResult_t, CloudEnumerateUserSubscribedFilesResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageUnsubscribePublishedFileResult_t, CloudUnsubscribePublishedFileResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageGetPublishedItemVoteDetailsResult_t, CloudGetPublishedItemVoteDetailsResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageUpdateUserPublishedItemVoteResult_t, CloudUpdateUserPublishedItemVoteResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageUserVoteDetails_t, CloudUserVoteDetails);
		SW_ASYNC_RESULT(CCloud, RemoteStorageEnumerateUserSharedWorkshopFilesResult_t, CloudEnumerateUserSharedWorkshopFilesResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageSetUserPublishedFileActionResult_t, CloudSetUserPublishedFileActionResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageEnumeratePublishedFilesByUserActionResult_t, CloudEnumeratePublishedFilesByUserActionResult);
		SW_ASYNC_RESULT(CCloud, RemoteStorageEnumerateWorkshopFilesResult_t, CloudEnumerateWorkshopFilesResult);

		//SW_ASYNC_RESULT(CCloud, PublishVideo, PublishVideoResult);
		SW_CALLBACK(CCloud, RemoteStoragePublishFileProgress_t, CloudPublishFileProgress);
		SW_CALLBACK(CCloud, RemoteStoragePublishedFileUpdated_t, CloudPublishedFileUpdated);
		
		// Added in 1.9.128 patch
		SW_CALLBACK(CCloud, RemoteStoragePublishedFileSubscribed_t, CloudPublishedFileSubscribed);
		SW_CALLBACK(CCloud, RemoteStoragePublishedFileUnsubscribed_t, CloudPublishedFileUnsubscribed);
		SW_CALLBACK(CCloud, RemoteStoragePublishedFileDeleted_t, CloudPublishedFileDeleted);

	public:
		
		//////////////////////////////////////////////////////////////////////////
		// Internal stuff

		void SetSteamInterface(ISteamRemoteStorage *cloud);
		void RunCallbackSizeCheck();

		//////////////////////////////////////////////////////////////////////////
		// Wrappers for Steam methods

		bool Write(PConstantString fileName, PConstantDataPointer buffer, s32 bufferLength);

		s32 Read(PConstantString fileName, PDataPointer buffer, s32 bufferLength);

		bool Forget(PConstantString fileName);

		bool Delete(PConstantString fileName);

		void Share(PConstantString fileName);

		bool SetSyncPlatforms(PConstantString fileName, Enum remoteStoragePlatform);

		bool Exists(PConstantString fileName);

		bool Persisted(PConstantString fileName);

		s32 GetSize(PConstantString fileName);

		s64 Timestamp(PConstantString fileName);

		Enum GetSyncPlatforms(PConstantString fileName);

		
		s32 GetFileCount();

		PConstantString GetFileNameAndSize(s32 fileID, s32 *fileSize);

		bool GetQuota(s32 *totalBytes, s32 *availableBytes);

		bool IsEnabledForAccount();

		bool IsEnabledForApplication();

		void SetEnabledForApplication(bool enabled);



		void UGCDownload(UGCHandle handle, u32 unPriority);

		bool GetUGCDownloadProgress(UGCHandle handle, s32 *bytesDownloaded, s32 *bytesExpected);

		bool GetUGCDetails(UGCHandle handle, u32 *appID, char **name, s32 *fileSize, SteamID *creator);

		s32 UGCRead(UGCHandle handle, PDataPointer buffer, s32 bufferLength, u32 offset, Enum action);

		s32 GetCachedUGCCount();

		UGCHandle GetUGCHandle(s32 handleID);

		void PublishWorkshopFile(PConstantString fileName, PConstantString previewFile, u32 consumerAppId, 
			PConstantString title, PConstantString description, Enum visibility, 
			PDataPointer tags, Enum workshopFileType);

		PublishedFileUpdateHandle CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId);
		bool UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, PConstantString file);
		bool UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, PConstantString previewFile);
		bool UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, PConstantString title);
		bool UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, PConstantString description );
		bool UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Enum visibility);
		bool UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle,  PDataPointer tags);

		void CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle);
		void GetPublishedFileDetails(PublishedFileId publishedFileId, u32 maxSecondsOld);
		void DeletePublishedFile(PublishedFileId publishedFileId);
		void EnumerateUserPublishedFiles(u32 startIndex);
		void SubscribePublishedFile(PublishedFileId publishedFileId);
		void EnumerateUserSubscribedFiles(u32 startIndex);
		void UnsubscribePublishedFile(PublishedFileId publishedFileId);
		bool UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, PConstantString changeDescription);
		void GetPublishedItemVoteDetails(PublishedFileId publishedFileId);
		void UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp);
		void GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId);
		void EnumerateUserSharedWorkshopFiles(SteamID steamId, u32 startIndex, PDataPointer requiredTags, PDataPointer excludedTags);
		void PublishVideo(EWorkshopVideoProvider eVideoProvider,PConstantString pchVideoAccount, PConstantString pchVideoIdentifier, PConstantString pchPreviewFile, AppID nConsumerAppId, PConstantString pchTitle, PConstantString pchDescription, ERemoteStoragePublishedFileVisibility visibility, PDataPointer tags);
		void SetUserPublishedFileAction(PublishedFileId publishedFileId, Enum action);
		void EnumeratePublishedFilesByUserAction(Enum action, u32 startIndex);
		void EnumeratePublishedWorkshopFiles(Enum enumerationType, u32 startIndex, u32 count, u32 days, PDataPointer tags, PDataPointer userTags);

		void UGCDownloadToLocation( UGCHandle content, PConstantString location, u32 priority );
	private:
		friend class CSingleton<CCloud>;
		CCloud();
		~CCloud() {}
		DISALLOW_COPY_AND_ASSIGN(CCloud);

		ISteamRemoteStorage *cloud;
	};
}

#endif // RemoteStorage_h_