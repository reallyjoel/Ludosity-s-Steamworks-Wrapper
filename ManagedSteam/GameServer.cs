using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;
using ManagedSteam.CallbackStructures;

namespace ManagedSteam
{
    /// <summary>
    /// Purpose: interface to steam for game servers
    /// </summary>
    public interface IGameServer
    {
        event CallbackEvent<SteamServersConnected> SteamServersConnected;
        event CallbackEvent<SteamServerConnectFailure> SteamServerConnectFailure;
        event CallbackEvent<SteamServersDisconnected> SteamServersDisconnected;
        event CallbackEvent<ValidateAuthTicketResponse> ValidateAuthTicketResponse;


        event CallbackEvent<GSClientApprove> GSClientApprove;
        event CallbackEvent<GSClientDeny> GSClientDeny;
        event CallbackEvent<GSClientKick> GSClientKick;
        event CallbackEvent<GSClientAchievementStatus> GSClientAchievementStatus;
        event CallbackEvent<GSPolicyResponse> GSPolicyResponse;
        event CallbackEvent<GSGameplayStats> GSGameplayStats;
        event CallbackEvent<GSClientGroupStatus> GSClientGroupStatus;

        event ResultEvent<GSReputation> GSReputation;
        event ResultEvent<AssociateWithClanResult> AssociateWithClanResult;
        event ResultEvent<ComputeNewPlayerCompatibilityResult> ComputeNewPlayerCompatibilityResult;

        /// <summary>
        /// This is called by SteamGameServer_Init, and you will usually not need to call it directly
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="gamePort"></param>
        /// <param name="queryPort"></param>
        /// <param name="flags"></param>
        /// <param name="gameAppId"></param>
        /// <param name="versionString"></param>
        /// <returns></returns>
        bool InitGameServer(uint ip, ushort gamePort, ushort queryPort, uint flags, AppID gameAppId, string versionString);

        /// <summary>
        /// Game product identifier.  This is currently used by the master server for version checking purposes.
        /// It's a required field, but will eventually will go away, and the AppID will be used for this purpose.
        /// </summary>
        /// <param name="product"></param>
        void SetProduct(string product);

        /// <summary>
        /// Description of the game.  This is a required field and is displayed in the steam server browser....for now.
        /// This is a required field, but it will go away eventually, as the data should be determined from the AppID.
        /// </summary>
        /// <param name="gameDescription"></param>
        void SetGameDescription(string gameDescription);

        /// <summary>
        /// If your game is a "mod," pass the string that identifies it.  The default is an empty string, meaning
        /// this application is the original game, not a mod.
        /// @see k_cbMaxGameServerGameDir
        /// </summary>
        /// <param name="modDir"></param>
        void SetModDir(string modDir);

        /// Is this is a dedicated server?  The default value is false.
        void SetDedicatedServer(bool dedicated);

        /// <summary>
        /// Begin process to login to a persistent game server account
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="password"></param>
        void LogOn(string accountName, string password);

        /// <summary>
        /// Login to a generic, anonymous account.
        ///
        /// Note: in previous versions of the SDK, this was automatically called within SteamGameServer_Init,
        /// but this is no longer the case.
        /// </summary>
        void LogOnAnonymous();

        /// <summary>
        /// Begin process of logging game server out of steam
        /// </summary>
        void LogOff();

        /// <summary>
        /// Status function
        /// </summary>
        /// <returns></returns>
        bool LoggedOn();

        /// <summary>
        /// Status function
        /// </summary>
        /// <returns></returns>
        bool Secure();

        /// <summary>
        /// Status function
        /// </summary>
        /// <returns></returns>
        SteamID GetSteamID();

        /// <summary>
        /// Returns true if the master server has requested a restart.
        /// Only returns true once per request.
        /// </summary>
        /// <returns></returns>
        bool WasRestartRequested();

        /// <summary>
        /// Max player count that will be reported to server browser and client queries
        /// </summary>
        /// <param name="playersMax"></param>
        void SetMaxPlayerCount(int playersMax);

        /// <summary>
        /// Number of bots.  Default value is zero
        /// </summary>
        /// <param name="botplayers"></param>
        void SetBotPlayerCount(int botPlayers);

        /// <summary>
        /// Set the name of server as it will appear in the server browser
        /// </summary>
        /// <param name="serverName"></param>
        void SetServerName(string serverName);

        /// <summary>
        /// Set name of map to report in the server browser
        /// </summary>
        /// <param name="mapName"></param>
        void SetMapName(string mapName);

        /// <summary>
        /// Let people know if your server will require a password
        /// </summary>
        /// <param name="passwordProtected"></param>
        void SetPasswordProtected(bool passwordProtected);

