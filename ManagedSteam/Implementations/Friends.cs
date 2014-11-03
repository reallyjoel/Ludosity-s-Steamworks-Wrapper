using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.Utility;
using ManagedSteam.SteamTypes;

namespace ManagedSteam.Implementations
{
    class Friends : SteamService, IFriends
    {
        private List<PersonaStateChange> personaStateChange;
        private List<GameOverlayActivated> gameOverlayActivated;
        private List<GameServerChangeRequested> gameServerChangeRequested;
        private List<GameLobbyJoinRequested> gameLobbyJoinRequested;
        private List<AvatarImageLoaded> avatarImageLoaded;
        private List<Result<ClanOfficerListResponse>> clanOfficerListResponse;
        private List<FriendRichPresenceUpdate> friendRichPresenceUpdate;
        private List<GameRichPresenceJoinRequested> gameRichPresenceJoinRequested;
        private List<GameConnectedClanChatMsg> gameConnectedClanChatMsg;
        private List<GameConnectedChatJoin> gameConnectedChatJoin;
        private List<GameConnectedChatLeave> gameConnectedChatLeave;
        private List<Result<DownloadClanActivityCountsResult>> downloadClanActivityCountsResult;
        private List<Result<JoinClanChatRoomCompletionResult>> joinClanChatRoomCompletionResult;
        private List<GameConnectedFriendChatMsg> gameConnectedFriendChatMsg;
        private List<Result<FriendsGetFollowerCount>> friendsGetFollowerCount;
        private List<Result<FriendsIsFollowing>> friendsIsFollowing;
        private List<Result<FriendsEnumerateFollowingList>> friendsEnumerateFollowingList;

        internal Friends()
        {
            personaStateChange = new List<PersonaStateChange>();
            gameOverlayActivated = new List<GameOverlayActivated>();
            gameServerChangeRequested = new List<GameServerChangeRequested>();
            gameLobbyJoinRequested = new List<GameLobbyJoinRequested>();
            avatarImageLoaded = new List<AvatarImageLoaded>();
            clanOfficerListResponse = new List<Result<ClanOfficerListResponse>>();
            friendRichPresenceUpdate = new List<FriendRichPresenceUpdate>();
            gameRichPresenceJoinRequested = new List<GameRichPresenceJoinRequested>();
            gameConnectedClanChatMsg = new List<GameConnectedClanChatMsg>();
            gameConnectedChatJoin = new List<GameConnectedChatJoin>();
            gameConnectedChatLeave = new List<GameConnectedChatLeave>();
            downloadClanActivityCountsResult = new List<Result<DownloadClanActivityCountsResult>>();
            joinClanChatRoomCompletionResult = new List<Result<JoinClanChatRoomCompletionResult>>();
            gameConnectedFriendChatMsg = new List<GameConnectedFriendChatMsg>();
            friendsGetFollowerCount = new List<Result<FriendsGetFollowerCount>>();
            friendsIsFollowing = new List<Result<FriendsIsFollowing>>();
            friendsEnumerateFollowingList = new List<Result<FriendsEnumerateFollowingList>>();


            Callbacks[CallbackID.PersonaStateChange] = (data, size) => personaStateChange.Add(CallbackStructures.PersonaStateChange.Create(data, size));
            Callbacks[CallbackID.GameOverlayActivated] = (data, size) => gameOverlayActivated.Add(CallbackStructures.GameOverlayActivated.Create(data, size));
            Callbacks[CallbackID.GameServerChangeRequested] = (data, size) => gameServerChangeRequested.Add(CallbackStructures.GameServerChangeRequested.Create(data, size));
            Callbacks[CallbackID.GameLobbyJoinRequested] = (data, size) => gameLobbyJoinRequested.Add(CallbackStructures.GameLobbyJoinRequested.Create(data, size));
            Callbacks[CallbackID.AvatarImageLoaded] = (data, size) => avatarImageLoaded.Add(CallbackStructures.AvatarImageLoaded.Create(data, size));
            Results[ResultID.ClanOfficerListResponse] = (data, size, flag) => clanOfficerListResponse.Add(new Result<ClanOfficerListResponse>(CallbackStructures.ClanOfficerListResponse.Create(data, size), flag));
            Callbacks[CallbackID.FriendRichPresenceUpdate] = (data, size) => friendRichPresenceUpdate.Add(CallbackStructures.FriendRichPresenceUpdate.Create(data, size));
            Callbacks[CallbackID.GameRichPresenceJoinRequested] = (data, size) => gameRichPresenceJoinRequested.Add(CallbackStructures.GameRichPresenceJoinRequested.Create(data, size));
            Callbacks[CallbackID.GameConnectedClanChatMsg] = (data, size) => gameConnectedClanChatMsg.Add(CallbackStructures.GameConnectedClanChatMsg.Create(data, size));
            Callbacks[CallbackID.GameConnectedChatJoin] = (data, size) => gameConnectedChatJoin.Add(CallbackStructures.GameConnectedChatJoin.Create(data, size));
            Callbacks[CallbackID.GameConnectedChatLeave] = (data, size) => gameConnectedChatLeave.Add(CallbackStructures.GameConnectedChatLeave.Create(data, size));
            Results[ResultID.DownloadClanActivityCountsResult] = (data, size, flag) => downloadClanActivityCountsResult.Add(new Result<DownloadClanActivityCountsResult>(CallbackStructures.DownloadClanActivityCountsResult.Create(data, size), flag));
            Results[ResultID.JoinClanChatRoomCompletionResult] = (data, size, flag) => joinClanChatRoomCompletionResult.Add(new Result<JoinClanChatRoomCompletionResult>(CallbackStructures.JoinClanChatRoomCompletionResult.Create(data, size), flag));
            Callbacks[CallbackID.GameConnectedFriendChatMsg] = (data, size) => gameConnectedFriendChatMsg.Add(CallbackStructures.GameConnectedFriendChatMsg.Create(data, size));
            Results[ResultID.FriendsGetFollowerCount] = (data, size, flag) => friendsGetFollowerCount.Add(new Result<FriendsGetFollowerCount>(CallbackStructures.FriendsGetFollowerCount.Create(data, size), flag));
            Results[ResultID.FriendsIsFollowing] = (data, size, flag) => friendsIsFollowing.Add(new Result<FriendsIsFollowing>(CallbackStructures.FriendsIsFollowing.Create(data, size), flag));
            Results[ResultID.FriendsEnumerateFollowingList] = (data, size, flag) => friendsEnumerateFollowingList.Add(new Result<FriendsEnumerateFollowingList>(CallbackStructures.FriendsEnumerateFollowingList.Create(data, size), flag));
        }

