using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct GameID : IEquatable<GameID>
    {
        private ulong handle;

        public GameID(ulong value)
        {
            this.handle = value;
        }

        public ulong AsUInt64 { get { return handle; } }

        public static bool operator ==(GameID x, GameID y)
        {
            return x.handle == y.handle;
        }

        public static bool operator !=(GameID x, GameID y)
        {
            return x.handle != y.handle;
        }

        public bool Equals(GameID other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            // Check if the other object is of the same type, then use == to check equality
            return obj is GameID && this == (GameID)obj;
        }

        public override int GetHashCode()
        {
            return handle.GetHashCode();
        }

        public override string ToString()
        {
            return handle.ToString(Steam.Instance.Culture);
        }

        public bool IsMod()
        {
            return Type() == EGameIDType.k_EGameIDTypeGameMod;
        }

        public bool IsShortcut()
        {
            return Type() == EGameIDType.k_EGameIDTypeShortcut;
        }

        public bool IsP2PFile()
        {
            return (Type() == EGameIDType.k_EGameIDTypeP2P );
        }

        public bool IsSteamApp()
        {
            return (Type() == EGameIDType.k_EGameIDTypeApp );
        }

        public EGameIDType Type()
        {
            return (EGameIDType)(handle >> 24);
        }

        public uint ModID()
        {
            return (uint)(handle >> 32);
        }

        /*
        public AppID AppID()
        {
            return new AppID(handle & 0xFFFFFF);
        }
        */

        public enum EGameIDType : byte
        {
            k_EGameIDTypeApp        = 0,
            k_EGameIDTypeGameMod    = 1,
            k_EGameIDTypeShortcut   = 2,
            k_EGameIDTypeP2P        = 3,
        };
    }
}
