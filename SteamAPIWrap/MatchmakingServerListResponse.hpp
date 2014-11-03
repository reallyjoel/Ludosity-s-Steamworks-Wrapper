#ifndef MatchmakingServerListResponse_h_
#define MatchmakingServerListResponse_h_

#include "MatchmakingServerListResponse.h"

namespace SteamAPIWrap
{
	class CMatchmakingServerListResponse : public ISteamMatchmakingServerListResponse
	{
	public:

		// We convert some pointers to regular integers as it makes it easier on the managed side.
		//SW_STATIC_ASSERT(sizeof(PDataPointer) == sizeof(uptr));

		static uptr CreateObject();

		static void DestroyObject(uptr obj);

		static void RegisterCallbacks(MatchmakingServerListResponse_ServerRespondedCallback serverResponded, MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond, MatchmakingServerListResponse_RefreshComplete refreshComplete);

		static void RemoveCallbacks();

		// Server has responded ok with updated data
		virtual void ServerResponded(HServerListRequest request, int server);

		// Server has failed to respond
		virtual void ServerFailedToRespond(HServerListRequest request, int server);

		// A list refresh you had initiated is now 100% completed
		virtual void RefreshComplete(HServerListRequest request, EMatchMakingServerResponse response);

	private:
		CMatchmakingServerListResponse();
		~CMatchmakingServerListResponse();
		DISALLOW_COPY_AND_ASSIGN(CMatchmakingServerListResponse);

		static MatchmakingServerListResponse_ServerRespondedCallback serverResponded;
		static MatchmakingServerListResponse_ServerFailedToRespond serverFailedToRespond;
		static MatchmakingServerListResponse_RefreshComplete refreshComplete;
	};
}

#endif // MatchmakingServerListResponse_h_
