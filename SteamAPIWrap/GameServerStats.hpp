#ifndef GameServerStats_h_
#define GameServerStats_h_

#include "GameServerStats.h"
#include "Singleton.hpp"

#include "ServicesGameServer.hpp"

// Types
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CGameServerStats : public CSingleton<CGameServerStats>
	{
		
		SW_GS_ASYNC_RESULT(CGameServerStats, GSStatsReceived_t, GSStatsReceived);
		SW_GS_ASYNC_RESULT(CGameServerStats, GSStatsStored_t, GSStatsStored);
		SW_GS_CALLBACK(CGameServerStats, GSStatsUnloaded_t, GSStatsUnloaded);
		


	public:
		void SetSteamInterface(ISteamGameServerStats *gameServerStats) { this->gameServerStats = gameServerStats; }

		void RequestUserStats(SteamID steamIDUser);

		bool GetUserStatInt(SteamID steamIDUser, PConstantString name, s32 *data);

		bool GetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 *data);

		bool GetUserAchievement(SteamID steamIDUser, PConstantString name, bool *achieved);

		bool SetUserStatInt(SteamID steamIDUser, PConstantString name, s32 data);

		bool SetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 data);

		bool UpdateUserAvgRateStat(SteamID steamIDUser, PConstantString name, f32 countThisSession, f64 sessionLength);

		bool SetUserAchievement(SteamID steamIDUser, PConstantString name);

		bool ClearUserAchievement(SteamID steamIDUser, PConstantString name);

		void StoreUserStats(SteamID steamIDUser);

		


	private:
		friend class CSingleton<CGameServerStats>;
		CGameServerStats();
		~CGameServerStats() {}
		DISALLOW_COPY_AND_ASSIGN(CGameServerStats);

		ISteamGameServerStats *gameServerStats;


	};

}


#endif