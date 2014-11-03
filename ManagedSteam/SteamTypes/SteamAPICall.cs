using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct SteamAPICall : IEquatable<SteamAPICall>
    {
        private ulong handle;

        public SteamAPICall(ulong value)
        {
            this.handle = value;
        }

        public ulong AsUInt64 { get { return handle; } }
        public uint AsUInt32 { get { return (uint)handle; } }

        public static bool operator ==(SteamAPICall x, SteamAPICall y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(SteamAPICall x, SteamAPICall y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(SteamAPICall other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is AppID && this == (SteamAPICall)obj;
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
