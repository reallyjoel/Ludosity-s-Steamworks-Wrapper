#ifndef SteamUser_h_interop_
#define SteamUser_h_interop_

ManagedSteam_API_Lite bool User_IsLoggedOn();

ManagedSteam_API_Lite SteamID User_GetSteamID();
		
ManagedSteam_API s32 User_InitiateGameConnection( PDataPointer authBlob, s32 maxAuthBlob, SteamID steamIDGameServer, u32 serverIP, u16 serverPort, bool secure );

ManagedSteam_API void User_TerminateGameConnection( u32 serverIP, u16 serverPort );

ManagedSteam_API void User_TrackAppUsageEvent( GameID gameID, s32 appUsageEvent, PConstantString extraInfo = "");

ManagedSteam_API_Lite bool User_GetUserDataFolder( PString buffer, s32 bufferLength );

ManagedSteam_API void User_StartVoiceRecording( );

ManagedSteam_API void User_StopVoiceRecording( );

ManagedSteam_API Enum User_GetAvailableVoice( u32* compressed, u32* uncompressed, u32 uncompressedVoiceDesiredSampleRate );

ManagedSteam_API Enum User_GetVoice( bool wantCompressed, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, bool wantUncompressed, PDataPointer uncompressedDestBuffer, u32 uncompressedDestBufferSize, u32 *uncompressedBytesWritten, u32 uncompressedVoiceDesiredSampleRate );

ManagedSteam_API Enum User_DecompressVoice(PConstantDataPointer compressed, u32 compressedSize, PDataPointer destBuffer, u32 destBufferSize, u32 *bytesWritten, u32 desiredSampleRate);

ManagedSteam_API u32 User_GetVoiceOptimalSampleRate( );

ManagedSteam_API u32 User_GetAuthSessionTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );

ManagedSteam_API Enum User_BeginAuthSession( PConstantDataPointer authTicket, s32 cbAuthTicket, SteamID steamID );

ManagedSteam_API void User_EndAuthSession( SteamID steamID );

ManagedSteam_API void User_CancelAuthTicket( u32 authTicket );

ManagedSteam_API Enum User_UserHasLicenseForApp( SteamID steamID, AppID appID );

ManagedSteam_API bool User_IsBehindNAT( );

ManagedSteam_API void User_AdvertiseGame( SteamID steamIDGameServer, u32 serverIP, u16 serverPort );

ManagedSteam_API void User_RequestEncryptedAppTicket( PDataPointer dataToInclude, s32 cbDataToInclude );

ManagedSteam_API bool User_GetEncryptedAppTicket( PDataPointer ticket, s32 maxTicket, u32 *ticketLength );

ManagedSteam_API s32 User_GetGameBadgeLevel( s32 nSeries, bool bFoil );

ManagedSteam_API s32 User_GetPlayerSteamLevel( );

#endif // SteamUser_h_interop_