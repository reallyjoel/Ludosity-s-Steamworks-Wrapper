using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.CallbackStructures
{
    using u8 = Byte;
    using s8 = SByte;
    using u16 = UInt16;
    using s16 = Int16;
    using u32 = UInt32;
    using s32 = Int32;
    using u64 = UInt64;
    using s64 = Int64;
    using f32 = Single;
    using f64 = Double;

    using Enum = Int32;

    /// <summary>
    /// callback notification - a user wants to talk to us over the P2P channel via the SendP2PPacket() API
    /// in response, a call to AcceptP2PPacketsFromUser() needs to be made, if you want to talk with them
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct P2PSessionRequest
    {
        private SteamID steamIDRemote;

        internal static P2PSessionRequest Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<P2PSessionRequest>(data, dataSize);
        }

        /// <summary>
        /// user we were sending packets to
        /// </summary>
        public SteamID SteamIDRemote { get { return steamIDRemote; } }
    }

    /// <summary>
    /// callback notification - packets can't get through to the specified user via the SendP2PPacket() API.
    /// all packets queued packets unsent at this point will be dropped.
    /// further attempts to send will retry making the connection (but will be dropped if we fail again)
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct P2PSessionConnectFail
    {
        private SteamID steamIDRemote;
        private u8 p2pSessionError;

        internal static P2PSessionConnectFail Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<P2PSessionConnectFail>(data, dataSize);
        }

        /// <summary>
        /// user we were sending packets to
        /// </summary>
        public SteamID SteamIDRemote { get { return steamIDRemote; } }
        public P2PSessionError SessionError { get { return (P2PSessionError)p2pSessionError; } }
    }

    /// <summary>
    /// callback notification - status of a socket has changed.
    /// used as part of the CreateListenSocket() / CreateP2PConnectionSocket() 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct SocketStatusCallback
    {
        private u32 socket;
        private u32 listenSocket;
        private SteamID steamIDRemote;
        private s32 netSocketState;

        internal static SocketStatusCallback Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SocketStatusCallback>(data, dataSize);
        }

        /// <summary>
        /// the socket used to send/receive data to the remote host
        /// </summary>
        public uint Socket { get { return socket; } }
        /// <summary>
        /// this is the server socket that we were listening on; NULL if this was an outgoing connection
        /// </summary>
        public uint ListenSocket { get { return listenSocket; } }
        /// <summary>
        /// remote steamID we have connected to, if it has one
        /// </summary>
        public SteamID SteamIDRemote { get { return steamIDRemote; } }
        /// <summary>
        /// socket state
        /// </summary>
        public SNetSocketState NetSocketState { get { return (SNetSocketState)netSocketState; } }
    }
}
