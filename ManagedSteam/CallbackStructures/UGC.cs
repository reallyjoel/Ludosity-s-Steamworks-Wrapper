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

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UGCQueryCompleted //SteamUGCQueryCompleted_t
    {
        UGCQueryHandle handle;
        Result result;
        u32 numResultsReturned;
        u32 totalMatchingResults;

        internal static UGCQueryCompleted Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UGCQueryCompleted>(data, dataSize);
        }

        UGCQueryHandle Handle { get { return handle; } }
        Result Result { get { return result; } }
        u32 NumResultsReturned { get { return numResultsReturned; } }
        u32 TotalMatchingResults { get { return totalMatchingResults; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UGCRequestUGCDetailsResult //SteamUGCRequestUGCDetailsResult_t
    {
        UGCDetails details;

        internal static UGCRequestUGCDetailsResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UGCRequestUGCDetailsResult>(data, dataSize);
        }

        UGCDetails Details { get { return details; } }
    }
}
