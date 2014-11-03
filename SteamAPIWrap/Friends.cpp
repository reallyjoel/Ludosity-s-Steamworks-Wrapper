#include "Precompiled.hpp"
#include "Friends.hpp"

#include "OverlayDialog.hpp"
#include "OverlayDialogToUser.hpp"

#include "MemoryHelpers.h"
#include <fstream>

using namespace SteamAPIWrap;

namespace SteamAPIWrap
{
	template <> CFriends * CSingleton<CFriends>::instance = nullptr;

	
	CFriends::CFriends()
		: nativePersonaStateChangeCallback(this, &CFriends::OnPersonaStateChange)
		, nativeGameOverlayActivatedCallback(this, &CFriends::OnGameOverlayActivated)
		, nativeGameServerChangeRequestedCallback(this, &CFriends::OnGameServerChangeRequested)
		, nativeGameLobbyJoinRequestedCallback(this, &CFriends::OnGameLobbyJoinRequested)
		, nativeAvatarImageLoadedCallback(this, &CFriends::OnAvatarImageLoaded)
		, nativeGameConnectedChatLeaveCallback(this, &CFriends::OnGameConnectedChatLeave)
		, nativeFriendRichPresenceUpdateCallback(this, &CFriends::OnFriendRichPresenceUpdate)
		, nativeGameRichPresenceJoinRequestedCallback(this, &CFriends::OnGameRichPresenceJoinRequested)
		, nativeGameConnectedClanChatMsgCallback(this, &CFriends::OnGameConnectedClanChatMsg)
		, nativeGameConnectedChatJoinCallback(this, &CFriends::OnGameConnectedChatJoin)
		, nativeGameConnectedFriendChatMsgCallback(this, &CFriends::OnGameConnectedFriendChatMsg)
		, friends(nullptr)
	{

	}

	void CFriends::SetSteamInterface(ISteamFriends *friends)
	{
		this->friends = friends;
	}

	void CFriends::RunCallbackSizeCheck()
	{
        PersonaStateChange_t* personaStateChange = new PersonaStateChange_t();
		OnPersonaStateChange(personaStateChange);
        delete personaStateChange;

		GameOverlayActivated_t* gameOverlayActivated = new GameOverlayActivated_t();
		OnGameOverlayActivated(gameOverlayActivated);
		delete gameOverlayActivated;

		GameServerChangeRequested_t* gameServerChangeRequested = new GameServerChangeRequested_t();
		OnGameServerChangeRequested(gameServerChangeRequested);
		delete gameServerChangeRequested;

		GameLobbyJoinRequested_t* gameLobbyJoinRequested = new GameLobbyJoinRequested_t();
		OnGameLobbyJoinRequested(gameLobbyJoinRequested);
		delete gameLobbyJoinRequested;

		AvatarImageLoaded_t* avatarImageLoaded = new AvatarImageLoaded_t();
		OnAvatarImageLoaded(avatarImageLoaded);
		delete avatarImageLoaded;

		GameConnectedChatLeave_t* gameConnectedChatLeave = new GameConnectedChatLeave_t();
		OnGameConnectedChatLeave(gameConnectedChatLeave);
		delete gameConnectedChatLeave;

		FriendRichPresenceUpdate_t* friendRichPresenceUpdate = new FriendRichPresenceUpdate_t();
		OnFriendRichPresenceUpdate(friendRichPresenceUpdate);
		delete friendRichPresenceUpdate;

		GameRichPresenceJoinRequested_t* gameRichPresenceJoinRequested = new GameRichPresenceJoinRequested_t();
		OnGameRichPresenceJoinRequested(gameRichPresenceJoinRequested);
		delete gameRichPresenceJoinRequested;

		GameConnectedClanChatMsg_t* gameConnectedClanChatMsg = new GameConnectedClanChatMsg_t();
		OnGameConnectedClanChatMsg(gameConnectedClanChatMsg);
		delete gameConnectedClanChatMsg;

		GameConnectedChatJoin_t* gameConnectedChatJoin = new GameConnectedChatJoin_t();
		OnGameConnectedChatJoin(gameConnectedChatJoin);
		delete gameConnectedChatJoin;

		GameConnectedFriendChatMsg_t* gameConnectedFriendChatMsg = new GameConnectedFriendChatMsg_t();
		OnGameConnectedFriendChatMsg(gameConnectedFriendChatMsg);
		delete gameConnectedFriendChatMsg;

		ClanOfficerListResponse_t* clanOfficerListResponse = new ClanOfficerListResponse_t();
		OnClanOfficerListResponse(clanOfficerListResponse, false);
		delete clanOfficerListResponse;

		DownloadClanActivityCountsResult_t* downloadClanActivityCountsResult = new DownloadClanActivityCountsResult_t();
		OnDownloadClanActivityCountsResult(downloadClanActivityCountsResult, false);
		delete downloadClanActivityCountsResult;

		JoinClanChatRoomCompletionResult_t* joinClanChatRoomCompletionResult = new JoinClanChatRoomCompletionResult_t();
		OnJoinClanChatRoomCompletionResult(joinClanChatRoomCompletionResult, false);
		delete joinClanChatRoomCompletionResult;

		FriendsGetFollowerCount_t* friendsGetFollowerCount = new FriendsGetFollowerCount_t();
		OnFriendsGetFollowerCount(friendsGetFollowerCount, false);
		delete friendsGetFollowerCount;

		FriendsIsFollowing_t* friendsIsFollowing = new FriendsIsFollowing_t();
		OnFriendsIsFollowing(friendsIsFollowing, false);
		delete friendsIsFollowing;

		FriendsEnumerateFollowingList_t* friendsEnumerateFollowingList = new FriendsEnumerateFollowingList_t();
		OnFriendsEnumerateFollowingList(friendsEnumerateFollowingList, false);
		delete friendsEnumerateFollowingList;
	}

