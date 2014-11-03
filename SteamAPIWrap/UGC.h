#ifndef SteamUGC_h_interop_
#define SteamUGC_h_interop_


ManagedSteam_API UGCQueryHandle UGC_CreateQueryUserUGCRequest( AccountID unAccountID, Enum eListType, Enum eMatchingUGCType, Enum eSortOrder, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

ManagedSteam_API UGCQueryHandle UGC_CreateQueryAllUGCRequest( Enum eQueryType, Enum eMatchingeMatchingUGCTypeFileType, AppID nCreatorAppID, AppID nConsumerAppID, u32 unPage );

ManagedSteam_API void UGC_SendQueryUGCRequest( UGCQueryHandle handle );

ManagedSteam_API bool UGC_GetQueryUGCResult( UGCQueryHandle handle, u32 index, PDataPointer pDetails );

ManagedSteam_API bool UGC_ReleaseQueryUGCRequest( UGCQueryHandle handle );

ManagedSteam_API bool UGC_AddRequiredTag( UGCQueryHandle handle, PConstantString pTagName );
ManagedSteam_API bool UGC_AddExcludedTag( UGCQueryHandle handle, PConstantString pTagName );
ManagedSteam_API bool UGC_SetReturnLongDescription( UGCQueryHandle handle, bool bReturnLongDescription );
ManagedSteam_API bool UGC_SetReturnTotalOnly( UGCQueryHandle handle, bool bReturnTotalOnly );

ManagedSteam_API bool UGC_SetCloudFileNameFilter( UGCQueryHandle handle, PConstantString pMatchCloudFileName );

ManagedSteam_API bool UGC_SetMatchAnyTag( UGCQueryHandle handle, bool bMatchAnyTag );
ManagedSteam_API bool UGC_SetSearchText( UGCQueryHandle handle, PConstantString pSearchText );
ManagedSteam_API bool UGC_SetRankedByTrendDays( UGCQueryHandle handle, u32 unDays );

ManagedSteam_API void UGC_RequestUGCDetails( u64 nPublishedFileID );

#endif // SteamUGC_h_interop_