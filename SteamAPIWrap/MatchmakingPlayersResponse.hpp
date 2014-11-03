#ifndef MatchmakingPlayersResponse_h_
#define MatchmakingPlayersResponse_h_

#include "MatchmakingPlayersResponse.h"

namespace SteamAPIWrap
{
	class CMatchmakingPlayersResponse : public ISteamMatchmakingPlayersResponse 
	{
	public:


		static uptr CreateObject();

		static void DestroyObject(uptr obj);

		static void RegisterCallbacks(MatchmakingPlayersResponse_AddPlayerToList addPlayerToList, MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond, MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete);

		static void RemoveCallbacks();
		
		virtual void AddPlayerToList(const char *name, int score, float timePlayed);

		virtual void PlayersFailedToRespond();

		virtual void PlayersRefreshComplete();
	
	private:
		CMatchmakingPlayersResponse();
		~CMatchmakingPlayersResponse();
		DISALLOW_COPY_AND_ASSIGN(CMatchmakingPlayersResponse);

		static MatchmakingPlayersResponse_AddPlayerToList addPlayerToList;
		static MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond;
		static MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete;
	};
}

#endif // MatchmakingPlayersResponse_h_