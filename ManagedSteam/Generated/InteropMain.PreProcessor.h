// include SteamAPIWrap\InteropMain.h followed -> SteamAPIWrap\InteropMain.h
// include SteamAPIWrap\InteropMain.h start





// Defined: INTEROP_CONVERSION -> 
// Defined: WIN32 -> 

// Defined: ManagedSteam_API -> 
// Defined: ManagedSteam_API_Lite -> 

// include Types.h followed -> SteamAPIWrap\Types.h
// include Types.h start
// False: [ifndef] [Types_h_] 
// Defined: Types_h_ -> 


// include steamtypes.h followed -> SteamworksSDK\public\steam\steamtypes.h
// include steamtypes.h start






// False: [ifndef] [STEAMTYPES_H] 
// Defined: STEAMTYPES_H -> 
// True: [if] [_WIN32] 


// False: [ifndef] [WCHARTYPES_H] 
typedef unsigned char uint8;

// False: [if] [defined] [(] [__GNUC__] [)] [&&] [!] [defined] [(] [POSIX] [)] 
// Skipped: [if] [__GNUC__] [<] [4] 
// Skipped: [error] ["Steamworks requires GCC 4.X (4.2 or 4.4 have been tested)"] 
// Skipped: [endif] 
// Skipped: [define] [POSIX] [1] 

// False: [if] [defined] [(] [__x86_64__] [)] [||] [defined] [(] [_WIN64] [)] 
// Skipped: [define] [X64BITS] 


// False: [if] [!] [defined] [(] [VALVE_BIG_ENDIAN] [)] [&&] [defined] [(] [_PS3] [)] 
// Skipped: [define] [VALVE_BIG_ENDIAN] 

typedef unsigned char uint8;
typedef signed char int8;

// True: [if] [defined] [(] [_WIN32] [)] 

typedef __int16 int16;
typedef unsigned __int16 uint16;
typedef __int32 int32;
typedef unsigned __int32 uint32;
typedef __int64 int64;
typedef unsigned __int64 uint64;

// False: [if] [X64BITS] 
// Skipped: [typedef] [__int64] [intp] [;] 
// Skipped: [typedef] [unsigned] [__int64] [uintp] [;] 
typedef __int32 intp;
typedef unsigned __int32 uintp;

// Skipped: 
// Skipped: [typedef] [short] [int16] [;] 
// Skipped: [typedef] [unsigned] [short] [uint16] [;] 
// Skipped: [typedef] [int] [int32] [;] 
// Skipped: [typedef] [unsigned] [int] [uint32] [;] 
// Skipped: [typedef] [long] [long] [int64] [;] 
// Skipped: [typedef] [unsigned] [long] [long] [uint64] [;] 
// Skipped: [if] [X64BITS] 
// Skipped: [typedef] [long] [long] [intp] [;] 
// Skipped: [typedef] [unsigned] [long] [long] [uintp] [;] 
// Skipped: [else] 
// Skipped: [typedef] [int] [intp] [;] 
// Skipped: [typedef] [unsigned] [int] [uintp] [;] 
// Skipped: [endif] 
// Skipped: 
// Skipped: [endif] 

const int k_cubSaltSize   = 8;
typedef	uint8 Salt_t[ k_cubSaltSize ];







typedef uint64 GID_t;

const GID_t k_GIDNil = 0xffffffffffffffffull;


typedef GID_t JobID_t;			
typedef GID_t TxnID_t;			

const GID_t k_TxnIDNil = k_GIDNil;
const GID_t k_TxnIDUnknown = 0;




typedef uint32 PackageId_t;
const PackageId_t k_uPackageIdFreeSub = 0x0;
const PackageId_t k_uPackageIdInvalid = 0xFFFFFFFF;




typedef uint32 AppId_t;
const AppId_t k_uAppIdInvalid = 0x0;

typedef uint64 AssetClassId_t;
const AssetClassId_t k_ulAssetClassIdInvalid = 0x0;

typedef uint32 PhysicalItemId_t;
const PhysicalItemId_t k_uPhysicalItemIdInvalid = 0x0;






typedef uint32 DepotId_t;
const DepotId_t k_uDepotIdInvalid = 0x0;




typedef uint32 RTime32;

typedef uint32 CellID_t;
const CellID_t k_uCellIDInvalid = 0xFFFFFFFF;


typedef uint64 SteamAPICall_t;
const SteamAPICall_t k_uAPICallInvalid = 0x0;

typedef uint32 AccountID_t;


// include steamtypes.h end

typedef uint8 u8;
typedef int8 s8;

typedef int16 s16;
typedef uint16 u16;
typedef int32 s32;
typedef uint32 u32;
typedef int64 s64;
typedef uint64 u64;

typedef intp sptr;
typedef uintp uptr;

typedef float f32;
typedef double f64;

typedef s32 Enum;

typedef char * PString;
typedef void * PUtf8String;
typedef char * PAnsiString;

typedef const char * PConstantString;
typedef const void * PConstantUtf8String;
typedef const char * PConstantAnsiString;

typedef const void * PConstantDataPointer;
typedef void * PDataPointer;

typedef u64 UGCHandle;
typedef u64 SteamID;
typedef u64 SteamLeaderboard;
typedef u64 SteamLeaderboardEntries;
typedef u64 PublishedFileUpdateHandle;
typedef u64 PublishedFileId;
typedef u32 AppID;
typedef u32 AuthTicket;
typedef u32 NetListenSocket;
typedef u32 NetSocket;



typedef uptr ServerListRequest;
typedef s32 ServerQuery;


// True: [if] [WIN32] 
// Defined: SW_MANAGED_CALLBACK_TYPE -> (returnType,callbackName,parameters) typedef returnType (__stdcall *callbackName)parameters
// Skipped: [define] [SW_MANAGED_CALLBACK_TYPE] [(] [returnType] [,] [callbackName] [,] [parameters] [)] [typedef] [returnType] [(] [*] [callbackName] [)] [parameters] [__attribute__] [(] [(] [stdcall] [)] [)] 
// Skipped: [endif] 

typedef void (__stdcall * ManagedCallback) (Enum id PConstantDataPointer data s32 dataSize);
typedef void (__stdcall * ManagedResultCallback) (Enum id PConstantDataPointer data s32 dataSize bool ioFailure);

typedef void (__stdcall * MatchmakingServerListResponse_ServerRespondedCallback) (uptr sender uptr request s32 server);
typedef void (__stdcall * MatchmakingServerListResponse_ServerFailedToRespond) (uptr sender uptr request s32 server);
typedef void (__stdcall * MatchmakingServerListResponse_RefreshComplete) (uptr sender uptr request Enum response);

typedef void (__stdcall * MatchmakingPingResponse_ServerRespondedCallback) (uptr sender PDataPointer server s32 serverSize);
typedef void (__stdcall * MatchmakingPingResponse_ServerFailedToRespond) (uptr sender);

