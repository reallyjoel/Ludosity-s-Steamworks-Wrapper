using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;
using ManagedSteam.CallbackStructures;

namespace ManagedSteam
{
    /// <summary>
    /// Functions for match making services for clients to get to favorites
    ///	and to operate on game lobbies.
    /// </summary>
    public interface IMatchmaking
    {
        event CallbackEvent<FavoritesListChanged> FavoritesListChanged;
        event CallbackEvent<LobbyInvite> LobbyInvite;
        event ResultEvent<LobbyEnter> LobbyEnterResult;
        event CallbackEvent<LobbyDataUpdate> LobbyDataUpdate;
        event CallbackEvent<LobbyChatUpdate> LobbyChatUpdate;
        event CallbackEvent<LobbyChatMsg> LobbyChatMsg;
        event CallbackEvent<LobbyGameCreated> LobbyGameCreated;
        event ResultEvent<LobbyMatchList> LobbyMatchListResult;
        event CallbackEvent<LobbyKicked> LobbyKicked;
        event ResultEvent<LobbyCreated> LobbyCreatedResult;


        /// <summary>
        /// returns the number of favorites servers the user has store
        /// </summary>
        /// <returns></returns>
        int GetFavoriteGameCount();
        /// <summary>
        /// returns the details of the game server
        /// iGame is of range [0,GetFavoriteGameCount())
        /// *pnIP, *pnConnPort are filled in the with IP:port of the game server
        /// *punFlags specify whether the game server was stored as an explicit favorite or in the history of connections
        /// *pRTime32LastPlayedOnServer is filled in the with the Unix time the favorite was added
        /// </summary>
        bool GetFavoriteGame(int game, out AppID appID, out uint ip, out ushort connPort, out ushort port, out uint flags, out uint time32LastPlayedOnServer);

        /// <summary>
        /// returns the details of the game server
        /// iGame is of range [0,GetFavoriteGameCount())
        /// </summary>
        MatchMakingGetFavoriteGameResult GetFavoriteGame(int game);

        /// <summary>
        /// adds the game server to the local list; updates the time played of the server if it already exists in the list
        /// </summary>
        int AddFavoriteGame(AppID appID, uint ip, ushort connPort, ushort queryPort, uint flags, uint time32LastPlayedOnServer);

        /// <summary>
        /// removes the game server from the local storage; returns true if one was removed
        /// </summary>
        bool RemoveFavoriteGame(AppID appID, uint ip, ushort connPort, ushort queryPort, uint flags);


        /// <summary>
        /// Get a list of relevant lobbies
        /// this is an asynchronous request
        /// results will be returned by LobbyMatchList_t callback and call result, with the number of lobbies found
        /// this will never return lobbies that are full
        /// to add more filter, the filter calls below need to be call before each and every RequestLobbyList() call
        /// use the CCallResult object in steam_api.h to match the SteamAPICall_t call result to a function in an object, e.g.
        /// </summary>
        void RequestLobbyList();

        /// <summary>
        /// filters for lobbies
        /// this needs to be called before RequestLobbyList() to take effect
        /// these are cleared on each call to RequestLobbyList()
        /// </summary>
        void AddRequestLobbyListStringFilter(string keyToMatch, string valueToMatch, LobbyComparison comparisonType);

        /// <summary>
        /// numerical comparison
        /// </summary>
        /// <param name="KeyToMatch"></param>
        /// <param name="ValueToMatch"></param>
        /// <param name="comparisonType"></param>
        void AddRequestLobbyListNumericalFilter(string keyToMatch, int valueToMatch, LobbyComparison comparisonType);

        /// <summary>
        /// returns results closest to the specified value. Multiple near filters can be added, with early filters taking precedence
        /// </summary>
        void AddRequestLobbyListNearValueFilter(string keyToMatch, int valueToBeCloseTo);

        /// <summary>
        /// returns only lobbies with the specified number of slots available
        /// </summary>
        void AddRequestLobbyListFilterSlotsAvailable(int slotsAvailable);

