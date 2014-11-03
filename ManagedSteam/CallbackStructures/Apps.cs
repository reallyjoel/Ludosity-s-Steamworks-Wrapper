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

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, Size=4, CharSet=CharSet.Ansi)]
    public struct DlcInstalled
    {
        private u32 appID;

        internal static DlcInstalled Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<DlcInstalled>(data, dataSize);
        }

        public u32 AppID { get { return appID; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet=CharSet.Ansi)]
    public struct RegisterActivationCodeResponse
    {
        private RegisterActivationCodeResult result;
        private u32 packadeRegistered;

        internal static RegisterActivationCodeResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<RegisterActivationCodeResponse>(data, dataSize);
        }

        public RegisterActivationCodeResult Result { get { return result; } }

        public u32 PackageRegistered { get { return packadeRegistered; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct AppProofOfPurchaseKeyResponse
    {
        private Result result;
        private u32 appID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Apps.AppProofOfPurchaseKeyMax)]
        private string key;

        internal static AppProofOfPurchaseKeyResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<AppProofOfPurchaseKeyResponse>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public u32 AppID { get { return appID; } }
        public string Key { get { return key; } }
    }

    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct NewLaunchQueryParameters
    {
        Byte ballast;

        internal static NewLaunchQueryParameters Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<NewLaunchQueryParameters>(data, dataSize);
        }
    }
}
