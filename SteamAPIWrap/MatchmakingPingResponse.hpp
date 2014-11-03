#ifndef MatchmakingPingResponse_h_
#define MatchmakingPingResponse_h_

#include "MatchmakingPingResponse.h"

namespace SteamAPIWrap
{
	class CMatchmakingPingResponse : public ISteamMatchmakingPingResponse 
	{
	public:

		static uptr CreateObject();

		static void DestroyObject(uptr obj);

		static void RegisterCallbacks(MatchmakingPingResponse_ServerRespondedCallback serverResponded, MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond);

		static void RemoveCallbacks();
		
		virtual void ServerResponded(gameserveritem_t &server);

		virtual void ServerFailedToRespond();
	
	private:
		CMatchmakingPingResponse();
		~CMatchmakingPingResponse();
		DISALLOW_COPY_AND_ASSIGN(CMatchmakingPingResponse);

		static MatchmakingPingResponse_ServerRespondedCallback serverResponded;
		static MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond;
	};
}

#endif // MatchmakingPingResponse_h_