#ifndef MatchmakingRulesResponse_h_
#define MatchmakingRulesResponse_h_

#include "MatchmakingRulesResponse.h"

namespace SteamAPIWrap
{
	class CMatchmakingRulesResponse : public ISteamMatchmakingRulesResponse 
	{
	public:


		static uptr CreateObject();

		static void DestroyObject(uptr obj);

		static void RegisterCallbacks(MatchmakingRulesResponse_RulesResponded rulesResponded, MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond, MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete);

		static void RemoveCallbacks();
		
		virtual void RulesResponded(const char *rule, const char *value);

		virtual void RulesFailedToRespond();

		virtual void RulesRefreshComplete();
	
	private:
		CMatchmakingRulesResponse();
		~CMatchmakingRulesResponse();
		DISALLOW_COPY_AND_ASSIGN(CMatchmakingRulesResponse);

		static MatchmakingRulesResponse_RulesResponded rulesResponded;
		static MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond;
		static MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete;
	};
}

#endif // MatchmakingPlayersResponse_h_