	PConstantUtf8String CFriends::GetPersonaName()
	{
		return friends->GetPersonaName();
	}

	void CFriends::SetPersonaName(PConstantUtf8String personaName)
	{
		friends->SetPersonaName(reinterpret_cast<PConstantString>(personaName));
	}

	Enum CFriends::GetPersonaState()
	{
		return friends->GetPersonaState();
	}

	s32 CFriends::GetFriendCount(Enum friendFlags)
	{
		return friends->GetFriendCount(friendFlags);
	}

	SteamID CFriends::GetFriendByIndex(s32 iFriend, s32 friendFlags)
	{
		return friends->GetFriendByIndex(iFriend, friendFlags).ConvertToUint64();
	}

	Enum CFriends::GetFriendRelationship(SteamID steamIDFriend)
	{
		CSteamID steamId(steamIDFriend);
		return friends->GetFriendRelationship(steamId);
	}

	Enum CFriends::GetFriendPersonaState(SteamID steamIDFriend)
	{
		CSteamID steamId(steamIDFriend);
		return friends->GetFriendPersonaState(steamId);
	}

	PConstantUtf8String CFriends::GetFriendPersonaName(SteamID steamIDFriend)
	{
		CSteamID steamId(steamIDFriend);
		return friends->GetFriendPersonaName(steamId);
	}

	bool CFriends::GetFriendGamePlayed(SteamID steamIDFriend, PDataPointer friendGameInfo)
	{
		CSteamID steamId(steamIDFriend);
		return friends->GetFriendGamePlayed(steamId, reinterpret_cast<FriendGameInfo_t *>(friendGameInfo));
	}

	PConstantUtf8String CFriends::GetFriendPersonaNameHistory(SteamID steamIDFriend, s32 personaName)
	{
		CSteamID steamId(steamIDFriend);
		return friends->GetFriendPersonaNameHistory(steamId, personaName);
	}

	PConstantUtf8String CFriends::GetPlayerNickname(SteamID steamIDPlayer)
	{
		CSteamID steamId(steamIDPlayer);
		return friends->GetPlayerNickname(steamId);
	}

	bool CFriends::HasFriend(SteamID steamIDFriend, s32 friendFlags)
	{
		CSteamID steamId(steamIDFriend);
		return friends->HasFriend(steamId, friendFlags);
	}