typedef void (__stdcall * MatchmakingPlayersResponse_AddPlayerToList) (uptr sender PConstantDataPointer name s32 score f32 timePlayed); 
typedef void (__stdcall * MatchmakingPlayersResponse_PlayersFailedToRespond) (uptr sender);
typedef void (__stdcall * MatchmakingPlayersResponse_PlayersRefreshComplete) (uptr sender);

typedef void (__stdcall * MatchmakingRulesResponse_RulesResponded) (uptr sender PConstantDataPointer key PConstantDataPointer value);
typedef void (__stdcall * MatchmakingRulesResponse_RulesFailedToRespond) (uptr sender);
typedef void (__stdcall * MatchmakingRulesResponse_RulesRefreshComplete) (uptr sender);


// True: [ifndef] [INTEROP_CONVERSION] 
// Skipped: [define] [nullptr] [NULL] 



// include Types.h end

// include Cloud.h followed -> SteamAPIWrap\Cloud.h
// include Cloud.h start
// False: [ifndef] [RemoteStorage_h_interop_] 
// Defined: RemoteStorage_h_interop_ -> 


 bool Cloud_Write(PConstantString fileName, PConstantDataPointer buffer, s32 bufferLength);

 s32 Cloud_Read(PConstantString fileName, PDataPointer buffer, s32 bufferLength);

 bool Cloud_Forget(PConstantString fileName);

 bool Cloud_Delete(PConstantString fileName);

 void Cloud_Share(PConstantString fileName);

 bool Cloud_SetSyncPlatforms(PConstantString fileName, Enum remoteStoragePlatform);


 bool Cloud_Exists(PConstantString fileName);

 bool Cloud_Persisted(PConstantString fileName);

 s32 Cloud_GetSize(PConstantString fileName);

 s64 Cloud_Timestamp(PConstantString fileName);

 Enum Cloud_GetSyncPlatforms(PConstantString fileName);


 s32 Cloud_GetFileCount();

 PConstantString Cloud_GetFileNameAndSize(s32 fileID, s32 *fileSize);


 bool Cloud_GetQuota(s32 *totalBytes, s32 *availableBytes);

 bool Cloud_IsEnabledForAccount();

 bool Cloud_IsEnabledForApplication();

 void Cloud_SetEnabledForApplication(bool enabled);


 void Cloud_UGCDownload(UGCHandle handle, u32 unPriority);

 bool Cloud_GetUGCDownloadProgress(UGCHandle handle, s32 *bytesDownloaded, s32 *bytesExpected);

 bool Cloud_GetUGCDetails(UGCHandle handle, u32 *appID, char **name, s32 *fileSize, SteamID *creator);

 s32 Cloud_UGCRead(UGCHandle handle, PDataPointer buffer, s32 bufferLength, u32 offset, Enum action);

 s32 Cloud_GetCachedUGCCount();

 UGCHandle Cloud_GetUGCHandle(s32 handleID);



 void Cloud_PublishWorkshopFile(PConstantString fileName, PConstantString previewFile, u32 consumerAppId, PConstantString title, PConstantString description, Enum visibility, PDataPointer tags, Enum workshopFileType);
 PublishedFileUpdateHandle Cloud_CreatePublishedFileUpdateRequest(PublishedFileId publishedFileId);
 bool Cloud_UpdatePublishedFileFile(PublishedFileUpdateHandle updateHandle, PConstantString file);
 bool Cloud_UpdatePublishedFilePreviewFile(PublishedFileUpdateHandle updateHandle, PConstantString previewFile);
 bool Cloud_UpdatePublishedFileTitle(PublishedFileUpdateHandle updateHandle, PConstantString title);
 bool Cloud_UpdatePublishedFileDescription(PublishedFileUpdateHandle updateHandle, PConstantString description );
 bool Cloud_UpdatePublishedFileVisibility(PublishedFileUpdateHandle updateHandle, Enum visibility);
 bool Cloud_UpdatePublishedFileTags(PublishedFileUpdateHandle updateHandle,  PDataPointer tags);

 void Cloud_CommitPublishedFileUpdate(PublishedFileUpdateHandle updateHandle);
 void Cloud_GetPublishedFileDetails(PublishedFileId publishedFileId, u32 maxSecondsOld);
 void Cloud_DeletePublishedFile(PublishedFileId publishedFileId);
 void Cloud_EnumerateUserPublishedFiles(u32 startIndex);
 void Cloud_SubscribePublishedFile(PublishedFileId publishedFileId);
 void Cloud_EnumerateUserSubscribedFiles(u32 startIndex);
 void Cloud_UnsubscribePublishedFile(PublishedFileId publishedFileId);
 bool Cloud_UpdatePublishedFileSetChangeDescription(PublishedFileUpdateHandle updateHandle, PConstantString changeDescription);
 void Cloud_GetPublishedItemVoteDetails(PublishedFileId publishedFileId);
 void Cloud_UpdateUserPublishedItemVote(PublishedFileId publishedFileId, bool voteUp);
 void Cloud_GetUserPublishedItemVoteDetails(PublishedFileId publishedFileId);
 void Cloud_EnumerateUserSharedWorkshopFiles(SteamID steamId, u32 startIndex, PDataPointer requiredTags, PDataPointer excludedTags);
 void Cloud_PublishVideo(EWorkshopVideoProvider eVideoProvider,PConstantString pchVideoAccount, PConstantString pchVideoIdentifier, PConstantString pchPreviewFile, AppID nConsumerAppId, PConstantString pchTitle, PConstantString pchDescription, ERemoteStoragePublishedFileVisibility visibility, PDataPointer tags);
 void Cloud_SetUserPublishedFileAction(PublishedFileId publishedFileId, Enum action);
 void Cloud_EnumeratePublishedFilesByUserAction(Enum action, u32 startIndex);
 void Cloud_EnumeratePublishedWorkshopFiles(Enum enumerationType, u32 startIndex, u32 count, u32 days, PDataPointer tags, PDataPointer userTags);

 void Cloud_UGCDownload( UGCHandle content, PConstantString location, u32 priority );

// include Cloud.h end
// include Services.h followed -> SteamAPIWrap\Services.h
// include Services.h start
// False: [ifndef] [Services_h_interop_] 
// Defined: Services_h_interop_ -> 


 u32 Services_GetInterfaceVersion();

 Enum Services_GetErrorCode();

 bool Services_Startup(u32 interfaceVersion);

 void Services_Shutdown();

 bool Services_RestartAppIfNecessary( u32 ownAppID );

 bool Services_IsSteamRunning();

 Enum Services_GetSteamLoadStatus();

 void Services_HandleCallbacks();

 u32 Services_GetAppID();


 void Services_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);

 void Services_RemoveManagedCallbacks();

