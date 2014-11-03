using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct AchievementIcon : IEquatable<AchievementIcon>
    {
        private int handle;

        public AchievementIcon(int value)
        {
            this.handle = value;
        }

        public int AsInt32 { get { return handle; } }

        public static bool operator ==(AchievementIcon x, AchievementIcon y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(AchievementIcon x, AchievementIcon y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(AchievementIcon other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is AchievementIcon && this == (AchievementIcon)obj;
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
