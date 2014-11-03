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
    /// called when a users coutry changes.
    /// 
    /// Wrapper for the \steamref IPCountry_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]//, CharSet = CharSet.Ansi)]
    public struct IPCountry
    {
        u8 deadWeight;      //The C++ counterpart is 1 byte large, even though it doesn't contain anything, so we need this byte to make the sizes match.

        internal static IPCountry Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<IPCountry>(data, dataSize);
        }
    }

    /// <summary>
    /// called when running on a laptop and less then 10 minutes of battery if left,
    /// fires then every minute.
    /// 
    /// Wrapper for the \steamref LowBatteryPower_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]//, CharSet = CharSet.Ansi)]
    public struct LowBatteryPower
    {
        private u8 minutesBatteryLeft;

        internal static LowBatteryPower Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LowBatteryPower>(data, dataSize);
        }

        public int MinutesBatteryLeft { get { return minutesBatteryLeft; } }
    }

    /// <summary>
    /// called when SteamAsyncCall_t has completed (or failed).
    /// 
    /// Wrapper for the \steamref SteamAPICallCompleted_t
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]//, CharSet = CharSet.Ansi)]
    public struct SteamAPICallCompleted
    {
        u64 hAsyncCall;

        internal static SteamAPICallCompleted Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SteamAPICallCompleted>(data, dataSize);
        }

        public u64 AsyncCall { get { return hAsyncCall; } }
    }

    /// <summary>
    /// Called when steam want to shut down.
    /// 
    /// Wrapper for \steamref SteamShutdown_t
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct SteamShutdown
    {
        Byte ballast;

        internal static SteamShutdown Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SteamShutdown>(data, dataSize);
        }
    }

    /// <summary>
    /// Callback for CheckFileSignature.
    /// 
    /// Wrapper for \steamref CheckFileSignature_t
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]//, CharSet = CharSet.Ansi)]
    public struct CheckFileSignature
    {
        ECheckFileSignature checkFileSignature;

        internal static CheckFileSignature Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<CheckFileSignature>(data, dataSize);
        }

        public ECheckFileSignature FileSignature { get { return checkFileSignature; } } 
    }

    /// <summary>
    /// Called when Big Picture gamepad text input has been closed
    /// 
    /// Wrapper for the \steamref GamepadTextInputDismissed_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GamepadTextInputDismissed
    {
        bool submitted;

        u32 submittedText;

        internal static GamepadTextInputDismissed Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GamepadTextInputDismissed>(data, dataSize);
        }

        public bool Submitted { get { return submitted; } }
    }
}