// include Services.h end
// include Stats.h followed -> SteamAPIWrap\Stats.h
// include Stats.h start
// False: [ifndef] [Stats_h_interop_] 
// Defined: Stats_h_interop_ -> 






 bool Stats_RequestCurrentStats();

 bool Stats_GetStatInt(PConstantString name, s32 *data);

 bool Stats_GetStatFloat(PConstantString name, float *data);

 bool Stats_SetStatInt(PConstantString name, s32 data);

 bool Stats_SetStatFloat(PConstantString name, float data);

 bool Stats_UpdateAverageRateStat(PConstantString name, float countThisSession, double sessionLength);

 bool Stats_GetAchievement(PConstantString name, bool *achieved);

 bool Stats_SetAchievement(PConstantString name);

 bool Stats_ClearAchievement(PConstantString name);

 bool Stats_GetAchievementAndUnlockTime(PConstantString name, bool *achieved, u32 *unlockTime);

 bool Stats_StoreStats();

 s32 Stats_GetAchievementIcon(PConstantString name);

 PConstantString Stats_GetAchievementDisplayAttribute(PConstantString name, PConstantString key);

 bool Stats_IndicateAchievementProgress(PConstantString name, u32 currentProgress, u32 maxProgess);

 void Stats_RequestUserStats(SteamID steamID);
 bool Stats_GetUserStatInt(SteamID steamID, PConstantString name, s32 *data);
 bool Stats_GetUserStatFloat(SteamID steamID, PConstantString name, float *data);
 bool Stats_GetUserAchievement(SteamID steamID, PConstantString name, bool *achieved);
 bool Stats_GetUserAchievementAndUnlockTime(SteamID steamID, PConstantString name, bool *achieved, u32 *unlockTime);
 bool Stats_ResetAllStats(bool achievementsToo);






 void Stats_FindOrCreateLeaderboard(PConstantString name, Enum sortMethod, Enum displayType);

 void Stats_FindLeaderboard(PConstantString name);

 PConstantString Stats_GetLeaderboardName(SteamLeaderboard handle);

 s32 Stats_GetLeaderboardEntryCount(SteamLeaderboard handle);

 Enum Stats_GetLeaderboardSortMethod(SteamLeaderboard handle);

 Enum Stats_GetLeaderboardDisplayType(SteamLeaderboard handle);

 void Stats_DownloadLeaderboardEntries(SteamLeaderboard handle, Enum dataRequest, s32 start, s32 end);

 void Stats_DownloadLeaderboardEntriesForUsers(SteamLeaderboard handle, PConstantDataPointer users, s32 numberOfUsers);

 bool Stats_GetDownloadedLeaderboardEntry(SteamLeaderboardEntries entries, s32 index, PDataPointer entry, PDataPointer detailsBuffer, s32 maxDetails);

 void Stats_UploadLeaderboardScore(SteamLeaderboard handle, Enum scoreMethod, s32 score, PConstantDataPointer details, s32 detailsCount);


 void Stats_AttachLeaderboardUGC(SteamLeaderboard handle, UGCHandle ugcHandle);





 void Stats_GetNumberOfCurrentPlayers();

 void Stats_RequestGlobalAchievementPercentages();

 s32 Stats_GetMostAchievedAchievementInfo(PString name, u32 nameLength, float *percent, bool *achieved);

 s32 Stats_GetNextMostAchievedAchievementInfo(s32 iterator, PString name, u32 nameLength, float *percent, bool *achieved);

 bool Stats_GetAchievementAchievedPercent(PConstantString name, float *percent);




 void Stats_RequestGlobalStats(s32 historyDays);

 bool Stats_GetGlobalStatInt(PConstantString name, s64 *data);
 bool Stats_GetGlobalStatDouble(PConstantString name, double *data);

 s32 Stats_GetGlobalStatHistoryInt(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);
 s32 Stats_GetGlobalStatHistoryDouble(PConstantString name, PDataPointer dataBuffer, u32 bufferSize);


// include Stats.h end
// include User.h followed -> SteamAPIWrap\User.h
// include User.h start
// False: [ifndef] [SteamUser_h_interop_] 
// Defined: SteamUser_h_interop_ -> 

 bool User_IsLoggedOn();

 SteamID User_GetSteamID();
 		
 s32 User_InitiateGameConnection( PDataPointer authBlob, s32 maxAuthBlob, SteamID steamIDGameServer, u32 serverIP, u16 serverPort, bool secure );
 
 void User_TerminateGameConnection( u32 serverIP, u16 serverPort );
 
 void User_TrackAppUsageEvent( GameID gameID, s32 appUsageEvent, PConstantString extraInfo = "");
 
 bool User_GetUserDataFolder( PString buffer, s32 bufferLength );
 
 void User_StartVoiceRecording( );
 
 void User_StopVoiceRecording( );
 
 Enum User_GetAvailableVoice( u32* compressed, u32* uncompressed, u32 uncompressedVoiceDesiredSampleRate );

 Enum User_GetVoice( bool wantCompressed, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, bool wantUncompressed, PDataPointer uncompressedDestBuffer, u32 uncompressedDestBufferSize, u32 *uncompressedBytesWritten, u32 uncompressedVoiceDesiredSampleRate );
 
 Enum User_DecompressVoice(PConstantDataPointer compressed, u32 compressedSize, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, u32 desiredSampleRate);
 
 u32 User_GetVoiceOptimalSampleRate( );
 
 u32 User_GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );
 
 Enum User_BeginAuthSession( PConstantDataPointer authTicket, s32 cbAuthTicket, SteamID steamID );
 
 void User_EndAuthSession( SteamID steamID );
 
 void User_CancelAuthTicket( u32 authTicket );
 
 Enum User_UserHasLicenseForApp( SteamID steamID, AppID appID );
 
 bool User_IsBehindNAT( );
 
 void User_AdvertiseGame( SteamID steamIDGameServer, u32 serverIP, u16 serverPort );
 
 void User_RequestEncryptedAppTicket( PDataPointer dataToInclude, s32 cbDataToInclude );
 
 bool User_GetEncryptedAppTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );

 s32 User_GetGameBadgeLevel( s32 nSeries, bool bFoil );

 s32 User_GetPlayerSteamLevel( );