	s32 CFriends::GetClanCount()
	{
		return friends->GetClanCount();
	}

	SteamID CFriends::GetClanByIndex(s32 clan)
	{
		return friends->GetClanByIndex(clan).ConvertToUint64();
	}

	PConstantString CFriends::GetClanName(SteamID steamIDClan)
	{
		CSteamID steamId(steamIDClan);
		return friends->GetClanName(steamId);
	}

	PConstantString CFriends::GetClanTag(SteamID steamIDClan)
	{
		CSteamID steamId(steamIDClan);
		return friends->GetClanTag(steamId);
	}

	bool CFriends::GetClanActivityCounts(SteamID steamIDClan, s32 *online, s32 *inGame, s32 *chatting)
	{
		CSteamID steamId(steamIDClan);
		return friends->GetClanActivityCounts(steamId, online, inGame, chatting);
	}

	void CFriends::DownloadClanActivityCounts(PConstantDataPointer steamIDClans, s32 clansToRequest)
	{
		SSteamIDArray ids(reinterpret_cast<const SteamID *>(steamIDClans), clansToRequest);
		resultDownloadClanActivityCountsResult.Set(
			friends->DownloadClanActivityCounts(ids.GetArray(), clansToRequest),
			this, &CFriends::OnDownloadClanActivityCountsResult);
	}

	s32 CFriends::GetFriendCountFromSource(SteamID steamIDSource)
	{
		CSteamID steamId(steamIDSource);
		return friends->GetFriendCountFromSource(steamId);
	}

	SteamID CFriends::GetFriendFromSourceByIndex(SteamID steamIDSource, s32 friendIndex)
	{
		CSteamID steamId(steamIDSource);
		CSteamID resultId = friends->GetFriendFromSourceByIndex(steamId, friendIndex);
		return resultId.ConvertToUint64();
	}

	bool CFriends::IsUserInSource(SteamID steamIDUser, SteamID steamIDSource)
	{
		CSteamID userSteamId(steamIDUser);
		CSteamID sourceSteamId(steamIDSource);
		return friends->IsUserInSource(userSteamId, sourceSteamId);
	}

