using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class MatchmakingServers : SteamService, IMatchmakingServers
    {
        private List<Exception> bufferedExceptions;

        internal MatchmakingServers()
        {

            bufferedExceptions = new List<Exception>();
            ServerListResponse = new Dictionary<uint, MatchmakingServerListResponse>();
            PingResponse = new Dictionary<uint, MatchmakingPingResponse>();
            PlayersResponse = new Dictionary<uint, MatchmakingPlayersResponse>();
            RulesResponse = new Dictionary<uint, MatchmakingRulesResponse>();

            MatchmakingServerListResponse.Initialize();
            MatchmakingPingResponse.Initialize();
            MatchmakingPlayersResponse.Initialize();
            MatchmakingRulesResponse.Initialize();
        }

        internal Dictionary<uint, MatchmakingServerListResponse> ServerListResponse { get; private set; }
        internal Dictionary<uint, MatchmakingPingResponse> PingResponse { get; private set; }
        internal Dictionary<uint, MatchmakingPlayersResponse> PlayersResponse { get; private set; }
        internal Dictionary<uint, MatchmakingRulesResponse> RulesResponse { get; private set; }

        internal override void CheckIfUsableInternal()
        {

        }

        internal override void ReleaseManagedResources()
        {
            foreach (var item in ServerListResponse)
            {
                item.Value.LibraryShuttingDown();
            }

            foreach (var item in PingResponse)
            {
                item.Value.LibraryShuttingDown();
            }

            foreach (var item in PlayersResponse)
            {
                item.Value.LibraryShuttingDown();
            }

            foreach (var item in RulesResponse)
            {
                item.Value.LibraryShuttingDown();
            }
        }

        internal override void InvokeEvents()
        {
            foreach (var item in ServerListResponse)
            {
                item.Value.InvokeEvents();
            }

            foreach (var item in PingResponse)
            {
                item.Value.InvokeEvents();
            }

            foreach (var item in PlayersResponse)
            {
                item.Value.InvokeEvents();
            }

            foreach (var item in RulesResponse)
            {
                item.Value.InvokeEvents();
            }
        }

        internal void ReportExceptions()
        {
            foreach (var item in bufferedExceptions)
            {
                Steam.Instance.ReportException(item);
            }
            bufferedExceptions.Clear();
        }

        internal void SaveException(Exception exception)
        {
            bufferedExceptions.Add(exception);
        }

        private ServerListRequestHandle ServerRequest(ServerRequestType requestType, AppID appID,
            MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestResponse)
        {
            // Code reuse FTW!

            // Allocate an array that will hold addresses to native MatchMakingKeyValuePair objects
            using (NativeBuffer arrayBuffer = new NativeBuffer(Marshal.SizeOf(typeof(IntPtr)) * filters.Length))
            {
                NativeBuffer[] nativeObjects = new NativeBuffer[filters.Length];
                // Fill each array slot with an address to an actual object
                try
                {
                    for (int i = 0; i < filters.Length; i++)
                    {
                        // Copy the managed objects to native memory
                        NativeBuffer buffer = NativeBuffer.CopyToNative(filters[i]);
                        nativeObjects[i] = buffer;
                        // Add the native address to the array
                        Marshal.WriteInt32(arrayBuffer.UnmanagedMemory, i * Marshal.SizeOf(typeof(int)), buffer.UnmanagedMemory.ToInt32());
                    }

                    // Now do the actual request

                    switch (requestType)
                    {
                        case ServerRequestType.Internet:
                            return new ServerListRequestHandle(
                                NativeMethods.MatchmakingServers_RequestInternetServerList(appID.AsUInt32,
                                arrayBuffer.UnmanagedMemory, (uint)filters.Length, requestResponse.ObjectId));
                        case ServerRequestType.Friends:
                            return new ServerListRequestHandle(
                                NativeMethods.MatchmakingServers_RequestFriendsServerList(appID.AsUInt32,
                                arrayBuffer.UnmanagedMemory, (uint)filters.Length, requestResponse.ObjectId));
                        case ServerRequestType.Favorites:
                            return new ServerListRequestHandle(
                                NativeMethods.MatchmakingServers_RequestFavoritesServerList(appID.AsUInt32,
                                arrayBuffer.UnmanagedMemory, (uint)filters.Length, requestResponse.ObjectId));
                        case ServerRequestType.History:
                            return new ServerListRequestHandle(
                                NativeMethods.MatchmakingServers_RequestHistoryServerList(appID.AsUInt32,
                                arrayBuffer.UnmanagedMemory, (uint)filters.Length, requestResponse.ObjectId));
                        case ServerRequestType.Spectator:
                            return new ServerListRequestHandle(
                                NativeMethods.MatchmakingServers_RequestSpectatorServerList(appID.AsUInt32,
                                arrayBuffer.UnmanagedMemory, (uint)filters.Length, requestResponse.ObjectId));
                        default:
                            // This should never happen as our code can not be allowed to make this error
                            throw new ArgumentException();
                    }
                }
                finally
                {
                    // Cleanup in all cases. Exception or not.
                    foreach (var item in nativeObjects)
                    {
                        if (item != null)
                        {
                            item.Dispose();
                        }
                    }
                }
            }
        }

        public ServerListRequestHandle RequestInternetServerList(AppID appID,
            MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestServersResponse)
        {
            return ServerRequest(ServerRequestType.Internet, appID, filters, requestServersResponse);
        }

        public ServerListRequestHandle RequestLANServerList(AppID appID,
            MatchmakingServerListResponse requestServersResponse)
        {
            return new ServerListRequestHandle(NativeMethods.MatchmakingServers_RequestLANServerList(
                appID.AsUInt32, requestServersResponse.ObjectId));
        }

        public ServerListRequestHandle RequestFriendsServerList(AppID appID, MatchMakingKeyValuePair[] filters,
            MatchmakingServerListResponse requestServersResponse)
        {
            return ServerRequest(ServerRequestType.Friends, appID, filters, requestServersResponse);
        }

        public ServerListRequestHandle RequestFavoritesServerList(AppID appID, MatchMakingKeyValuePair[] filters,
            MatchmakingServerListResponse requestServersResponse)
        {
            return ServerRequest(ServerRequestType.Favorites, appID, filters, requestServersResponse);
        }

        public ServerListRequestHandle RequestHistoryServerList(AppID appID, MatchMakingKeyValuePair[] filters,
            MatchmakingServerListResponse requestServersResponse)
        {
            return ServerRequest(ServerRequestType.History, appID, filters, requestServersResponse);
        }

        public ServerListRequestHandle RequestSpectatorServerList(AppID appID, MatchMakingKeyValuePair[] filters,
            MatchmakingServerListResponse requestServersResponse)
        {
            return ServerRequest(ServerRequestType.Spectator, appID, filters, requestServersResponse);
        }

        public void ReleaseRequest(ServerListRequestHandle serverListRequest)
        {
            NativeMethods.MatchmakingServers_ReleaseRequest(serverListRequest.AsUInt32);
        }

        public GameServerItem GetServerDetails(ServerListRequestHandle request, int server)
        {
            IntPtr returnValue;
            returnValue = NativeMethods.MatchmakingServers_GetServerDetails(request.AsUInt32, server);
            return GameServerItem.Create(returnValue, NativeMethods.MatchmakingServers_GetGameServerItemSize());
        }

        public void CancelQuery(ServerListRequestHandle request)
        {
            NativeMethods.MatchmakingServers_CancelQuery(request.AsUInt32);
        }

        public void RefreshQuery(ServerListRequestHandle request)
        {
            NativeMethods.MatchmakingServers_RefreshQuery(request.AsUInt32);
        }

        public bool IsRefreshing(ServerListRequestHandle request)
        {
            return NativeMethods.MatchmakingServers_IsRefreshing(request.AsUInt32);
        }

        public int GetServerCount(ServerListRequestHandle request)
        {
            return NativeMethods.MatchmakingServers_GetServerCount(request.AsUInt32);
        }

        public void RefreshServer(ServerListRequestHandle request, int server)
        {
            NativeMethods.MatchmakingServers_RefreshServer(request.AsUInt32, server);
        }

        public ServerQueryHandle PingServer(uint ip, ushort port, MatchmakingPingResponse requestServersResponse)
        {
            return new ServerQueryHandle(NativeMethods.MatchmakingServers_PingServer(ip, port, requestServersResponse.ObjectId));
        }
        public ServerQueryHandle PlayerDetails(uint ip, ushort port, MatchmakingPlayersResponse requestServersResponse)
        {
            return new ServerQueryHandle(NativeMethods.MatchmakingServers_PlayerDetails(ip, port, requestServersResponse.ObjectId));
        }
        public ServerQueryHandle ServerRules(uint ip, ushort port, MatchmakingRulesResponse requestServersResponse)
        {
            return new ServerQueryHandle(NativeMethods.MatchmakingServers_ServerRules(ip, port, requestServersResponse.ObjectId));
        }
        public void CancelServerQuery(ServerQueryHandle serverQuery)
        {
            NativeMethods.MatchmakingServers_CancelServerQuery(serverQuery.AsInt32);
        }

        private enum ServerRequestType
        {
            Internet,
            Friends,
            Favorites,
            History,
            Spectator,
        }
    }
}
