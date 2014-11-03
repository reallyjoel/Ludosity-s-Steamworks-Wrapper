using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class GameServer : SteamServiceGameServer, IGameServer
    {
        private List<SteamServersConnected> steamServersConnected;
        private List<SteamServerConnectFailure> steamServerConnectFailure;
        private List<SteamServersDisconnected> steamServersDisconnected;
        private List<ValidateAuthTicketResponse> validateAuthTicketResponse;

        private List<GSClientApprove> gsClientApprove;
        private List<GSClientDeny> gsClientDeny;
        private List<GSClientKick> gsClientKick;
        private List<GSClientAchievementStatus> gsClientAchievementStatus;
        private List<GSPolicyResponse> gsPolicyResponse;
        private List<GSGameplayStats> gsGameplayStats;
        private List<GSClientGroupStatus> gsClientGroupStatus;

        private List<Result<GSReputation>> gsReputation;
        private List<Result<AssociateWithClanResult>> associateWithClanResult;
        private List<Result<ComputeNewPlayerCompatibilityResult>> computeNewPlayerCompatibilityResult;

        public GameServer()
        {
            steamServersConnected = new List<SteamServersConnected>();
            steamServerConnectFailure = new List<SteamServerConnectFailure>();
            steamServersDisconnected = new List<SteamServersDisconnected>();
            validateAuthTicketResponse = new List<ValidateAuthTicketResponse>();

            gsClientApprove = new List<GSClientApprove>();
            gsClientDeny = new List<GSClientDeny>();
            gsClientKick = new List<GSClientKick>();
            gsClientAchievementStatus = new List<GSClientAchievementStatus>();
            gsPolicyResponse = new List<GSPolicyResponse>();
            gsGameplayStats = new List<GSGameplayStats>();
            gsClientGroupStatus = new List<GSClientGroupStatus>();

            gsReputation = new List<Result<GSReputation>>();
            associateWithClanResult = new List<Result<AssociateWithClanResult>>();
            computeNewPlayerCompatibilityResult = new List<Result<ComputeNewPlayerCompatibilityResult>>();


            Callbacks[CallbackID.SteamServersConnected] = (data, size) => steamServersConnected.Add(CallbackStructures.SteamServersConnected.Create(data, size));
            Callbacks[CallbackID.SteamServerConnectFailure] = (data, size) => steamServerConnectFailure.Add(CallbackStructures.SteamServerConnectFailure.Create(data, size));
            Callbacks[CallbackID.SteamServersDisconnected] = (data, size) => steamServersDisconnected.Add(CallbackStructures.SteamServersDisconnected.Create(data, size));
            Callbacks[CallbackID.ValidateAuthTicketResponse] = (data, size) => validateAuthTicketResponse.Add(CallbackStructures.ValidateAuthTicketResponse.Create(data, size));

            Callbacks[CallbackID.GSClientApprove] = (data, size) => gsClientApprove.Add(CallbackStructures.GSClientApprove.Create(data, size));
            Callbacks[CallbackID.GSClientDeny] = (data, size) => gsClientDeny.Add(CallbackStructures.GSClientDeny.Create(data, size));
            Callbacks[CallbackID.GSClientKick] = (data, size) => gsClientKick.Add(CallbackStructures.GSClientKick.Create(data, size));
            Callbacks[CallbackID.GSClientAchievementStatus] = (data, size) => gsClientAchievementStatus.Add(CallbackStructures.GSClientAchievementStatus.Create(data, size));
            Callbacks[CallbackID.GSPolicyResponse] = (data, size) => gsPolicyResponse.Add(CallbackStructures.GSPolicyResponse.Create(data, size));
            Callbacks[CallbackID.GSGameplayStats] = (data, size) => gsGameplayStats.Add(CallbackStructures.GSGameplayStats.Create(data, size));
            Callbacks[CallbackID.GSClientGroupStatus] = (data, size) => gsClientGroupStatus.Add(CallbackStructures.GSClientGroupStatus.Create(data, size));

            Results[ResultID.GSReputation] = (data, size, flag) => gsReputation.Add(new Result<GSReputation>(CallbackStructures.GSReputation.Create(data, size), flag));
            Results[ResultID.AssociateWithClanResult] = (data, size, flag) => associateWithClanResult.Add(new Result<AssociateWithClanResult>(CallbackStructures.AssociateWithClanResult.Create(data, size), flag));
            Results[ResultID.ComputeNewPlayerCompatibilityResult] = (data, size, flag) => computeNewPlayerCompatibilityResult.Add(new Result<ComputeNewPlayerCompatibilityResult>(CallbackStructures.ComputeNewPlayerCompatibilityResult.Create(data, size), flag));
        }

        public event CallbackEvent<SteamServersConnected> SteamServersConnected;
        public event CallbackEvent<SteamServerConnectFailure> SteamServerConnectFailure;
        public event CallbackEvent<SteamServersDisconnected> SteamServersDisconnected;
        public event CallbackEvent<ValidateAuthTicketResponse> ValidateAuthTicketResponse;

        public event CallbackEvent<GSClientApprove> GSClientApprove;
        public event CallbackEvent<GSClientDeny> GSClientDeny;
        public event CallbackEvent<GSClientKick> GSClientKick;
        public event CallbackEvent<GSClientAchievementStatus> GSClientAchievementStatus;
        public event CallbackEvent<GSPolicyResponse> GSPolicyResponse;
        public event CallbackEvent<GSGameplayStats> GSGameplayStats;
        public event CallbackEvent<GSClientGroupStatus> GSClientGroupStatus;

        public event ResultEvent<GSReputation> GSReputation;
        public event ResultEvent<AssociateWithClanResult> AssociateWithClanResult;
        public event ResultEvent<ComputeNewPlayerCompatibilityResult> ComputeNewPlayerCompatibilityResult;


        internal override void CheckIfUsableInternal()
        {

        }

        internal override void ReleaseManagedResources()
        {
            steamServersConnected = null;
            SteamServersConnected = null;
            steamServerConnectFailure = null;
            SteamServerConnectFailure = null;
            steamServersDisconnected = null;
            SteamServersDisconnected = null;
            validateAuthTicketResponse = null;
            ValidateAuthTicketResponse = null;

            gsClientApprove = null;
            GSClientApprove = null;
            gsClientDeny = null;
            GSClientDeny = null;
            gsClientKick = null;
            GSClientKick = null;
            gsClientAchievementStatus = null;
            GSClientAchievementStatus = null;
            gsPolicyResponse = null;
            GSPolicyResponse = null;
            gsGameplayStats = null;
            GSGameplayStats = null;
            gsClientGroupStatus = null;
            GSClientGroupStatus = null;

            gsReputation = null;
            GSReputation = null;
            associateWithClanResult = null;
            AssociateWithClanResult = null;
            computeNewPlayerCompatibilityResult = null;
            ComputeNewPlayerCompatibilityResult = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(steamServersConnected, SteamServersConnected);
            InvokeEvents(steamServerConnectFailure, SteamServerConnectFailure);
            InvokeEvents(steamServersDisconnected, SteamServersDisconnected);
            InvokeEvents(validateAuthTicketResponse, ValidateAuthTicketResponse);

            InvokeEvents(gsClientApprove, GSClientApprove);
            InvokeEvents(gsClientDeny, GSClientDeny);
            InvokeEvents(gsClientKick, GSClientKick);
            InvokeEvents(gsClientAchievementStatus, GSClientAchievementStatus);
            InvokeEvents(gsPolicyResponse, GSPolicyResponse);
            InvokeEvents(gsGameplayStats, GSGameplayStats);
            InvokeEvents(gsClientGroupStatus, GSClientGroupStatus);

            InvokeEvents(gsReputation, GSReputation);
            InvokeEvents(associateWithClanResult, AssociateWithClanResult);
            InvokeEvents(computeNewPlayerCompatibilityResult, ComputeNewPlayerCompatibilityResult);
        }

        public bool InitGameServer(uint ip, ushort gamePort, ushort queryPort, uint flags, AppID gameAppId, string versionString)
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_InitGameServer(ip, gamePort, queryPort, flags, gameAppId.AsUInt32, versionString);
        }

        public void SetProduct(string product)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetProduct(product);
        }

        public void SetGameDescription(string gameDescription)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetGameDescription(gameDescription);
        }

        public void SetModDir(string modDir)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetModDir(modDir);
        }

        public void SetDedicatedServer(bool dedicated)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetDedicatedServer(dedicated);
        }

        public void LogOn(string accountName, string password)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_LogOn(accountName, password);
        }

        public void LogOnAnonymous()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_LogOnAnonymous();
        }

        public void LogOff()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_LogOff();
        }

        public bool LoggedOn()
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_LoggedOn();
        }

        public bool Secure()
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_Secure();
        }

        public SteamID GetSteamID()
        {
            //CheckIfUsable();
            return new SteamID(NativeMethods.GameServer_GetSteamID());
        }

        public bool WasRestartRequested()
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_WasRestartRequested();
        }

        public void SetMaxPlayerCount(int playersMax)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetMaxPlayerCount(playersMax);
        }

        public void SetBotPlayerCount(int botPlayers)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetBotPlayerCount(botPlayers);
        }

        public void SetServerName(string serverName)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetServerName(serverName);
        }

        public void SetMapName(string mapName)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetMapName(mapName);
        }

        public void SetPasswordProtected(bool passwordProtected)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetPasswordProtected(passwordProtected);
        }

        public void SetSpectatorPort(ushort spectatorPort)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetSpectatorPort(spectatorPort);
        }

        public void SetSpectatorServerName(string spectatorServerName)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetSpectatorServerName(spectatorServerName);
        }

        public void ClearAllKeyValues()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_ClearAllKeyValues();
        }

        public void SetKeyValue(string key, string value)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetKeyValue(key, value);
        }

        public void SetGameTags(string gameTags)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetGameTags(gameTags);
        }

        public void SetGameData(string gameData)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetGameData(gameData);
        }

        public void SetRegion(string region)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetRegion(region);
        }

        public bool SendUserConnectAndAuthenticate(uint ipClient, byte[] authenticationBlob, out SteamID steamIDUser)
        {
            //CheckIfUsable();

            using (NativeBuffer blobBuffer = new NativeBuffer(authenticationBlob))
            {
                blobBuffer.WriteToUnmanagedMemory();
                ulong rawCreator = 0;
                bool result = NativeMethods.GameServer_SendUserConnectAndAuthenticate(ipClient,
                    blobBuffer.UnmanagedMemory, (uint)blobBuffer.UnmanagedMemory, ref rawCreator);

                steamIDUser = new SteamID(rawCreator);
                return result;

            }

        }

        public GameServerSendUserConnectAndAuthenticateResult SendUserConnectAndAuthenticate(uint ipClient, byte[] authenticationBlob)
        {
            GameServerSendUserConnectAndAuthenticateResult result = new GameServerSendUserConnectAndAuthenticateResult();

            result.Result = SendUserConnectAndAuthenticate(ipClient, authenticationBlob, out result.SteamIDUser);

            return result;
        }


        public SteamID CreateUnauthenticatedUserConnection()
        {
            //CheckIfUsable();
            return new SteamID(NativeMethods.GameServer_CreateUnauthenticatedUserConnection());
        }

        public void SendUserDisconnect(SteamID steamIDUser)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SendUserDisconnect(steamIDUser.AsUInt64);
        }

        public bool UpdateUserData(SteamID steamIDUser, string playerName, uint score)
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_UpdateUserData(steamIDUser.AsUInt64, playerName, score);
        }

        public AuthTicketHandle GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength)
        {
            //CheckIfUsable();
            ticketLength = 0;
            return new AuthTicketHandle(NativeMethods.GameServer_GetAuthSessionTicket(ticket, maxTicket, ref ticketLength));
        }

        public GameServerGetAuthSessionTicketResult GetAuthSessionTicket(System.IntPtr ticket, int maxTicket)
        {
            GameServerGetAuthSessionTicketResult result = new GameServerGetAuthSessionTicketResult();

            result.Result = GetAuthSessionTicket(ticket, maxTicket, out result.TicketSize);

            return result;
        }

        public BeginAuthSessionResult BeginAuthSession(System.IntPtr authTicket, int cbAuthTicket, SteamID steamID)
        {
            //CheckIfUsable();
            return (BeginAuthSessionResult)NativeMethods.GameServer_BeginAuthSession(authTicket, cbAuthTicket, steamID.AsUInt64);
        }

        public void EndAuthSession(SteamID steamID)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_EndAuthSession(steamID.AsUInt64);
        }

        public void CancelAuthTicket(AuthTicketHandle authTicket)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_CancelAuthTicket(authTicket.AsUInt32);
        }

        public UserHasLicenseForAppResult UserHasLicenseForApp(SteamID steamID, AppID appID)
        {
            //CheckIfUsable();
            int tempreturn = NativeMethods.GameServer_UserHasLicenseForApp(steamID.AsUInt64, appID.AsUInt32);
            return (UserHasLicenseForAppResult)tempreturn;
        }

        public bool RequestUserGroupStatus(SteamID steamIDUser, SteamID steamIDGroup)
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_RequestUserGroupStatus(steamIDUser.AsUInt64, steamIDGroup.AsUInt64);
        }

        [Obsolete("As of Steamworks SDK 1.28 this function has been deprecated. It currently does not return anything, and will be removed in the future.")]
        public void GetGameplayStats()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_GetGameplayStats();
        }

        [Obsolete("As of Steamworks SDK 1.28 this function has been deprecated. It currently does not return anything, and will be removed in the future.")]
        public void GetServerReputation()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_GetServerReputation();
        }

        public uint GetPublicIP()
        {
            //CheckIfUsable();
            return NativeMethods.GameServer_GetPublicIP();
        }

        public bool HandleIncomingPacket(byte[] data, uint ip, ushort port)
        {
            //CheckIfUsable();
            using (NativeBuffer packetBuffer = new NativeBuffer(data))
            {
                packetBuffer.WriteToUnmanagedMemory();
                return NativeMethods.GameServer_HandleIncomingPacket(packetBuffer.UnmanagedMemory,
                    packetBuffer.UnmanagedSize, ip, port);
            }
        }

        public int GetNextOutgoingPacket(byte[] data, out uint netAdr, out ushort port)
        {
            //CheckIfUsable();
            netAdr = 0;
            port = 0;
            using (NativeBuffer packetBuffer = new NativeBuffer(data))
            {
                int result = NativeMethods.GameServer_GetNextOutgoingPacket(packetBuffer.UnmanagedMemory, packetBuffer.UnmanagedSize, ref netAdr, ref port);
                packetBuffer.ReadFromUnmanagedMemory(result);
                return result;
            }
        }

        public GameServerGetNextOutgoingPacketResult GetNextOutgoingPacket(byte[] data)
        {
            GameServerGetNextOutgoingPacketResult result = new GameServerGetNextOutgoingPacketResult();

            result.Result = GetNextOutgoingPacket(data, out result.NetAdr, out result.Port);

            return result;


        }

        public void EnableHeartbeats(bool active)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_EnableHeartbeats(active);
        }

        public void SetHeartbeatInterval(int heartbeatInterval)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_SetHeartbeatInterval(heartbeatInterval);
        }

        public void ForceHeartbeat()
        {
            //CheckIfUsable();
            NativeMethods.GameServer_ForceHeartbeat();
        }

        public void AssociateWithClan(SteamID steamIDClan)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_AssociateWithClan(steamIDClan.AsUInt64);
        }

        public void ComputeNewPlayerCompatibility(SteamID steamIDNewPlayer)
        {
            //CheckIfUsable();
            NativeMethods.GameServer_ComputeNewPlayerCompatibility(steamIDNewPlayer.AsUInt64);

        }

    }
}