        /// <summary>
        /// sets the distance for which we should search for lobbies (based on users IP address to location map on the Steam backed)
        /// </summary>
        void AddRequestLobbyListDistanceFilter(LobbyDistanceFilter lobbyDistanceFilter);

        /// <summary>
        /// sets how many results to return, the lower the count the faster it is to download the lobby results and details to the client
        /// </summary>
        void AddRequestLobbyListResultCountFilter(int maxResults);

        /// <summary>
        /// returns the CSteamID of a lobby, as retrieved by a RequestLobbyList call
        /// should only be called after a LobbyMatchList_t callback is received
        /// iLobby is of the range [0, LobbyMatchList_t::m_nLobbiesMatching)
        /// the returned CSteamID::IsValid() will be false if iLobby is out of range
        /// </summary>
        void AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby);

        /// <summary>
        /// returns the CSteamID of a lobby, as retrieved by a RequestLobbyList call
        /// should only be called after a LobbyMatchList_t callback is received
        /// iLobby is of the range [0, LobbyMatchList_t::m_nLobbiesMatching)
        /// the returned CSteamID::IsValid() will be false if iLobby is out of range
        /// </summary>
        /// <param name="lobby"></param>
        /// <returns></returns>
        SteamID GetLobbyByIndex(int lobby);

        /// <summary>
        /// Create a lobby on the Steam servers.
        /// If private, then the lobby will not be returned by any RequestLobbyList() call; the CSteamID
        /// of the lobby will need to be communicated via game channels or via InviteUserToLobby()
        /// this is an asynchronous request. 
        /// Results will be returned by LobbyCreated_t callback and call result.
        /// Lobby is joinable and ready to use at this point.
        /// a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)
        /// </summary>
        /// <param name="lobbyType"></param>
        /// <param name="maxMembers"></param>
        void CreateLobby(LobbyType lobbyType, int maxMembers);


        /// <summary>
        /// Joins an existing lobby
        /// this is an asynchronous request
        /// results will be returned by LobbyEnter_t callback and call result, check m_EChatRoomEnterResponse to see if was successful
        /// lobby metadata is available to use immediately on this call completing
        /// </summary>
        /// <param name="steamIDLobby"></param>
        void JoinLobby(SteamID steamIDLobby);

        /// <summary>
        /// eave a lobby; this will take effect immediately on the client side
        /// other users in the lobby will be notified by a LobbyChatUpdate_t callback
        /// </summary>
        /// <param name="steamIDLobby"></param>
        void LeaveLobby(SteamID steamIDLobby);

