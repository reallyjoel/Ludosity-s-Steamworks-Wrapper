#include "Precompiled.hpp"
#include "MatchMakingServers.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CMatchmakingServers * CSingleton<CMatchmakingServers>::instance = nullptr;


	CMatchmakingServers::CMatchmakingServers()
		: matchmakingServers(nullptr)
	{

	}

	ServerListRequest CMatchmakingServers::RequestInternetServerList(u32 appId, PDataPointer filters,
		u32 filterCount, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestInternetServerList(appId,
			reinterpret_cast<MatchMakingKeyValuePair_t **>(filters), filterCount,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));

		// Handle the pointer as an ServerListRequest (u32) on the managed side.
		return reinterpret_cast<ServerListRequest>(request);
	}

	ServerListRequest CMatchmakingServers::RequestLANServerList(u32 appID, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestLANServerList(appID,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));
		return reinterpret_cast<ServerListRequest>(request);
	}

	ServerListRequest CMatchmakingServers::RequestFriendsServerList(u32 appId, PDataPointer filters,
		u32 filterCount, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestFriendsServerList(appId,
			reinterpret_cast<MatchMakingKeyValuePair_t **>(filters), filterCount,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));

		return reinterpret_cast<ServerListRequest>(request);
	}

	ServerListRequest CMatchmakingServers::RequestFavoritesServerList(u32 appId, PDataPointer filters,
		u32 filterCount, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestFavoritesServerList(appId,
			reinterpret_cast<MatchMakingKeyValuePair_t **>(filters), filterCount,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));

		return reinterpret_cast<ServerListRequest>(request);
	}

	ServerListRequest CMatchmakingServers::RequestHistoryServerList(u32 appId, PDataPointer filters,
		u32 filterCount, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestHistoryServerList(appId,
			reinterpret_cast<MatchMakingKeyValuePair_t **>(filters), filterCount,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));

		return reinterpret_cast<ServerListRequest>(request);
	}

	ServerListRequest CMatchmakingServers::RequestSpectatorServerList(u32 appId, PDataPointer filters,
		u32 filterCount, uptr requestServersResponse)
	{
		HServerListRequest request = matchmakingServers->RequestSpectatorServerList(appId,
			reinterpret_cast<MatchMakingKeyValuePair_t **>(filters), filterCount,
			reinterpret_cast<ISteamMatchmakingServerListResponse *>(requestServersResponse));

		return reinterpret_cast<ServerListRequest>(request);
	}

	void CMatchmakingServers::ReleaseRequest(ServerListRequest request)
	{
		matchmakingServers->ReleaseRequest(reinterpret_cast<HServerListRequest>(request));
	}

	PDataPointer CMatchmakingServers::GetServerDetails(ServerListRequest request, int server)
	{
		return matchmakingServers->GetServerDetails(reinterpret_cast<HServerListRequest>(request), server);
	}

	void CMatchmakingServers::CancelQuery(ServerListRequest request)
	{
		matchmakingServers->CancelQuery(reinterpret_cast<HServerListRequest>(request));
	}

	void CMatchmakingServers::RefreshQuery(ServerListRequest request)
	{
		matchmakingServers->RefreshQuery(reinterpret_cast<HServerListRequest>(request));
	}

	bool CMatchmakingServers::IsRefreshing(ServerListRequest request)
	{
		return matchmakingServers->IsRefreshing(reinterpret_cast<HServerListRequest>(request));
	}

	s32 CMatchmakingServers::GetServerCount(ServerListRequest request)
	{
		return matchmakingServers->GetServerCount(reinterpret_cast<HServerListRequest>(request));
	}

	void CMatchmakingServers::RefreshServer(ServerListRequest request, s32 server)
	{
		matchmakingServers->RefreshServer(reinterpret_cast<HServerListRequest>(request), server);
	}

	ServerQuery CMatchmakingServers::PingServer(u32 ip, u16 port, uptr requestServersResponse)
	{
		return matchmakingServers->PingServer(ip, port,
			reinterpret_cast<ISteamMatchmakingPingResponse *>(requestServersResponse));
	}

	ServerQuery CMatchmakingServers::PlayerDetails(u32 ip, u16 port, uptr requestServersResponse)
	{
		return matchmakingServers->PlayerDetails(ip, port,
			reinterpret_cast<ISteamMatchmakingPlayersResponse *>(requestServersResponse));
	}

	ServerQuery CMatchmakingServers::ServerRules(u32 ip, u16 port, uptr requestServersResponse)
	{
		return matchmakingServers->ServerRules(ip, port,
			reinterpret_cast<ISteamMatchmakingRulesResponse *>(requestServersResponse));
	}

	void CMatchmakingServers::CancelServerQuery(s32 serverQuery)
	{
		matchmakingServers->CancelServerQuery(serverQuery);
	}
}

