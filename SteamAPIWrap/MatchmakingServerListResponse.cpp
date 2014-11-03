#include "Precompiled.hpp"
#include "MatchmakingServerListResponse.hpp"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	MatchmakingServerListResponse_ServerRespondedCallback CMatchmakingServerListResponse::serverResponded = nullptr;
	MatchmakingServerListResponse_ServerFailedToRespond CMatchmakingServerListResponse::serverFailedToRespond = nullptr;
	MatchmakingServerListResponse_RefreshComplete CMatchmakingServerListResponse::refreshComplete = nullptr;

	CMatchmakingServerListResponse::CMatchmakingServerListResponse()
	{

	}

	CMatchmakingServerListResponse::~CMatchmakingServerListResponse()
	{

	}

	uptr CMatchmakingServerListResponse::CreateObject()
	{
		CMatchmakingServerListResponse *obj = new CMatchmakingServerListResponse();
		return reinterpret_cast<uptr>(obj);
	}



	void CMatchmakingServerListResponse::DestroyObject(uptr obj)
	{
		CMatchmakingServerListResponse *actualObject = reinterpret_cast<CMatchmakingServerListResponse *>(obj);
		delete actualObject;
	}

	void CMatchmakingServerListResponse::RegisterCallbacks(
		MatchmakingServerListResponse_ServerRespondedCallback serverResponded, 
		MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond, 
		MatchmakingServerListResponse_RefreshComplete refreshComplete)
	{
		CMatchmakingServerListResponse::serverResponded = serverResponded;
		CMatchmakingServerListResponse::serverFailedToRespond = serverFailedToRespond;
		CMatchmakingServerListResponse::refreshComplete = refreshComplete;
	}

	void CMatchmakingServerListResponse::RemoveCallbacks()
	{
		serverResponded = nullptr;
		serverFailedToRespond = nullptr;
		refreshComplete = nullptr;
	}

	void CMatchmakingServerListResponse::ServerResponded(HServerListRequest request, int server)
	{
		// Only send the callback if a receiver is registered
		if (serverResponded != nullptr)
		{
			serverResponded(reinterpret_cast<uptr>(this), reinterpret_cast<uptr>(request), server);
		}
	}

	void CMatchmakingServerListResponse::ServerFailedToRespond(HServerListRequest request, int server)
	{
		if (serverFailedToRespond != nullptr)
		{
			serverFailedToRespond(reinterpret_cast<uptr>(this), reinterpret_cast<uptr>(request), server);
		}
	}

	void CMatchmakingServerListResponse::RefreshComplete(HServerListRequest request, EMatchMakingServerResponse response)
	{
		if (refreshComplete != nullptr)
		{
			refreshComplete(reinterpret_cast<uptr>(this), reinterpret_cast<uptr>(request), response);
		}
	}

}

ManagedSteam_API_Lite uptr MatchmakingServerListResponse_CreateObject()
{
	return CMatchmakingServerListResponse::CreateObject();
}

ManagedSteam_API_Lite void MatchmakingServerListResponse_DestroyObject(uptr obj)
{
	CMatchmakingServerListResponse::DestroyObject(obj);
}

ManagedSteam_API_Lite void MatchmakingServerListResponse_RegisterCallbacks(
	MatchmakingServerListResponse_ServerRespondedCallback serverResponded, 
	MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond, 
	MatchmakingServerListResponse_RefreshComplete refreshComplete)
{
	CMatchmakingServerListResponse::RegisterCallbacks(serverResponded, serverFailedToRespond, refreshComplete);
}

ManagedSteam_API_Lite void MatchmakingServerListResponse_RemoveCallbacks()
{
	CMatchmakingServerListResponse::RemoveCallbacks();
}