// include User.h end
// include Friends.h followed -> SteamAPIWrap\Friends.h
// include Friends.h start
// False: [ifndef] [Friends_h_interop_] 
// Defined: Friends_h_interop_ -> 


 PConstantUtf8String Friends_GetPersonaName();

 void Friends_SetPersonaName(PConstantUtf8String personaName);

 Enum Friends_GetPersonaState();

 s32 Friends_GetFriendCount(Enum friendFlags);

 SteamID Friends_GetFriendByIndex(s32 friendIndex, s32 friendFlags);

 Enum Friends_GetFriendRelationship(SteamID steamIDFriend);

 Enum Friends_GetFriendPersonaState(SteamID steamIDFriend);

 PConstantUtf8String Friends_GetFriendPersonaName(SteamID steamIDFriend);

 bool Friends_GetFriendGamePlayed(SteamID steamIDFriend, PDataPointer friendGameInfo);

 s32 Friends_GetFriendGameInfoSize();

 PConstantUtf8String Friends_GetFriendPersonaNameHistory(SteamID steamIDFriend, s32 personaName);

 PConstantUtf8String Friends_GetPlayerNickname(SteamID steamIDPlayer);

 bool Friends_HasFriend(SteamID steamIDFriend, s32 friendFlags);

 s32 Friends_GetClanCount();
 SteamID Friends_GetClanByIndex(s32 clan);
 PConstantString Friends_GetClanName(SteamID steamIDClan);
 PConstantString Friends_GetClanTag(SteamID steamIDClan);

 bool Friends_GetClanActivityCounts(SteamID steamIDClan, s32 *online, s32 *inGame, s32 *chatting);

 void Friends_DownloadClanActivityCounts(PConstantDataPointer steamIDClans, s32 clansToRequest);

 s32 Friends_GetFriendCountFromSource(SteamID steamIDSource);
 SteamID Friends_GetFriendFromSourceByIndex(SteamID steamIDSource, s32 friendIndex);

 bool Friends_IsUserInSource(SteamID steamIDUser, SteamID steamIDSource);

 void Friends_SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking);

 void Friends_ActivateGameOverlay(Enum dialogType);

 void Friends_ActivateGameOverlayToUser(Enum dialogType, SteamID steamID);

 void Friends_ActivateGameOverlayToWebPage(PConstantString url);

 void Friends_ActivateGameOverlayToStore(u32 appID, EOverlayToStoreFlag eFlag);

 void Friends_SetPlayedWith(SteamID steamIDUserPlayedWith);

 void Friends_ActivateGameOverlayInviteDialog(SteamID steamIDLobby);

 s32 Friends_GetSmallFriendAvatar(SteamID steamIDFriend);

 s32 Friends_GetMediumFriendAvatar(SteamID steamIDFriend);

 s32 Friends_GetLargeFriendAvatar(SteamID steamIDFriend);

 bool Friends_RequestUserInformation(SteamID steamIDUser, bool requireNameOnly);

 void Friends_RequestClanOfficerList(SteamID steamIDClan);

 SteamID Friends_GetClanOwner(SteamID steamIDClan);
 s32 Friends_GetClanOfficerCount(SteamID steamIDClan);
 SteamID Friends_GetClanOfficerByIndex(SteamID steamIDClan, s32 officer);
 u32 Friends_GetUserRestrictions();

 bool Friends_SetRichPresence(PConstantString key, PConstantUtf8String value);

 void Friends_ClearRichPresence();
 PConstantUtf8String Friends_GetFriendRichPresence(SteamID steamIDFriend, PConstantString key);
 s32 Friends_GetFriendRichPresenceKeyCount(SteamID steamIDFriend);
 PConstantUtf8String Friends_GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, s32 key);
 void Friends_RequestFriendRichPresence(SteamID steamIDFriend);

 bool Friends_InviteUserToGame(SteamID steamIDFriend, PConstantString connectString);

 s32 Friends_GetCoplayFriendCount();
 SteamID Friends_GetCoplayFriend(s32 coplayFriend);
 s32 Friends_GetFriendCoplayTime(SteamID steamIDFriend);
 AppID Friends_GetFriendCoplayGame(SteamID steamIDFriend);

 void Friends_JoinClanChatRoom(SteamID steamIDClan);
 bool Friends_LeaveClanChatRoom(SteamID steamIDClan);
 s32 Friends_GetClanChatMemberCount(SteamID steamIDClan);
 SteamID Friends_GetChatMemberByIndex(SteamID steamIDClan, s32 user);
 bool Friends_SendClanChatMessage(SteamID steamIDClanChat, PConstantUtf8String text);
 s32 Friends_GetClanChatMessage(SteamID steamIDClanChat, s32 message, PUtf8String text, s32 textSize, Enum *chatEntryType, SteamID *sender);
 bool Friends_IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser);

 bool Friends_IsClanChatWindowOpenInSteam(SteamID steamIDClanChat);
 bool Friends_OpenClanChatWindowInSteam(SteamID steamIDClanChat);
 bool Friends_CloseClanChatWindowInSteam(SteamID steamIDClanChat);

 bool Friends_SetListenForFriendsMessages(bool interceptEnabled);
 bool Friends_ReplyToFriendMessage(SteamID steamIDFriend, PConstantUtf8String msgToSend);
 s32 Friends_GetFriendMessage(SteamID steamIDFriend, s32 messageID, PUtf8String text, s32 textSize, Enum *chatEntryType);

 void Friends_GetFollowerCount(SteamID steamID);
 void Friends_IsFollowing(SteamID steamID);
 void Friends_EnumerateFollowingList(u32 startIndex);


// include Friends.h end
// include MatchMaking.h followed -> SteamAPIWrap\MatchMaking.h
// include MatchMaking.h start
// False: [ifndef] [MatchMaking_h_interop_] 
// Defined: MatchMaking_h_interop_ -> 

 s32 MatchMaking_GetFavoriteGameCount();

 bool MatchMaking_GetFavoriteGame(s32 game, u32 *appID, u32 *ip, u16 *connPort, u16 *queryPort, u32 *flags, u32 *time32LastPlayedOnServer );

 s32 MatchMaking_AddFavoriteGame(u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags, u32 time32LastPlayedOnServer );

 bool MatchMaking_RemoveFavoriteGame( u32 appID, u32 IP, u16 connPort, u16 queryPort, u32 flags );

 void MatchMaking_RequestLobbyList();

 void MatchMaking_AddRequestLobbyListStringFilter(PConstantString keyToMatch, PConstantString valueToMatch, Enum comparisonType);

 void MatchMaking_AddRequestLobbyListNumericalFilter(PConstantString keyToMatch, s32 valueToMatch, Enum comparisonType);

 void MatchMaking_AddRequestLobbyListNearValueFilter(PConstantString keyToMatch, s32 valueToBeCloseTo);

 void MatchMaking_AddRequestLobbyListFilterSlotsAvailable( s32 SlotsAvailable );

 void MatchMaking_AddRequestLobbyListDistanceFilter(Enum lobbyDistanceFilter);

 void MatchMaking_AddRequestLobbyListResultCountFilter(s32 maxResults);

 void MatchMaking_AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby);

 SteamID MatchMaking_GetLobbyByIndex(s32 lobby);

 void MatchMaking_CreateLobby(Enum lobbyType, s32 maxMembers);

 void MatchMaking_JoinLobby(SteamID steamIDLobby);

 void MatchMaking_LeaveLobby(SteamID steamIDLobby);

 bool MatchMaking_InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee);

 s32 MatchMaking_GetNumLobbyMembers(SteamID steamIDLobby);

 SteamID MatchMaking_GetLobbyMemberByIndex(SteamID steamIDLobby, s32 member);

 PConstantString MatchMaking_GetLobbyData(SteamID steamIDLobby, PConstantString key);

 bool MatchMaking_SetLobbyData(SteamID steamIDLobby, PConstantString key, PConstantString value);

 s32 MatchMaking_GetLobbyDataCount(SteamID steamIDLobby);

 bool MatchMaking_GetLobbyDataByIndex(SteamID steamIDLobby, s32 lobbyData, PString key, s32 keyBufferSize, PString value, s32 valueBufferSize);

 bool MatchMaking_DeleteLobbyData(SteamID steamIDLobby, PConstantString key);

 PConstantString MatchMaking_GetLobbyMemberData(SteamID steamIDLobby, SteamID SteamIDUser, PConstantString key);

 void MatchMaking_SetLobbyMemberData(SteamID steamIDLobby, PConstantString key, PConstantString value);

 bool MatchMaking_SendLobbyChatMsg(SteamID steamIDLobby, PConstantDataPointer msg, s32 cubMsg);

 s32 MatchMaking_GetLobbyChatEntry(SteamID steamIDLobby, s32 chatID, SteamID *steamIDUser, PDataPointer data, s32 dataBufferSize, Enum *chatEntryType);

 bool MatchMaking_RequestLobbyData(SteamID steamIDLobby);

 void MatchMaking_SetLobbyGameServer(SteamID steamIDLobby, u32 gameServerIP, u16 gameServerPort, SteamID steamIDGameServer);

 bool MatchMaking_GetLobbyGameServer(SteamID steamIDLobby, u32 *gameServerIP, u16 *gameServerPort, SteamID *steamIDGameServer);

 bool MatchMaking_SetLobbyMemberLimit(SteamID steamIDLobby, s32 maxMembers);

 s32  MatchMaking_GetLobbyMemberLimit(SteamID steamIDlobby);

 bool MatchMaking_SetLobbyType(SteamID steamIDLobby, Enum lobbyType);

 bool MatchMaking_SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable);

 SteamID MatchMaking_GetLobbyOwner(SteamID steamIDLobby);

 bool MatchMaking_SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner);

 bool MatchMaking_SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent);