	void CFriends::SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking)
	{
		CSteamID userSteamId(steamIDUser);
		friends->SetInGameVoiceSpeaking(userSteamId, speaking);
	}

	void CFriends::ActivateGameOverlay(Enum dialogType)
	{
		EOverlayDialog::Enum dialog = static_cast<EOverlayDialog::Enum>(dialogType);
		PConstantString dialogString;
		switch (dialog)
		{
		default:
		case EOverlayDialog::None:
			dialogString = nullptr;
			break;
		case EOverlayDialog::Friends:
			dialogString = "Friends";
			break;
		case EOverlayDialog::Community:
			dialogString = "Community";
			break;
		case EOverlayDialog::Players:
			dialogString = "Players";
			break;
		case EOverlayDialog::Settings:
			dialogString = "Settings";
			break;
		case EOverlayDialog::OfficialGameGroup:
			dialogString = "OfficialGameGroup";
			break;
		case EOverlayDialog::Stats:
			dialogString = "Stats";
			break;
		case EOverlayDialog::Achievements:
			dialogString = "Achievements";
			break;
		}

		friends->ActivateGameOverlay(dialogString);
	}

	void CFriends::ActivateGameOverlayToUser(Enum dialogType, SteamID steamID)
	{
		EOverlayDialogToUser::Enum dialog = static_cast<EOverlayDialogToUser::Enum>(dialogType);
		PConstantString dialogString;
		switch (dialog)
		{
		default:
		case EOverlayDialogToUser::SteamId:
			dialogString = "steamid";
			break;
		case EOverlayDialogToUser::Chat:
			dialogString = "chat";
			break;
		case EOverlayDialogToUser::JoinTrade:
			dialogString = "jointrade";
			break;
		case EOverlayDialogToUser::Stats:
			dialogString = "stats";
			break;
		case EOverlayDialogToUser::Achievements:
			dialogString = "achievements";
			break;
		case EOverlayDialogToUser::FriendAdd:
			dialogString = "friendadd";
			break;
		case EOverlayDialogToUser::FriendRemove:
			dialogString = "friendremove";
			break;
		case EOverlayDialogToUser::FriendRequestAccept:
			dialogString = "friendrequestaccept";
			break;
		case EOverlayDialogToUser::FriendRequestIgnore:
			dialogString = "friendrequestignore";
			break;
		}

		CSteamID userSteamId(steamID);
		friends->ActivateGameOverlayToUser(dialogString, userSteamId);
	}

	void CFriends::ActivateGameOverlayToWebPage(PConstantString url)
	{
		friends->ActivateGameOverlayToWebPage(url);
	}

	void CFriends::ActivateGameOverlayToStore(u32 appID, EOverlayToStoreFlag eFlag)
	{
		friends->ActivateGameOverlayToStore(appID, eFlag);
	}

	void CFriends::SetPlayedWith(SteamID steamIDUserPlayedWith)
	{
		CSteamID userSteamId(steamIDUserPlayedWith);
		friends->SetPlayedWith(userSteamId);
	}

	void CFriends::ActivateGameOverlayInviteDialog(SteamID steamIDLobby)
	{
		CSteamID steamId(steamIDLobby);
		friends->ActivateGameOverlayInviteDialog(steamId);
	}

	s32 CFriends::GetSmallFriendAvatar(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetSmallFriendAvatar(friendId);
	}

	s32 CFriends::GetMediumFriendAvatar(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetMediumFriendAvatar(friendId);
	}

	s32 CFriends::GetLargeFriendAvatar(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetLargeFriendAvatar(friendId);
	}

	bool CFriends::RequestUserInformation(SteamID steamIDUser, bool requireNameOnly)
	{
		CSteamID userId(steamIDUser);
		return friends->RequestUserInformation(userId, requireNameOnly);
	}

	void CFriends::RequestClanOfficerList(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		resultClanOfficerListResponse.Set(friends->RequestClanOfficerList(clanId),
			this, &CFriends::OnClanOfficerListResponse);
	}

	SteamID CFriends::GetClanOwner(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		CSteamID ownerId = friends->GetClanOwner(clanId);
		return ownerId.ConvertToUint64();
	}

	s32 CFriends::GetClanOfficerCount(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		return friends->GetClanOfficerCount(clanId);
	}

	SteamID CFriends::GetClanOfficerByIndex(SteamID steamIDClan, s32 officer)
	{
		CSteamID clanId(steamIDClan);
		CSteamID officerId = friends->GetClanOfficerByIndex(clanId, officer);
		return officerId.ConvertToUint64();
	}

	u32 CFriends::GetUserRestrictions()
	{
		return friends->GetUserRestrictions();
	}

	bool CFriends::SetRichPresence(PConstantString key, PConstantUtf8String value)
	{
		return friends->SetRichPresence(key, reinterpret_cast<PConstantString>(value));
	}

	void CFriends::ClearRichPresence()
	{
		friends->ClearRichPresence();
	}

	PConstantUtf8String CFriends::GetFriendRichPresence(SteamID steamIDFriend, PConstantString key)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendRichPresence(friendId, key);
	}

	s32 CFriends::GetFriendRichPresenceKeyCount(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendRichPresenceKeyCount(friendId);
	}

	PConstantUtf8String CFriends::GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, s32 key)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendRichPresenceKeyByIndex(friendId, key);
	}

	void CFriends::RequestFriendRichPresence(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		friends->RequestFriendRichPresence(friendId);
	}

	bool CFriends::InviteUserToGame(SteamID steamIDFriend, PConstantString connectString)
	{
		CSteamID friendId(steamIDFriend);
		return friends->InviteUserToGame(friendId, connectString);
	}

	s32 CFriends::GetCoplayFriendCount()
	{
		return friends->GetCoplayFriendCount();
	}

	SteamID CFriends::GetCoplayFriend(s32 coplayFriend)
	{
		CSteamID id = friends->GetCoplayFriend(coplayFriend);
		return id.ConvertToUint64();
	}

	s32 CFriends::GetFriendCoplayTime(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendCoplayTime(friendId);
	}

	AppID CFriends::GetFriendCoplayGame(SteamID steamIDFriend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendCoplayGame(friendId);
	}

	void CFriends::JoinClanChatRoom(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		resultJoinClanChatRoomCompletionResult.Set(friends->JoinClanChatRoom(clanId),
			this, &CFriends::OnJoinClanChatRoomCompletionResult);
	}

	bool CFriends::LeaveClanChatRoom(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		return friends->LeaveClanChatRoom(clanId);
	}

	s32 CFriends::GetClanChatMemberCount(SteamID steamIDClan)
	{
		CSteamID clanId(steamIDClan);
		return friends->GetClanChatMemberCount(clanId);
	}

	SteamID CFriends::GetChatMemberByIndex(SteamID steamIDClan, s32 user)
	{
		CSteamID clanId(steamIDClan);
		CSteamID memberId = friends->GetChatMemberByIndex(clanId, user);
		return memberId.ConvertToUint64();
	}

	bool CFriends::SendClanChatMessage(SteamID steamIDClanChat, PConstantUtf8String text)
	{
		CSteamID clanId(steamIDClanChat);
		return friends->SendClanChatMessage(clanId, reinterpret_cast<const char*>(text));
	}

	s32 CFriends::GetClanChatMessage(SteamID steamIDClanChat, s32 message, PUtf8String text, s32 textSize, 
		Enum *chatEntryType, SteamID *sender)
	{
		CSteamID senderId;
		s32 result = friends->GetClanChatMessage(steamIDClanChat, message, text, textSize, 
			reinterpret_cast<EChatEntryType *>(chatEntryType), &senderId);
		*sender = senderId.ConvertToUint64();
		return result;
	}

	bool CFriends::IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser)
	{
		CSteamID clanId(steamIDClanChat);
		CSteamID userId(steamIDUser);
		return friends->IsClanChatAdmin(clanId, userId);
	}

	bool CFriends::IsClanChatWindowOpenInSteam(SteamID steamIDClanChat)
	{
		CSteamID clanId(steamIDClanChat);
		return friends->IsClanChatWindowOpenInSteam(clanId);
	}

	bool CFriends::OpenClanChatWindowInSteam(SteamID steamIDClanChat)
	{
		CSteamID clanId(steamIDClanChat);
		return friends->OpenClanChatWindowInSteam(clanId);
	}

	bool CFriends::CloseClanChatWindowInSteam(SteamID steamIDClanChat)
	{
		CSteamID clanId(steamIDClanChat);
		return friends->CloseClanChatWindowInSteam(clanId);
	}

	bool CFriends::SetListenForFriendsMessages(bool interceptEnabled)
	{
		return friends->SetListenForFriendsMessages(interceptEnabled);
	}

	bool CFriends::ReplyToFriendMessage(SteamID steamIDFriend, PConstantUtf8String msgToSend)
	{
		CSteamID friendId(steamIDFriend);
		return friends->ReplyToFriendMessage(friendId, reinterpret_cast<const char *>(msgToSend));
	}

	s32 CFriends::GetFriendMessage(SteamID steamIDFriend, s32 messageID, PUtf8String text, s32 textSize, 
		Enum *chatEntryType)
	{
		CSteamID friendId(steamIDFriend);
		return friends->GetFriendMessage(friendId, messageID, text, textSize, 
			reinterpret_cast<EChatEntryType *>(chatEntryType));
	}

	void CFriends::GetFollowerCount(SteamID steamID)
	{
		resultFriendsGetFollowerCount.Set(friends->GetFollowerCount(steamID), this, 
			&CFriends::OnFriendsGetFollowerCount);
	}

	void CFriends::IsFollowing(SteamID steamID)
	{
		resultFriendsIsFollowing.Set(friends->IsFollowing(steamID), this, 
			&CFriends::OnFriendsIsFollowing);
	}

	void CFriends::EnumerateFollowingList(u32 startIndex)
	{
		resultFriendsEnumerateFollowingList.Set(friends->EnumerateFollowingList(startIndex), this,
			&CFriends::OnFriendsEnumerateFollowingList);
	}
}

