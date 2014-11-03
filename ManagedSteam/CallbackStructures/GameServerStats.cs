using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.CallbackStructures
{
    using u8 = Byte;
    using s8 = SByte;
    using u16 = UInt16;
    using s16 = Int16;
    using u32 = UInt32;
    using s32 = Int32;
    using u64 = UInt64;
    using s64 = Int64;
    using f32 = Single;
    using f64 = Double;

    using Enum = Int32;


    /// <summary>
    /// Wrapper for the \a GSStatsRecieved_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSStatsReceived
    {
        Result result;
        SteamID steamIDUser;

        internal static GSStatsReceived Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSStatsReceived>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public SteamID SteamIDUser { get { return steamIDUser; } }
    }

    /// <summary>
    /// Wrapper for the \a GSStatsStored_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSStatsStored
    {
        Result result;
        SteamID steamIDUser;

        internal static GSStatsStored Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSStatsStored>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public SteamID SteamIDUser { get { return steamIDUser; } }
    }

    /// <summary>
    /// Wrapper for the \a GSStatsUnloaded_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSStatsUnloaded
    {
        SteamID steamIDUser;

        internal static GSStatsUnloaded Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSStatsUnloaded>(data, dataSize);
        }

        public SteamID SteamIDUser { get { return steamIDUser; } }
    }
}