        public event CallbackEvent<PersonaStateChange> PersonaStateChange;
        public event CallbackEvent<GameOverlayActivated> GameOverlayActivated;
        public event CallbackEvent<GameServerChangeRequested> GameServerChangeRequested;
        public event CallbackEvent<GameLobbyJoinRequested> GameLobbyJoinRequested;
        public event CallbackEvent<AvatarImageLoaded> AvatarImageLoaded;
        public event ResultEvent<ClanOfficerListResponse> ClanOfficerListResponseResult;
        public event CallbackEvent<FriendRichPresenceUpdate> FriendRichPresenceUpdate;
        public event CallbackEvent<GameRichPresenceJoinRequested> GameRichPresenceJoinRequested;
        public event CallbackEvent<GameConnectedClanChatMsg> GameConnectedClanChatMsg;
        public event CallbackEvent<GameConnectedChatJoin> GameConnectedChatJoin;
        public event CallbackEvent<GameConnectedChatLeave> GameConnectedChatLeave;
        public event ResultEvent<DownloadClanActivityCountsResult> DownloadClanActivityCountsResultResult;
        public event ResultEvent<JoinClanChatRoomCompletionResult> JoinClanChatRoomCompletionResultResult;
        public event CallbackEvent<GameConnectedFriendChatMsg> GameConnectedFriendChatMsg;
        public event ResultEvent<FriendsGetFollowerCount> FriendsGetFollowerCount;
        public event ResultEvent<FriendsIsFollowing> FriendsIsFollowing;
        public event ResultEvent<FriendsEnumerateFollowingList> FriendsEnumerateFollowingList;


        internal override void CheckIfUsableInternal()
        {

        }