ManagedSteam_API PConstantUtf8String Friends_GetPersonaName()
{
	return CFriends::Instance().GetPersonaName();
}

ManagedSteam_API void Friends_SetPersonaName(PConstantUtf8String personaName)
{
	CFriends::Instance().SetPersonaName(personaName);
}

ManagedSteam_API Enum Friends_GetPersonaState()
{
	return CFriends::Instance().GetPersonaState();
}

ManagedSteam_API s32 Friends_GetFriendCount(Enum friendFlags)
{
	return CFriends::Instance().GetFriendCount(friendFlags);
}

ManagedSteam_API SteamID Friends_GetFriendByIndex(s32 iFriend, s32 friendFlags)
{
	return CFriends::Instance().GetFriendByIndex(iFriend, friendFlags);
}

ManagedSteam_API Enum Friends_GetFriendRelationship(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendRelationship(steamIDFriend);
}

ManagedSteam_API Enum Friends_GetFriendPersonaState(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendPersonaState(steamIDFriend);
}

ManagedSteam_API PConstantUtf8String Friends_GetFriendPersonaName(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendPersonaName(steamIDFriend);
}

ManagedSteam_API bool Friends_GetFriendGamePlayed(SteamID steamIDFriend, PDataPointer friendGameInfo)
{
	return CFriends::Instance().GetFriendGamePlayed(steamIDFriend, friendGameInfo);
}

