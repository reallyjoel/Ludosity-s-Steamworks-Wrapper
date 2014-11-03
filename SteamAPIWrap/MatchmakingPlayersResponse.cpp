#include "Precompiled.hpp"
#include "MatchmakingPlayersResponse.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	MatchmakingPlayersResponse_AddPlayerToList CMatchmakingPlayersResponse::addPlayerToList = nullptr;
	MatchmakingPlayersResponse_PlayersFailedToRespond CMatchmakingPlayersResponse::playersFailedToRespond = nullptr;
	MatchmakingPlayersResponse_PlayersRefreshComplete CMatchmakingPlayersResponse::playersRefreshComplete = nullptr;

	CMatchmakingPlayersResponse::CMatchmakingPlayersResponse()
	{

	}

	CMatchmakingPlayersResponse::~CMatchmakingPlayersResponse()
	{

	}

	uptr CMatchmakingPlayersResponse::CreateObject()
	{
		CMatchmakingPlayersResponse *obj = new CMatchmakingPlayersResponse();
		return reinterpret_cast<uptr>(obj);
	}

	void CMatchmakingPlayersResponse::DestroyObject(uptr obj)
	{
		CMatchmakingPlayersResponse *actualObject = reinterpret_cast<CMatchmakingPlayersResponse *>(obj);
		delete actualObject;
	}

	void CMatchmakingPlayersResponse::RegisterCallbacks(
		MatchmakingPlayersResponse_AddPlayerToList addPlayerToList, 
		MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond, 
		MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete)
	{
		CMatchmakingPlayersResponse::addPlayerToList = addPlayerToList;
		CMatchmakingPlayersResponse::playersFailedToRespond = playersFailedToRespond;
		CMatchmakingPlayersResponse::playersRefreshComplete = playersRefreshComplete;
	}

	void CMatchmakingPlayersResponse::RemoveCallbacks()
	{
		addPlayerToList = nullptr;
		playersFailedToRespond = nullptr;
		playersRefreshComplete = nullptr;
	}

	void CMatchmakingPlayersResponse::AddPlayerToList(const char *name, int score, float timePlayed)
	{
		// Only send the callback if a receiver is registered
		if (addPlayerToList != nullptr)
		{
			addPlayerToList(reinterpret_cast<uptr>(this), name, score, timePlayed);
		}
	}

	void CMatchmakingPlayersResponse::PlayersFailedToRespond()
	{
		if (playersFailedToRespond != nullptr)
		{
			playersFailedToRespond(reinterpret_cast<uptr>(this));
		}
	}

	void CMatchmakingPlayersResponse::PlayersRefreshComplete()
	{
		if (playersRefreshComplete != nullptr)
		{
			playersRefreshComplete(reinterpret_cast<uptr>(this));
		}
	}

}

ManagedSteam_API_Lite uptr MatchmakingPlayersResponse_CreateObject()
{
	return CMatchmakingPlayersResponse::CreateObject();
}

ManagedSteam_API_Lite void MatchmakingPlayersResponse_DestroyObject(uptr obj)
{
	CMatchmakingPlayersResponse::DestroyObject(obj);
}

ManagedSteam_API_Lite void MatchmakingPlayersResponse_RegisterCallbacks(
	MatchmakingPlayersResponse_AddPlayerToList addPlayerToList, 
	MatchmakingPlayersResponse_PlayersFailedToRespond playersFailedToRespond, 
	MatchmakingPlayersResponse_PlayersRefreshComplete playersRefreshComplete)
{
	CMatchmakingPlayersResponse::RegisterCallbacks(addPlayerToList, playersFailedToRespond, playersRefreshComplete);
}

ManagedSteam_API_Lite void MatchmakingPlayersResponse_RemoveCallbacks()
{
	CMatchmakingPlayersResponse::RemoveCallbacks();
}