        internal override void ReleaseManagedResources()
        {
            personaStateChange = null;
            PersonaStateChange = null;
            gameOverlayActivated = null;
            GameOverlayActivated = null;
            gameServerChangeRequested = null;
            GameServerChangeRequested = null;
            gameLobbyJoinRequested = null;
            GameLobbyJoinRequested = null;
            avatarImageLoaded = null;
            AvatarImageLoaded = null;
            clanOfficerListResponse = null;
            ClanOfficerListResponseResult = null;
            friendRichPresenceUpdate = null;
            FriendRichPresenceUpdate = null;
            gameRichPresenceJoinRequested = null;
            GameRichPresenceJoinRequested = null;
            gameConnectedClanChatMsg = null;
            GameConnectedClanChatMsg = null;
            gameConnectedChatJoin = null;
            GameConnectedChatJoin = null;
            gameConnectedChatLeave = null;
            GameConnectedChatLeave = null;
            downloadClanActivityCountsResult = null;
            DownloadClanActivityCountsResultResult = null;
            joinClanChatRoomCompletionResult = null;
            JoinClanChatRoomCompletionResultResult = null;
            gameConnectedFriendChatMsg = null;
            GameConnectedFriendChatMsg = null;
            friendsGetFollowerCount = null;
            FriendsGetFollowerCount = null;
            friendsIsFollowing = null;
            FriendsIsFollowing = null;
            friendsEnumerateFollowingList = null;
            FriendsEnumerateFollowingList = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(personaStateChange, PersonaStateChange);
            InvokeEvents(gameOverlayActivated, GameOverlayActivated);
            InvokeEvents(gameServerChangeRequested, GameServerChangeRequested);
            InvokeEvents(gameLobbyJoinRequested, GameLobbyJoinRequested);
            InvokeEvents(avatarImageLoaded, AvatarImageLoaded);
            InvokeEvents(clanOfficerListResponse, ClanOfficerListResponseResult);
            InvokeEvents(friendRichPresenceUpdate, FriendRichPresenceUpdate);
            InvokeEvents(gameRichPresenceJoinRequested, GameRichPresenceJoinRequested);
            InvokeEvents(gameConnectedClanChatMsg, GameConnectedClanChatMsg);
            InvokeEvents(gameConnectedChatJoin, GameConnectedChatJoin);
            InvokeEvents(gameConnectedChatLeave, GameConnectedChatLeave);
            InvokeEvents(downloadClanActivityCountsResult, DownloadClanActivityCountsResultResult);
            InvokeEvents(joinClanChatRoomCompletionResult, JoinClanChatRoomCompletionResultResult);
            InvokeEvents(gameConnectedFriendChatMsg, GameConnectedFriendChatMsg);
            InvokeEvents(friendsGetFollowerCount, FriendsGetFollowerCount);
            InvokeEvents(friendsIsFollowing, FriendsIsFollowing);
            InvokeEvents(friendsEnumerateFollowingList, FriendsEnumerateFollowingList);
        }

        public string GetPersonaName()
        {
            CheckIfUsable();

            return NativeHelpers.ToStringUtf8(NativeMethods.Friends_GetPersonaName());
        }

        public void SetPersonaName(string personaName)
        {
            CheckIfUsable();

            using (NativeString nativeString = new NativeString(personaName))
            {
                NativeMethods.Friends_SetPersonaName(nativeString.ToNativeAsUtf8());
            }
        }

        public PersonaState GetPersonaState()
        {
            CheckIfUsable();

            return (PersonaState)NativeMethods.Friends_GetPersonaState();
        }

        public int GetFriendCount(FriendFlags friendFlags)
        {
            CheckIfUsable();

            return NativeMethods.Friends_GetFriendCount((int)friendFlags);
        }

        public SteamID GetFriendByIndex(int friendIndex, FriendFlags friendFlags)
        {
            CheckIfUsable();

            return new SteamID(NativeMethods.Friends_GetFriendByIndex(friendIndex, (int)friendFlags));
        }

        public FriendRelationship GetFriendRelationship(SteamID steamIDFriend)
        {
            CheckIfUsable();

            return (FriendRelationship)NativeMethods.Friends_GetFriendRelationship(steamIDFriend.AsUInt64);
        }