ManagedSteam_API s32 Friends_GetFriendGameInfoSize()
{
	return sizeof(FriendGameInfo_t);
}

ManagedSteam_API PConstantUtf8String Friends_GetFriendPersonaNameHistory(SteamID steamIDFriend, s32 personaName)
{
	return CFriends::Instance().GetFriendPersonaNameHistory(steamIDFriend, personaName);
}

ManagedSteam_API PConstantUtf8String Friends_GetPlayerNickname(SteamID steamIDPlayer)
{
	return CFriends::Instance().GetPlayerNickname(steamIDPlayer);
}

ManagedSteam_API bool Friends_HasFriend(SteamID steamIDFriend, s32 friendFlags)
{
	return CFriends::Instance().HasFriend(steamIDFriend, friendFlags);
}

ManagedSteam_API s32 Friends_GetClanCount()
{
	return CFriends::Instance().GetClanCount();
}

ManagedSteam_API SteamID Friends_GetClanByIndex(s32 clan)
{
	return CFriends::Instance().GetClanByIndex(clan);
}

ManagedSteam_API PConstantString Friends_GetClanName(SteamID steamIDClan)
{
	return CFriends::Instance().GetClanName(steamIDClan);
}

ManagedSteam_API PConstantString Friends_GetClanTag(SteamID steamIDClan)
{
	return CFriends::Instance().GetClanTag(steamIDClan);
}

ManagedSteam_API bool Friends_GetClanActivityCounts(SteamID steamIDClan, s32 *online, s32 *inGame, s32 *chatting)
{
	return CFriends::Instance().GetClanActivityCounts(steamIDClan, online, inGame, chatting);
}

ManagedSteam_API void Friends_DownloadClanActivityCounts(PConstantDataPointer steamIDClans, s32 clansToRequest)
{
	CFriends::Instance().DownloadClanActivityCounts(steamIDClans, clansToRequest);
}

ManagedSteam_API s32 Friends_GetFriendCountFromSource(SteamID steamIDSource)
{
	return CFriends::Instance().GetFriendCountFromSource(steamIDSource);
}

ManagedSteam_API SteamID Friends_GetFriendFromSourceByIndex(SteamID steamIDSource, s32 friendIndex)
{
	return CFriends::Instance().GetFriendFromSourceByIndex(steamIDSource, friendIndex);
}

ManagedSteam_API bool Friends_IsUserInSource(SteamID steamIDUser, SteamID steamIDSource)
{
	return CFriends::Instance().IsUserInSource(steamIDUser, steamIDSource);
}

