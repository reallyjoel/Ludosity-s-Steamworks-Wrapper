#ifndef GameServer_h_interop_
#define GameServer_h_interop_

ManagedSteam_API bool GameServer_InitGameServer(u32 ip, u16 gamePort, u16 queryPort, u32 flags, AppID gameAppId, PConstantString versionString);

ManagedSteam_API void GameServer_SetProduct(PConstantString product);

ManagedSteam_API void GameServer_SetGameDescription(PConstantString gameDescription );

ManagedSteam_API void GameServer_SetModDir( PConstantString modDir );

ManagedSteam_API void GameServer_SetDedicatedServer( bool dedicated );

ManagedSteam_API void GameServer_LogOn(PConstantString accountName, PConstantString password);

ManagedSteam_API void GameServer_LogOnAnonymous();

ManagedSteam_API void GameServer_LogOff();

ManagedSteam_API bool GameServer_LoggedOn();

ManagedSteam_API bool GameServer_Secure();

ManagedSteam_API SteamID GameServer_GetSteamID();

ManagedSteam_API bool GameServer_WasRestartRequested();

ManagedSteam_API void GameServer_SetMaxPlayerCount(s32 playersMax);

ManagedSteam_API void GameServer_SetBotPlayerCount(s32 botplayers);

ManagedSteam_API void GameServer_SetServerName(PConstantString  serverName);

ManagedSteam_API void GameServer_SetMapName(PConstantString mapName);

ManagedSteam_API void GameServer_SetPasswordProtected(bool passwordProtected);

ManagedSteam_API void GameServer_SetSpectatorPort(u16 spectatorPort);

ManagedSteam_API void GameServer_SetSpectatorServerName(PConstantString spectatorServerName);

ManagedSteam_API void GameServer_ClearAllKeyValues();

ManagedSteam_API void GameServer_SetKeyValue(PConstantString key, PConstantString value);

ManagedSteam_API void GameServer_SetGameTags(PConstantString gameTags);

ManagedSteam_API void GameServer_SetGameData(PConstantString gameData);

ManagedSteam_API void GameServer_SetRegion(PConstantString region);

ManagedSteam_API bool GameServer_SendUserConnectAndAuthenticate(u32 ipClient, PConstantDataPointer authBlob, u32 authBlobSize, SteamID *steamIDUser );

ManagedSteam_API SteamID GameServer_CreateUnauthenticatedUserConnection();

ManagedSteam_API void GameServer_SendUserDisconnect(SteamID steamIDUser);

ManagedSteam_API bool GameServer_UpdateUserData(SteamID steamIDUser, PConstantString playerName, u32 core);

ManagedSteam_API AuthTicket GameServer_GetAuthSessionTicket(PDataPointer ticket, s32 maxTicket, u32 *ticketSize);

ManagedSteam_API Enum GameServer_BeginAuthSession(PConstantDataPointer authTicket, s32 authTicketSize, SteamID steamID);

ManagedSteam_API void GameServer_EndAuthSession(SteamID steamID );

ManagedSteam_API void GameServer_CancelAuthTicket(AuthTicket authTicket);

ManagedSteam_API Enum GameServer_UserHasLicenseForApp(SteamID steamID, AppID appID);

ManagedSteam_API bool GameServer_RequestUserGroupStatus(SteamID steamIDUser, SteamID steamIDGroup);

ManagedSteam_API void GameServer_GetGameplayStats();

ManagedSteam_API void GameServer_GetServerReputation();

ManagedSteam_API u32 GameServer_GetPublicIP();

ManagedSteam_API bool GameServer_HandleIncomingPacket(PConstantDataPointer data, s32 dataSize, u32 ip, u16 srcPort);

ManagedSteam_API s32 GameServer_GetNextOutgoingPacket(PDataPointer out, s32 maxOut, u32 *netAdr, u16 *port);

ManagedSteam_API void GameServer_EnableHeartbeats(bool active);

ManagedSteam_API void GameServer_SetHeartbeatInterval(s32 heartbeatInterval);

ManagedSteam_API void GameServer_ForceHeartbeat();

ManagedSteam_API void GameServer_AssociateWithClan(SteamID steamIDClan);

ManagedSteam_API void GameServer_ComputeNewPlayerCompatibility(SteamID steamIDNewPlayer);



#endif