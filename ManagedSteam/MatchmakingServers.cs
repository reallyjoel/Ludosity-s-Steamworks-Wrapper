using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IMatchmakingServers
    {
        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="filters"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestInternetServerList(AppID appID, MatchMakingKeyValuePair[] filters,
            MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestLANServerList(AppID appID, MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="filters"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestFriendsServerList(AppID appID, MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="filters"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestFavoritesServerList(AppID appID, MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="filters"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestHistoryServerList(AppID appID, MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Request a new list of servers of the interney type. 
        /// Each call allocates a new asynchronous request object.
        /// Request object must be released by calling ReleaseRequest( hServerListRequest )
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="filters"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerListRequestHandle RequestSpectatorServerList(AppID appID, MatchMakingKeyValuePair[] filters, MatchmakingServerListResponse requestServersResponse);

        /// <summary>
        /// Releases the asynchronous request object and cancels any pending query on it if there's a pending query in progress.
        /// RefreshComplete callback is not posted when request is released.
        /// </summary>
        /// <param name="serverListRequest"></param>
        void ReleaseRequest(ServerListRequestHandle serverListRequest);

        /// <summary>
        /// Get details on a given server in the list, you can get the valid range of index
        /// values by calling GetServerCount().  You will also receive index values in 
        /// ISteamMatchmakingServerListResponse::ServerResponded() callbacks
        /// </summary>
        /// <param name="request"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        GameServerItem GetServerDetails(ServerListRequestHandle request, int server);


        /// <summary>
        /// Cancel an request which is operation on the given list type.  You should call this to cancel
        /// any in-progress requests before destructing a callback object that may have been passed 
        /// to one of the above list request calls.  Not doing so may result in a crash when a callback
        /// occurs on the destructed object.
        /// Canceling a query does not release the allocated request handle.
        /// The request handle must be released using ReleaseRequest( hRequest )
        /// </summary>
        /// <param name="request"></param>
        void CancelQuery(ServerListRequestHandle request);

        /// <summary>
        /// Ping every server in your list again but don't update the list of servers
        /// Query callback installed when the server list was requested will be used
        /// again to post notifications and RefreshComplete, so the callback must remain
        /// valid until another RefreshComplete is called on it or the request
        /// is released with ReleaseRequest( hRequest )
        /// </summary>
        /// <param name="request"></param>
        void RefreshQuery(ServerListRequestHandle request);
        bool IsRefreshing(ServerListRequestHandle request);
        int GetServerCount(ServerListRequestHandle request);
        void RefreshServer(ServerListRequestHandle request, int server);

        /// <summary>
        /// Request updated ping time and other details from a single server
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerQueryHandle PingServer(uint ip, ushort port, MatchmakingPingResponse requestServersResponse);

        /// <summary>
        /// Request the list of players currently playing on a server
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerQueryHandle PlayerDetails(uint ip, ushort port, MatchmakingPlayersResponse requestServersResponse);

        /// <summary>
        /// Request the list of rules that the server is running (See ISteamGameServer::SetKeyValue() to set the rules server side)
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="requestServersResponse"></param>
        /// <returns></returns>
        ServerQueryHandle ServerRules(uint ip, ushort port, MatchmakingRulesResponse requestServersResponse);

        /// <summary>
        /// Cancel an outstanding Ping/Players/Rules query from above.  You should call this to cancel
        /// any in-progress requests before destructing a callback object that may have been passed 
        /// to one of the above calls to avoid crashing when callbacks occur.
        /// </summary>
        /// <param name="hServerQuery"></param>
        void CancelServerQuery(ServerQueryHandle serverQuery);
    }
}