// include MatchMaking.h end
// include MatchmakingServers.h followed -> SteamAPIWrap\MatchmakingServers.h
// include MatchmakingServers.h start
// False: [ifndef] [MatchmakingServers_h_interop_] 
// Defined: MatchmakingServers_h_interop_ -> 

 PConstantAnsiString MatchmakingServerNetworkAddress_GetConnectionString(PConstantDataPointer instance);
 PConstantAnsiString MatchmakingServerNetworkAddress_GetQueryString(PConstantDataPointer instance);

 ServerListRequest MatchmakingServers_RequestInternetServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
 ServerListRequest MatchmakingServers_RequestLANServerList(u32 appId, uptr requestServersResponse);
 ServerListRequest MatchmakingServers_RequestFriendsServerList(u32 appId, PDataPointer filters, u32 filtersCount, uptr requestServersResponse);
 ServerListRequest MatchmakingServers_RequestFavoritesServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
 ServerListRequest MatchmakingServers_RequestHistoryServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
 ServerListRequest MatchmakingServers_RequestSpectatorServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);

 void MatchmakingServers_ReleaseRequest(ServerListRequest request); 

 PDataPointer MatchmakingServers_GetServerDetails(ServerListRequest request, s32 server);

 s32 MatchmakingServers_GetGameServerItemSize();

 void MatchmakingServers_CancelQuery(ServerListRequest request);

 void MatchmakingServers_RefreshQuery(ServerListRequest request);

 bool MatchmakingServers_IsRefreshing(ServerListRequest request); 

 s32 MatchmakingServers_GetServerCount(ServerListRequest request); 

 void MatchmakingServers_RefreshServer(ServerListRequest request, s32 server); 

 ServerQuery MatchmakingServers_PingServer( u32 ip, u16 port, uptr requestServersResponse ); 

 ServerQuery MatchmakingServers_PlayerDetails( u32 ip, u16 port, uptr requestServersResponse );

 ServerQuery MatchmakingServers_ServerRules( u32 ip, u16 port, uptr requestServersResponse ); 

 void MatchmakingServers_CancelServerQuery(s32 serverQuery);

// include MatchmakingServers.h end
// include MatchmakingServerListResponse.h followed -> SteamAPIWrap\MatchmakingServerListResponse.h
// include MatchmakingServerListResponse.h start
// False: [ifndef] [MatchmakingServerListResponse_h_interop_] 
// Defined: MatchmakingServerListResponse_h_interop_ -> 

 uptr MatchmakingServerListResponse_CreateObject();

 void MatchmakingServerListResponse_DestroyObject(uptr obj);

 void MatchmakingServerListResponse_RegisterCallbacks(MatchmakingServerListResponse_ServerRespondedCallback serverResponded, MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond, MatchmakingServerListResponse_RefreshComplete refreshComplete);

 void MatchmakingServerListResponse_RemoveCallbacks();

// include MatchmakingServerListResponse.h end
// include MatchmakingPingResponse.h followed -> SteamAPIWrap\MatchmakingPingResponse.h
// include MatchmakingPingResponse.h start
// False: [ifndef] [MatchmakingPingResponse_h_interop_] 
// Defined: MatchmakingPingResponse_h_interop_ -> 

 uptr MatchmakingPingResponse_CreateObject();

 void MatchmakingPingResponse_DestroyObject(uptr obj);

 void MatchmakingPingResponse_RegisterCallbacks(MatchmakingPingResponse_ServerRespondedCallback serverResponded, MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond);

 void MatchmakingPingResponse_RemoveCallbacks();

// include MatchmakingPingResponse.h end
// include MatchmakingPlayersResponse.h followed -> SteamAPIWrap\MatchmakingPlayersResponse.h
// include MatchmakingPlayersResponse.h start
// False: [ifndef] [MatchmakingPlayers_h_interop_] 
// Defined: MatchmakingPlayers_h_interop_ -> 

 uptr MatchmakingPlayersResponse_CreateObject();

 void MatchmakingPlayersResponse_DestroyObject(uptr obj);

 void MatchmakingPlayersResponse_RegisterCallbacks(MatchmakingPlayersResponse_AddPlayerToList addPlayerToList, MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond, MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete);

 void MatchmakingPlayersResponse_RemoveCallbacks();

// include MatchmakingPlayersResponse.h end
// include MatchMakingRulesResponse.h followed -> SteamAPIWrap\MatchMakingRulesResponse.h
// include MatchMakingRulesResponse.h start
// False: [ifndef] [MatchmakingRulesPlayers_h_interop_] 
// Defined: MatchmakingRulesPlayers_h_interop_ -> 

 uptr MatchmakingRulesResponse_CreateObject();

 void MatchmakingRulesResponse_DestroyObject(uptr obj);

 void MatchmakingRulesResponse_RegisterCallbacks(MatchmakingRulesResponse_RulesResponded rulesResponded, MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond, MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete);

 void MatchmakingRulesResponse_RemoveCallbacks();

