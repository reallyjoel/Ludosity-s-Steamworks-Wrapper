#ifndef Friends_h_interop_
#define Friends_h_interop_


ManagedSteam_API PConstantUtf8String Friends_GetPersonaName();

ManagedSteam_API void Friends_SetPersonaName(PConstantUtf8String personaName);

ManagedSteam_API Enum Friends_GetPersonaState();

ManagedSteam_API s32 Friends_GetFriendCount(Enum friendFlags);

ManagedSteam_API SteamID Friends_GetFriendByIndex(s32 friendIndex, s32 friendFlags);

ManagedSteam_API Enum Friends_GetFriendRelationship(SteamID steamIDFriend);

ManagedSteam_API Enum Friends_GetFriendPersonaState(SteamID steamIDFriend);

ManagedSteam_API PConstantUtf8String Friends_GetFriendPersonaName(SteamID steamIDFriend);

ManagedSteam_API bool Friends_GetFriendGamePlayed(SteamID steamIDFriend, PDataPointer friendGameInfo);

ManagedSteam_API s32 Friends_GetFriendGameInfoSize();

ManagedSteam_API PConstantUtf8String Friends_GetFriendPersonaNameHistory(SteamID steamIDFriend, s32 personaName);

ManagedSteam_API PConstantUtf8String Friends_GetPlayerNickname(SteamID steamIDPlayer);

ManagedSteam_API bool Friends_HasFriend(SteamID steamIDFriend, s32 friendFlags);

ManagedSteam_API s32 Friends_GetClanCount();
ManagedSteam_API SteamID Friends_GetClanByIndex(s32 clan);
ManagedSteam_API PConstantString Friends_GetClanName(SteamID steamIDClan);
ManagedSteam_API PConstantString Friends_GetClanTag(SteamID steamIDClan);

ManagedSteam_API bool Friends_GetClanActivityCounts(SteamID steamIDClan, s32 *online, s32 *inGame, s32 *chatting);

ManagedSteam_API void Friends_DownloadClanActivityCounts(PConstantDataPointer steamIDClans, s32 clansToRequest);

ManagedSteam_API s32 Friends_GetFriendCountFromSource(SteamID steamIDSource);
ManagedSteam_API SteamID Friends_GetFriendFromSourceByIndex(SteamID steamIDSource, s32 friendIndex);

ManagedSteam_API bool Friends_IsUserInSource(SteamID steamIDUser, SteamID steamIDSource);

ManagedSteam_API void Friends_SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking);

ManagedSteam_API void Friends_ActivateGameOverlay(Enum dialogType);

ManagedSteam_API void Friends_ActivateGameOverlayToUser(Enum dialogType, SteamID steamID);

ManagedSteam_API void Friends_ActivateGameOverlayToWebPage(PConstantString url);

ManagedSteam_API void Friends_ActivateGameOverlayToStore(u32 appID, EOverlayToStoreFlag eFlag);

ManagedSteam_API void Friends_SetPlayedWith(SteamID steamIDUserPlayedWith);

ManagedSteam_API void Friends_ActivateGameOverlayInviteDialog(SteamID steamIDLobby);

ManagedSteam_API s32 Friends_GetSmallFriendAvatar(SteamID steamIDFriend);

ManagedSteam_API s32 Friends_GetMediumFriendAvatar(SteamID steamIDFriend);

ManagedSteam_API s32 Friends_GetLargeFriendAvatar(SteamID steamIDFriend);

ManagedSteam_API bool Friends_RequestUserInformation(SteamID steamIDUser, bool requireNameOnly);

ManagedSteam_API void Friends_RequestClanOfficerList(SteamID steamIDClan);

ManagedSteam_API SteamID Friends_GetClanOwner(SteamID steamIDClan);
ManagedSteam_API s32 Friends_GetClanOfficerCount(SteamID steamIDClan);
ManagedSteam_API SteamID Friends_GetClanOfficerByIndex(SteamID steamIDClan, s32 officer);
ManagedSteam_API u32 Friends_GetUserRestrictions();

ManagedSteam_API bool Friends_SetRichPresence(PConstantString key, PConstantUtf8String value);

ManagedSteam_API void Friends_ClearRichPresence();
ManagedSteam_API PConstantUtf8String Friends_GetFriendRichPresence(SteamID steamIDFriend, PConstantString key);
ManagedSteam_API s32 Friends_GetFriendRichPresenceKeyCount(SteamID steamIDFriend);
ManagedSteam_API PConstantUtf8String Friends_GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, s32 key);
ManagedSteam_API void Friends_RequestFriendRichPresence(SteamID steamIDFriend);

ManagedSteam_API bool Friends_InviteUserToGame(SteamID steamIDFriend, PConstantString connectString);

ManagedSteam_API s32 Friends_GetCoplayFriendCount();
ManagedSteam_API SteamID Friends_GetCoplayFriend(s32 coplayFriend);
ManagedSteam_API s32 Friends_GetFriendCoplayTime(SteamID steamIDFriend);
ManagedSteam_API AppID Friends_GetFriendCoplayGame(SteamID steamIDFriend);

ManagedSteam_API void Friends_JoinClanChatRoom(SteamID steamIDClan);
ManagedSteam_API bool Friends_LeaveClanChatRoom(SteamID steamIDClan);
ManagedSteam_API s32 Friends_GetClanChatMemberCount(SteamID steamIDClan);
ManagedSteam_API SteamID Friends_GetChatMemberByIndex(SteamID steamIDClan, s32 user);
ManagedSteam_API bool Friends_SendClanChatMessage(SteamID steamIDClanChat, PConstantUtf8String text);
ManagedSteam_API s32 Friends_GetClanChatMessage(SteamID steamIDClanChat, s32 message, PUtf8String text, s32 textSize, Enum *chatEntryType, SteamID *sender);
ManagedSteam_API bool Friends_IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser);

ManagedSteam_API bool Friends_IsClanChatWindowOpenInSteam(SteamID steamIDClanChat);
ManagedSteam_API bool Friends_OpenClanChatWindowInSteam(SteamID steamIDClanChat);
ManagedSteam_API bool Friends_CloseClanChatWindowInSteam(SteamID steamIDClanChat);

ManagedSteam_API bool Friends_SetListenForFriendsMessages(bool interceptEnabled);
ManagedSteam_API bool Friends_ReplyToFriendMessage(SteamID steamIDFriend, PConstantUtf8String msgToSend);
ManagedSteam_API s32 Friends_GetFriendMessage(SteamID steamIDFriend, s32 messageID, PUtf8String text, s32 textSize, Enum *chatEntryType);

ManagedSteam_API void Friends_GetFollowerCount(SteamID steamID);
ManagedSteam_API void Friends_IsFollowing(SteamID steamID);
ManagedSteam_API void Friends_EnumerateFollowingList(u32 startIndex);


#endif // Friends_h_interop_