ManagedSteam_API PConstantAnsiString MatchmakingServerNetworkAddress_GetConnectionString(PConstantDataPointer instance)
{
	const servernetadr_t *fakedInstance = reinterpret_cast<const servernetadr_t *>(instance);
	return fakedInstance->GetConnectionAddressString();
}

ManagedSteam_API PConstantAnsiString MatchmakingServerNetworkAddress_GetQueryString(PConstantDataPointer instance)
{
	const servernetadr_t *fakedInstance = reinterpret_cast<const servernetadr_t *>(instance);
	return fakedInstance->GetQueryAddressString();
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestInternetServerList(u32 appId,
	PDataPointer filters, u32 filterCount, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestInternetServerList(appId, filters, filterCount,
		requestServersResponse);
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestLANServerList(u32 appId, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestLANServerList(appId, requestServersResponse);
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestFriendsServerList(u32 appId,
	PDataPointer filters, u32 filterCount, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestFriendsServerList(appId, filters, filterCount,requestServersResponse);
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestFavoritesServerList(u32 appId,
	PDataPointer filters, u32 filterCount, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestFavoritesServerList(appId, filters, filterCount,requestServersResponse);
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestHistoryServerList(u32 appId,
	PDataPointer filters, u32 filterCount, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestHistoryServerList(appId, filters, filterCount,requestServersResponse);
}

ManagedSteam_API ServerListRequest MatchmakingServers_RequestSpectatorServerList(u32 appId,
	PDataPointer filters, u32 filterCount, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().RequestSpectatorServerList(appId, filters, filterCount,requestServersResponse);
}

ManagedSteam_API void MatchmakingServers_ReleaseRequest(ServerListRequest request)
{
	CMatchmakingServers::Instance().ReleaseRequest(request);
}

ManagedSteam_API PDataPointer MatchmakingServers_GetServerDetails(ServerListRequest request, s32 server)
{
	return CMatchmakingServers::Instance().GetServerDetails(request, server);
}

ManagedSteam_API s32 MatchmakingServers_GetGameServerItemSize()
{
	return sizeof(gameserveritem_t);
}

ManagedSteam_API void MatchmakingServers_CancelQuery(ServerListRequest request)
{
	CMatchmakingServers::Instance().CancelQuery(request);
}

ManagedSteam_API void MatchmakingServers_RefreshQuery(ServerListRequest request)
{
	CMatchmakingServers::Instance().RefreshQuery(request);
}

ManagedSteam_API bool MatchmakingServers_IsRefreshing(ServerListRequest request)
{
	return CMatchmakingServers::Instance().IsRefreshing(request);
}

ManagedSteam_API int MatchmakingServers_GetServerCount(ServerListRequest request)
{
	return CMatchmakingServers::Instance().GetServerCount(request);
}

ManagedSteam_API void MatchmakingServers_RefreshServer(ServerListRequest request, s32 server)
{
	CMatchmakingServers::Instance().RefreshServer(request, server);
}

ManagedSteam_API ServerQuery MatchmakingServers_PingServer(u32 ip, u16 port, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().PingServer(ip, port, requestServersResponse);
}

ManagedSteam_API ServerQuery MatchmakingServers_PlayerDetails(u32 ip, u16 port, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().PlayerDetails(ip, port, requestServersResponse);
}

ManagedSteam_API ServerQuery MatchmakingServers_ServerRules(u32 ip, u16 port, uptr requestServersResponse)
{
	return CMatchmakingServers::Instance().ServerRules(ip, port, requestServersResponse);
}

ManagedSteam_API void MatchmakingServers_CancelServerQuery(s32 serverQuery)
{
	CMatchmakingServers::Instance().CancelServerQuery(serverQuery);
}
