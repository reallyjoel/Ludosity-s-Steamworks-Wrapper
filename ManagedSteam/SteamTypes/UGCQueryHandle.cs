using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

// This comment section is so that doxygen shows the namespace
/// <summary>
/// 
/// </summary>
namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UGCQueryHandle : IEquatable<UGCQueryHandle>
    {
        public static readonly UGCQueryHandle Invalid = new UGCQueryHandle(0xfffffffffffffffful);

        private ulong handle;

        public UGCQueryHandle(ulong value)
        {
            this.handle = value;
        }

        public ulong AsUInt64 { get { return handle; } }
        public uint AsUInt32 { get { return (uint)handle; } }

        public static bool operator ==(UGCQueryHandle x, UGCQueryHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(UGCQueryHandle x, UGCQueryHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(UGCQueryHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is UGCQueryHandle && this == (UGCQueryHandle)obj;
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