        public PersonaState GetFriendPersonaState(SteamID steamIDFriend)
        {
            CheckIfUsable();

            return (PersonaState)NativeMethods.Friends_GetFriendPersonaState(steamIDFriend.AsUInt64);
        }

        public string GetFriendPersonaName(SteamID steamIDFriend)
        {
            CheckIfUsable();

            IntPtr stringPtr = NativeMethods.Friends_GetFriendPersonaName(steamIDFriend.AsUInt64);
            return NativeHelpers.ToStringUtf8(stringPtr);
        }

        public bool GetFriendGamePlayed(SteamID steamIDFriend, out FriendGameInfo friendGameInfo)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Marshal.SizeOf(typeof(FriendGameInfo))))
            {
                if (buffer.UnmanagedSize != NativeMethods.Friends_GetFriendGameInfoSize())
                {
                    Error.ThrowError(ErrorCodes.CallbackStructSizeMissmatch, typeof(FriendGameInfo).Name);
                }
                bool result = NativeMethods.Friends_GetFriendGamePlayed(steamIDFriend.AsUInt64, buffer.UnmanagedMemory);
                friendGameInfo = FriendGameInfo.Create(buffer.UnmanagedMemory, buffer.UnmanagedSize);
                return result;
            }
        }

        public FriendsGetFriendGamePlayedResult GetFriendGamePlayed(SteamID steamIDFriend)
        {

            FriendsGetFriendGamePlayedResult result = new FriendsGetFriendGamePlayedResult();

            result.Result = GetFriendGamePlayed(steamIDFriend, out result.FriendGameInfo);

            return result;

        }

        public string GetFriendPersonaNameHistory(SteamID steamIDFriend, int personaName)
        {
            CheckIfUsable();

            IntPtr stringPtr = NativeMethods.Friends_GetFriendPersonaNameHistory(steamIDFriend.AsUInt64, personaName);
            return NativeHelpers.ToStringUtf8(stringPtr);
        }

        public string GetPlayerNickname(SteamID steamIDPlayer)
        {
            CheckIfUsable();

            IntPtr stringPtr = NativeMethods.Friends_GetPlayerNickname(steamIDPlayer.AsUInt64);
            return NativeHelpers.ToStringUtf8(stringPtr);
        }

        public bool HasFriend(SteamID steamIDFriend, FriendFlags friendFlags)
        {
            CheckIfUsable();

            return NativeMethods.Friends_HasFriend(steamIDFriend.AsUInt64, (int)friendFlags);
        }

        public int GetClanCount()
        {
            CheckIfUsable();

            return NativeMethods.Friends_GetClanCount();
        }

        public SteamID GetClanByIndex(int clan)
        {
            CheckIfUsable();

            return new SteamID(NativeMethods.Friends_GetClanByIndex(clan));
        }

        public string GetClanName(SteamID steamIDClan)
        {
            CheckIfUsable();

            return NativeHelpers.ToStringUtf8(NativeMethods.Friends_GetClanName(steamIDClan.AsUInt64));
        }

        public string GetClanTag(SteamID steamIDClan)
        {
            CheckIfUsable();

            return NativeHelpers.ToStringUtf8(NativeMethods.Friends_GetClanTag(steamIDClan.AsUInt64));
        }

        public bool GetClanActivityCounts(SteamID steamIDClan, out int online, out int inGame, out int chatting)
        {
            CheckIfUsable();

            online = 0;
            inGame = 0;
            chatting = 0;
            return NativeMethods.Friends_GetClanActivityCounts(steamIDClan.AsUInt64, ref online, ref inGame, ref chatting);
        }

        public FriendsGetClanActivityCountsResult GetClanActivityCounts(SteamID steamIDClan)
        {

            FriendsGetClanActivityCountsResult result = new FriendsGetClanActivityCountsResult();

            result.Result = GetClanActivityCounts(steamIDClan, out result.Online, out result.InGame, out result.Chatting);

            return result;
        }

        public void DownloadClanActivityCounts(SteamID[] clanIDs)
        {
            CheckIfUsable();

            byte[] idBuffer = NativeBuffer.ToBytes(clanIDs);

            using (NativeBuffer buffer = new NativeBuffer(idBuffer))
            {
                NativeMethods.Friends_DownloadClanActivityCounts(buffer.UnmanagedMemory, clanIDs.Length);
            }
        }

        public int GetFriendCountFromSource(SteamID steamIDSource)
        {
            CheckIfUsable();

            return NativeMethods.Friends_GetFriendCountFromSource(steamIDSource.AsUInt64);
        }

        public SteamID GetFriendFromSourceByIndex(SteamID steamIDSource, int friendIndex)
        {
            CheckIfUsable();

            return new SteamID(NativeMethods.Friends_GetFriendFromSourceByIndex(steamIDSource.AsUInt64, friendIndex));
        }

        public bool IsUserInSource(SteamID steamIDUser, SteamID steamIDSource)
        {
            CheckIfUsable();

            return NativeMethods.Friends_IsUserInSource(steamIDUser.AsUInt64, steamIDSource.AsUInt64);
        }

        public void SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking)
        {
            CheckIfUsable();

            NativeMethods.Friends_SetInGameVoiceSpeaking(steamIDUser.AsUInt64, speaking);
        }

        public void ActivateGameOverlay(OverlayDialog dialogType)
        {
            CheckIfUsable();
            NativeMethods.Friends_ActivateGameOverlay((int)dialogType);
        }

        public void ActivateGameOverlayToUser(OverlayDialogToUser dialogType, SteamID steamID)
        {
            CheckIfUsable();
            NativeMethods.Friends_ActivateGameOverlayToUser((int)dialogType, steamID.AsUInt64);
        }

        public void ActivateGameOverlayToWebPage(string url)
        {
            CheckIfUsable();
            NativeMethods.Friends_ActivateGameOverlayToWebPage(url);
        }

        public void ActivateGameOverlayToStore(AppID appID, OverlayToStoreFlag flag)
        {
            CheckIfUsable();
            NativeMethods.Friends_ActivateGameOverlayToStore(appID.AsUInt32, (int)flag);
        }

        public void SetPlayedWith(SteamID steamIDUserPlayedWith)
        {
            CheckIfUsable();
            NativeMethods.Friends_SetPlayedWith(steamIDUserPlayedWith.AsUInt64);
        }

        public void ActivateGameOverlayInviteDialog(SteamID steamIDLobby)
        {
            CheckIfUsable();
            NativeMethods.Friends_ActivateGameOverlayInviteDialog(steamIDLobby.AsUInt64);
        }

        public ImageHandle GetSmallFriendAvatar(SteamID steamIDFriend)
        {
            CheckIfUsable();
            var result = NativeMethods.Friends_GetSmallFriendAvatar(steamIDFriend.AsUInt64);
            return new ImageHandle(result);
        }

        public ImageHandle GetMediumFriendAvatar(SteamID steamIDFriend)
        {
            CheckIfUsable();
            var result = NativeMethods.Friends_GetMediumFriendAvatar(steamIDFriend.AsUInt64);
            return new ImageHandle(result);
        }

        public ImageHandle GetLargeFriendAvatar(SteamID steamIDFriend)
        {
            CheckIfUsable();
            var result = NativeMethods.Friends_GetLargeFriendAvatar(steamIDFriend.AsUInt64);
            return new ImageHandle(result);
        }

        public bool RequestUserInformation(SteamID steamIDUser, bool requireNameOnly)
        {
            CheckIfUsable();
            return NativeMethods.Friends_RequestUserInformation(steamIDUser.AsUInt64, requireNameOnly);
        }

        public void RequestClanOfficerList(SteamID steamIDClan)
        {
            CheckIfUsable();
            NativeMethods.Friends_RequestClanOfficerList(steamIDClan.AsUInt64);
        }

        public SteamID GetClanOwner(SteamID steamIDClan)
        {
            CheckIfUsable();
            ulong tempReturn = NativeMethods.Friends_GetClanOwner(steamIDClan.AsUInt64);
            return new SteamID(tempReturn);
        }

        public int GetClanOfficerCount(SteamID steamIDClan)
        {
            CheckIfUsable();
            return NativeMethods.Friends_GetClanOfficerCount(steamIDClan.AsUInt64);
        }




        public SteamID GetClanOfficerByIndex(SteamID steamIDClan, int officer)
        {
            CheckIfUsable();
            ulong tempReturn = NativeMethods.Friends_GetClanOfficerByIndex(steamIDClan.AsUInt64, officer);
            return new SteamID(tempReturn);
        }

        public UserRestriction GetUserRestrictions()
        {
            CheckIfUsable();
            return (UserRestriction)NativeMethods.Friends_GetUserRestrictions();
        }

        public bool SetRichPresence(string key, string value)
        {
            CheckIfUsable();
            using (NativeString rawString = new NativeString(value))
            {
                return NativeMethods.Friends_SetRichPresence(key, rawString.ToNativeAsUtf8());
            }
        }

        public void ClearRichPresence()
        {
            CheckIfUsable();
            NativeMethods.Friends_ClearRichPresence();
        }

        public string GetFriendRichPresence(SteamID steamIDFriend, string key)
        {
            CheckIfUsable();
            IntPtr stringPtr = NativeMethods.Friends_GetFriendRichPresence(steamIDFriend.AsUInt64, key);
            return NativeHelpers.ToStringUtf8(stringPtr);
        }

        public int GetFriendRichPresenceKeyCount(SteamID steamIDFriend)
        {
            CheckIfUsable();
            return NativeMethods.Friends_GetFriendRichPresenceKeyCount(steamIDFriend.AsUInt64);
        }

        public string GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, int key)
        {
            CheckIfUsable();
            IntPtr stringPtr = NativeMethods.Friends_GetFriendRichPresenceKeyByIndex(steamIDFriend.AsUInt64, key);
            return NativeHelpers.ToStringUtf8(stringPtr);
        }

        public void RequestFriendRichPresence(SteamID steamIDFriend)
        {
            CheckIfUsable();
            NativeMethods.Friends_RequestFriendRichPresence(steamIDFriend.AsUInt64);
        }

        public bool InviteUserToGame(SteamID steamIDFriend, string connectString)
        {
            CheckIfUsable();
            return NativeMethods.Friends_InviteUserToGame(steamIDFriend.AsUInt64, connectString);
        }

        public int GetCoplayFriendCount()
        {
            CheckIfUsable();
            return NativeMethods.Friends_GetCoplayFriendCount();
        }

        public SteamID GetCoplayFriend(int coplayFriend)
        {
            CheckIfUsable();

            ulong tempReturn = NativeMethods.Friends_GetCoplayFriend(coplayFriend);
            return new SteamID(tempReturn);

        }

        public int GetFriendCoplayTime(SteamID steamIDFriend)
        {
            CheckIfUsable();
            return NativeMethods.Friends_GetFriendCoplayTime(steamIDFriend.AsUInt64);
        }

        public AppID GetFriendCoplayGame(SteamID steamIDFriend)
        {
            CheckIfUsable();
            return new AppID(NativeMethods.Friends_GetFriendCoplayGame(steamIDFriend.AsUInt64));
        }

        public void JoinClanChatRoom(SteamID steamIDClan)
        {
            CheckIfUsable();
            NativeMethods.Friends_JoinClanChatRoom(steamIDClan.AsUInt64);
        }

        public bool LeaveClanChatRoom(SteamID steamIDClan)
        {
            CheckIfUsable();
            return NativeMethods.Friends_LeaveClanChatRoom(steamIDClan.AsUInt64);
        }

        public int GetClanChatMemberCount(SteamID steamIDClan)
        {
            CheckIfUsable();
            return NativeMethods.Friends_GetClanChatMemberCount(steamIDClan.AsUInt64);
        }

        public SteamID GetChatMemberByIndex(SteamID steamIDClan, int user)
        {
            CheckIfUsable();
            ulong tempReturn = NativeMethods.Friends_GetChatMemberByIndex(steamIDClan.AsUInt64, user);
            return new SteamID(tempReturn);
        }

        public bool SendClanChatMessage(SteamID steamIDClanChat, string text)
        {
            CheckIfUsable();
            using (NativeString rawText = new NativeString(text))
            {
                return NativeMethods.Friends_SendClanChatMessage(steamIDClanChat.AsUInt64, rawText.ToNativeAsUtf8());
            }
        }

        public int GetClanChatMessage(SteamID steamIDClanChat, int message, int maxMessageSize, out string text,
            out ChatEntryType chatEntryType, out SteamID sender)
        {
            CheckIfUsable();
            int rawChatType = 0;
            ulong rawSender = 0;
            using (NativeBuffer buffer = new NativeBuffer(maxMessageSize))
            {
                var result = NativeMethods.Friends_GetClanChatMessage(steamIDClanChat.AsUInt64, message,
                    buffer.UnmanagedMemory, buffer.UnmanagedSize, ref rawChatType, ref rawSender);
                chatEntryType = (ChatEntryType)rawChatType;
                sender = new SteamID(rawSender);
                text = NativeHelpers.ToStringUtf8(buffer.UnmanagedMemory);
                return result;
            }
        }

        public FriendsGetClanChatMessageResult GetClanChatMessage(SteamID steamIDClanChat, int message,
            int maxMessageSize)
        {
            FriendsGetClanChatMessageResult result = new FriendsGetClanChatMessageResult();

            result.Result = GetClanChatMessage(steamIDClanChat, message, maxMessageSize, out result.Text,
                out result.ChatEntryType, out result.Sender);

            return result;
        }

        public bool IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser)
        {
            CheckIfUsable();
            return NativeMethods.Friends_IsClanChatAdmin(steamIDClanChat.AsUInt64, steamIDUser.AsUInt64);
        }

        public bool IsClanChatWindowOpenInSteam(SteamID steamIDClanChat)
        {
            CheckIfUsable();
            return NativeMethods.Friends_IsClanChatWindowOpenInSteam(steamIDClanChat.AsUInt64);
        }

        public bool OpenClanChatWindowInSteam(SteamID steamIDClanChat)
        {
            CheckIfUsable();
            return NativeMethods.Friends_OpenClanChatWindowInSteam(steamIDClanChat.AsUInt64);
        }

        public bool CloseClanChatWindowInSteam(SteamID steamIDClanChat)
        {
            CheckIfUsable();
            return NativeMethods.Friends_CloseClanChatWindowInSteam(steamIDClanChat.AsUInt64);
        }

        public bool SetListenForFriendsMessages(bool interceptEnabled)
        {
            CheckIfUsable();
            return NativeMethods.Friends_SetListenForFriendsMessages(interceptEnabled);
        }

        public bool ReplyToFriendMessage(SteamID steamIDFriend, string message)
        {
            CheckIfUsable();
            using (NativeString rawMessage = new NativeString(message))
            {
                return NativeMethods.Friends_ReplyToFriendMessage(steamIDFriend.AsUInt64, rawMessage.ToNativeAsUtf8());
            }
        }

        public int GetFriendMessage(SteamID steamIDFriend, int messageID, int maxMessageSize,
            out string text, out ChatEntryType chatEntryType)
        {
            CheckIfUsable();
            int rawChatType = 0;
            using (NativeBuffer buffer = new NativeBuffer(maxMessageSize))
            {
                var result = NativeMethods.Friends_GetFriendMessage(steamIDFriend.AsUInt64, messageID,
                    buffer.UnmanagedMemory, buffer.UnmanagedSize, ref rawChatType);
                chatEntryType = (ChatEntryType)rawChatType;
                text = NativeHelpers.ToStringUtf8(buffer.UnmanagedMemory);
                return result;
            }
        }

        public FriendsGetFriendMessageResult GetFriendMessage(SteamID steamIDFriend, int messageID, int maxMessageSize)
        {
            FriendsGetFriendMessageResult result = new FriendsGetFriendMessageResult();

            result.Result = GetFriendMessage(steamIDFriend, messageID, maxMessageSize, out result.Text,
                out result.ChatEntryType);

            return result;
        }

        public void GetFollowerCount(SteamID steamID)
        {
            CheckIfUsable();
            NativeMethods.Friends_GetFollowerCount(steamID.AsUInt64);
        }

        public void IsFollowing(SteamID steamID)
        {
            CheckIfUsable();
            NativeMethods.Friends_IsFollowing(steamID.AsUInt64);
        }

        public void EnumerateFollowingList(uint startIndex)
        {
            CheckIfUsable();
            NativeMethods.Friends_EnumerateFollowingList(startIndex);
        }

    }
}
