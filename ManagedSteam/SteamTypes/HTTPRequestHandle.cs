using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>
    {
        private uint handle;

        public HTTPRequestHandle(uint value)
        {
            this.handle = value;
        }

        public uint AsUInt32 { get { return handle; } }

        public static bool operator ==(HTTPRequestHandle x, HTTPRequestHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(HTTPRequestHandle x, HTTPRequestHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(HTTPRequestHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return obj is HTTPRequestHandle && this == (HTTPRequestHandle)obj;
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
