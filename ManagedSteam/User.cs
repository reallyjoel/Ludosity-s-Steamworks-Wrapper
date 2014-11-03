using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    /// <summary>
    /// Handles user information
    /// </summary>
    public interface IUser
    {
        event CallbackEvent<SteamServersConnected> SteamServersConnected;
        event CallbackEvent<SteamServerConnectFailure> SteamServerConnectFailure;
        event CallbackEvent<SteamServersDisconnected> SteamServersDisconnected;
        event CallbackEvent<ClientGameServerDeny> ClientGameServerDeny;
        event CallbackEvent<IPCFailure> IPCFailure;
        event CallbackEvent<ValidateAuthTicketResponse> ValidateAuthTicketResponse;
        event CallbackEvent<MicroTxnAuthorizationResponse> MicroTxnAuthorizationResponse;
        event ResultEvent<EncryptedAppTicketResponse> EncryptedAppTicketResponse;
        event CallbackEvent<GetAuthSessionTicketResponse> GetAuthSessionTicketResponse;
        event CallbackEvent<GameWebCallback> GameWebCallback;

        /// <summary>
        /// Available in Lite
        /// </summary>
        bool IsLoggedOn();

        /// <summary>
        /// Available in Lite
        /// </summary>
        SteamID GetSteamID();

        /// <summary>
        /// InitiateGameConnection() starts the state machine for authenticating the game client with the game server
        /// It is the client portion of a three-way handshake between the client, the game server, and the steam servers 
        /// </summary>
        /// <param name="authBlob">A pointer to empty memory that will be filled in with the authentication token.</param>
        /// <param name="maxAuthBlob">The number of bytes of allocated memory in pBlob. Should be at least 2048 bytes.</param>
        /// <param name="steamIDGameServer">The steamID of the game server, received from the game server by the client.</param>
        /// <param name="serverIP">The ID of the current game. For games without mods, this is just CGameID( appID ).</param>
        /// <param name="serverPort">The IP address of the game server.</param>
        /// <param name="secure">Whether or not the client thinks that the game server is reporting itself as secure (i.e. VAC is running).</param>
        /// <returns>Returns the number of bytes written to pBlob. If the return is 0, then the buffer passed in was too small, and the call has failed.
        /// The contents of pBlob should then be sent to the game server, for it to use to complete the authentication process.</returns>
        int InitiateGameConnection( System.IntPtr authBlob, int maxAuthBlob, SteamID steamIDGameServer, uint serverIP, ushort serverPort, bool secure );

        /// <summary>
        /// Notify of disconnect, needs to occur when the game client leaves the specified game server, needs to match with the InitiateGameConnection() call.
        /// </summary>
        void TerminateGameConnection(uint serverIP, ushort serverPort);

        /// <summary>
        /// Used by only a few games to track usage events.
        /// </summary>
        void TrackAppUsageEvent(GameID gameID, int appUsageEvent, string extraInfo = "");

        /// <summary>
        /// Get the local storage folder for current Steam account to write application data, e.g. save games, configs etc.
        /// This will usually be something like "C:\Progam Files\Steam\userdata\Your_SteamID\Your_AppId\local".
        /// </summary>
        bool GetUserDataFolder(out string text);
        /// <summary>
        /// Get the local storage folder for current Steam account to write application data, e.g. save games, configs etc.
        /// This will usually be something like "C:\Progam Files\Steam\userdata\Your_SteamID\Your_AppId\local".
        /// </summary>
        UserGetUserDataFolder GetUserDataFolder();

        /// <summary>
        /// Starts voice recording. Once started, use GetVoice() to get the data.
        /// </summary>
        void StartVoiceRecording();

        /// <summary>
        /// Stops voice recording. Because people often release push-to-talk keys early, the system will keep recording for
        /// a little bit after this function is called. GetVoice() should continue to be called until it returns
        /// k_eVoiceResultNotRecording.
        /// </summary>
        void StopVoiceRecording();

        /// <summary>
        /// Determine the amount of captured audio data that is available in bytes.
        /// This provides both the compressed and uncompressed data. Please note that the uncompressed
        /// data is not the raw feed from the microphone: data may only be available if audible 
        /// levels of speech are detected.
        /// nUncompressedVoiceDesiredSampleRate is necessary to know the number of bytes to return in pcbUncompressed - can be set to 0 if you don't need uncompressed (the usual case)
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nUncompressedVoiceDesiredSampleRate
        /// </summary>
        VoiceResult GetAvailableVoice(out uint compressed, out uint uncompressed, uint uncompressedVoiceDesiredSampleRate);/// <summary>
        /// Determine the amount of captured audio data that is available in bytes.
        /// This provides both the compressed and uncompressed data. Please note that the uncompressed
        /// data is not the raw feed from the microphone: data may only be available if audible 
        /// levels of speech are detected.
        /// nUncompressedVoiceDesiredSampleRate is necessary to know the number of bytes to return in pcbUncompressed - can be set to 0 if you don't need uncompressed (the usual case)
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nUncompressedVoiceDesiredSampleRate
        /// </summary>
        UserGetAvailableVoiceResult GetAvailableVoice(uint uncompressedVoiceDesiredSampleRate);
    
        /// <summary>
        /// Gets the latest voice data from the microphone. Compressed data is an arbitrary format, and is meant to be handed back to 
        /// DecompressVoice() for playback later as a binary blob. Uncompressed data is 16-bit, signed integer, 11025Hz PCM format.
        /// Please note that the uncompressed data is not the raw feed from the microphone: data may only be available if audible 
        /// levels of speech are detected, and may have passed through denoising filters, etc.
        /// This function should be called as often as possible once recording has started; once per frame at least.
        /// nBytesWritten is set to the number of bytes written to pDestBuffer. 
        /// nUncompressedBytesWritten is set to the number of bytes written to pUncompressedDestBuffer. 
        /// You must grab both compressed and uncompressed here at the same time, if you want both.
        /// Matching data that is not read during this call will be thrown away.
        /// GetAvailableVoice() can be used to determine how much data is actually available.
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nUncompressedVoiceDesiredSampleRate
        /// </summary>
        VoiceResult GetVoice(bool wantCompressed, System.IntPtr destBuffer, uint destBufferSize, out uint bytesWritten, bool wantUncompressed, System.IntPtr uncompressedDestBuffer, uint uncompressedDestBufferSize, out uint uncompressedBytesWritten, uint uncompressedVoiceDesiredSampleRate);
        /// <summary>
        /// Gets the latest voice data from the microphone. Compressed data is an arbitrary format, and is meant to be handed back to 
        /// DecompressVoice() for playback later as a binary blob. Uncompressed data is 16-bit, signed integer, 11025Hz PCM format.
        /// Please note that the uncompressed data is not the raw feed from the microphone: data may only be available if audible 
        /// levels of speech are detected, and may have passed through denoising filters, etc.
        /// This function should be called as often as possible once recording has started; once per frame at least.
        /// nBytesWritten is set to the number of bytes written to pDestBuffer. 
        /// nUncompressedBytesWritten is set to the number of bytes written to pUncompressedDestBuffer. 
        /// You must grab both compressed and uncompressed here at the same time, if you want both.
        /// Matching data that is not read during this call will be thrown away.
        /// GetAvailableVoice() can be used to determine how much data is actually available.
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nUncompressedVoiceDesiredSampleRate
        /// </summary>
        UserGetVoiceResult GetVoice(bool wantCompressed, System.IntPtr destBuffer, uint destBufferSize, bool wantUncompressed, System.IntPtr uncompressedDestBuffer, uint uncompressedDestBufferSize, uint uncompressedVoiceDesiredSampleRate);
    
        /// <summary>
        /// Decompresses a chunk of compressed data produced by GetVoice().
        /// nBytesWritten is set to the number of bytes written to pDestBuffer unless the return value is k_EVoiceResultBufferTooSmall.
        /// In that case, nBytesWritten is set to the size of the buffer required to decompress the given
        /// data. The suggested buffer size for the destination buffer is 22 kilobytes.
        /// The output format of the data is 16-bit signed at the requested samples per second.
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nDesiredSampleRate
        /// </summary>
        VoiceResult DecompressVoice(System.IntPtr compressed, uint compressedSize, System.IntPtr destBuffer, uint destBufferSize, out uint bytesWritten, uint desiredSampleRate);
        /// <summary>
        /// Decompresses a chunk of compressed data produced by GetVoice().
        /// nBytesWritten is set to the number of bytes written to pDestBuffer unless the return value is k_EVoiceResultBufferTooSmall.
        /// In that case, nBytesWritten is set to the size of the buffer required to decompress the given
        /// data. The suggested buffer size for the destination buffer is 22 kilobytes.
        /// The output format of the data is 16-bit signed at the requested samples per second.
        /// If you're upgrading from an older Steamworks API, you'll want to pass in 11025 to nDesiredSampleRate
        /// </summary>
        UserDecompressVoiceResult DecompressVoice(System.IntPtr compressed, uint compressedSize, System.IntPtr destBuffer, uint destBufferSize, uint desiredSampleRate);
    
        /// <summary>
        /// This returns the frequency of the voice data as it's stored internally; calling DecompressVoice() with this size will yield the best results
        /// </summary>
        uint GetVoiceOptimalSampleRate();

        /// <summary>
        /// Retrieve ticket to be sent to the entity who wishes to authenticate you. 
        /// pcbTicket retrieves the length of the actual ticket.
        /// </summary>
        AuthTicketHandle GetAuthSessionTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength);
        /// <summary>
        /// Retrieve ticket to be sent to the entity who wishes to authenticate you. 
        /// pcbTicket retrieves the length of the actual ticket.
        /// </summary>
        UserGetAuthSessionTicketResult GetAuthSessionTicket(System.IntPtr ticket, int maxTicket);

        /// <summary>
        /// Authenticate ticket from entity steamID to be sure it is valid and isnt reused
        /// Registers for callbacks if the entity goes offline or cancels the ticket ( see ValidateAuthTicketResponse_t callback and EAuthSessionResponse )
        /// </summary>
        BeginAuthSessionResult BeginAuthSession(System.IntPtr authTicket, int cbAuthTicket, SteamID steamID);

        /// <summary>
        /// Stop tracking started by BeginAuthSession - called when no longer playing game with this entity
        /// </summary>
        void EndAuthSession(SteamID steamID);

        /// <summary>
        /// Cancel auth ticket from GetAuthSessionTicket, called when no longer playing game with the entity you gave the ticket to
        /// </summary>
        void CancelAuthTicket(uint authTicket);

        /// <summary>
        /// After receiving a user's authentication data, and passing it to BeginAuthSession, use this function
        /// to determine if the user owns downloadable content specified by the provided AppID.
        /// </summary>
        UserHasLicenseForAppResult UserHasLicenseForApp(SteamID steamID, AppID appID);

        /// <summary>
        /// returns true if this users looks like they are behind a NAT device. Only valid once the user has connected to steam 
        /// (i.e a SteamServersConnected_t has been issued) and may not catch all forms of NAT.
        /// </summary>
        bool IsBehindNAT();

        /// <summary>
        /// Set data to be replicated to friends so that they can join your game
        /// </summary>
        /// <param name="steamIDGameServer">the steamID of the game server, received from the game server by the client</param>
        /// <param name="serverIP">the IP address of the game server</param>
        /// <param name="serverPort">the port of the game server</param>
        void AdvertiseGame(SteamID steamIDGameServer, uint serverIP, ushort serverPort);

        /// <summary>
        /// Requests a ticket encrypted with an app specific shared key
        /// pDataToInclude, cbDataToInclude will be encrypted into the ticket
        /// ( This is asynchronous, you must wait for the ticket to be completed by the server )
        /// </summary>
        void RequestEncryptedAppTicket(System.IntPtr dataToInclude, int cbDataToInclude);

        /// <summary>
        /// Retrieve a finished ticket
        /// </summary>
        bool GetEncryptedAppTicket(System.IntPtr ticket, int maxTicket, out uint ticketLength);
        /// <summary>
        /// Retrieve a finished ticket
        /// </summary>
        UserGetEncryptedAppTicketResult GetEncryptedAppTicket(System.IntPtr ticket, int maxTicket);

        /// <summary>
        /// Trading Card badges data access
        /// </summary>
        /// <param name="nSeries">If you only have one set of cards, the series will be 1</param>
        /// <param name="bFoil">The user has can have two different badges for a series; the regular (max level 5) and the foil (max level 1)</param>
        int GetGameBadgeLevel(int nSeries, bool bFoil);

        /// <summary>
        /// Gets the Steam Level of the user, as shown on their profile
        /// </summary>
        int GetPlayerSteamLevel();
    }

    public struct UserGetUserDataFolder
    {
        public bool Result;
        public string Path;
    }
    
    public struct UserGetAvailableVoiceResult
    {
        public VoiceResult Result;
        public uint Compressed;
        public uint UnCompressed;
    }

    public struct UserGetVoiceResult
    {
        public VoiceResult Result;
        public uint BytesWritten;
        public uint UnCompressedBytesWritten;
    }

    public struct UserDecompressVoiceResult
    {
        public VoiceResult Result;
        public uint BytesWritten;
    }

    public struct UserGetAuthSessionTicketResult
    {
        public AuthTicketHandle Result;
        public uint TicketLength;
    }

    public struct UserGetEncryptedAppTicketResult
    {
        public bool Result;
        public uint TicketLength;
    }
}
