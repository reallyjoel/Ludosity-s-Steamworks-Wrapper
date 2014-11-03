#ifndef MatchMaking_h_interop_
#define MatchMaking_h_interop_

ManagedSteam_API s32 MatchMaking_GetFavoriteGameCount();

ManagedSteam_API bool MatchMaking_GetFavoriteGame(s32 game, u32 *appID, u32 *ip, u16 *connPort, u16 *queryPort, u32 *flags, u32 *time32LastPlayedOnServer );

ManagedSteam_API s32 MatchMaking_AddFavoriteGame(u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags, u32 time32LastPlayedOnServer );

ManagedSteam_API bool MatchMaking_RemoveFavoriteGame( u32 appID, u32 IP, u16 connPort, u16 queryPort, u32 flags );

ManagedSteam_API void MatchMaking_RequestLobbyList();

ManagedSteam_API void MatchMaking_AddRequestLobbyListStringFilter(PConstantString keyToMatch, PConstantString valueToMatch, Enum comparisonType);

ManagedSteam_API void MatchMaking_AddRequestLobbyListNumericalFilter(PConstantString keyToMatch, s32 valueToMatch, Enum comparisonType);

ManagedSteam_API void MatchMaking_AddRequestLobbyListNearValueFilter(PConstantString keyToMatch, s32 valueToBeCloseTo);

ManagedSteam_API void MatchMaking_AddRequestLobbyListFilterSlotsAvailable( s32 SlotsAvailable );

ManagedSteam_API void MatchMaking_AddRequestLobbyListDistanceFilter(Enum lobbyDistanceFilter);

ManagedSteam_API void MatchMaking_AddRequestLobbyListResultCountFilter(s32 maxResults);

ManagedSteam_API void MatchMaking_AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby);

ManagedSteam_API SteamID MatchMaking_GetLobbyByIndex(s32 lobby);

ManagedSteam_API void MatchMaking_CreateLobby(Enum lobbyType, s32 maxMembers);

ManagedSteam_API void MatchMaking_JoinLobby(SteamID steamIDLobby);

ManagedSteam_API void MatchMaking_LeaveLobby(SteamID steamIDLobby);

ManagedSteam_API bool MatchMaking_InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee);

ManagedSteam_API s32 MatchMaking_GetNumLobbyMembers(SteamID steamIDLobby);

ManagedSteam_API SteamID MatchMaking_GetLobbyMemberByIndex(SteamID steamIDLobby, s32 member);

ManagedSteam_API PConstantString MatchMaking_GetLobbyData(SteamID steamIDLobby, PConstantString key);

ManagedSteam_API bool MatchMaking_SetLobbyData(SteamID steamIDLobby, PConstantString key, PConstantString value);

ManagedSteam_API s32 MatchMaking_GetLobbyDataCount(SteamID steamIDLobby);

ManagedSteam_API bool MatchMaking_GetLobbyDataByIndex(SteamID steamIDLobby, s32 lobbyData, PString key, s32 keyBufferSize, PString value, s32 valueBufferSize);

ManagedSteam_API bool MatchMaking_DeleteLobbyData(SteamID steamIDLobby, PConstantString key);

ManagedSteam_API PConstantString MatchMaking_GetLobbyMemberData(SteamID steamIDLobby, SteamID SteamIDUser, PConstantString key);

ManagedSteam_API void MatchMaking_SetLobbyMemberData(SteamID steamIDLobby, PConstantString key, PConstantString value);

ManagedSteam_API bool MatchMaking_SendLobbyChatMsg(SteamID steamIDLobby, PConstantDataPointer msg, s32 cubMsg);

ManagedSteam_API s32 MatchMaking_GetLobbyChatEntry(SteamID steamIDLobby, s32 chatID, SteamID *steamIDUser, PDataPointer data, s32 dataBufferSize, Enum *chatEntryType);

ManagedSteam_API bool MatchMaking_RequestLobbyData(SteamID steamIDLobby);

ManagedSteam_API void MatchMaking_SetLobbyGameServer(SteamID steamIDLobby, u32 gameServerIP, u16 gameServerPort, SteamID steamIDGameServer);

ManagedSteam_API bool MatchMaking_GetLobbyGameServer(SteamID steamIDLobby, u32 *gameServerIP, u16 *gameServerPort, SteamID *steamIDGameServer);

ManagedSteam_API bool MatchMaking_SetLobbyMemberLimit(SteamID steamIDLobby, s32 maxMembers);

ManagedSteam_API s32  MatchMaking_GetLobbyMemberLimit(SteamID steamIDlobby);

ManagedSteam_API bool MatchMaking_SetLobbyType(SteamID steamIDLobby, Enum lobbyType);

ManagedSteam_API bool MatchMaking_SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable);

ManagedSteam_API SteamID MatchMaking_GetLobbyOwner(SteamID steamIDLobby);

ManagedSteam_API bool MatchMaking_SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner);

ManagedSteam_API bool MatchMaking_SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent);

#endif // RemoteStorage_h_interop_