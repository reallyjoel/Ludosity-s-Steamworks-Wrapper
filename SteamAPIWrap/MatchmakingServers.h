#ifndef MatchmakingServers_h_interop_
#define MatchmakingServers_h_interop_

ManagedSteam_API PConstantAnsiString MatchmakingServerNetworkAddress_GetConnectionString(PConstantDataPointer instance);
ManagedSteam_API PConstantAnsiString MatchmakingServerNetworkAddress_GetQueryString(PConstantDataPointer instance);

ManagedSteam_API ServerListRequest MatchmakingServers_RequestInternetServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
ManagedSteam_API ServerListRequest MatchmakingServers_RequestLANServerList(u32 appId, uptr requestServersResponse);
ManagedSteam_API ServerListRequest MatchmakingServers_RequestFriendsServerList(u32 appId, PDataPointer filters, u32 filtersCount, uptr requestServersResponse);
ManagedSteam_API ServerListRequest MatchmakingServers_RequestFavoritesServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
ManagedSteam_API ServerListRequest MatchmakingServers_RequestHistoryServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);
ManagedSteam_API ServerListRequest MatchmakingServers_RequestSpectatorServerList(u32 appId, PDataPointer filters, u32 filterCount, uptr requestServersResponse);

ManagedSteam_API void MatchmakingServers_ReleaseRequest(ServerListRequest request); 

ManagedSteam_API PDataPointer MatchmakingServers_GetServerDetails(ServerListRequest request, s32 server);

ManagedSteam_API s32 MatchmakingServers_GetGameServerItemSize();

ManagedSteam_API void MatchmakingServers_CancelQuery(ServerListRequest request);

ManagedSteam_API void MatchmakingServers_RefreshQuery(ServerListRequest request);

ManagedSteam_API bool MatchmakingServers_IsRefreshing(ServerListRequest request); 

ManagedSteam_API s32 MatchmakingServers_GetServerCount(ServerListRequest request); 

ManagedSteam_API void MatchmakingServers_RefreshServer(ServerListRequest request, s32 server); 

ManagedSteam_API ServerQuery MatchmakingServers_PingServer( u32 ip, u16 port, uptr requestServersResponse ); 

ManagedSteam_API ServerQuery MatchmakingServers_PlayerDetails( u32 ip, u16 port, uptr requestServersResponse );

ManagedSteam_API ServerQuery MatchmakingServers_ServerRules( u32 ip, u16 port, uptr requestServersResponse ); 

ManagedSteam_API void MatchmakingServers_CancelServerQuery(s32 serverQuery);

#endif // MatchmakingServers_h_interop_