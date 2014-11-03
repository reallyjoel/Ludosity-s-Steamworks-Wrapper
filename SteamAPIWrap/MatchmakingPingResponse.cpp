#include "Precompiled.hpp"
#include "MatchmakingPingResponse.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	MatchmakingPingResponse_ServerRespondedCallback CMatchmakingPingResponse::serverResponded = nullptr;
	MatchmakingPingResponse_ServerFailedToRespond CMatchmakingPingResponse::serverFailedToRespond = nullptr;

	CMatchmakingPingResponse::CMatchmakingPingResponse()
	{

	}

	CMatchmakingPingResponse::~CMatchmakingPingResponse()
	{

	}

	uptr CMatchmakingPingResponse::CreateObject()
	{
		CMatchmakingPingResponse *obj = new CMatchmakingPingResponse();
		return reinterpret_cast<uptr>(obj);
	}

	void CMatchmakingPingResponse::DestroyObject(uptr obj)
	{
		CMatchmakingPingResponse *actualObject = reinterpret_cast<CMatchmakingPingResponse *>(obj);
		delete actualObject;
	}

	void CMatchmakingPingResponse::RegisterCallbacks(
		MatchmakingPingResponse_ServerRespondedCallback serverResponded, 
		MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond) 
	{
		CMatchmakingPingResponse::serverResponded = serverResponded;
		CMatchmakingPingResponse::serverFailedToRespond = serverFailedToRespond;
	}

	void CMatchmakingPingResponse::RemoveCallbacks()
	{
		serverResponded = nullptr;
		serverFailedToRespond = nullptr;
	}

	void CMatchmakingPingResponse::ServerResponded(gameserveritem_t &server)
	{
		// Only send the callback if a receiver is registered
		if (serverResponded != nullptr)
		{
			serverResponded(reinterpret_cast<uptr>(this), &server, sizeof(gameserveritem_t));
		}
	}

	void CMatchmakingPingResponse::ServerFailedToRespond()
	{
		if (serverFailedToRespond != nullptr)
		{
			serverFailedToRespond(reinterpret_cast<uptr>(this));
		}
	}


}

ManagedSteam_API_Lite uptr MatchmakingPingResponse_CreateObject()
{
	return CMatchmakingPingResponse::CreateObject();
}

ManagedSteam_API_Lite void MatchmakingPingResponse_DestroyObject(uptr obj)
{
	CMatchmakingPingResponse::DestroyObject(obj);
}

ManagedSteam_API_Lite void MatchmakingPingResponse_RegisterCallbacks(
	MatchmakingPingResponse_ServerRespondedCallback serverResponded, 
	MatchmakingPingResponse_ServerFailedToRespond serverFailedToRespond) 
{
	CMatchmakingPingResponse::RegisterCallbacks(serverResponded, serverFailedToRespond);
}

ManagedSteam_API_Lite void MatchmakingPingResponse_RemoveCallbacks()
{
	CMatchmakingPingResponse::RemoveCallbacks();
}