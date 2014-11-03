using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.Utility;

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


    /// <summary>
    /// Managed version of the \a servernetadr_t class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ServerNetworkAddress : IComparable<ServerNetworkAddress>
    {
        private u16 connectionPort;
        private u16 queryPort;
        private u32 ip;

        internal static ServerNetworkAddress Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ServerNetworkAddress>(data, dataSize);
        }

        /// <summary>
        /// If an instance is created with this constructor, there is no need to call Init.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="queryPort"></param>
        /// <param name="connectionPort"></param>
        public ServerNetworkAddress(uint ip, ushort queryPort, ushort connectionPort)
        {
            this.ip = ip;
            this.queryPort = queryPort;
            this.connectionPort = connectionPort;
        }

        public void Init(uint ip, ushort queryPort, ushort connectionPort)
        {
            this.ip = ip;
            this.queryPort = queryPort;
            this.connectionPort = connectionPort;
        }

        /// <summary>
        /// (in HOST byte order)
        /// </summary>
        public ushort ConnectionPort
        {
            get { return connectionPort; }
            set { connectionPort = value; }
        }
        public ushort QueryPort
        {
            get { return queryPort; }
            set { queryPort = value; }
        }
        public uint IP
        {
            get { return ip; }
            set { ip = value; }
        }

        /// <summary>
        /// This gets the 'a.b.c.d:port' string with the connection port (instead of the query port).
        /// </summary>
        /// <returns></returns>
        public string GetConnectionAddressString()
        {
            using (NativeBuffer buffer = NativeBuffer.CopyToNative(this))
            {
                IntPtr stringPtr = NativeMethods.MatchmakingServerNetworkAddress_GetConnectionString(buffer.UnmanagedMemory);
                return NativeHelpers.ToStringAnsi(stringPtr);
            }
        }

        public string GetQueryAddressString()
        {
            using (NativeBuffer buffer = NativeBuffer.CopyToNative(this))
            {
                IntPtr stringPtr = NativeMethods.MatchmakingServerNetworkAddress_GetQueryString(buffer.UnmanagedMemory);
                return NativeHelpers.ToStringAnsi(stringPtr);
            }
        }

        public int CompareTo(ServerNetworkAddress other)
        {
            if ((ip < other.ip) || (ip == other.ip && queryPort < other.queryPort))
            {
                return -1;
            }
            else if (ip == other.ip && queryPort == other.queryPort)
            {
                return 0;
            }
            return 1;
        }
    }
}
