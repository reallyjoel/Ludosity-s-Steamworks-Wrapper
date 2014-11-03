#include "Precompiled.hpp"
#include "MatchMakingRulesResponse.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	MatchmakingRulesResponse_RulesResponded CMatchmakingRulesResponse::rulesResponded = nullptr;
	MatchmakingRulesResponse_RulesFailedToRespond CMatchmakingRulesResponse::rulesFailedToRespond = nullptr;
	MatchmakingRulesResponse_RulesRefreshComplete CMatchmakingRulesResponse::rulesRefreshComplete = nullptr;

	CMatchmakingRulesResponse::CMatchmakingRulesResponse()
	{

	}

	CMatchmakingRulesResponse::~CMatchmakingRulesResponse()
	{

	}

	uptr CMatchmakingRulesResponse::CreateObject()
	{
		CMatchmakingRulesResponse *obj = new CMatchmakingRulesResponse();
		return reinterpret_cast<uptr>(obj);
	}

	void CMatchmakingRulesResponse::DestroyObject(uptr obj)
	{
		CMatchmakingRulesResponse *actualObject = reinterpret_cast<CMatchmakingRulesResponse *>(obj);
		delete actualObject;
	}

	void CMatchmakingRulesResponse::RegisterCallbacks(
		MatchmakingRulesResponse_RulesResponded rulesResponded,
		MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond,
		MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete)
	{
		CMatchmakingRulesResponse::rulesResponded = rulesResponded;
		CMatchmakingRulesResponse::rulesFailedToRespond = rulesFailedToRespond;
		CMatchmakingRulesResponse::rulesRefreshComplete = rulesRefreshComplete;
	}

	void CMatchmakingRulesResponse::RemoveCallbacks()
	{
		rulesResponded = nullptr;
		rulesFailedToRespond = nullptr;
		rulesRefreshComplete = nullptr;
	}

	void CMatchmakingRulesResponse::RulesResponded(const char *key, const char *value)
	{
		// Only send the callback if a receiver is registered
		if (rulesResponded != nullptr)
		{
			rulesResponded(reinterpret_cast<uptr>(this), reinterpret_cast<PConstantDataPointer>(key), reinterpret_cast<PConstantDataPointer>(value));
		}
	}

	void CMatchmakingRulesResponse::RulesFailedToRespond()
	{
		if (rulesFailedToRespond != nullptr)
		{
			rulesFailedToRespond(reinterpret_cast<uptr>(this));
		}
	}

	void CMatchmakingRulesResponse::RulesRefreshComplete()
	{
		if (rulesRefreshComplete != nullptr)
		{
			rulesRefreshComplete(reinterpret_cast<uptr>(this));
		}
	}

}

ManagedSteam_API_Lite uptr MatchmakingRulesResponse_CreateObject()
{
	return CMatchmakingRulesResponse::CreateObject();
}

ManagedSteam_API_Lite void MatchmakingRulesResponse_DestroyObject(uptr obj)
{
	CMatchmakingRulesResponse::DestroyObject(obj);
}

ManagedSteam_API_Lite void MatchmakingRulesResponse_RegisterCallbacks(
	MatchmakingRulesResponse_RulesResponded rulesResponded,
	MatchmakingRulesResponse_RulesFailedToRespond rulesFailedToRespond,
	MatchmakingRulesResponse_RulesRefreshComplete rulesRefreshComplete)
{
	CMatchmakingRulesResponse::RegisterCallbacks(rulesResponded, rulesFailedToRespond, rulesRefreshComplete);
}

ManagedSteam_API_Lite void MatchmakingRulesResponse_RemoveCallbacks()
{
	CMatchmakingRulesResponse::RemoveCallbacks();
}
