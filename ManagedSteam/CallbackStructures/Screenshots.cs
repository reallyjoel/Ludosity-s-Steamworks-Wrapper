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

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ScreenshotReady
    {
        private ScreenshotHandle local;
        private Result result;

        internal static ScreenshotReady Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ScreenshotReady>(data, dataSize);
        }

        public ScreenshotHandle Local { get { return local; } }
        public Result Result { get { return result; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ScreenshotRequested
    {
        Byte ballast;

        internal static ScreenshotRequested Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ScreenshotRequested>(data, dataSize);
        }
    }
}
