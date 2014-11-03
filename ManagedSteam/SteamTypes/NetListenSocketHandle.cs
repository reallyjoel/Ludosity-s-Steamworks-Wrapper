using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct NetListenSocketHandle : IEquatable<NetListenSocketHandle>
    {
        private uint handle;

        public NetListenSocketHandle(uint value)
        {
            this.handle = value;
        }

        public uint AsUInt32 { get { return handle; } }

        public static bool operator ==(NetListenSocketHandle x, NetListenSocketHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(NetListenSocketHandle x, NetListenSocketHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(NetListenSocketHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is NetListenSocketHandle && this == (NetListenSocketHandle)obj;
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
