using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class User : SteamService, IUser
    {

        private List<SteamServersConnected> steamServersConnected;
        private List<SteamServerConnectFailure> steamServerConnectFailure;
        private List<SteamServersDisconnected> steamServersDisconnected;
        private List<ClientGameServerDeny> clientGameServerDeny;
        private List<IPCFailure> ipcFailure;
        private List<ValidateAuthTicketResponse> validateAuthTicketResponse;
        private List<MicroTxnAuthorizationResponse> microTxnAuthorizationResponse;
        private List<Result<EncryptedAppTicketResponse>> encryptedAppTicketResponse;
        private List<GetAuthSessionTicketResponse> getAuthSessionTicketResponse;
        private List<GameWebCallback> gameWebCallback;

        public User()
        {
            steamServersConnected           = new List<SteamServersConnected>();
            steamServerConnectFailure       = new List<SteamServerConnectFailure>();
            steamServersDisconnected        = new List<SteamServersDisconnected>();
            clientGameServerDeny            = new List<ClientGameServerDeny>();
            ipcFailure                      = new List<IPCFailure>();
            validateAuthTicketResponse      = new List<ValidateAuthTicketResponse>();
            microTxnAuthorizationResponse   = new List<MicroTxnAuthorizationResponse>();
            encryptedAppTicketResponse      = new List<Result<EncryptedAppTicketResponse>>();
            getAuthSessionTicketResponse    = new List<GetAuthSessionTicketResponse>();
            gameWebCallback                 = new List<GameWebCallback>();
            
            Callbacks[CallbackID.SteamServersConnected] = (data, dataSize) => steamServersConnected.Add(CallbackStructures.SteamServersConnected.Create(data, dataSize));
            Callbacks[CallbackID.SteamServerConnectFailure] = (data, dataSize) => steamServerConnectFailure.Add(CallbackStructures.SteamServerConnectFailure.Create(data, dataSize));
            Callbacks[CallbackID.SteamServersDisconnected] = (data, dataSize) => steamServersDisconnected.Add(CallbackStructures.SteamServersDisconnected.Create(data, dataSize));
            Callbacks[CallbackID.ClientGameServerDeny] = (data, dataSize) => clientGameServerDeny.Add(CallbackStructures.ClientGameServerDeny.Create(data, dataSize));
            Callbacks[CallbackID.IPCFailure] = (data, dataSize) => ipcFailure.Add(CallbackStructures.IPCFailure.Create(data, dataSize));
            Callbacks[CallbackID.ValidateAuthTicketResponse] = (data, dataSize) => validateAuthTicketResponse.Add(CallbackStructures.ValidateAuthTicketResponse.Create(data, dataSize));
            Callbacks[CallbackID.MicroTxnAuthorizationResponse] = (data, dataSize) => microTxnAuthorizationResponse.Add(CallbackStructures.MicroTxnAuthorizationResponse.Create(data, dataSize));
            Results[ResultID.EncryptedAppTicketResponse] = (data, dataSize, flag) => encryptedAppTicketResponse.Add(new Result<EncryptedAppTicketResponse>(CallbackStructures.EncryptedAppTicketResponse.Create(data, dataSize), flag));
            Callbacks[CallbackID.GetAuthSessionTicketResponse] = (data, dataSize) => getAuthSessionTicketResponse.Add(CallbackStructures.GetAuthSessionTicketResponse.Create(data, dataSize));
            Callbacks[CallbackID.GameWebCallback] = (data, dataSize) => gameWebCallback.Add(CallbackStructures.GameWebCallback.Create(data, dataSize));
        }

        public event CallbackEvent<SteamServersConnected> SteamServersConnected;
        public event CallbackEvent<SteamServerConnectFailure> SteamServerConnectFailure;
        public event CallbackEvent<SteamServersDisconnected> SteamServersDisconnected;
        public event CallbackEvent<ClientGameServerDeny> ClientGameServerDeny;
        public event CallbackEvent<IPCFailure> IPCFailure;
        public event CallbackEvent<ValidateAuthTicketResponse> ValidateAuthTicketResponse;
        public event CallbackEvent<MicroTxnAuthorizationResponse> MicroTxnAuthorizationResponse;
        public event ResultEvent<EncryptedAppTicketResponse> EncryptedAppTicketResponse;
        public event CallbackEvent<GetAuthSessionTicketResponse> GetAuthSessionTicketResponse;
        public event CallbackEvent<GameWebCallback> GameWebCallback;

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

            clientGameServerDeny = null;
            ClientGameServerDeny = null;

            ipcFailure = null;
            IPCFailure = null;

            validateAuthTicketResponse = null;
            ValidateAuthTicketResponse = null;

            microTxnAuthorizationResponse = null;
            MicroTxnAuthorizationResponse = null;

            encryptedAppTicketResponse = null;
            EncryptedAppTicketResponse = null;

            getAuthSessionTicketResponse = null;
            GetAuthSessionTicketResponse = null;

            gameWebCallback = null;
            GameWebCallback = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(steamServersConnected, SteamServersConnected);
            InvokeEvents(steamServerConnectFailure, SteamServerConnectFailure);
            InvokeEvents(steamServersDisconnected, SteamServersDisconnected);
            InvokeEvents(clientGameServerDeny, ClientGameServerDeny);
            InvokeEvents(ipcFailure, IPCFailure);
            InvokeEvents(validateAuthTicketResponse, ValidateAuthTicketResponse);
            InvokeEvents(microTxnAuthorizationResponse, MicroTxnAuthorizationResponse);
            InvokeEvents(encryptedAppTicketResponse, EncryptedAppTicketResponse);
            InvokeEvents(getAuthSessionTicketResponse, GetAuthSessionTicketResponse);
            InvokeEvents(gameWebCallback, GameWebCallback);
        }

        public bool IsLoggedOn()
        {
            CheckIfUsable();
            return NativeMethods.User_IsLoggedOn();
        }

        public SteamID GetSteamID()
        {
            CheckIfUsable();
            return new SteamID(NativeMethods.User_GetSteamID());
        }

        public int InitiateGameConnection(System.IntPtr authBlob, int maxAuthBlob, SteamID steamIDGameServer, uint serverIP, ushort serverPort, bool secure)
        {
            CheckIfUsable();
            return NativeMethods.User_InitiateGameConnection(authBlob, maxAuthBlob, steamIDGameServer.AsUInt64, serverIP, serverPort, secure);
        }

        public void TerminateGameConnection(uint serverIP, ushort serverPort)
        {
            CheckIfUsable();
            NativeMethods.User_TerminateGameConnection(serverIP, serverPort);
        }

        public void TrackAppUsageEvent(GameID gameID, int appUsageEvent, string extraInfo = "")
        {
            CheckIfUsable();
            NativeMethods.User_TrackAppUsageEvent(gameID.AsUInt64, appUsageEvent, extraInfo);
        }

        public bool GetUserDataFolder(out string text)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Constants.User.URLNameMax))
            {
                bool result = NativeMethods.User_GetUserDataFolder(buffer.UnmanagedMemory, buffer.UnmanagedSize);

                text = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }
        public UserGetUserDataFolder GetUserDataFolder()
        {
            UserGetUserDataFolder result = new UserGetUserDataFolder();
            result.Result = GetUserDataFolder(out result.Path);

            return result;
        }

        public void StartVoiceRecording()
        {
            CheckIfUsable();
            NativeMethods.User_StartVoiceRecording();
        }

        public void StopVoiceRecording()
        {
            CheckIfUsable();
            NativeMethods.User_StopVoiceRecording();
        }

        public VoiceResult GetAvailableVoice(out uint compressed, out uint uncompressed, uint uncompressedVoiceDesiredSampleRate)
        {
            CheckIfUsable();
            compressed = 0;
            uncompressed = 0;
            return (VoiceResult)NativeMethods.User_GetAvailableVoice(ref compressed, ref uncompressed, uncompressedVoiceDesiredSampleRate);
        }
        public UserGetAvailableVoiceResult GetAvailableVoice(uint uncompressedVoiceDesiredsampleRate)
        {
            UserGetAvailableVoiceResult result = new UserGetAvailableVoiceResult();
            result.Result = GetAvailableVoice(out result.Compressed, out result.UnCompressed, uncompressedVoiceDesiredsampleRate);

            return result;
        }

        public VoiceResult GetVoice(bool wantCompressed, System.IntPtr destBuffer, uint destBufferSize, out uint bytesWritten, bool wantUncompressed, System.IntPtr uncompressedDestBuffer, uint uncompressedDestBufferSize, out uint uncompressedBytesWritten, uint uncompressedVoiceDesiredSampleRate)
        {
            CheckIfUsable();
            bytesWritten = 0;
            uncompressedBytesWritten = 0;
            return (VoiceResult)NativeMethods.User_GetVoice(wantCompressed, destBuffer, destBufferSize, ref bytesWritten, wantUncompressed, uncompressedDestBuffer, uncompressedDestBufferSize, ref uncompressedBytesWritten, uncompressedVoiceDesiredSampleRate);
        }
        public UserGetVoiceResult GetVoice(bool wantCompressed, System.IntPtr destBuffer, uint destBufferSize, bool wantUncompressed, System.IntPtr uncompressedDestBuffer, uint uncompressedDestBufferSize, uint uncompressedVoiceDesiredSampleRate)
        {
            UserGetVoiceResult result = new UserGetVoiceResult();

            result.Result = GetVoice(wantCompressed, destBuffer, destBufferSize, out result.BytesWritten, wantUncompressed, uncompressedDestBuffer, uncompressedDestBufferSize, out result.UnCompressedBytesWritten, uncompressedVoiceDesiredSampleRate);

            return result;
        }

        public VoiceResult DecompressVoice(System.IntPtr compressed, uint compressedSize, System.IntPtr destBuffer, uint destBufferSize, out uint bytesWritten, uint desiredSampleRate)
        {
            CheckIfUsable();
            bytesWritten = 0;
            return (VoiceResult)NativeMethods.User_DecompressVoice(compressed, compressedSize, destBuffer, destBufferSize, ref bytesWritten, desiredSampleRate);
        }
        public UserDecompressVoiceResult DecompressVoice(System.IntPtr compressed, uint compressedSize, System.IntPtr destBuffer, uint destBufferSize, uint desiredSampleRate)
        {
            UserDecompressVoiceResult result = new UserDecompressVoiceResult();

            result.Result = DecompressVoice(compressed, compressedSize, destBuffer, destBufferSize, out result.BytesWritten, desiredSampleRate);

            return result;
        }

        public uint GetVoiceOptimalSampleRate()
        {
            CheckIfUsable();
            return NativeMethods.User_GetVoiceOptimalSampleRate();
        }

        public AuthTicketHandle GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength)
        {
            CheckIfUsable();
            ticketLength = 0;
            return new AuthTicketHandle(NativeMethods.User_GetAuthSessionTicket(ticket, maxTicket, ref ticketLength));
        }
        public UserGetAuthSessionTicketResult GetAuthSessionTicket(System.IntPtr ticket, int maxTicket)
        {
            UserGetAuthSessionTicketResult result = new UserGetAuthSessionTicketResult();

            result.Result = GetAuthSessionTicket(ticket, maxTicket, out result.TicketLength);

            return result;
        }

        public BeginAuthSessionResult BeginAuthSession(System.IntPtr authTicket, int cbAuthTicket, SteamID steamID)
        {
            CheckIfUsable();
            return (BeginAuthSessionResult)NativeMethods.User_BeginAuthSession(authTicket, cbAuthTicket, steamID.AsUInt64);
        }

        public void EndAuthSession(SteamID steamID)
        {
            CheckIfUsable();
            NativeMethods.User_EndAuthSession(steamID.AsUInt64);
        }

        public void CancelAuthTicket(uint authTicket)
        {
            CheckIfUsable();
            NativeMethods.User_CancelAuthTicket(authTicket);
        }

        public UserHasLicenseForAppResult UserHasLicenseForApp(SteamID steamID, AppID appID)
        {
            CheckIfUsable();
            return (UserHasLicenseForAppResult)NativeMethods.User_UserHasLicenseForApp(steamID.AsUInt64, appID.AsUInt32);
        }

        public bool IsBehindNAT()
        {
            CheckIfUsable();
            return NativeMethods.User_IsBehindNAT();
        }

        public void AdvertiseGame(SteamID steamIDGameServer, uint serverIP, ushort serverPort)
        {
            CheckIfUsable();
            NativeMethods.User_AdvertiseGame(steamIDGameServer.AsUInt64, serverIP, serverPort);
        }

        public void RequestEncryptedAppTicket(System.IntPtr dataToInclude, int cbDataToInclude)
        {
            CheckIfUsable();
            NativeMethods.User_RequestEncryptedAppTicket(dataToInclude, cbDataToInclude);
        }


        public bool GetEncryptedAppTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength)
        {
            CheckIfUsable();
            ticketLength = 0;
            return NativeMethods.User_GetEncryptedAppTicket(ticket, maxTicket, ref ticketLength);
        }
        public UserGetEncryptedAppTicketResult GetEncryptedAppTicket(System.IntPtr ticket, int maxTicket)
        {
            UserGetEncryptedAppTicketResult result = new UserGetEncryptedAppTicketResult();

            result.Result = GetEncryptedAppTicket(ticket, maxTicket, out result.TicketLength);

            return result;
        }

        public int GetGameBadgeLevel(int nSeries, bool bFoil)
        {
            CheckIfUsable();
            return NativeMethods.User_GetGameBadgeLevel(nSeries, bFoil);
        }

        public int GetPlayerSteamLevel()
        {
            CheckIfUsable();
            return NativeMethods.User_GetPlayerSteamLevel();
        }
    }
}
