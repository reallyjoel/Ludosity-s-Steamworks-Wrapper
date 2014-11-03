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
    /// 
    /// 
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]//, CharSet = CharSet.Ansi)]
    public struct TemplateName
    {
        internal static TemplateName Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<TemplateName>(data, dataSize);
        }
    }
}