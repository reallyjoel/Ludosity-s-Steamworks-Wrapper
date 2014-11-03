#ifndef Friends_h_
#define Friends_h_

#include "Friends.h"

#include "Singleton.hpp"
#include "Services.hpp"
#include "CallbackID.hpp"
#include "ResultID.hpp"

namespace SteamAPIWrap
{
	class CFriends : public CSingleton<CFriends>
	{
		
		SW_CALLBACK(CFriends, PersonaStateChange_t, PersonaStateChange);
		SW_CALLBACK(CFriends, GameOverlayActivated_t, GameOverlayActivated);
		SW_CALLBACK(CFriends, GameServerChangeRequested_t, GameServerChangeRequested);
		SW_CALLBACK(CFriends, GameLobbyJoinRequested_t, GameLobbyJoinRequested);
		SW_CALLBACK(CFriends, AvatarImageLoaded_t, AvatarImageLoaded);
		SW_ASYNC_RESULT(CFriends, ClanOfficerListResponse_t, ClanOfficerListResponse);
		SW_CALLBACK(CFriends, FriendRichPresenceUpdate_t, FriendRichPresenceUpdate);
		SW_CALLBACK(CFriends, GameRichPresenceJoinRequested_t, GameRichPresenceJoinRequested);
		SW_CALLBACK(CFriends, GameConnectedClanChatMsg_t, GameConnectedClanChatMsg);
		SW_CALLBACK(CFriends, GameConnectedChatJoin_t, GameConnectedChatJoin);
		SW_CALLBACK(CFriends, GameConnectedChatLeave_t, GameConnectedChatLeave);
		SW_ASYNC_RESULT(CFriends, DownloadClanActivityCountsResult_t, DownloadClanActivityCountsResult);
		SW_ASYNC_RESULT(CFriends, JoinClanChatRoomCompletionResult_t, JoinClanChatRoomCompletionResult);
		SW_CALLBACK(CFriends, GameConnectedFriendChatMsg_t, GameConnectedFriendChatMsg);
		SW_ASYNC_RESULT(CFriends, FriendsGetFollowerCount_t, FriendsGetFollowerCount);
		SW_ASYNC_RESULT(CFriends, FriendsIsFollowing_t, FriendsIsFollowing);
		SW_ASYNC_RESULT(CFriends, FriendsEnumerateFollowingList_t, FriendsEnumerateFollowingList);

	public:
		void SetSteamInterface(ISteamFriends *friends);
		void RunCallbackSizeCheck();

		PConstantUtf8String GetPersonaName();

		void SetPersonaName(PConstantUtf8String personaName);

		Enum GetPersonaState();

		s32 GetFriendCount(Enum friendFlags);
		SteamID GetFriendByIndex(s32 iFriend, s32 friendFlags);
		Enum GetFriendRelationship(SteamID steamIDFriend);
		Enum GetFriendPersonaState(SteamID steamIDFriend);
		PConstantUtf8String GetFriendPersonaName(SteamID steamIDFriend);
		bool GetFriendGamePlayed(SteamID steamIDFriend, PDataPointer friendGameInfo);
		PConstantUtf8String GetFriendPersonaNameHistory(SteamID steamIDFriend, s32 personaName);
		PConstantUtf8String GetPlayerNickname(SteamID steamIDPlayer);
		bool HasFriend(SteamID steamIDFriend, s32 friendFlags);
		s32 GetClanCount();
		SteamID GetClanByIndex(s32 clan);
		PConstantString GetClanName(SteamID steamIDClan);
		PConstantString GetClanTag(SteamID steamIDClan);
		bool GetClanActivityCounts(SteamID steamIDClan, s32 *online, s32 *inGame, s32 *chatting);
		void DownloadClanActivityCounts(PConstantDataPointer steamIDClans, s32 clansToRequest);
		s32 GetFriendCountFromSource(SteamID steamIDSource);
		SteamID GetFriendFromSourceByIndex(SteamID steamIDSource, s32 friendIndex);
		bool IsUserInSource(SteamID steamIDUser, SteamID steamIDSource);
		void SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking);
	
		void ActivateGameOverlay(Enum dialogType);
		void ActivateGameOverlayToUser(Enum dialogType, SteamID steamID);
		void ActivateGameOverlayToWebPage(PConstantString url);
		void ActivateGameOverlayToStore(u32 appID, EOverlayToStoreFlag eFlag);
		void SetPlayedWith(SteamID steamIDUserPlayedWith);

		void ActivateGameOverlayInviteDialog(SteamID steamIDLobby);
		s32 GetSmallFriendAvatar(SteamID steamIDFriend);
		s32 GetMediumFriendAvatar(SteamID steamIDFriend);
		s32 GetLargeFriendAvatar(SteamID steamIDFriend);
		bool RequestUserInformation(SteamID steamIDUser, bool requireNameOnly);
		void RequestClanOfficerList(SteamID steamIDClan);
		SteamID GetClanOwner(SteamID steamIDClan);
		s32 GetClanOfficerCount(SteamID steamIDClan);
		SteamID GetClanOfficerByIndex(SteamID steamIDClan, s32 officer);
		u32 GetUserRestrictions();
		bool SetRichPresence(PConstantString key, PConstantUtf8String value);



		void ClearRichPresence();
		PConstantUtf8String GetFriendRichPresence(SteamID steamIDFriend, PConstantString key);
		s32 GetFriendRichPresenceKeyCount(SteamID steamIDFriend);
		PConstantUtf8String GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, s32 key);
		void RequestFriendRichPresence(SteamID steamIDFriend);
		bool InviteUserToGame(SteamID steamIDFriend, PConstantString connectString);
		s32 GetCoplayFriendCount();
		SteamID GetCoplayFriend(s32 coplayFriend);
		s32 GetFriendCoplayTime(SteamID steamIDFriend);
		AppID GetFriendCoplayGame(SteamID steamIDFriend);
		void JoinClanChatRoom(SteamID steamIDClan);
		bool LeaveClanChatRoom(SteamID steamIDClan);
		s32 GetClanChatMemberCount(SteamID steamIDClan);
		SteamID GetChatMemberByIndex(SteamID steamIDClan, s32 user);
		bool SendClanChatMessage(SteamID steamIDClanChat, PConstantUtf8String text);
		s32 GetClanChatMessage(SteamID steamIDClanChat, s32 message, PUtf8String text, s32 textSize, Enum *chatEntryType, SteamID *sender);
		bool IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser);
		bool IsClanChatWindowOpenInSteam(SteamID steamIDClanChat);
		bool OpenClanChatWindowInSteam(SteamID steamIDClanChat);
		bool CloseClanChatWindowInSteam(SteamID steamIDClanChat);
		bool SetListenForFriendsMessages(bool interceptEnabled);
		bool ReplyToFriendMessage(SteamID steamIDFriend, PConstantUtf8String msgToSend);
		s32 GetFriendMessage(SteamID steamIDFriend, s32 messageID, PDataPointer text, s32 textSize, Enum *chatEntryType);
		void GetFollowerCount(SteamID steamID);
		void IsFollowing(SteamID steamID);
		void EnumerateFollowingList(u32 startIndex);

	private:
		friend class CSingleton<CFriends>;
		CFriends();
		~CFriends() {}
		DISALLOW_COPY_AND_ASSIGN(CFriends);

		ISteamFriends *friends;
	};
}

#endif // Friends_h_