        /// <summary>
        /// Invite another user to the lobby
        /// the target user will receive a LobbyInvite_t callback
        /// will return true if the invite is successfully sent, whether or not the target responds
        /// returns false if the local user is not connected to the Steam servers
        /// if the other user clicks the join link, a GameLobbyJoinRequested_t will be posted if the user is in-game,
        /// or if the game isn't running yet the game will be launched with the parameter +connect_lobby (64-bit lobby id)
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="steamIDInvitee"></param>
        /// <returns></returns>
        bool InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee);

        /// <summary>
        /// returns the number of users in the specified lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <returns></returns>
        int GetNumLobbyMembers(SteamID steamIDLobby);

        /// <summary>
        /// returns the CSteamID of a user in the lobby
        /// iMember is of range [0,GetNumLobbyMembers())
        /// note that the current user must be in a lobby to retrieve CSteamIDs of other users in that lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        SteamID GetLobbyMemberByIndex(SteamID steamIDLobby, int member);

        /// <summary>
        /// Get data associated with this lobby
        /// takes a simple key, and returns the string associated with it
        /// "" will be returned if no value is set, or if steamIDLobby is invalid
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetLobbyData(SteamID steamIDLobby, string key);

        /// <summary>
        ///Sets a key/value pair in the lobby metadata
        /// each user in the lobby will be broadcast this new value, and any new users joining will receive any existing data
        /// this can be used to set lobby names, map, etc.
        /// to reset a key, just set it to ""
        /// other users in the lobby will receive notification of the lobby data change via a LobbyDataUpdate_t callback
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool SetLobbyData(SteamID steamIDLobby, string key, string value);

        /// <summary>
        /// returns the number of metadata keys set on the specified lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <returns></returns>
        int GetLobbyDataCount(SteamID steamIDLobby);

        /// <summary>
        /// returns a lobby metadata key/values pair by index, of range [0, GetLobbyDataCount())
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="lobbyData"></param>
        /// <param name="key"></param>
        /// <param name="keyBufferSize"></param>
        /// <param name="value"></param>
        /// <param name="valueBufferSize"></param>
        /// <returns></returns>
        bool GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData, out string key, out string value);


        /// <summary>
        /// returns a lobby metadata key/values pair by index, of range [0, GetLobbyDataCount())
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="lobbyData"></param>
        /// <param name="key"></param>
        /// <param name="keyBufferSize"></param>
        /// <param name="value"></param>
        /// <param name="valueBufferSize"></param>
        /// <returns></returns>
        MatchMakingGetLobbyDataByIndexResult GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData);

        /// <summary>
        /// removes a metadata key from the lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        bool DeleteLobbyData(SteamID steamIDLobby, string key);

        /// <summary>
        /// Gets per-user metadata for someone in this lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="steamIDUser"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetLobbyMemberData(SteamID steamIDLobby, SteamID steamIDUser, string key);

        /// <summary>
        ///  Sets per-user metadata (for the local user implicitly)
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetLobbyMemberData(SteamID steamIDLobby, string key, string value);

        /// <summary>
        /// Broadcasts a chat message to the all the users in the lobby
        /// users in the lobby (including the local user) will receive a LobbyChatMsg_t callback
        /// returns true if the message is successfully sent
        /// pvMsgBody can be binary or text data, up to 4k
        /// if pvMsgBody is text, cubMsgBody should be strlen( text ) + 1, to include the null terminator
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="msgBody"></param>
        /// <returns></returns>
        bool SendLobbyChatMsg(SteamID steamIDLobby, byte[] msgBody);

        /// <summary>
        ///Refreshes metadata for a lobby you're not necessarily in right now
        /// you never do this for lobbies you're a member of, only if your
        /// this will send down all the metadata associated with a lobby
        /// this is an asynchronous call
        /// returns false if the local user is not connected to the Steam servers
        /// results will be returned by a LobbyDataUpdate_t callback
        /// if the specified lobby doesn't exist, LobbyDataUpdate_t::m_bSuccess will be set to false
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="chatID"></param>
        /// <param name="steamIDUser"></param>
        /// <param name="data"></param>
        /// <param name="chatEntryType"></param>
        /// <returns></returns>
        int GetLobbyChatEntry(SteamID steamIDLobby, int chatID, out SteamID steamIDUser, byte[] data, out ChatEntryType chatEntryType);

        MatchmakingGetLobbyChatEntryResult GetLobbyChatEntry(SteamID steamIDLobby, int chatID, byte[] data);

        /// <summary>
        /// Refreshes metadata for a lobby you're not necessarily in right now
        /// you never do this for lobbies you're a member of, only if your
        /// this will send down all the metadata associated with a lobby
        /// this is an asynchronous call
        /// returns false if the local user is not connected to the Steam servers
        /// results will be returned by a LobbyDataUpdate_t callback
        /// if the specified lobby doesn't exist, LobbyDataUpdate_t::m_bSuccess will be set to false
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <returns></returns>
        bool RequestLobbyData(SteamID steamIDLobby);

        /// <summary>
        /// sets the game server associated with the lobby
        /// usually at this point, the users will join the specified game server
        /// either the IP/Port or the steamID of the game server has to be valid, depending on how you want the clients to be able to connect
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="gameServerIP"></param>
        /// <param name="gameServerPort"></param>
        /// <param name="steamIDGameServer"></param>
        void SetLobbyGameServer(SteamID steamIDLobby, uint gameServerIP, ushort gameServerPort, SteamID steamIDGameServer);

        /// <summary>
        /// returns the details of a game server set in a lobby - returns false if there is no game server set, or that lobby doesn't exist
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="gameServerIP"></param>
        /// <param name="gameServerPort"></param>
        /// <param name="steamIDGameServer"></param>
        /// <returns></returns>
        bool GetLobbyGameServer(SteamID steamIDLobby, out uint gameServerIP, out ushort gameServerPort, out SteamID steamIDGameServer);

        /// <summary>
        /// returns the details of a game server set in a lobby - returns false if there is no game server set, or that lobby doesn't exist
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="gameServerIP"></param>
        /// <param name="gameServerPort"></param>
        /// <param name="steamIDGameServer"></param>
        /// <returns></returns>
        MatchMakingGetLobbyGameServerResult GetLobbyGameServer(SteamID steamIDLobby);

        /// <summary>
        /// set the limit on the # of users who can join the lobby
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="maxMembers"></param>
        /// <returns></returns>
        bool SetLobbyMemberLimit(SteamID steamIDLobby, int maxMembers);

        /// <summary>
        /// returns the current limit on the # of users who can join the lobby; returns 0 if no limit is defined
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <returns></returns>
        int GetLobbyMemberLimit(SteamID steamIDLobby);

        /// <summary>
        /// updates which type of lobby it is
        /// only lobbies that are k_ELobbyTypePublic or k_ELobbyTypeInvisible, and are set to joinable, will be returned by RequestLobbyList() calls
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="lobbyType"></param>
        /// <returns></returns>
        bool SetLobbyType(SteamID steamIDLobby, LobbyType lobbyType);


        /// <summary>
        /// sets whether or not a lobby is joinable - defaults to true for a new lobby
        /// if set to false, no user can join, even if they are a friend or have been invited
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="lobbyJoinable"></param>
        /// <returns></returns>
        bool SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable);

        /// <summary>
        /// returns the current lobby owner
        /// you must be a member of the lobby to access this
        /// there always one lobby owner - if the current owner leaves, another user will become the owner
        /// it is possible (bur rare) to join a lobby just as the owner is leaving, thus entering a lobby with self as the owner
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <returns></returns>
        SteamID GetLobbyOwner(SteamID steamIDLobby);


        /// <summary>
        /// changes who the lobby owner is
        /// you must be the lobby owner for this to succeed, and steamIDNewOwner must be in the lobby
        /// after completion, the local user will no longer be the owner
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="steamIDNewOwner"></param>
        /// <returns></returns>
        bool SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner);

        /// <summary>
        /// Link two lobbies for the purposes of checking player compatibility
        /// you must be the lobby owner of both lobbies
        /// </summary>
        /// <param name="steamIDLobby"></param>
        /// <param name="steamIDLobbyDependent"></param>
        /// <returns></returns>
        bool SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent);
    }

    public struct MatchMakingGetFavoriteGameResult
    {
        public bool Result;
        public AppID AppID;
        public uint IP;
        public ushort ConnPort;
        public ushort Port;
        public uint Flags;
        public uint Time32LastPlayedOnServer;

    }

    public struct MatchMakingGetLobbyDataByIndexResult
    {
        public bool Result;
        public string Key;
        public string Value;
    }

    public struct MatchmakingGetLobbyChatEntryResult
    {
        public int Result;
        public SteamID SteamIDUser;
        public ChatEntryType ChatEntryType;
    }

    public struct MatchMakingGetLobbyGameServerResult
    {
        public bool Result;
        public uint GameServerIP;
        public ushort GameServerPort;
        public SteamID SteamIDGameServer;
    }

}
