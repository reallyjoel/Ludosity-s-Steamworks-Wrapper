#include "Precompiled.hpp"
#include "MatchMaking.hpp"

#include "OverlayDialog.hpp"
#include "OverlayDialogToUser.hpp"

#include "MemoryHelpers.h"

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CMatchMaking * CSingleton<CMatchMaking>::instance = nullptr;

	CMatchMaking::CMatchMaking() 
		: nativeLobbyChatMsgCallback(this, &CMatchMaking::OnLobbyChatMsg)
		, nativeFavoritesListChangedCallback(this, &CMatchMaking::OnFavoritesListChanged)
		, nativeLobbyInviteCallback(this, &CMatchMaking::OnLobbyInvite)
		, nativeLobbyDataUpdateCallback(this, &CMatchMaking::OnLobbyDataUpdate )
		, nativeLobbyChatUpdateCallback(this, &CMatchMaking::OnLobbyChatUpdate )
		, nativeLobbyGameCreatedCallback(this, &CMatchMaking::OnLobbyGameCreated )
		, nativeLobbyKickedCallback(this, &CMatchMaking::OnLobbyKicked )
		, matchMaking(nullptr)
	{

	}

	void CMatchMaking::RunCallbackSizeCheck()
	{
		LobbyChatMsg_t* lobbyChatMsg = new LobbyChatMsg_t();
		OnLobbyChatMsg(lobbyChatMsg);
		delete lobbyChatMsg;

		FavoritesListChanged_t* favoritesListChanged = new FavoritesListChanged_t();
		OnFavoritesListChanged(favoritesListChanged);
		delete favoritesListChanged;

		LobbyInvite_t* lobbyInvite = new LobbyInvite_t();
		OnLobbyInvite(lobbyInvite);
		delete lobbyInvite;

		LobbyDataUpdate_t* lobbyDataUpdate = new LobbyDataUpdate_t();
		OnLobbyDataUpdate(lobbyDataUpdate);
		delete lobbyDataUpdate;

		LobbyChatUpdate_t* lobbyChatUpdate = new LobbyChatUpdate_t();
		OnLobbyChatUpdate(lobbyChatUpdate);
		delete lobbyChatUpdate;

		LobbyGameCreated_t* lobbyGameCreated = new LobbyGameCreated_t();
		OnLobbyGameCreated(lobbyGameCreated);
		delete lobbyGameCreated;

		LobbyKicked_t* lobbyKicked = new LobbyKicked_t();
		OnLobbyKicked(lobbyKicked);
		delete lobbyKicked;

        LobbyEnter_t* lobbyEnter = new LobbyEnter_t();
		OnLobbyEnterResult(lobbyEnter, false);
        delete lobbyEnter;

		LobbyMatchList_t* lobbyMatchList = new LobbyMatchList_t();
		OnLobbyMatchList(lobbyMatchList, false);
		delete lobbyMatchList;

		LobbyCreated_t* lobbyCreated = new LobbyCreated_t();
		OnLobbyCreated(lobbyCreated, false);
		delete lobbyCreated;
	}

	int CMatchMaking::GetFavoriteGameCount()
	{
		return matchMaking->GetFavoriteGameCount();
	}

	bool CMatchMaking::GetFavoriteGame(int game, u32 *appID, u32 *ip, u16 *connPort, u16 *Port, u32 *flags, u32 *time32LastPlayedOnServer )
	{
		return matchMaking->GetFavoriteGame(game, appID, ip, connPort, Port, flags, time32LastPlayedOnServer);
	}

	int CMatchMaking::AddFavoriteGame( u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags, u32 rtime32LastPlayedOnServer )
	{
		return matchMaking->AddFavoriteGame(appID, ip, connPort, queryPort, flags, rtime32LastPlayedOnServer);
	}

	bool CMatchMaking::RemoveFavoriteGame(u32 AppId, u32 ip, u16 connPort, u16 QueryPort, u32 flags)
	{
		return matchMaking->RemoveFavoriteGame(AppId,ip, connPort,QueryPort,flags);

	}

	void CMatchMaking::RequestLobbyList()
	{
		resultLobbyMatchList.Set(matchMaking->RequestLobbyList(), this, &CMatchMaking::OnLobbyMatchList);
	}

	void CMatchMaking::AddRequestLobbyListStringFilter(PConstantString keyToMatch, PConstantString valueToMatch, Enum comparisonType)
	{
		matchMaking->AddRequestLobbyListStringFilter(keyToMatch, valueToMatch, static_cast<ELobbyComparison>(comparisonType));
	
	}

	void CMatchMaking::AddRequestLobbyListNearValueFilter( PConstantString keyToMatch, int ValueToBeCloseTo )
	{
		matchMaking->AddRequestLobbyListNearValueFilter(keyToMatch, ValueToBeCloseTo);
	}


	void CMatchMaking::AddRequestLobbyListNumericalFilter( PConstantString keyToMatch, int valueToMatch, Enum comparisonType )
	{
		matchMaking->AddRequestLobbyListNumericalFilter(keyToMatch,valueToMatch,static_cast<ELobbyComparison>(comparisonType));
	}

	void CMatchMaking::AddRequestLobbyListFilterSlotsAvailable( int SlotsAvailable )
	{
		matchMaking->AddRequestLobbyListFilterSlotsAvailable(SlotsAvailable);
	}

	void CMatchMaking::AddRequestLobbyListDistanceFilter( Enum lobbyDistanceFilter )
	{
		matchMaking->AddRequestLobbyListDistanceFilter(static_cast<ELobbyDistanceFilter>(lobbyDistanceFilter));
	}

	void CMatchMaking::AddRequestLobbyListResultCountFilter( int MaxResults )
	{
		matchMaking->AddRequestLobbyListResultCountFilter(MaxResults);
	}

	void CMatchMaking::AddRequestLobbyListCompatibleMembersFilter( SteamID steamIDLobby )
	{
		matchMaking->AddRequestLobbyListCompatibleMembersFilter(SteamID(steamIDLobby));
	}

	SteamID CMatchMaking::GetLobbyByIndex( int lobby )
	{
		return matchMaking->GetLobbyByIndex(lobby).ConvertToUint64();
	}

	void CMatchMaking::CreateLobby( Enum lobbyType, int maxMembers )
	{
		resultLobbyCreated.Set(matchMaking->CreateLobby(static_cast<ELobbyType>(lobbyType),maxMembers), this, &CMatchMaking::OnLobbyCreated);
	}

	void CMatchMaking::JoinLobby( SteamID steamIDLobby )
	{
		resultLobbyEnterResult.Set(matchMaking->JoinLobby(SteamID(steamIDLobby)),this, &CMatchMaking::OnLobbyEnterResult);

	}

	void CMatchMaking::LeaveLobby(SteamID steamIDLobby)
	{
		matchMaking->LeaveLobby(SteamID(steamIDLobby));
	}

	bool CMatchMaking::InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee)
	{
		return matchMaking->InviteUserToLobby(SteamID(steamIDLobby),SteamID(steamIDInvitee));
	}

	int CMatchMaking::GetNumLobbyMembers(SteamID steamIDLobby)
	{
		return matchMaking->GetNumLobbyMembers(SteamID(steamIDLobby));
	}

	SteamID CMatchMaking::GetLobbyMemberByIndex(SteamID steamIDLobby, int member)
	{
		return matchMaking->GetLobbyMemberByIndex(SteamID(steamIDLobby),member).ConvertToUint64();
	}

	PConstantString CMatchMaking::GetLobbyData(SteamID steamIDLobby, PConstantString key)
	{
		return matchMaking->GetLobbyData(SteamID(steamIDLobby), key);
	}

	bool CMatchMaking::SetLobbyData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue)
	{
		return matchMaking->SetLobbyData(SteamID(steamIDLobby),key,returnValue);
	}

	int CMatchMaking::GetLobbyDataCount(SteamID steamIDLobby)
	{
		return matchMaking->GetLobbyDataCount(SteamID(steamIDLobby));
	}

	bool CMatchMaking::GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData, PString key, int keyBufferSize, PString returnValue, int valueBufferSize)
	{
		return matchMaking->GetLobbyDataByIndex(SteamID(steamIDLobby),lobbyData,key,keyBufferSize,returnValue,valueBufferSize);
	}

	bool CMatchMaking::DeleteLobbyData(SteamID steamIDLobby, PConstantString key)
	{
		return matchMaking->DeleteLobbyData(SteamID(steamIDLobby),key);
	}

	PConstantString CMatchMaking::GetLobbyMemberData(SteamID steamIDLobby, SteamID steamIDUser, PConstantString key)
	{
		return matchMaking->GetLobbyMemberData(SteamID(steamIDLobby),SteamID(steamIDUser), key);
	}

	void CMatchMaking::SetLobbyMemberData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue)
	{
		matchMaking->SetLobbyMemberData(SteamID(steamIDLobby),key,returnValue);
	}

	bool CMatchMaking::SendLobbyChatMsg(SteamID steamIDLobby, PConstantDataPointer msg, int cubMsg)
	{
		return matchMaking->SendLobbyChatMsg(SteamID(steamIDLobby), msg, cubMsg);
		
	
	}

	int CMatchMaking::GetLobbyChatEntry( SteamID steamIDLobby, int chatID, SteamID *steamIDUser, PDataPointer data, int cubData, Enum *chatEntryType )
	{
		CSteamID id;
		int results =  matchMaking->GetLobbyChatEntry(steamIDLobby,chatID,&id,data,cubData,reinterpret_cast<EChatEntryType *>(chatEntryType));
		*steamIDUser = id.ConvertToUint64();
		return results;
	}

	void CMatchMaking::SetLobbyGameServer(SteamID steamIDLobby, u32 gameServerIP, u16 gameServerPort, SteamID steamIDGameServer)
	{
		matchMaking->SetLobbyGameServer((SteamID)steamIDLobby,gameServerIP,gameServerPort,SteamID(steamIDGameServer));
	}

	bool CMatchMaking::GetLobbyGameServer(SteamID steamIDLobby, u32 *gameServerIP, u16 *gameServerPort, SteamID *steamIDGameServer)
	{
		CSteamID id;
		bool results = matchMaking->GetLobbyGameServer(SteamID(steamIDLobby),gameServerIP,gameServerPort,&id);
		*steamIDGameServer = id.ConvertToUint64();
		return results;
	}

	bool CMatchMaking::SetLobbyMemberLimit( SteamID steamIDLobby, int maxMembers )
	{
		return matchMaking->SetLobbyMemberLimit((SteamID)steamIDLobby,maxMembers);
	}

	int CMatchMaking::GetLobbyMemberLimit( SteamID steamIDLobby )
	{
		return matchMaking->GetLobbyMemberLimit((SteamID)steamIDLobby);
	}

	bool CMatchMaking::SetLobbyType( SteamID steamIDLobby,Enum lobbyType )
	{
		return matchMaking->SetLobbyType(steamIDLobby,static_cast<ELobbyType>(lobbyType));
	}

	bool CMatchMaking::SetLobbyJoinable( SteamID steamIDLobby, bool lobbyJoinable )
	{
		return matchMaking->SetLobbyJoinable(steamIDLobby,lobbyJoinable);
	}

	SteamID CMatchMaking::GetLobbyOwner( SteamID steamIDLobby )
	{
		return matchMaking->GetLobbyOwner((SteamID)steamIDLobby).ConvertToUint64();
	}

	bool CMatchMaking::SetLobbyOwner( SteamID steamIDLobby, SteamID steamIDNewOwner )
	{
		return matchMaking->SetLobbyOwner((SteamID)steamIDLobby, (SteamID)steamIDNewOwner);
	}

	bool CMatchMaking::SetLinkedLobby( SteamID steamIDLobby, SteamID steamIDLobbyDependent )
	{
		return matchMaking->SetLinkedLobby((SteamID)steamIDLobby,(SteamID)steamIDLobbyDependent);
	}

	bool CMatchMaking::RequestLobbyData( SteamID steamIDLobby )
	{
		return matchMaking->RequestLobbyData((SteamID)steamIDLobby);
	}




}

	ManagedSteam_API s32 MatchMaking_GetFavoriteGameCount()
	{
		return CMatchMaking::Instance().GetFavoriteGameCount();
	}

	ManagedSteam_API bool MatchMaking_GetFavoriteGame(int game, u32 *appID, u32 *ip, u16 *connPort, u16 *Port, u32 *flags, u32 *time32LastPlayedOnServer )
	{
		return CMatchMaking::Instance().GetFavoriteGame(game,appID,ip, connPort,Port,flags,time32LastPlayedOnServer);
	}

	ManagedSteam_API int MatchMaking_AddFavoriteGame(u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags, u32 time32LastPlayedOnServer )
	{
		return CMatchMaking::Instance().AddFavoriteGame(appID,ip,connPort,queryPort,flags,time32LastPlayedOnServer);
	}

	ManagedSteam_API bool MatchMaking_RemoveFavoriteGame( u32 appID, u32 ip, u16 connPort, u16 queryPort, u32 flags )
	{
		return CMatchMaking::Instance().RemoveFavoriteGame(appID,ip,connPort,queryPort, flags);
	}

	ManagedSteam_API void MatchMaking_RequestLobbyList()
	{
		CMatchMaking::Instance().RequestLobbyList();
	}

	
	ManagedSteam_API void MatchMaking_AddRequestLobbyListStringFilter(PConstantString keyToMatch, PConstantString valueToMatch, Enum comparisonType)
	{
		CMatchMaking::Instance().AddRequestLobbyListStringFilter(keyToMatch, valueToMatch, comparisonType);
	}

	ManagedSteam_API void MatchMaking_AddRequestLobbyListNumericalFilter(PConstantString keyToMatch, int valueToMatch, Enum comparisonType)
	{
		CMatchMaking::Instance().AddRequestLobbyListNumericalFilter(keyToMatch, valueToMatch, comparisonType);
	}
	
	ManagedSteam_API void MatchMaking_AddRequestLobbyListNearValueFilter(PConstantString keyToMatch, int ValueToBeCloseTo)
	{
		CMatchMaking::Instance().AddRequestLobbyListNearValueFilter(keyToMatch,ValueToBeCloseTo);
	}

	ManagedSteam_API void MatchMaking_AddRequestLobbyListFilterSlotsAvailable( int slotsAvailable )
	{
		CMatchMaking::Instance().AddRequestLobbyListFilterSlotsAvailable(slotsAvailable);
	}

	ManagedSteam_API void MatchMaking_AddRequestLobbyListDistanceFilter(Enum lobbyDistanceFilter)
	{
		CMatchMaking::Instance().AddRequestLobbyListDistanceFilter(lobbyDistanceFilter);
	}

	ManagedSteam_API void MatchMaking_AddRequestLobbyListResultCountFilter(int maxDistance)
	{
		CMatchMaking::Instance().AddRequestLobbyListResultCountFilter(maxDistance);
	}

	ManagedSteam_API void MatchMaking_AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby)
	{
		CMatchMaking::Instance().AddRequestLobbyListCompatibleMembersFilter(steamIDLobby);
	}

	ManagedSteam_API SteamID MatchMaking_GetLobbyByIndex(int lobby)
	{
		return CMatchMaking::Instance().GetLobbyByIndex(lobby);
	}

	ManagedSteam_API void MatchMaking_CreateLobby(Enum lobbyType, int maxMembers)
	{
		CMatchMaking::Instance().CreateLobby(lobbyType, maxMembers);
	}

	ManagedSteam_API void MatchMaking_JoinLobby(SteamID steamIDLobby)
	{
		CMatchMaking::Instance().JoinLobby(steamIDLobby);
	}

	ManagedSteam_API void MatchMaking_LeaveLobby(SteamID steamIDLobby)
	{
		CMatchMaking::Instance().LeaveLobby(steamIDLobby);
	}

	ManagedSteam_API bool MatchMaking_InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee)
	{
		return CMatchMaking::Instance().InviteUserToLobby(steamIDLobby,steamIDInvitee);
	}

	ManagedSteam_API int MatchMaking_GetNumLobbyMembers(SteamID steamIDLobby)
	{
		return CMatchMaking::Instance().GetNumLobbyMembers(steamIDLobby);
	}

	ManagedSteam_API SteamID MatchMaking_GetLobbyMemberByIndex(SteamID steamIDLobby, int member)
	{
		return CMatchMaking::Instance().GetLobbyMemberByIndex(steamIDLobby,member);
	}

	ManagedSteam_API PConstantString MatchMaking_GetLobbyData(SteamID steamIDLobby, PConstantString key)
	{
		return CMatchMaking::Instance().GetLobbyData(steamIDLobby, key);
	}

	ManagedSteam_API bool MatchMaking_SetLobbyData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue)
	{
		return CMatchMaking::Instance().SetLobbyData(steamIDLobby,key,returnValue);
	}

	ManagedSteam_API int MatchMaking_GetLobbyDataCount(SteamID steamIDLobby)
	{
		return CMatchMaking::Instance().GetLobbyDataCount(steamIDLobby);
	}

	ManagedSteam_API bool MatchMaking_GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData, PString key, int keyBufferSize, PString returnValue, int valueBufferSize)
	{
		return CMatchMaking::Instance().GetLobbyDataByIndex(steamIDLobby,lobbyData,key,keyBufferSize,returnValue,valueBufferSize);
	}

	ManagedSteam_API bool MatchMaking_DeleteLobbyData(SteamID steamIDLobby, PConstantString key)
	{
		return CMatchMaking::Instance().DeleteLobbyData(steamIDLobby, key);
	}

	ManagedSteam_API PConstantString MatchMaking_GetLobbyMemberData(SteamID steamIDLobby, SteamID SteamIDUser, PConstantString key)
	{
		return CMatchMaking::Instance().GetLobbyMemberData(steamIDLobby,SteamIDUser,key);
	}

	ManagedSteam_API void MatchMaking_SetLobbyMemberData(SteamID steamIDLobby, PConstantString key, PConstantString returnValue)
	{
		CMatchMaking::Instance().SetLobbyMemberData(steamIDLobby,key,returnValue);
	}


	ManagedSteam_API bool MatchMaking_SendLobbyChatMsg(SteamID steamIDLobby, PConstantDataPointer msg, int cubMsg)
	{
		return CMatchMaking::Instance().SendLobbyChatMsg(steamIDLobby,msg,cubMsg);
	}

	ManagedSteam_API int MatchMaking_GetLobbyChatEntry( SteamID steamIDLobby, int chatID, SteamID *steamIDUser, PDataPointer data, int cubData, Enum *entryType )
	{
		return CMatchMaking::Instance().GetLobbyChatEntry(steamIDLobby,chatID,steamIDUser,data,cubData,entryType);
	}


	ManagedSteam_API void MatchMaking_SetLobbyGameServer(SteamID steamIDLobby, u32 gameServerIP, u16 gameServerPort, SteamID steamIDGameServer)
	{
		CMatchMaking::Instance().SetLobbyGameServer(steamIDLobby,gameServerIP,gameServerPort,steamIDGameServer);
	}

	ManagedSteam_API bool MatchMaking_GetLobbyGameServer(SteamID steamIDLobby, u32 *gameServerIP, u16 *gameServerPort, SteamID *steamIDGameServer)
	{
		return CMatchMaking::Instance().GetLobbyGameServer(steamIDLobby,gameServerIP,gameServerPort,steamIDGameServer);
	}

	ManagedSteam_API bool MatchMaking_SetLobbyMemberLimit(SteamID steamIDLobby, int maxMembers)
	{
		return CMatchMaking::Instance().SetLobbyMemberLimit(steamIDLobby,maxMembers);
	}

	ManagedSteam_API int MatchMaking_GetLobbyMemberLimit(SteamID steamIDLobby)
	{
		return CMatchMaking::Instance().GetLobbyMemberLimit(steamIDLobby);
	}

	ManagedSteam_API bool MatchMaking_SetLobbyType(SteamID steamIDLobby, Enum lobbyType)
	{
		return CMatchMaking::Instance().SetLobbyType(steamIDLobby,lobbyType);
	}

	ManagedSteam_API bool MatchMaking_SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable)
	{
		return CMatchMaking::Instance().SetLobbyJoinable(steamIDLobby,lobbyJoinable);
	}

	ManagedSteam_API SteamID MatchMaking_GetLobbyOwner(SteamID steamIDLobby)
	{
		return CMatchMaking::Instance().GetLobbyOwner(steamIDLobby);
	}

	ManagedSteam_API bool MatchMaking_SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner)
	{
		return CMatchMaking::Instance().SetLobbyOwner(steamIDLobby,steamIDNewOwner);
	}

	ManagedSteam_API bool MatchMaking_SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent)
	{
		return CMatchMaking::Instance().SetLinkedLobby(steamIDLobby,steamIDLobbyDependent);
	}

	ManagedSteam_API bool MatchMaking_RequestLobbyData( SteamID steamIDLobby )
	{
		return CMatchMaking::Instance().RequestLobbyData(steamIDLobby);
	}