ManagedSteam_API void Friends_SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking)
{
	CFriends::Instance().SetInGameVoiceSpeaking(steamIDUser, speaking);
}

ManagedSteam_API void Friends_ActivateGameOverlay(Enum dialogType)
{
	CFriends::Instance().ActivateGameOverlay(dialogType);
}

ManagedSteam_API void Friends_ActivateGameOverlayToUser(Enum dialogType, SteamID steamID)
{
	CFriends::Instance().ActivateGameOverlayToUser(dialogType, steamID);
}

ManagedSteam_API void Friends_ActivateGameOverlayToWebPage(PConstantString url)
{
	CFriends::Instance().ActivateGameOverlayToWebPage(url);
}

ManagedSteam_API void Friends_ActivateGameOverlayToStore(u32 appID, EOverlayToStoreFlag eFlag)
{
	CFriends::Instance().ActivateGameOverlayToStore(appID, eFlag);
}

ManagedSteam_API void Friends_SetPlayedWith(SteamID steamIDUserPlayedWith)
{
	CFriends::Instance().SetPlayedWith(steamIDUserPlayedWith);
}

ManagedSteam_API void Friends_ActivateGameOverlayInviteDialog(SteamID steamIDLobby)
{
	CFriends::Instance().ActivateGameOverlayInviteDialog(steamIDLobby);
}

ManagedSteam_API s32 Friends_GetSmallFriendAvatar(SteamID steamIDFriend)
{
	return CFriends::Instance().GetSmallFriendAvatar(steamIDFriend);
}

ManagedSteam_API s32 Friends_GetMediumFriendAvatar(SteamID steamIDFriend)
{
	return CFriends::Instance().GetMediumFriendAvatar(steamIDFriend);
}

ManagedSteam_API s32 Friends_GetLargeFriendAvatar(SteamID steamIDFriend)
{
	return CFriends::Instance().GetLargeFriendAvatar(steamIDFriend);
}

ManagedSteam_API bool Friends_RequestUserInformation(SteamID steamIDUser, bool requireNameOnly)
{
	return CFriends::Instance().RequestUserInformation(steamIDUser, requireNameOnly);
}

ManagedSteam_API void Friends_RequestClanOfficerList(SteamID steamIDClan)
{
	CFriends::Instance().RequestClanOfficerList(steamIDClan);
}

ManagedSteam_API SteamID Friends_GetClanOwner(SteamID steamIDClan)
{
	return CFriends::Instance().GetClanOwner(steamIDClan);
}

ManagedSteam_API s32 Friends_GetClanOfficerCount(SteamID steamIDClan)
{
	return CFriends::Instance().GetClanOfficerCount(steamIDClan);
}

ManagedSteam_API SteamID Friends_GetClanOfficerByIndex(SteamID steamIDClan, s32 officer)
{
	return CFriends::Instance().GetClanOfficerByIndex(steamIDClan, officer);
}

ManagedSteam_API u32 Friends_GetUserRestrictions()
{
	return CFriends::Instance().GetUserRestrictions();
}

ManagedSteam_API bool Friends_SetRichPresence(PConstantString key, PConstantUtf8String value)
{
	return CFriends::Instance().SetRichPresence(key, value);
}

ManagedSteam_API void Friends_ClearRichPresence()
{
	CFriends::Instance().ClearRichPresence();
}

ManagedSteam_API PConstantUtf8String Friends_GetFriendRichPresence(SteamID steamIDFriend, PConstantString key)
{
	return CFriends::Instance().GetFriendRichPresence(steamIDFriend,key);
}

ManagedSteam_API s32 Friends_GetFriendRichPresenceKeyCount(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendRichPresenceKeyCount(steamIDFriend);
}

ManagedSteam_API PConstantUtf8String Friends_GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, s32 key)
{
	return CFriends::Instance().GetFriendRichPresenceKeyByIndex(steamIDFriend,key);
}

ManagedSteam_API void Friends_RequestFriendRichPresence(SteamID steamIDFriend)
{
	return CFriends::Instance().RequestFriendRichPresence(steamIDFriend);
}

