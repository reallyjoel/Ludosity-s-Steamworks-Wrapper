using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a HServerListRequest type
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct ServerListRequestHandle : IEquatable<ServerListRequestHandle>
    {
        public static readonly ServerListRequestHandle Invalid = new ServerListRequestHandle(0);

        private uint handle;

        public ServerListRequestHandle(uint value)
        {
            this.handle = value;
        }

        public uint AsUInt32 { get { return handle; } }

        public static bool operator ==(ServerListRequestHandle x, ServerListRequestHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(ServerListRequestHandle x, ServerListRequestHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(ServerListRequestHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is ServerListRequestHandle && this == (ServerListRequestHandle)obj;
        }

        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        public override string ToString()
        {
            return handle.ToString(Steam.Instance.Culture);
        }
    }
}