// include MatchMakingRulesResponse.h end
// include GameServer.h followed -> SteamAPIWrap\GameServer.h
// include GameServer.h start
// False: [ifndef] [GameServer_h_interop_] 
// Defined: GameServer_h_interop_ -> 

 bool GameServer_InitGameServer(u32 ip, u16 gamePort, u16 queryPort, u32 flags, AppID gameAppId, PConstantString versionString);

 void GameServer_SetProduct(PConstantString product);

 void GameServer_SetGameDescription(PConstantString gameDescription );

 void GameServer_SetModDir( PConstantString modDir );

 void GameServer_SetDedicatedServer( bool dedicated );

 void GameServer_LogOn(PConstantString accountName, PConstantString password);

 void GameServer_LogOnAnonymous();

 void GameServer_LogOff();

 bool GameServer_LoggedOn();

 bool GameServer_Secure();

 SteamID GameServer_GetSteamID();

 bool GameServer_WasRestartRequested();

 void GameServer_SetMaxPlayerCount(s32 playersMax);

 void GameServer_SetBotPlayerCount(s32 botplayers);

 void GameServer_SetServerName(PConstantString  serverName);

 void GameServer_SetMapName(PConstantString mapName);

 void GameServer_SetPasswordProtected(bool passwordProtected);

 void GameServer_SetSpectatorPort(u16 spectatorPort);

 void GameServer_SetSpectatorServerName(PConstantString spectatorServerName);

 void GameServer_ClearAllKeyValues();

 void GameServer_SetKeyValue(PConstantString key, PConstantString value);

 void GameServer_SetGameTags(PConstantString gameTags);

 void GameServer_SetGameData(PConstantString gameData);

 void GameServer_SetRegion(PConstantString region);

 bool GameServer_SendUserConnectAndAuthenticate(u32 ipClient, PConstantDataPointer authBlob, u32 authBlobSize, SteamID *steamIDUser );

 SteamID GameServer_CreateUnauthenticatedUserConnection();

 void GameServer_SendUserDisconnect(SteamID steamIDUser);

 bool GameServer_UpdateUserData(SteamID steamIDUser, PConstantString playerName, u32 core);

 AuthTicket GameServer_GetAuthSessionTicket(PDataPointer ticket, s32 maxTicket, u32 *ticketSize);

 Enum GameServer_BeginAuthSession(PConstantDataPointer authTicket, s32 authTicketSize, SteamID steamID);

 void GameServer_EndAuthSession(SteamID steamID );

 void GameServer_CancelAuthTicket(AuthTicket authTicket);

 Enum GameServer_UserHasLicenseForApp(SteamID steamID, AppID appID);

 bool GameServer_RequestUserGroupStatus(SteamID steamIDUser, SteamID steamIDGroup);

 void GameServer_GetGameplayStats();

 void GameServer_GetServerReputation();

 u32 GameServer_GetPublicIP();

 bool GameServer_HandleIncomingPacket(PConstantDataPointer data, s32 dataSize, u32 ip, u16 srcPort);

 s32 GameServer_GetNextOutgoingPacket(PDataPointer out, s32 maxOut, u32 *netAdr, u16 *port);

 void GameServer_EnableHeartbeats(bool active);

 void GameServer_SetHeartbeatInterval(s32 heartbeatInterval);

 void GameServer_ForceHeartbeat();

 void GameServer_AssociateWithClan(SteamID steamIDClan);

 void GameServer_ComputeNewPlayerCompatibility(SteamID steamIDNewPlayer);



// include GameServer.h end
// include GameServerStats.h followed -> SteamAPIWrap\GameServerStats.h
// include GameServerStats.h start
// False: [ifndef] [GameServerStats_h_interop_] 
// Defined: GameServerStats_h_interop_ -> 

 void GameServerStats_RequestUserStats(SteamID steamIDUser);

 bool GameServerStats_GetUserStatInt(SteamID steamIDUser, PConstantString name, s32 *data);

 bool GameServerStats_GetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 *data);

 bool GameServerStats_GetUserAchievement(SteamID steamIDUser, PConstantString name, bool *achieved);

 bool GameServerStats_SetUserStatInt(SteamID steamIDUser, PConstantString name, s32 data);

 bool GameServerStats_SetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 data);

 bool GameServerStats_UpdateUserAvgRateStat(SteamID steamIDUser, PConstantString name, f32 countThisSession, f64 sessionLength);

 bool GameServerStats_SetUserAchievement(SteamID steamIDUser, PConstantString name);

 bool GameServerStats_ClearUserAchievement(SteamID steamIDUser, PConstantString name);

 void GameServerStats_StoreUserStats(SteamID steamIDUser);

// include GameServerStats.h end
// include Networking.h followed -> SteamAPIWrap\Networking.h
// include Networking.h start
// False: [ifndef] [Networking_h_interop_] 
// Defined: Networking_h_interop_ -> 

 bool Networking_SendP2PPacket(SteamID steamIDRemote, PConstantDataPointer data, uint32 cubData, Enum p2pSendType, int channel);

 bool Networking_IsP2PPacketAvailable( u32 *msgSize, int channel);

 bool Networking_ReadP2PPacket(PDataPointer dest, u32 cubDest, u32 *msgSize, SteamID *steamIDRemote, int channel);

 bool Networking_AcceptP2PSessionWithUser(SteamID steamIDRemote);

 bool Networking_CloseP2PSessionWithUser(SteamID steamIDRemote);

 bool Networking_CloseP2PChannelWithUser(SteamID steamIDRemote, int channel);

 bool Networking_GetP2PSessionState(SteamID steamIDRemote, PDataPointer connectionState);

 bool Networking_AllowP2PPacketRelay(bool allow);

 NetListenSocket Networking_CreateListenSocket(int virtualP2PPort, u32 ip, u16 port, bool allowUseOfPacketRelay);

 NetSocket Networking_CreateP2PConnectionSocket(SteamID steamIDTarget, int virtualPort, int timeoutSec, bool allowUseOfPacketRelay);

 NetSocket Networking_CreateConnectionSocket(u32 ip, u16 port, int timeoutSec);

 bool Networking_DestroySocket(NetSocket socket, bool notifyRemoteEnd);

 bool Networking_DestroyListenSocket(NetListenSocket socket, bool notifyRemoteEnd);

 bool Networking_SendDataOnSocket(NetSocket socket, PDataPointer data, u32 cubData, bool reliable);

 bool Networking_IsDataAvailableOnSocket(NetSocket socket, u32* msgSize);

 bool Networking_RetrieveDataFromSocket(NetSocket socket, void* dest, u32 cubDest, u32* msgSize);

 bool Networking_IsDataAvailable(NetListenSocket listenSocket, u32* msgSize, NetSocket* socket);

 bool Networking_RetrieveData(NetListenSocket listenSocket, void* pubDest, u32 cubDest, u32* msgSize, NetSocket* socket);

 bool Networking_GetSocketInfo(NetSocket socket, SteamID* steamIDRemote, Enum* socketStatus, u32* ipRemote, u16* portRemote);

 bool Networking_GetListenSocketInfo(NetListenSocket listenSocket, u32* ip, u16* port);

 Enum Networking_GetSocketConnectionType(NetSocket socket);

 int Networking_GetMaxPacketSize(u32 socket); 


 s32 Networking_GetP2PSessionStateSize();

