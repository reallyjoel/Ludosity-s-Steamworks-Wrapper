#ifndef Matchmaking_h_
#define Matchmaking_h_

#include "MatchMaking.h"
#include "Singleton.hpp"

#include "Services.hpp"

// Types
#include "ConvertedStructures.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

#include "Helper.hpp"

namespace SteamAPIWrap
{
	class CMatchMaking : public CSingleton<CMatchMaking>
	{
		SW_CALLBACK(CMatchMaking, FavoritesListChanged_t, FavoritesListChanged);
		SW_CALLBACK(CMatchMaking, LobbyInvite_t, LobbyInvite);
		SW_ASYNC_RESULT(CMatchMaking, LobbyEnter_t, LobbyEnterResult);
		SW_CALLBACK(CMatchMaking, LobbyDataUpdate_t, LobbyDataUpdate);
		SW_CALLBACK(CMatchMaking, LobbyChatUpdate_t, LobbyChatUpdate);
		SW_CALLBACK(CMatchMaking, LobbyChatMsg_t, LobbyChatMsg);
		SW_CALLBACK(CMatchMaking, LobbyGameCreated_t, LobbyGameCreated);
		SW_ASYNC_RESULT(CMatchMaking, LobbyMatchList_t, LobbyMatchList);
		SW_CALLBACK(CMatchMaking, LobbyKicked_t, LobbyKicked);
		SW_ASYNC_RESULT(CMatchMaking, LobbyCreated_t, LobbyCreated);


		public:
			void SetSteamInterface(ISteamMatchmaking *matchMaking) { this->matchMaking = matchMaking; }
			void RunCallbackSizeCheck();

			s32 GetFavoriteGameCount();
			bool GetFavoriteGame(s32 game, u32 *appID, u32 *ip, u16 *connPort, u16 *port, u32 *flags, u32 *time32LastPlayedOnServer );
			s32 AddFavoriteGame( u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags, u32 time32LastPlayedOnServer );
			bool RemoveFavoriteGame( u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags );
			void RequestLobbyList();
			void AddRequestLobbyListStringFilter(PConstantString keyToMatch, PConstantString valueToMatch, Enum comparisonType);
			void AddRequestLobbyListNumericalFilter(PConstantString keyToMatch, s32 valueToMatch, Enum comparisonType);
			void AddRequestLobbyListNearValueFilter(PConstantString keyToMatch, s32 valueToBeCloseTo);
			void AddRequestLobbyListFilterSlotsAvailable( s32 slotsAvailable );
			void AddRequestLobbyListDistanceFilter(Enum lobbyDistanceFilter);
			void AddRequestLobbyListResultCountFilter(s32 maxResults);
			void AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby);
			SteamID GetLobbyByIndex(s32 lobby);
			void CreateLobby(Enum lobbyType, s32 maxMembers);
			void JoinLobby(SteamID steamIDLobby);
			void LeaveLobby(SteamID steamIDLobby);
			bool InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee);
			s32 GetNumLobbyMembers(SteamID steamIDLobby);
			SteamID GetLobbyMemberByIndex(SteamID steamIDLobby, s32 member);
			PConstantString GetLobbyData(SteamID steamIDLobby, PConstantString key);
			bool SetLobbyData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue);
			s32 GetLobbyDataCount(SteamID steamIDLobby);
			bool GetLobbyDataByIndex(SteamID steamIDLobby, s32 lobbyData, PString key, s32 keyBufferSize, PString returnValue, s32 valueBufferSize);
			bool DeleteLobbyData(SteamID steamIDLobby, PConstantString key);
			PConstantString GetLobbyMemberData(SteamID steamIDLobby, SteamID steamIDUser, PConstantString key);
			void SetLobbyMemberData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue);

			bool SendLobbyChatMsg(SteamID steamIDLobby, PConstantDataPointer msg, s32 cubMsg);
			s32 GetLobbyChatEntry( SteamID steamIDLobby, s32 chatID, SteamID *steamIDUser, PDataPointer data, s32 cubData, Enum *chatEntryType );
			bool RequestLobbyData(SteamID steamIDLobby);

			void SetLobbyGameServer(SteamID steamIDLobby, u32 gameServerIP, u16 gameServerPort, SteamID steamIDGameServer);
			bool GetLobbyGameServer(SteamID steamIDLobby, u32 *gameServerIP, u16 *gameServerPort, SteamID *steamIDGameServer);
			bool SetLobbyMemberLimit(SteamID steamIDLobby, s32 maxMembers);
			s32 GetLobbyMemberLimit(SteamID steamIDLobby);
			bool SetLobbyType(SteamID steamIDLobby, Enum lobbyType);
			bool SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable);
			SteamID GetLobbyOwner(SteamID steamIDLobby);
			bool SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner);
			bool SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent);
		

		private:
			friend class CSingleton<CMatchMaking>;
			CMatchMaking();
			~CMatchMaking() {}
			DISALLOW_COPY_AND_ASSIGN(CMatchMaking);

			ISteamMatchmaking *matchMaking;
	};

}

#endif // MatchMaking_h_