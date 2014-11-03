using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UGCHandle : IEquatable<UGCHandle>
    {
        public static readonly UGCHandle Invalid = new UGCHandle(0xfffffffffffffffful);

        private ulong handle;

        public UGCHandle(ulong value)
        {
            this.handle = value;
        }

        public ulong AsUInt64 { get { return handle; } }

        public static bool operator ==(UGCHandle x, UGCHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(UGCHandle x, UGCHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(UGCHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is UGCHandle && this == (UGCHandle)obj;
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