// include Networking.h end
// include ServicesGameServer.h followed -> SteamAPIWrap\ServicesGameServer.h
// include ServicesGameServer.h start
// False: [ifndef] [ServicesGameServer_h_interop_] 
// Defined: ServicesGameServer_h_interop_ -> 

 u32 ServicesGameServer_GetInterfaceVersion();

 Enum ServicesGameServer_GetErrorCode();

 bool ServicesGameServer_Startup(u32 interfaceVersion, u32 ip, u16 steamPort, u16 gamePort, u16 queryPort, Enum serverMode, PConstantString versionString);

 void ServicesGameServer_Shutdown();

 Enum ServicesGameServer_GetSteamLoadStatus();

 void ServicesGameServer_HandleCallbacks();

 void ServicesGameServer_RegisterManagedCallbacks(ManagedCallback callback, ManagedResultCallback resultCallback);

 void ServicesGameServer_RemoveManagedCallbacks();

// include ServicesGameServer.h end
// include Utils.h followed -> SteamAPIWrap\Utils.h
// include Utils.h start
// False: [ifndef] [Utils_h_interop_] 
// Defined: Utils_h_interop_ -> 

 u32 Utils_GetSecondsSinceAppActive();

 u32 Utils_GetSecondsSinceComputerActive();

 Enum Utils_GetConnectedUniverse();

 u32 Utils_GetServerRealTime();

 PConstantString Utils_GetIPCountry();

 bool Utils_GetImageSize(int iImage, uint32 *pnWidth, uint32 *pnHeightr);
		
 bool Utils_GetImageRGBA( int iImage, uint8 *pubDest, int nDestBufferSize);

 bool Utils_GetCSERIPPort( u32 *unIP, u16 *usPort);

 u8 Utils_GetCurrentBatteryPower();

 u32 Utils_GetAppID();

 void Utils_SetOverlayNotificationPosition( Enum eNotificationPosition );

 bool Utils_IsAPICallCompleted( u64 hSteamAPICall, bool *pbFailed );

 bool Utils_GetAPICallResult( u64 hSteamAPICall, void *pCallback, int cubCallback, int iCallbackExpected, bool *pbFailed );

 void Utils_RunFrame();

 u32 Utils_GetIPCCallCount();

 void Utils_SetWarningMessageHook( SteamAPIWarningMessageHook_t pFunction );

 bool Utils_IsOverlayEnabled();

 bool Utils_OverlayNeedsPresent();

 bool Utils_ShowGamepadTextInput( Enum eInputMode, Enum eLineInputMode, PConstantString pchDescription, uint32 unCharMax);

 uint32 Utils_GetEnteredGamepadTextLength();

 bool Utils_GetEnteredGamepadTextInput( PString pchText, uint32 cchText);

 bool Utils_IsSteamRunningInVR();

// include Utils.h end
// include Apps.h followed -> SteamAPIWrap\Apps.h
// include Apps.h start
// False: [ifndef] [Apps_h_interop_] 
// Defined: Apps_h_interop_ -> 

 bool Apps_IsSubscribed();

 bool Apps_IsLowViolence();

 bool Apps_IsCybercafe();

 bool Apps_IsVACBanned();

 PConstantString Apps_GetCurrentGameLanguage();

 PConstantString Apps_GetAvailableGameLanguages();
 
 bool Apps_IsSubscribedApp( u32 appID );
 
 bool Apps_IsDlcInstalled( u32 appID );
 
 u32 Apps_GetEarliestPurchaseUnixTime( u32 appID );
 
 bool Apps_IsSubscribedFromFreeWeekend();
 
 int Apps_GetDLCCount();
 
 bool Apps_GetDLCDataByIndex( int iDLC, u32 *pAppID, bool *pbAvailable, PString pchName, int cchNameBufferSize );
 
 void Apps_InstallDLC( u32 appID );

 void Apps_UninstallDLC( u32 appID );
 
 void Apps_RequestAppProofOfPurchaseKey( u32 appID );
 
 bool Apps_GetCurrentBetaName( PString pchName, int cchNameBufferSize );

 bool Apps_MarkContentCorrupt( bool bMissingFilesOnly );

 u32 Apps_GetInstalledDepots( u32 appID, u32* pvecDepots, u32 cMaxDepots );
 
 SteamID Apps_GetAppOwner();

 PConstantString Apps_GetLaunchQueryParam( PConstantString key );

// include Apps.h end
// include HTTP.h followed -> SteamAPIWrap\HTTP.h
// include HTTP.h start
// False: [ifndef] [HTTP_h_interop_]
// Defined: HTTP_h_interop_ ->

 u32 HTTP_CreateHTTPRequest( Enum eHTTPRequestMethod, PConstantUtf8String pchAbsoluteURL );
 
 bool HTTP_SetHTTPRequestContextValue( u32 hRequest, u64 ulContextValue );
 
 bool HTTP_SetHTTPRequestNetworkActivityTimeout( u32 hRequest, u32 unTimeoutSeconds );
 
 bool HTTP_SetHTTPRequestHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, PConstantUtf8String pchHeaderValue );
 
 bool HTTP_SetHTTPRequestGetOrPostParameter( u32 hRequest, PConstantUtf8String pchParamName, PConstantUtf8String pchParamValue );
 
 bool HTTP_SendHTTPRequest( u32 hRequest, u64 *pCallHandle );
 
 bool HTTP_SendHTTPRequestAndStreamResponse( u32 hRequest, u64 *pCallHandle );
 
 bool HTTP_DeferHTTPRequest( u32 hRequest );
 
 bool HTTP_PrioritizeHTTPRequest( u32 hRequest );
 
 bool HTTP_GetHTTPResponseHeaderSize( u32 hRequest, PConstantUtf8String pchHeaderName, u32 *unResponseHeaderSize );
 
 bool HTTP_GetHTTPResponseHeaderValue( u32 hRequest, PConstantUtf8String pchHeaderName, uint8 *pHeaderValueBuffer, u32 unBufferSize );
 
 bool HTTP_GetHTTPResponseBodySize( u32 hRequest, u32 *unBodySize );
 
 bool HTTP_GetHTTPResponseBodyData( u32 hRequest, uint8 *pBodyDataBuffer, u32 unBufferSize );
 
 bool HTTP_GetHTTPStreamingResponseBodyData( u32 hRequest, u32 cOffset, uint8 *pBodyDataBuffer, u32 unBufferSize );
 
 bool HTTP_ReleaseHTTPRequest( u32 hRequest );
 
 bool HTTP_GetHTTPDownloadProgressPct( u32 hRequest, float *pflPercentOut );
 
 bool HTTP_SetHTTPRequestRawPostBody( u32 hRequest, PConstantUtf8String pchContentType, uint8 *pubBody, u32 unBodyLen );

