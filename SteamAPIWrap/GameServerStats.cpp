#include "Precompiled.hpp"
#include "GameServerStats.hpp"

#include "OverlayDialog.hpp"
#include "OverlayDialogToUser.hpp"

#include "MemoryHelpers.h"
#include "isteamgameserver.h"


using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CGameServerStats* CSingleton<CGameServerStats>::instance = nullptr;

	CGameServerStats::CGameServerStats() 
		: nativeGSStatsUnloadedCallback(this, &CGameServerStats::OnGSStatsUnloaded)
		, gameServerStats(nullptr)
	{

	}

	void CGameServerStats::RequestUserStats( SteamID steamIDUser )
	{
		resultGSStatsReceived.Set(gameServerStats->RequestUserStats(steamIDUser),
			this, &CGameServerStats::OnGSStatsReceived);
	}

	bool CGameServerStats::GetUserStatInt( SteamID steamIDUser, PConstantString name, s32 *data )
	{
		return gameServerStats->GetUserStat(steamIDUser, name, data);
	}

	bool CGameServerStats::GetUserStatFloat( SteamID steamIDUser, PConstantString name, f32 *data )
	{
		return gameServerStats->GetUserStat(steamIDUser, name, data);
	}

	bool CGameServerStats::GetUserAchievement( SteamID steamIDUser, PConstantString name, bool *achieved )
	{
		return gameServerStats->GetUserAchievement(steamIDUser, name, achieved);
	}

	bool CGameServerStats::SetUserStatInt(SteamID steamIDUser, PConstantString name, s32 data)
	{
		return gameServerStats->SetUserStat(steamIDUser, name, data);
	}

	bool CGameServerStats::SetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 data)
	{
		return gameServerStats->SetUserStat(steamIDUser, name, data);
	}

	bool CGameServerStats::UpdateUserAvgRateStat( SteamID steamIDUser, PConstantString name, f32 countThisSession, f64 sessionLength )
	{
		return gameServerStats->UpdateUserAvgRateStat(steamIDUser, name, countThisSession, sessionLength);
	}

	bool CGameServerStats::SetUserAchievement( SteamID steamIDUser, PConstantString name )
	{
		return gameServerStats->SetUserAchievement(steamIDUser, name);
	}

	bool CGameServerStats::ClearUserAchievement( SteamID steamIDUser, PConstantString name )
	{
		return gameServerStats->ClearUserAchievement(steamIDUser, name);
	}

	void CGameServerStats::StoreUserStats( SteamID steamIDUser )
	{
		resultGSStatsStored.Set(gameServerStats->StoreUserStats(steamIDUser), 
			this, &CGameServerStats::OnGSStatsStored);
	}

}

ManagedSteam_API void GameServerStats_RequestUserStats( SteamID steamIDUser )
{
	CGameServerStats::Instance().RequestUserStats(steamIDUser);
}

ManagedSteam_API bool GameServerStats_GetUserStatInt( SteamID steamIDUser, PConstantString name, s32 *data )
{
	return CGameServerStats::Instance().GetUserStatInt(steamIDUser, name, data);
}

ManagedSteam_API bool GameServerStats_GetUserStatFloat( SteamID steamIDUser, PConstantString name, f32 *data )
{
	return CGameServerStats::Instance().GetUserStatFloat(steamIDUser, name, data);
}

ManagedSteam_API bool GameServerStats_GetUserAchievement( SteamID steamIDUser, PConstantString name, bool *achieved )
{
	return CGameServerStats::Instance().GetUserAchievement(steamIDUser, name, achieved);
}

ManagedSteam_API bool GameServerStats_SetUserStatInt(SteamID steamIDUser, PConstantString name, int data)
{
	return CGameServerStats::Instance().SetUserStatInt(steamIDUser, name, data);
}

ManagedSteam_API bool GameServerStats_SetUserStatFloat(SteamID steamIDUser, PConstantString name, f32 data)
{
	return CGameServerStats::Instance().SetUserStatFloat(steamIDUser, name, data);
}

ManagedSteam_API bool GameServerStats_UpdateUserAvgRateStat( SteamID steamIDUser, PConstantString name, f32 countThisSession, f64 sessionLength )
{
	return CGameServerStats::Instance().UpdateUserAvgRateStat(steamIDUser, name, countThisSession, sessionLength);
}

ManagedSteam_API bool GameServerStats_SetUserAchievement( SteamID steamIDUser, PConstantString name )
{
	return CGameServerStats::Instance().SetUserAchievement(steamIDUser, name);
}

ManagedSteam_API bool GameServerStats_ClearUserAchievement( SteamID steamIDUser, PConstantString name )
{
	return CGameServerStats::Instance().ClearUserAchievement(steamIDUser, name);
}

ManagedSteam_API void GameServerStats_StoreUserStats( SteamID steamIDUser )
{
	CGameServerStats::Instance().StoreUserStats(steamIDUser);
}
