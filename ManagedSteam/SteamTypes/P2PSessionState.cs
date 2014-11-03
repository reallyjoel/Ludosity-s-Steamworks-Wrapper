using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
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

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct P2PSessionState
    {
        private u8 connectionActive;
        private u8 connecting;
        private u8 p2pSessionError;
        private u8 usingRelay;
        private s32 bytesQueuedForSend;
        private s32 packetsQueuedForSend;
        private u32 remoteIP;
        private u16 remotePort;

        internal static P2PSessionState Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<P2PSessionState>(data, dataSize);
        }


        /// <summary>
        /// true if we've got an active open connection
        /// </summary>
        public bool ConnectionActive { get { return connectionActive != 0; } }
        /// <summary>
        /// true if we're currently trying to establish a connection
        /// </summary>
        public bool Connecting { get { return connecting != 0; } }
        /// <summary>
        /// last error recorded 
        /// </summary>
        public P2PSessionError P2PSessionError { get { return (P2PSessionError)p2pSessionError; } }
        /// <summary>
        /// true if it's going through a relay server (TURN)
        /// </summary>
        public bool UsingRelay { get { return usingRelay != 0; } }
        public int BytesQueuedForSend { get { return bytesQueuedForSend; } }
        public int PacketsQueuedForSend { get { return packetsQueuedForSend; } }
        /// <summary>
        /// potential IP:Port of remote host. Could be TURN server. 
        /// </summary>
        public uint RemoteIP { get { return remoteIP; } }
        /// <summary>
        /// Only exists for compatibility with older authentication api's
        /// </summary>
        public ushort RemotePort { get { return remotePort; } }


    }
}