        /// <summary>
        /// Spectator server.  The default value is zero, meaning the service
        /// is not used.
        /// </summary>
        /// <param name="spectatorPort"></param>
        void SetSpectatorPort(ushort spectatorPort);

        /// <summary>
        /// Name of the spectator server.  (Only used if spectator port is nonzero.)
        /// </summary>
        /// <param name="spectatorServerName"></param>
        void SetSpectatorServerName(string spectatorServerName);

        /// <summary>
        /// Call this to clear the whole list of key/values that are sent in rules queries.
        /// </summary>
        void ClearAllKeyValues();

        /// <summary>
        /// Call this to add/update a key/value pair.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void SetKeyValue(string key, string value);

        /// <summary>
        /// Sets a string defining the "gametags" for this server, this is optional, but if it is set
        /// it allows users to filter in the matchmaking/server-browser interfaces based on the value
        /// 
        /// \see Constants.Matchmaking.MaxGameServerTags
        /// </summary>
        /// <param name="gameTags"></param>
        void SetGameTags(string gameTags);

        /// <summary>
        /// Sets a string defining the "gamedata" for this server, this is optional, but if it is set
        /// it allows users to filter in the matchmaking/server-browser interfaces based on the value
        /// don't set this unless it actually changes, its only uploaded to the master once (when
        /// acknowledged)
        /// </summary>
        /// <param name="gameData"></param>
        void SetGameData(string gameData);

        /// <summary>
        /// Region identifier.  This is an optional field, the default value is empty, meaning the "world" region
        /// </summary>
        /// <param name="region"></param>
        void SetRegion(string region);

        /// <summary>
        /// Handles receiving a new connection from a Steam user.  This call will ask the Steam
        /// servers to validate the users identity, app ownership, and VAC status.  If the Steam servers 
        /// are off-line, then it will validate the cached ticket itself which will validate app ownership 
        /// and identity.  The AuthBlob here should be acquired on the game client using SteamUser()->InitiateGameConnection()
        /// and must then be sent up to the game server for authentication.
        ///
        /// Return Value: returns true if the users ticket passes basic checks. pSteamIDUser will contain the Steam ID of this user. pSteamIDUser must NOT be NULL
        /// If the call succeeds then you should expect a GSClientApprove_t or GSClientDeny_t callback which will tell you whether authentication
        /// for the user has succeeded or failed (the steamid in the callback will match the one returned by this call)
        /// </summary>
        /// <returns></returns>
        bool SendUserConnectAndAuthenticate(uint ipClient, byte[] authenticationBlob, out SteamID steamIDUser);

        GameServerSendUserConnectAndAuthenticateResult SendUserConnectAndAuthenticate(uint ipClient, byte[] authenticationBlob);


        /// <summary>
        ///Creates a fake user (ie, a bot) which will be listed as playing on the server, but skips validation.  
        /// 
        /// Return Value: Returns a SteamID for the user to be tracked with, you should call HandleUserDisconnect()
        /// when this user leaves the server just like you would for a real user.
        /// </summary>
        /// <returns></returns>
        SteamID CreateUnauthenticatedUserConnection();

        /// <summary>
        /// Should be called whenever a user leaves our game server, this lets Steam internally
        /// track which users are currently on which servers for the purposes of preventing a single
        /// account being logged into multiple servers, showing who is currently on a server, etc.
        /// </summary>
        /// <param name="steamIDUser"></param>
        void SendUserDisconnect(SteamID steamIDUser);

        /// <summary>
        /// Update the data to be displayed in the server browser and matchmaking interfaces for a user
        /// currently connected to the server.  For regular users you must call this after you receive a
        /// GSUserValidationSuccess callback.
        /// 
        /// Return Value: true if successful, false if failure (ie, steamIDUser wasn't for an active player)
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        /// <returns></returns>
        bool UpdateUserData(SteamID steamIDUser, string playerName, uint score);

        /// <summary>
        /// New auth system APIs - do not mix with the old auth system APIs.
        /// ----------------------------------------------------------------
        /// Retrieve ticket to be sent to the entity who wishes to authenticate you ( using BeginAuthSession API ). 
        /// pcbTicket retrieves the length of the actual ticket.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ticket"></param>
        /// <returns></returns>
        AuthTicketHandle GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength);

        GameServerGetAuthSessionTicketResult GetAuthSessionTicket(System.IntPtr ticket, int maxTicket);

        /// <summary>
        /// Authenticate ticket ( from GetAuthSessionTicket ) from entity steamID to be sure it is valid and isnt reused
        /// Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )
        /// </summary>
        /// <param name="authTicket"></param>
        /// <param name="steamID"></param>
        /// <returns></returns>
        BeginAuthSessionResult BeginAuthSession(System.IntPtr authTicket, int cbAuthTicket, SteamID steamID);