// include HTTP.h end
// include Screenshots.h followed -> SteamAPIWrap\Screenshots.h
// include Screenshots.h start
// False: [ifndef] [Screenshots_h_interop_]
// Defined: Screenshots_h_interop

 u32 Screenshots_WriteScreenshot(PDataPointer pubRGB, u32 cubRGB, s32 nWidth, s32 nHeight);

 u32 Screenshots_AddScreenshotToLibrary( PConstantString pchFilename, PConstantString pchThumbnailFilename, s32 nWidth, s32 nHeight );

 void Screenshots_TriggerScreenshot();

 void Screenshots_HookScreenshots( bool bHook );

 bool Screenshots_SetLocation( u32 hScreenshot, PConstantString pchLocation );

 bool Screenshots_TagUser( u32 hScreenshot, u64 steamID );

 bool Screenshots_TagPublishedFile( u32 hScreenshot, u64 unPublishedFileID );

// inlude Screenshots.h end
// include UGC.h followed -> SteamAPIWrap\UGC.h
// include UGC.h start
// False: [ifndef] [UGC_h_interop_]
// Defined: UGC_h_interop_


 UGCQueryHandle UGC_CreateQueryUserUGCRequest( AccountID unAccountID, Enum eListType, Enum eMatchingUGCType, Enum eSortOrder, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

 UGCQueryHandle UGC_CreateQueryAllUGCRequest( Enum eQueryType, Enum eMatchingeMatchingUGCTypeFileType, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

 void UGC_SendQueryUGCRequest( UGCQueryHandle handle );
	  
 bool UGC_GetQueryUGCResult( UGCQueryHandle handle, u32 index, PDataPointer pDetails );
	  
 bool UGC_ReleaseQueryUGCRequest( UGCQueryHandle handle );
	  
 bool UGC_AddRequiredTag( UGCQueryHandle handle, PConstantString pTagName );
 bool UGC_AddExcludedTag( UGCQueryHandle handle, PConstantString pTagName );
 bool UGC_SetReturnLongDescription( UGCQueryHandle handle, bool bReturnLongDescription );
 bool UGC_SetReturnTotalOnly( UGCQueryHandle handle, bool bReturnTotalOnly );
 	  
 bool UGC_SetCloudFileNameFilter( UGCQueryHandle handle, PConstantString pMatchCloudFileName );
 	  
 bool UGC_SetMatchAnyTag( UGCQueryHandle handle, bool bMatchAnyTag );
 bool UGC_SetSearchText( UGCQueryHandle handle, PConstantString pSearchText );
 bool UGC_SetRankedByTrendDays( UGCQueryHandle handle, u32 unDays );
 	  
 void UGC_RequestUGCDetails( u32 nPublishedFileID );

// include UGC.h end
// include SteamController.h followed -> SteamAPIWrap\SteamController.h
// include SteamController.h start
// False: [ifndef] [SteamController_h_interop_]
// Defined: SteamController_h_interop_
 
 bool SteamController_Init( PConstantString absolutPathToControllerConfigVDF );
 bool SteamController_Shutdown();
 
 void SteamController_RunFrame();
 
 bool SteamController_GetControllerState( u32 controllerIndex, PDataPointer state );
 void SteamController_TriggerHapticPulse( u32 controllerIndex, Enum targetPad, u16 durationMicroSec );
 void SteamController_SetOverrideMode( PConstantString mode );

// include SteamController.h end
// include Hmd.h followed -> SteamAPIWrap\Hmd.h
// include Hmd.h start
// False: [ifndef] [Hmd_h_interop_]
// Defined: Hmd_h_interop_

 Enum VR_Hmd_Init();

 void VR_Hmd_Shutdown();
 
 bool VR_Hmd_GetWindowBounds( s32* X, s32* Y, u32* Width, u32* Height );
 
 void VR_Hmd_GetRecommendedRenderTargetSize( u32* Width, u32* Height );
 
 void VR_Hmd_GetEyeOutputViewport( Enum Eye, Enum APIType, u32* X, u32* Y, u32* Width, u32* Height );
 
 PDataPointer VR_Hmd_GetProjectionMatrix( Enum Eye, f32 NearZ, f32 FarZ, Enum ProjType );
 
 void VR_Hmd_GetProjectionRaw( Enum Eye, f32* Left, f32* Right, f32* Top, f32* Bottom );
 
 PDataPointer VR_Hmd_ComputeDistortion( Enum Eye, f32 U, f32 V );
 
 PDataPointer VR_Hmd_GetEyeMatrix( Enum Eye );
 
 bool VR_Hmd_GetViewMatrix( f32 SecondsFromNow, PDataPointer MatLeftView, PDataPointer MatRightView, Enum* Result );
 
 s32 VR_Hmd_GetD3D9AdapterIndex();
 
 bool VR_Hmd_GetWorldFromHeadPose( f32 PredictedSecondsFromNow, PDataPointer Pose, Enum* Result );
 
 bool VR_Hmd_GetLastWorldFromHeadPose( PDataPointer* Pose );
 
 bool VR_Hmd_WillDriftInYaw();
 
 void VR_Hmd_ZeroTracker();
 
 u32 VR_Hmd_GetDriverId( PString Buffer, u32 BufferLen );
 
 u32 VR_Hmd_GetDisplayId( PString Buffer, u32 BufferLen );

// include Hmd.h end
// include SteamAPIWrap\InteropMain.h end
// Macro Map Dump
// Friends_h_interop_ -> 
// GameServerStats_h_interop_ -> 
// GameServer_h_interop_ -> 
// INTEROP_CONVERSION -> 
// ManagedSteam_API -> 
// ManagedSteam_API_Lite -> 
// MatchMaking_h_interop_ -> 
// MatchmakingPingResponse_h_interop_ -> 
// MatchmakingPlayers_h_interop_ -> 
// MatchmakingRulesPlayers_h_interop_ -> 
// MatchmakingServerListResponse_h_interop_ -> 
// MatchmakingServers_h_interop_ -> 
// Networking_h_interop_ -> 
// RemoteStorage_h_interop_ -> 
// STEAMTYPES_H -> 
// SW_MANAGED_CALLBACK_TYPE -> (returnType,callbackName,parameters) typedef returnType (__stdcall *callbackName)parameters
// ServicesGameServer_h_interop_ -> 
// Services_h_interop_ -> 
// Stats_h_interop_ -> 
// SteamUser_h_interop_ -> 
// Types_h_ -> 
// UNICODE -> 1
// Utils_h_interop_ -> 
// WIN32 -> 
// WINAPI -> __winapi
// WINVER -> 0x0600
// _MSC_FULL_VER -> 99999999
// _MSC_VER -> 9999
// _PREFAST_ -> 
// _WIN32 -> 
// _WIN32_WINNT -> 0x0600
// _X86_ -> 
// __STDC__ -> 1
// __w64 -> 