ManagedSteam_API bool Friends_InviteUserToGame(SteamID steamIDFriend, PConstantString connectString)
{
	return CFriends::Instance().InviteUserToGame(steamIDFriend,connectString);
}

ManagedSteam_API s32 Friends_GetCoplayFriendCount()
{
	return CFriends::Instance().GetCoplayFriendCount();
}

ManagedSteam_API SteamID Friends_GetCoplayFriend(s32 coplayFriend)
{
	return CFriends::Instance().GetCoplayFriend(coplayFriend);
}

ManagedSteam_API s32 Friends_GetFriendCoplayTime(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendCoplayTime(steamIDFriend);
}

ManagedSteam_API AppID Friends_GetFriendCoplayGame(SteamID steamIDFriend)
{
	return CFriends::Instance().GetFriendCoplayGame(steamIDFriend);
}

ManagedSteam_API void Friends_JoinClanChatRoom(SteamID steamIDClan)
{
	return CFriends::Instance().JoinClanChatRoom(steamIDClan);
}

ManagedSteam_API bool Friends_LeaveClanChatRoom(SteamID steamIDClan)
{
	return CFriends::Instance().LeaveClanChatRoom(steamIDClan);
}

ManagedSteam_API s32 Friends_GetClanChatMemberCount(SteamID steamIDClan)
{
	return CFriends::Instance().GetClanChatMemberCount(steamIDClan);
}

ManagedSteam_API SteamID Friends_GetChatMemberByIndex(SteamID steamIDClan, s32 user)
{
	return CFriends::Instance().GetChatMemberByIndex(steamIDClan,user);
}

ManagedSteam_API bool Friends_SendClanChatMessage(SteamID steamIDClanChat, PConstantUtf8String text)
{
	return CFriends::Instance().SendClanChatMessage(steamIDClanChat,text);
}

ManagedSteam_API s32 Friends_GetClanChatMessage(SteamID steamIDClanChat, s32 message, PUtf8String text, s32 textSize, Enum *chatEntryType, SteamID *sender)
{
	return CFriends::Instance().GetClanChatMessage(steamIDClanChat, message,text,textSize,chatEntryType,sender);
}

ManagedSteam_API bool Friends_IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser)
{
	return CFriends::Instance().IsClanChatAdmin(steamIDClanChat, steamIDUser);
}

ManagedSteam_API bool Friends_IsClanChatWindowOpenInSteam(SteamID steamIDClanChat)
{
	return CFriends::Instance().IsClanChatWindowOpenInSteam(steamIDClanChat);
}

ManagedSteam_API bool Friends_OpenClanChatWindowInSteam(SteamID steamIDClanChat)
{
	return CFriends::Instance().OpenClanChatWindowInSteam(steamIDClanChat);
}

ManagedSteam_API bool Friends_CloseClanChatWindowInSteam(SteamID steamIDClanChat)
{
	return CFriends::Instance().CloseClanChatWindowInSteam(steamIDClanChat);
}

ManagedSteam_API bool Friends_SetListenForFriendsMessages(bool interceptEnabled)
{
	return CFriends::Instance().SetListenForFriendsMessages(interceptEnabled);
}

ManagedSteam_API bool Friends_ReplyToFriendMessage(SteamID steamIDFriend, PConstantUtf8String msgToSend)
{
	return CFriends::Instance().ReplyToFriendMessage(steamIDFriend,msgToSend);
}

ManagedSteam_API s32 Friends_GetFriendMessage(SteamID steamIDFriend, s32 messageID, PUtf8String text, s32 textSize, Enum *chatEntryType)
{
	return CFriends::Instance().GetFriendMessage(steamIDFriend, messageID, text, textSize, chatEntryType);
}

ManagedSteam_API void Friends_GetFollowerCount(SteamID steamID)
{
	return CFriends::Instance().GetFollowerCount(steamID);
}

ManagedSteam_API void Friends_IsFollowing(SteamID steamID)
{
	return CFriends::Instance().IsFollowing(steamID);
}

ManagedSteam_API void Friends_EnumerateFollowingList(u32 startIndex)
{
	return CFriends::Instance().EnumerateFollowingList(startIndex);
}
