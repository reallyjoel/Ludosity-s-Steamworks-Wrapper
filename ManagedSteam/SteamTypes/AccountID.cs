using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct AccountID : IEquatable<AccountID>
    {
        private uint handle;

        public AccountID(uint value)
        {
            this.handle = value;
        }

        public uint AsUInt32 { get { return handle; } }

        public static bool operator ==(AccountID x, AccountID y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(AccountID x, AccountID y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(AccountID other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is AccountID && this == (AccountID)obj;
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
