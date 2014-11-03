using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class MatchMaking : SteamService, IMatchmaking
    {
        private List<FavoritesListChanged> favoritesListChanged;
        private List<LobbyInvite> lobbyInvite;
        private List<Result<LobbyEnter>> lobbyEnter;
        private List<LobbyDataUpdate> lobbyDataUpdate;
        private List<LobbyChatUpdate> lobbyChatUpdate;
        private List<LobbyChatMsg> lobbyChatMsg;
        private List<LobbyGameCreated> lobbyGameCreated;
        private List<Result<LobbyMatchList>> lobbyMatchList;
        private List<LobbyKicked> lobbyKicked;
        private List<Result<LobbyCreated>> lobbyCreated;


        public MatchMaking()
        {
            favoritesListChanged = new List<FavoritesListChanged>();
            lobbyInvite = new List<LobbyInvite>();

            lobbyEnter = new List<Result<LobbyEnter>>();
            lobbyDataUpdate = new List<LobbyDataUpdate>();

            lobbyChatUpdate = new List<LobbyChatUpdate>();
            lobbyChatMsg = new List<LobbyChatMsg>();

            lobbyGameCreated = new List<LobbyGameCreated>();
            lobbyMatchList = new List<Result<LobbyMatchList>>();

            lobbyKicked = new List<LobbyKicked>();
            lobbyCreated = new List<Result<LobbyCreated>>();


            Callbacks[CallbackID.FavoritesListChanged] = (data, size) => favoritesListChanged.Add(CallbackStructures.FavoritesListChanged.Create(data, size));
            Callbacks[CallbackID.LobbyInvite] = (data, size) => lobbyInvite.Add(CallbackStructures.LobbyInvite.Create(data, size));

            Results[ResultID.LobbyEnterResult] = (data, size, flag) => lobbyEnter.Add(new Result<LobbyEnter>(CallbackStructures.LobbyEnter.Create(data, size), flag));
            Callbacks[CallbackID.LobbyDataUpdate] = (data, size) => lobbyDataUpdate.Add(CallbackStructures.LobbyDataUpdate.Create(data, size));

            Callbacks[CallbackID.LobbyChatUpdate] = (data, size) => lobbyChatUpdate.Add(CallbackStructures.LobbyChatUpdate.Create(data, size));
            Callbacks[CallbackID.LobbyChatMsg] = (data, size) => lobbyChatMsg.Add(CallbackStructures.LobbyChatMsg.Create(data, size));

            Callbacks[CallbackID.LobbyGameCreated] = (data, size) => lobbyGameCreated.Add(CallbackStructures.LobbyGameCreated.Create(data, size));
            Results[ResultID.LobbyMatchList] = (data, size, flag) => lobbyMatchList.Add(new Result<LobbyMatchList>(CallbackStructures.LobbyMatchList.Create(data, size), flag));

            Callbacks[CallbackID.LobbyKicked] = (data, size) => lobbyKicked.Add(CallbackStructures.LobbyKicked.Create(data, size));
            Results[ResultID.LobbyCreated] = (data, size, flag) => lobbyCreated.Add(new Result<LobbyCreated>(CallbackStructures.LobbyCreated.Create(data, size), flag));


        }

        public event CallbackEvent<FavoritesListChanged> FavoritesListChanged;
        public event CallbackEvent<LobbyInvite> LobbyInvite;


        public event ResultEvent<LobbyEnter> LobbyEnterResult;
        public event CallbackEvent<LobbyDataUpdate> LobbyDataUpdate;

        public event CallbackEvent<LobbyChatUpdate> LobbyChatUpdate;
        public event CallbackEvent<LobbyChatMsg> LobbyChatMsg;

        public event CallbackEvent<LobbyGameCreated> LobbyGameCreated;
        public event ResultEvent<LobbyMatchList> LobbyMatchListResult;

        public event CallbackEvent<LobbyKicked> LobbyKicked;
        public event ResultEvent<LobbyCreated> LobbyCreatedResult;


        internal override void InvokeEvents()
        {
            InvokeEvents(favoritesListChanged, FavoritesListChanged);
            InvokeEvents(lobbyInvite, LobbyInvite);

            InvokeEvents(lobbyEnter, LobbyEnterResult);
            InvokeEvents(lobbyDataUpdate, LobbyDataUpdate);

            InvokeEvents(lobbyChatUpdate, LobbyChatUpdate);
            InvokeEvents(lobbyChatMsg, LobbyChatMsg);

            InvokeEvents(lobbyGameCreated, LobbyGameCreated);
            InvokeEvents(lobbyMatchList, LobbyMatchListResult);

            InvokeEvents(lobbyKicked, LobbyKicked);
            InvokeEvents(lobbyCreated, LobbyCreatedResult);
        }

        internal override void ReleaseManagedResources()
        {
            lobbyMatchList = null;
            LobbyMatchListResult = null;

            lobbyCreated = null;
            LobbyCreatedResult = null;

            lobbyEnter = null;
            LobbyEnterResult = null;

            lobbyChatMsg = null;
            LobbyChatMsg = null;
        }

        internal override void CheckIfUsableInternal()
        {

        }

        public int GetFavoriteGameCount()
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_GetFavoriteGameCount();
        }

        public bool GetFavoriteGame(int game, out AppID appID, out uint ip, out ushort connPort, out ushort port, out uint flags, out uint time32LastPlayedOnServer)
        {
            CheckIfUsable();
            ip = 0;
            connPort = 0;
            port = 0;
            flags = 0;
            time32LastPlayedOnServer = 0;
            uint localAppID = 0;
            bool returnValue = NativeMethods.MatchMaking_GetFavoriteGame(game, ref localAppID, ref ip, ref connPort, ref port, ref flags, ref time32LastPlayedOnServer);
            appID = new AppID(localAppID);
            return returnValue;
        }

        public MatchMakingGetFavoriteGameResult GetFavoriteGame(int game)
        {
            MatchMakingGetFavoriteGameResult result = new MatchMakingGetFavoriteGameResult();
            result.Result = GetFavoriteGame(game, out result.AppID, out result.IP, out result.ConnPort, out result.Port, out result.Flags, out result.Time32LastPlayedOnServer);
            return result;
        }

        public int AddFavoriteGame(AppID appID, uint ip, ushort connPort, ushort queryPort, uint flags, uint time32LastPlayedOnServer)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_AddFavoriteGame(appID.AsUInt32, ip, connPort, queryPort, flags, time32LastPlayedOnServer);
        }

        public bool RemoveFavoriteGame(AppID appID, uint ip, ushort connPort, ushort queryPort, uint flags)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_RemoveFavoriteGame(appID.AsUInt32, ip, connPort, queryPort, flags);
        }

        public void RequestLobbyList()
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_RequestLobbyList();
        }

        public void AddRequestLobbyListStringFilter(string keyToMatch, string valueToMatch, LobbyComparison comparisonType)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListStringFilter(keyToMatch, valueToMatch, (int)comparisonType);
        }

        public void AddRequestLobbyListNumericalFilter(string keyToMatch, int valueToMatch, LobbyComparison comparisonType)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListNumericalFilter(keyToMatch, valueToMatch, (int)comparisonType);
        }

        public void AddRequestLobbyListNearValueFilter(string keyToMatch, int valueToBeCloseTo)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListNearValueFilter(keyToMatch, valueToBeCloseTo);
        }

        public void AddRequestLobbyListFilterSlotsAvailable(int slotsAvailable)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListFilterSlotsAvailable(slotsAvailable);
        }

        public void AddRequestLobbyListDistanceFilter(LobbyDistanceFilter lobbyDistanceFilter)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListDistanceFilter((int)lobbyDistanceFilter);
        }

        public void AddRequestLobbyListResultCountFilter(int maxResults)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListResultCountFilter(maxResults);
        }

        public void AddRequestLobbyListCompatibleMembersFilter(SteamID steamIDLobby)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_AddRequestLobbyListCompatibleMembersFilter(steamIDLobby.AsUInt64);
        }

        public SteamID GetLobbyByIndex(int lobby)
        {
            CheckIfUsable();
            return new SteamID(NativeMethods.MatchMaking_GetLobbyByIndex(lobby));
        }

        public void CreateLobby(LobbyType lobbyType, int maxMembers)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_CreateLobby((int)lobbyType, maxMembers);
        }

        public void JoinLobby(SteamID steamIDLobby)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_JoinLobby(steamIDLobby.AsUInt64);
        }

        public void LeaveLobby(SteamID steamIDLobby)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_LeaveLobby(steamIDLobby.AsUInt64);
        }

        public bool InviteUserToLobby(SteamID steamIDLobby, SteamID steamIDInvitee)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_InviteUserToLobby(steamIDLobby.AsUInt64, steamIDInvitee.AsUInt64);
        }

        public int GetNumLobbyMembers(SteamID steamIDLobby)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_GetNumLobbyMembers(steamIDLobby.AsUInt64);
        }

        public SteamID GetLobbyMemberByIndex(SteamID steamIDLobby, int member)
        {
            CheckIfUsable();
            return new SteamID(NativeMethods.MatchMaking_GetLobbyMemberByIndex(steamIDLobby.AsUInt64, member));
        }

        public string GetLobbyData(SteamID steamIDLobby, string key)
        {
            CheckIfUsable();
            return NativeHelpers.ToStringAnsi(NativeMethods.MatchMaking_GetLobbyData(steamIDLobby.AsUInt64, key));
        }

        public bool SetLobbyData(SteamID steamIDLobby, string key, string value)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyData(steamIDLobby.AsUInt64, key, value);
        }

        public int GetLobbyDataCount(SteamID steamIDLobby)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_GetLobbyDataCount(steamIDLobby.AsUInt64);
        }

        public bool GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData, out string key, out string value)
        {
            CheckIfUsable();

            using (NativeBuffer bufferKey = new NativeBuffer(Constants.Matchmaking.MaxLobbyKeyLength))
            {
                using (NativeBuffer bufferValue = new NativeBuffer(Constants.Matchmaking.MaxLobbyValueLength))
                {
                    bool result = NativeMethods.MatchMaking_GetLobbyDataByIndex(steamIDLobby.AsUInt64,
                        lobbyData, bufferKey.UnmanagedMemory, bufferKey.UnmanagedSize,
                        bufferValue.UnmanagedMemory, bufferValue.UnmanagedSize);

                    key = NativeHelpers.ToStringAnsi(bufferKey.UnmanagedMemory);
                    value = NativeHelpers.ToStringAnsi(bufferValue.UnmanagedMemory);
                    return result;
                }
            }
        }

        public MatchMakingGetLobbyDataByIndexResult GetLobbyDataByIndex(SteamID steamIDLobby, int lobbyData)
        {
            MatchMakingGetLobbyDataByIndexResult result = new MatchMakingGetLobbyDataByIndexResult();
            result.Result = GetLobbyDataByIndex(steamIDLobby, lobbyData, out result.Key, out result.Value);
            return result;
        }

        public bool DeleteLobbyData(SteamID steamIDLobby, string key)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_DeleteLobbyData(steamIDLobby.AsUInt64, key);
        }

        public string GetLobbyMemberData(SteamID steamIDLobby, SteamID steamIDUser, string key)
        {
            CheckIfUsable();
            return NativeHelpers.ToStringAnsi(NativeMethods.MatchMaking_GetLobbyMemberData(steamIDLobby.AsUInt64, steamIDUser.AsUInt64, key));
        }

        public void SetLobbyMemberData(SteamID steamIDLobby, string key, string value)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_SetLobbyMemberData(steamIDLobby.AsUInt64, key, value);
        }

        public bool SendLobbyChatMsg(SteamID steamIDLobby, byte[] msgBody)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(msgBody))
            {
                buffer.WriteToUnmanagedMemory();
                return NativeMethods.MatchMaking_SendLobbyChatMsg(steamIDLobby.AsUInt64, buffer.UnmanagedMemory, buffer.UnmanagedSize);
            }
        }

        public int GetLobbyChatEntry(SteamID steamIDLobby, int chatID, out SteamID steamIDUser, byte[] data, out ChatEntryType chatEntryType)
        {
            CheckIfUsable();
            ulong rawCreator = 0;
            int chatEntryTemp = 0;

            using (NativeBuffer buffer = new NativeBuffer(data))
            {
                int result = NativeMethods.MatchMaking_GetLobbyChatEntry(steamIDLobby.AsUInt64, chatID, ref rawCreator, buffer.UnmanagedMemory, buffer.UnmanagedSize, ref chatEntryTemp);
                buffer.ReadFromUnmanagedMemory(result);

                steamIDUser = new SteamID(rawCreator);
                chatEntryType = (ChatEntryType)chatEntryTemp;
                return result;
            }
        }

        public MatchmakingGetLobbyChatEntryResult GetLobbyChatEntry(SteamID steamIDLobby, int chatID, byte[] data)
        {
            MatchmakingGetLobbyChatEntryResult result = new MatchmakingGetLobbyChatEntryResult();
            result.Result = GetLobbyChatEntry(steamIDLobby, chatID, out result.SteamIDUser, data, out result.ChatEntryType);
            return result;
        }

        void IMatchmaking.SetLobbyGameServer(SteamID steamIDLobby, uint gameServerIP, ushort gameServerPort, SteamID steamIDGameServer)
        {
            CheckIfUsable();
            NativeMethods.MatchMaking_SetLobbyGameServer(steamIDLobby.AsUInt64, gameServerIP, gameServerPort, steamIDGameServer.AsUInt64);
        }

        public bool GetLobbyGameServer(SteamID steamIDLobby, out uint gameServerIP, out ushort gameServerPort, out SteamID steamIDGameServer)
        {
            CheckIfUsable();

            gameServerIP = 0;
            gameServerPort = 0;
            ulong rawCreator = 0;

            bool result = NativeMethods.MatchMaking_GetLobbyGameServer(steamIDLobby.AsUInt64, ref gameServerIP, ref gameServerPort, ref  rawCreator);

            steamIDGameServer = new SteamID(rawCreator);
            return result;
        }

        public MatchMakingGetLobbyGameServerResult GetLobbyGameServer(SteamID steamIDLobby)
        {
            MatchMakingGetLobbyGameServerResult result = new MatchMakingGetLobbyGameServerResult();
            result.Result = GetLobbyGameServer(steamIDLobby, out result.GameServerIP, out result.GameServerPort, out result.SteamIDGameServer);
            return result;
        }

        public bool SetLobbyMemberLimit(SteamID steamIDLobby, int maxMembers)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyMemberLimit(steamIDLobby.AsUInt64, maxMembers);
        }

        public int GetLobbyMemberLimit(SteamID steamIDLobby)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_GetLobbyMemberLimit(steamIDLobby.AsUInt64);
        }

        public bool SetLobbyType(SteamID steamIDLobby, LobbyType lobbyType)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyType(steamIDLobby.AsUInt64, (int)lobbyType);
        }

        public bool SetLobbyJoinable(SteamID steamIDLobby, bool lobbyJoinable)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyJoinable(steamIDLobby.AsUInt64, lobbyJoinable);
        }

        public SteamID GetLobbyOwner(SteamID steamIDLobby)
        {
            CheckIfUsable();
            return new SteamID(NativeMethods.MatchMaking_GetLobbyOwner(steamIDLobby.AsUInt64));
        }

        public bool SetLobbyOwner(SteamID steamIDLobby, SteamID steamIDNewOwner)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyOwner(steamIDLobby.AsUInt64, steamIDNewOwner.AsUInt64);
        }

        public bool SetLinkedLobby(SteamID steamIDLobby, SteamID steamIDLobbyDependent)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_SetLobbyOwner(steamIDLobby.AsUInt64, steamIDLobbyDependent.AsUInt64);
        }

        public bool RequestLobbyData(SteamID steamIDLobby)
        {
            CheckIfUsable();
            return NativeMethods.MatchMaking_RequestLobbyData(steamIDLobby.AsUInt64);
        }
    }
}
