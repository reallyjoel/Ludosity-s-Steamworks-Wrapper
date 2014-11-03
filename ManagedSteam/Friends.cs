using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    /// <summary>
    /// Handles communication with the friends system and the game overlay.
    /// </summary>
    public interface IFriends
    {
        event CallbackEvent<PersonaStateChange> PersonaStateChange;
        event CallbackEvent<GameOverlayActivated> GameOverlayActivated;
        event CallbackEvent<GameServerChangeRequested> GameServerChangeRequested;
        event CallbackEvent<GameLobbyJoinRequested> GameLobbyJoinRequested;
        event CallbackEvent<AvatarImageLoaded> AvatarImageLoaded;
        event ResultEvent<ClanOfficerListResponse> ClanOfficerListResponseResult;
        event CallbackEvent<FriendRichPresenceUpdate> FriendRichPresenceUpdate;
        event CallbackEvent<GameRichPresenceJoinRequested> GameRichPresenceJoinRequested;
        event CallbackEvent<GameConnectedClanChatMsg> GameConnectedClanChatMsg;
        event CallbackEvent<GameConnectedChatJoin> GameConnectedChatJoin;
        event CallbackEvent<GameConnectedChatLeave> GameConnectedChatLeave;
        event ResultEvent<DownloadClanActivityCountsResult> DownloadClanActivityCountsResultResult;
        event ResultEvent<JoinClanChatRoomCompletionResult> JoinClanChatRoomCompletionResultResult;
        event CallbackEvent<GameConnectedFriendChatMsg> GameConnectedFriendChatMsg;
        event ResultEvent<FriendsGetFollowerCount> FriendsGetFollowerCount;
        event ResultEvent<FriendsIsFollowing> FriendsIsFollowing;
        event ResultEvent<FriendsEnumerateFollowingList> FriendsEnumerateFollowingList;


        /// <summary>
        /// returns the local players name - guaranteed to not be NULL.
        /// this is the same name as on the users community profile page
        /// this is stored in UTF-8 format
        /// like all the other interface functions that return a char *, it's important that this pointer is not saved
        /// off; it will eventually be free'd or re-allocated
        /// </summary>
        /// <returns></returns>
        string GetPersonaName();

        /// <summary>
        /// sets the player name, stores it on the server and publishes the changes to all friends who are online
        /// </summary>
        /// <param name="personaName"></param>
        void SetPersonaName(string personaName);

        /// <summary>
        /// gets the status of the current user
        /// </summary>
        /// <returns></returns>
        PersonaState GetPersonaState();

        /// <summary>
        /// friend iteration
        /// takes a set of k_EFriendFlags, and returns the number of users the client knows about who meet that criteria
        /// then GetFriendByIndex() can then be used to return the id's of each of those users
        /// </summary>
        /// <param name="friendFlags"></param>
        /// <returns></returns>
        int GetFriendCount(FriendFlags friendFlags);

        /// <summary>
        /// returns the steamID of a user
        /// iFriend is a index of range [0, GetFriendCount())
        /// iFriendsFlags must be the same value as used in GetFriendCount()
        /// the returned CSteamID can then be used by all the functions below to access details about the user
        /// </summary>
        /// <param name="friendIndex"></param>
        /// <param name="friendFlags"></param>
        /// <returns></returns>
        SteamID GetFriendByIndex(int friendIndex, FriendFlags friendFlags);

        /// <summary>
        /// returns a relationship to a user
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        FriendRelationship GetFriendRelationship(SteamID steamIDFriend);

        /// <summary>
        /// returns the current status of the specified user
        /// this will only be known by the local user if steamIDFriend is in their friends list; on the same game server; in a chat room or lobby; or in a small group with the local user
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        PersonaState GetFriendPersonaState(SteamID steamIDFriend);

        /// <summary>
        /// returns the name another user - guaranteed to not be NULL.
        /// same rules as GetFriendPersonaState() apply as to whether or not the user knowns the name of the other user
        /// note that on first joining a lobby, chat room or game server the local user will not known the name of the other users automatically; that information will arrive asyncronously
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        string GetFriendPersonaName(SteamID steamIDFriend);

        /// <summary>
        /// returns true if the friend is actually in a game, and fills in pFriendGameInfo with an extra details
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="friendGameInfo"></param>
        /// <returns></returns>
        bool GetFriendGamePlayed(SteamID steamIDFriend, out FriendGameInfo friendGameInfo);

        /// <summary>
        /// returns true if the friend is actually in a game, and fills in pFriendGameInfo with an extra details
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="friendGameInfo"></param>
        /// <returns></returns>
        FriendsGetFriendGamePlayedResult GetFriendGamePlayed(SteamID steamIDFriend);

        /// <summary>
        /// accesses old friends names - returns an empty string when their are no more items in the histor
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="personaName"></param>
        /// <returns></returns>
        string GetFriendPersonaNameHistory(SteamID steamIDFriend, int personaName);

        /// <summary>
        /// Returns nickname the current user has set for the specified player. Returns NULL if the no nickname has been set for that player.
        /// </summary>
        /// <param name="steamIDPlayer"></param>
        /// <returns></returns>
        string GetPlayerNickname(SteamID steamIDPlayer);

        /// <summary>
        /// returns true if the specified user meets any of the criteria specified in iFriendFlags
        /// iFriendFlags can be the union (binary or, |) of one or more k_EFriendFlags values
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="friendFlags"></param>
        /// <returns></returns>
        bool HasFriend(SteamID steamIDFriend, FriendFlags friendFlags);

        /// <summary>
        /// clan (group) iteration and access function
        /// </summary>
        /// <returns></returns>
        int GetClanCount();

        /// <summary>
        /// clan (group) iteration and access function
        /// </summary>
        /// <param name="clan"></param>
        /// <returns></returns>
        SteamID GetClanByIndex(int clan);

        /// <summary>
        /// clan (group) iteration and access function
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        string GetClanName(SteamID steamIDClan);

        /// <summary>
        /// clan (group) iteration and access function
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        string GetClanTag(SteamID steamIDClan);

        /// <summary>
        /// returns the most recent information we have about what's happening in a clan
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <param name="online"></param>
        /// <param name="inGame"></param>
        /// <param name="chatting"></param>
        /// <returns></returns>
        bool GetClanActivityCounts(SteamID steamIDClan, out int online, out int inGame, out int chatting);



        /// <summary>
        /// returns the most recent information we have about what's happening in a clan
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <param name="online"></param>
        /// <param name="inGame"></param>
        /// <param name="chatting"></param>
        /// <returns></returns>
        FriendsGetClanActivityCountsResult GetClanActivityCounts(SteamID steamIDClan);



        /// <summary>
        /// for clans a user is a member of, they will have reasonably up-to-date information, but for others you'll have to download the info to have the latest
        /// </summary>
        /// <param name="clanIDs"></param>
        void DownloadClanActivityCounts(SteamID[] clanIDs);

        /// <summary>
        /// iterator for getting users in a chat room, lobby, game server or clan
        /// note that large clans that cannot be iterated by the local user
        /// note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby
        /// steamIDSource can be the steamID of a group, game server, lobby or chat room
        /// </summary>
        /// <param name="steamIDSource"></param>
        /// <returns></returns>
        int GetFriendCountFromSource(SteamID steamIDSource);

        /// <summary>
        /// iterator for getting users in a chat room, lobby, game server or clan
        /// note that large clans that cannot be iterated by the local user
        /// note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby
        /// steamIDSource can be the steamID of a group, game server, lobby or chat room
        /// </summary>
        /// <param name="steamIDSource"></param>
        /// <param name="friendIndex"></param>
        /// <returns></returns>
        SteamID GetFriendFromSourceByIndex(SteamID steamIDSource, int friendIndex);

        /// <summary>
        /// returns true if the local user can see that steamIDUser is a member or in steamIDSource
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="steamIDSource"></param>
        /// <returns></returns>
        bool IsUserInSource(SteamID steamIDUser, SteamID steamIDSource);

        /// <summary>
        /// User is in a game pressing the talk button (will suppress the microphone for all voice comms from the Steam friends UI)
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="speaking"></param>
        void SetInGameVoiceSpeaking(SteamID steamIDUser, bool speaking);

        /// <summary>
        /// activates the game overlay, with an optional dialog to open 
        /// valid options are "Friends", "Community", "Players", "Settings", "OfficialGameGroup", "Stats", "Achievements"
        /// </summary>
        /// <param name="dialogType"></param>
        void ActivateGameOverlay(OverlayDialog dialogType);

        /// <summary>
        /// activates game overlay to a specific place
        /// valid options are
        ///		"steamid" - opens the overlay web browser to the specified user or groups profile
        ///		"chat" - opens a chat window to the specified user, or joins the group chat 
        ///		"jointrade" - opens a window to a Steam Trading session that was started with the ISteamEconomy/StartTrade Web API
        ///		"stats" - opens the overlay web browser to the specified user's stats
        ///		"achievements" - opens the overlay web browser to the specified user's achievement
        /// </summary>
        /// <param name="dialogType"></param>
        /// <param name="steamID"></param>
        void ActivateGameOverlayToUser(OverlayDialogToUser dialogType, SteamID steamID);

        /// <summary>
        /// activates game overlay web browser directly to the specified URL
        /// full address with protocol type is required, e.g. http://www.steamgames.com/
        /// </summary>
        /// <param name="url"></param>
        void ActivateGameOverlayToWebPage(string url);

        /// <summary>
        /// activates game overlay to store page for app
        /// </summary>
        /// <param name="appID"></param>
        void ActivateGameOverlayToStore(AppID appID, OverlayToStoreFlag flag);

        /// <summary>
        /// Mark a target user as 'played with'. This is a client-side only feature that requires that the calling user is 
        /// in game 
        /// </summary>
        /// <param name="steamIDUserPlayedWith"></param>
        void SetPlayedWith(SteamID steamIDUserPlayedWith);

        /// <summary>
        /// activates game overlay to open the invite dialog. Invitations will be sent for the provided lobby.
        /// </summary>
        /// <param name="steamIDLobby"></param>
        void ActivateGameOverlayInviteDialog(SteamID steamIDLobby);

        /// <summary>
        /// gets the small (32x32) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        ImageHandle GetSmallFriendAvatar(SteamID steamIDFriend);

        /// <summary>
        /// gets the medium (64x64) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        ImageHandle GetMediumFriendAvatar(SteamID steamIDFriend);

        /// <summary>
        /// gets the large (184x184) avatar of the current user, which is a handle to be used in IClientUtils::GetImageRGBA(), or 0 if none set
        /// returns -1 if this image has yet to be loaded, in this case wait for a AvatarImageLoaded_t callback and then call this again
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        ImageHandle GetLargeFriendAvatar(SteamID steamIDFriend);

        /// <summary>
        /// requests information about a user - persona name and avatar
        /// if bRequireNameOnly is set, then the avatar of a user isn't downloaded 
        /// - it's a lot slower to download avatars and churns the local cache, so if you don't need avatars, don't request them
        /// if returns true, it means that data is being requested, and a PersonaStateChanged_t callback will be posted when it's retrieved
        /// if returns false, it means that we already have all the details about that user, and functions can be called immediatel
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="requireNameOnly"></param>
        /// <returns></returns>
        bool RequestUserInformation(SteamID steamIDUser, bool requireNameOnly);

        /// <summary>
        /// requests information about a clan officer list
        /// when complete, data is returned in ClanOfficerListResponse_t call result
        /// this makes available the calls below
        /// you can only ask about clans that a user is a member of
        /// note that this won't download avatars automatically; if you get an officer,
        /// and no avatar image is available, call RequestUserInformation( steamID, false ) to download the avatar
        /// </summary>
        /// <param name="steamIDClan"></param>
        void RequestClanOfficerList(SteamID steamIDClan);

        /// <summary>
        /// returns the steamID of the clan owner
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        SteamID GetClanOwner(SteamID steamIDClan);

        /// <summary>
        /// returns the number of officers in a clan (including the owner)
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        int GetClanOfficerCount(SteamID steamIDClan);

        /// <summary>
        /// returns the steamID of a clan officer, by index, of range [0,GetClanOfficerCount)
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <param name="officer"></param>
        /// <returns></returns>
        SteamID GetClanOfficerByIndex(SteamID steamIDClan, int officer);

        /// <summary>
        /// if current user is chat restricted, he can't send or receive any text/voice chat messages.
        /// the user can't see custom avatars. But the user can be online and send/recv game invites.
        /// a chat restricted user can't add friends or join any groups.
        /// </summary>
        /// <returns></returns>
        UserRestriction GetUserRestrictions();

        /// <summary>
        /// if current user is chat restricted, he can't send or receive any text/voice chat messages.
        /// the user can't see custom avatars. But the user can be online and send/recv game invites.
        /// a chat restricted user can't add friends or join any group
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetRichPresence(string key, string value);


        /// <summary>
        /// Rich Presence data is automatically shared between friends who are in the same game
        /// Each user has a set of Key/Value pairs
        /// Up to 20 different keys can be set
        /// There are two magic keys:
        ///		"status"  - a UTF-8 string that will show up in the 'view game info' dialog in the Steam friends list
        ///		"connect" - a UTF-8 string that contains the command-line for how a friend can connect to a game
        /// SetRichPresence() to a NULL or an empty string deletes the key
        /// You can iterate the current set of keys for a friend with GetFriendRichPresenceKeyCount()
        /// and GetFriendRichPresenceKeyByIndex() (typically only used for debugging)
        /// </summary>
        void ClearRichPresence();

        /// <summary>
        ///  returns an empty string "" if no value is set
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetFriendRichPresence(SteamID steamIDFriend, string key);

        /// <summary>
        /// Rich Presence data is automatically shared between friends who are in the same game
        /// Each user has a set of Key/Value pairs
        /// Up to 20 different keys can be set
        /// There are two magic keys:
        ///		"status"  - a UTF-8 string that will show up in the 'view game info' dialog in the Steam friends list
        ///		"connect" - a UTF-8 string that contains the command-line for how a friend can connect to a game
        /// SetRichPresence() to a NULL or an empty string deletes the key
        /// You can iterate the current set of keys for a friend with GetFriendRichPresenceKeyCount()
        /// and GetFriendRichPresenceKeyByIndex() (typically only used for debugging)
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        int GetFriendRichPresenceKeyCount(SteamID steamIDFriend);

        /// <summary>
        /// Rich Presence data is automatically shared between friends who are in the same game
        /// Each user has a set of Key/Value pairs
        /// Up to 20 different keys can be set
        /// There are two magic keys:
        ///		"status"  - a UTF-8 string that will show up in the 'view game info' dialog in the Steam friends list
        ///		"connect" - a UTF-8 string that contains the command-line for how a friend can connect to a game
        /// SetRichPresence() to a NULL or an empty string deletes the key
        /// You can iterate the current set of keys for a friend with GetFriendRichPresenceKeyCount()
        /// and GetFriendRichPresenceKeyByIndex() (typically only used for debugging)
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetFriendRichPresenceKeyByIndex(SteamID steamIDFriend, int key);

        /// <summary>
        /// Requests rich presence for a specific user.
        /// </summary>
        /// <param name="steamIDFriend"></param>
        void RequestFriendRichPresence(SteamID steamIDFriend);

        /// <summary>
        /// rich invite support
        /// if the target accepts the invite, the pchConnectString gets added to the command-line for launching the game
        /// if the game is already running, a GameRichPresenceJoinRequested_t callback is posted containing the connect string
        /// invites can only be sent to friends
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="connectString"></param>
        /// <returns></returns>
        bool InviteUserToGame(SteamID steamIDFriend, string connectString);

        /// <summary>
        /// recently-played-with friends iteration
        /// this iterates the entire list of users recently played with, across games
        /// GetFriendCoplayTime() returns as a unix time 
        /// </summary>
        /// <returns></returns>
        int GetCoplayFriendCount();

        /// <summary>
        /// recently-played-with friends iteration
        /// this iterates the entire list of users recently played with, across games
        /// GetFriendCoplayTime() returns as a unix time 
        /// </summary>
        /// <param name="coplayFriend"></param>
        /// <returns></returns>
        SteamID GetCoplayFriend(int coplayFriend);

        /// <summary>
        /// recently-played-with friends iteration
        /// this iterates the entire list of users recently played with, across games
        /// GetFriendCoplayTime() returns as a unix time 
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        int GetFriendCoplayTime(SteamID steamIDFriend);

        /// <summary>
        /// recently-played-with friends iteration
        /// this iterates the entire list of users recently played with, across games
        /// GetFriendCoplayTime() returns as a unix time 
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <returns></returns>
        AppID GetFriendCoplayGame(SteamID steamIDFriend);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClan"></param>
        void JoinClanChatRoom(SteamID steamIDClan);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat 
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        bool LeaveClanChatRoom(SteamID steamIDClan);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat 
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        int GetClanChatMemberCount(SteamID steamIDClan);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        SteamID GetChatMemberByIndex(SteamID steamIDClan, int user);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        bool SendClanChatMessage(SteamID steamIDClanChat, string text);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <param name="message"></param>
        /// <param name="maxMessageSize"></param>
        /// <param name="text"></param>
        /// <param name="chatEntryType"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        int GetClanChatMessage(SteamID steamIDClanChat, int message, int maxMessageSize, out string text, out ChatEntryType chatEntryType, out SteamID sender);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <param name="message"></param>
        /// <param name="text"></param>
        /// <param name="textSize"></param>
        /// <param name="chatEntryType"></param>
        /// <param name="sender"></param>
        /// <returns></returns>
        FriendsGetClanChatMessageResult GetClanChatMessage(SteamID steamIDClanChat, int message, int maxMessageSize);

        /// <summary>
        /// chat interface for games
        /// this allows in-game access to group (clan) chats from in the game
        /// the behavior is somewhat sophisticated, because the user may or may not be already in the group chat from outside the game or in the overlay
        /// use ActivateGameOverlayToUser( "chat", steamIDClan ) to open the in-game overlay version of the chat
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <param name="steamIDUser"></param>
        /// <returns></returns>
        bool IsClanChatAdmin(SteamID steamIDClanChat, SteamID steamIDUser);

        /// <summary>
        /// interact with the Steam (game overlay / desktop)
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <returns></returns>
        bool IsClanChatWindowOpenInSteam(SteamID steamIDClanChat);

        /// <summary>
        /// interact with the Steam (game overlay / desktop)
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <returns></returns>
        bool OpenClanChatWindowInSteam(SteamID steamIDClanChat);

        /// <summary>
        /// interact with the Steam (game overlay / desktop)
        /// </summary>
        /// <param name="steamIDClanChat"></param>
        /// <returns></returns>
        bool CloseClanChatWindowInSteam(SteamID steamIDClanChat);

        /// <summary>
        /// peer-to-peer chat interception
        /// this is so you can show P2P chats inline in the game
        /// </summary>
        /// <param name="interceptEnabled"></param>
        /// <returns></returns>
        bool SetListenForFriendsMessages(bool interceptEnabled);

        /// <summary>
        /// peer-to-peer chat interception
        /// this is so you can show P2P chats inline in the game
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool ReplyToFriendMessage(SteamID steamIDFriend, string message);

        /// <summary>
        /// peer-to-peer chat interception
        /// this is so you can show P2P chats inline in the game
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="messageID"></param>
        /// <param name="text"></param>
        /// <param name="chatEntryType"></param>
        /// <returns></returns>
        int GetFriendMessage(SteamID steamIDFriend, int messageID, int maxMessageSize, out string text, out ChatEntryType chatEntryType);

        /// <summary>
        /// peer-to-peer chat interception
        /// this is so you can show P2P chats inline in the game
        /// </summary>
        /// <param name="steamIDFriend"></param>
        /// <param name="messageID"></param>
        /// <param name="text"></param>
        /// <param name="chatEntryType"></param>
        /// <returns></returns>
        FriendsGetFriendMessageResult GetFriendMessage(SteamID steamIDFriend, int messageID, int maxMessageSize);

        /// <summary>
        /// following apis
        /// </summary>
        /// <param name="steamID"></param>
        void GetFollowerCount(SteamID steamID);
        void IsFollowing(SteamID steamID);
        void EnumerateFollowingList(uint startIndex);
    }

    public struct FriendsGetClanChatMessageResult
    {
        public int Result;
        public string Text;
        public ChatEntryType ChatEntryType;
        public SteamID Sender;
    }

    public struct FriendsGetFriendGamePlayedResult
    {
        public bool Result;
        public FriendGameInfo FriendGameInfo;
    }


    public struct FriendsGetClanActivityCountsResult
    {
        public bool Result;
        public int Online;
        public int InGame;
        public int Chatting;

    }

    public struct FriendsGetFriendMessageResult
    {
        public int Result;
        public string Text;
        public ChatEntryType ChatEntryType;

    }


}

