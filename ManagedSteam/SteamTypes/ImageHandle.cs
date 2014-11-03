using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct ImageHandle : IEquatable<ImageHandle>
    {
        public static readonly ImageHandle Invalid = new ImageHandle(0);
        public static readonly ImageHandle NotLoaded = new ImageHandle(-1);

        private int handle;

        public ImageHandle(int value)
        {
            this.handle = value;
        }

        public int AsInt32 { get { return handle; } }

        public bool IsValid { get { return handle != -1 && handle != 0; }}

        public static bool operator ==(ImageHandle x, ImageHandle y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(ImageHandle x, ImageHandle y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(ImageHandle other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is ImageHandle && this == (ImageHandle)obj;
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
