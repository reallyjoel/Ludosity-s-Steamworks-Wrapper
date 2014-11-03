#ifndef MatchmakingServers_h_
#define MatchmakingServers_h_

#include "MatchmakingServers.h"
#include "Singleton.hpp"

namespace SteamAPIWrap
{
	class CMatchmakingServers : public CSingleton<CMatchmakingServers>
	{
		
	public:
		void SetSteamInterface(ISteamMatchmakingServers *matchmakingServers)
		{ 
			this->matchmakingServers = matchmakingServers; 
		}



		ServerListRequest RequestInternetServerList(u32 appId, PDataPointer filters, u32 filterCount, 
			uptr requestServersResponse);
		ServerListRequest RequestLANServerList(u32 appId, uptr requestServerResponse);
		ServerListRequest RequestFriendsServerList(u32 appId, PDataPointer filters, u32 filtersCount, 
			uptr requestServersResponse);

		ServerListRequest RequestFavoritesServerList(u32 appId, PDataPointer filters, u32 filterCount, 
			uptr requestServersResponse);
		ServerListRequest RequestHistoryServerList(u32 appId, PDataPointer filters, u32 filterCount, 
			uptr requestServersResponse);
		ServerListRequest RequestSpectatorServerList(u32 appId, PDataPointer filters, u32 filterCount, 
			uptr requestServersResponse);

		void ReleaseRequest(ServerListRequest request);

		PDataPointer GetServerDetails(ServerListRequest request, s32 server );

		void CancelQuery(ServerListRequest request);

		void RefreshQuery(ServerListRequest request);

		bool IsRefreshing(ServerListRequest request); 

		s32 GetServerCount(ServerListRequest request); 

		void RefreshServer(ServerListRequest request, s32 server); 

		ServerQuery PingServer( u32 ip, u16 port, uptr requestServersResponse ); 

		ServerQuery PlayerDetails( u32 ip, u16 port, uptr requestServersResponse );

		ServerQuery ServerRules( u32 ip, u16 port, uptr requestServersResponse ); 

		void CancelServerQuery(s32 serverQuery);
	
	private:
		friend class CSingleton<CMatchmakingServers>;
		CMatchmakingServers();
		~CMatchmakingServers() {}
		DISALLOW_COPY_AND_ASSIGN(CMatchmakingServers);

		ISteamMatchmakingServers *matchmakingServers;
	};
}

#endif // MatchmakingServers_h_