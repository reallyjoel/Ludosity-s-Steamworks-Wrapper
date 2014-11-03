#ifndef Apps_h_interop_
#define Apps_h_interop_


ManagedSteam_API bool Apps_IsSubscribed();
ManagedSteam_API bool Apps_IsLowViolence();
ManagedSteam_API bool Apps_IsCybercafe();
ManagedSteam_API bool Apps_IsVACBanned();
ManagedSteam_API PConstantString Apps_GetCurrentGameLanguage();
ManagedSteam_API PConstantString Apps_GetAvailableGameLanguages();

ManagedSteam_API bool Apps_IsSubscribedApp( u32 appID );

ManagedSteam_API bool Apps_IsDlcInstalled( u32 appID );

ManagedSteam_API u32 Apps_GetEarliestPurchaseUnixTime( u32 appID );

ManagedSteam_API bool Apps_IsSubscribedFromFreeWeekend();

ManagedSteam_API int Apps_GetDLCCount();

ManagedSteam_API bool Apps_GetDLCDataByIndex( int iDLC, u32 *pAppID, bool *pbAvailable, PString pchName, int cchNameBufferSize );

ManagedSteam_API void Apps_InstallDLC( u32 appID );
ManagedSteam_API void Apps_UninstallDLC( u32 appID );

ManagedSteam_API void Apps_RequestAppProofOfPurchaseKey( u32 appID );

ManagedSteam_API bool Apps_GetCurrentBetaName( PString pchName, int cchNameBufferSize ); // returns current beta branch name, 'public' is the default branch
ManagedSteam_API bool Apps_MarkContentCorrupt( bool bMissingFilesOnly ); // signal Steam that game files seems corrupt or missing
ManagedSteam_API u32 Apps_GetInstalledDepots( u32 appID, u32 *pvecDepots, u32 cMaxDepots ); // return installed depots in mount order
ManagedSteam_API SteamID Apps_GetAppOwner(); // returns the SteamID of the original owner. If different from current user, it's borrowed
ManagedSteam_API PConstantString Apps_GetLaunchQueryParam( PConstantString pchKey );

#endif