        /// <summary>
        /// Stop tracking started by BeginAuthSession - called when no longer playing game with this entity
        /// </summary>
        /// <param name="steamID"></param>
        void EndAuthSession(SteamID steamID);

        /// <summary>
        /// Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to
        /// </summary>
        /// <param name="authTicket"></param>
        void CancelAuthTicket(AuthTicketHandle authTicket);

        /// <summary>
        /// After receiving a user's authentication data, and passing it to SendUserConnectAndAuthenticate, use this function
        /// to determine if the user owns downloadable content specified by the provided AppID.
        /// </summary>
        /// <param name="steamID"></param>
        /// <param name="appID"></param>
        /// <returns></returns>
        UserHasLicenseForAppResult UserHasLicenseForApp(SteamID steamID, AppID appID);

        /// <summary>
        /// Ask if a user in in the specified group, results returns async by GSUserGroupStatus_t
        /// returns false if we're not connected to the steam servers and thus cannot ask
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="steamIDGroup"></param>
        /// <returns></returns>
        bool RequestUserGroupStatus(SteamID steamIDUser, SteamID steamIDGroup);

        /// <summary>
        /// Ask for the gameplay stats for the server. Results returned in a callback
        /// </summary>
        void GetGameplayStats();

        /// <summary>
        /// Gets the reputation score for the game server. This API also checks if the server or some
        /// other server on the same IP is banned from the Steam master servers.
        /// </summary>
        /// <returns></returns>
        void GetServerReputation();

        /// <summary>
        /// Returns the public IP of the server according to Steam, useful when the server is 
        /// behind NAT and you want to advertise its IP in a lobby for other clients to directly
        /// connect to
        /// </summary>
        /// <returns></returns>
        uint GetPublicIP();

        /// <summary>
        /// These are in GameSocketShare mode, where instead of ISteamGameServer creating its own
        /// socket to talk to the master server on, it lets the game use its socket to forward messages
        /// back and forth. This prevents us from requiring server ops to open up yet another port
        /// in their firewalls.
        ///
        /// the IP address and port should be in host order, i.e 127.0.0.1 == 0x7f000001
        ///
        /// These are used when you've elected to multiplex the game server's UDP socket
        /// rather than having the master server updater use its own sockets.
        /// 
        /// Source games use this to simplify the job of the server admins, so they 
        /// don't have to open up more ports on their firewalls.
        ///
        /// Call this when a packet that starts with 0xFFFFFFFF comes in. That means
        /// it's for us.
        /// </summary>
        /// <returns></returns>
        bool HandleIncomingPacket(byte[] packet, uint sourceIP, ushort sourcePort);

        /// <summary>
        /// AFTER calling HandleIncomingPacket for any packets that came in that frame, call this.
        /// This gets a packet that the master server updater needs to send out on UDP.
        /// It returns the length of the packet it wants to send, or 0 if there are no more packets to send.
        /// Call this each frame until it returns 0
        /// </summary>
        /// <param name="data"></param>
        /// <param name="netAdr"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        int GetNextOutgoingPacket(byte[] packet, out uint netAdr, out ushort port);

        GameServerGetNextOutgoingPacketResult GetNextOutgoingPacket(byte[] data);

        /// <summary>
        /// Call this as often as you like to tell the master server updater whether or not
        /// you want it to be active (default: off).
        /// </summary>
        /// <param name="active"></param>
        void EnableHeartbeats(bool active);

        /// <summary>
        ///You usually don't need to modify this.
        /// Pass -1 to use the default value for iHeartbeatInterval.
        /// Some mods change this
        /// </summary>
        /// <param name="heartbeatInterval"></param>
        void SetHeartbeatInterval(int heartbeatInterval);

        /// <summary>
        /// Force a heartbeat to steam at the next opportunity
        /// </summary>
        void ForceHeartbeat();

        /// <summary>
        /// associate this game server with this clan for the purposes of computing player compat
        /// </summary>
        /// <param name="steamIDClan"></param>
        /// <returns></returns>
        void AssociateWithClan(SteamID steamIDClan);

        /// <summary>
        /// ask if any of the current players dont want to play with this new player - or vice versa
        /// </summary>
        /// <param name="steamIDNewPlayer"></param>
        /// <returns></returns>
        void ComputeNewPlayerCompatibility(SteamID steamIDNewPlayer);
    }


    public struct GameServerSendUserConnectAndAuthenticateResult
    {
        public bool Result;
        public SteamID SteamIDUser;
    }

    public struct GameServerGetAuthSessionTicketResult
    {
        public AuthTicketHandle Result;
        public uint TicketSize;
    }

    public struct GameServerGetNextOutgoingPacketResult
    {
        public int Result;
        public uint NetAdr;
        public ushort Port;

    }

}
