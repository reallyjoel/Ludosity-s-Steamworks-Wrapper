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
    /// Wrapper for the \a SteamServersConnected_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct SteamServersConnected
    {
        Byte ballast;

        internal static SteamServersConnected Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SteamServersConnected>(data, dataSize);
        }
    }

    /// <summary>
    /// Wrapper for the \a SteamServerConnectFailure_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct SteamServerConnectFailure
    {
        private Result result;

        internal static SteamServerConnectFailure Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SteamServerConnectFailure>(data, dataSize);
        }

        public Result Result { get { return result; } }
    }

    /// <summary>
    /// Wrapper for the \a SteamServersDisconnected_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct SteamServersDisconnected
    {
        private Result result;

        internal static SteamServersDisconnected Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<SteamServersDisconnected>(data, dataSize);
        }

        public Result Result { get { return result; } }
    }


    /// <summary>
    /// Wrapper for the \a ClientGameServerDeny_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ClientGameServerDeny
    {
        private u32 appID;
        private u32 gameServerIP;
        private u16 gameServerPort;
        private u16 secure;
        private u32 reason;

        internal static ClientGameServerDeny Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ClientGameServerDeny>(data, dataSize);
        }

        public u32 AppID { get { return appID; } }
        public u32 GameServerIP { get { return gameServerIP; } }
        public u16 GameServerPort { get { return gameServerPort; } }
        public u16 Secure { get { return secure; } }
        public u32 Reason { get { return reason; } } 
    }

    /// <summary>
    /// Wrapper for the \a IPCFailure_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct IPCFailure
    {
        public enum EFailureType : byte
        {
            FlushedCalbackQueue,
            PipeFail,
        }

        private EFailureType failureType;

        internal static IPCFailure Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<IPCFailure>(data, dataSize);
        }

        public EFailureType FailureType { get { return failureType; } }
    }

    /// <summary>
    /// Wrapper for the \a ValidateAuthTicketResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 20, CharSet = CharSet.Ansi)]
    public struct ValidateAuthTicketResponse
    {
        private SteamID steamID;    
        private Enum authSessionResponse;
        private SteamID ownerSteamID;


        internal static ValidateAuthTicketResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ValidateAuthTicketResponse>(data, dataSize);
        }

        public SteamID SteamIDUser { get { return steamID; } }
        public AuthSessionResponse AuthSessionResponseResponse { get { return (AuthSessionResponse)authSessionResponse; } }
        public SteamID SteamIDOwner { get { return ownerSteamID; } }
    }

    /// <summary>
    /// Wrapper for the \a MicroTxnAuthorizationResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct MicroTxnAuthorizationResponse
    {
        private u32 appID;
        private u64 orderID;
        private u8 authorized;

        internal static MicroTxnAuthorizationResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<MicroTxnAuthorizationResponse>(data, dataSize);
        }

        public u32 AppID { get { return appID; } }
        public u64 OrderID { get { return orderID; } }
        public u8 Authorized { get { return authorized; } }
    }

    /// <summary>
    /// Wrapper for the \a EncryptedAppTicketResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct EncryptedAppTicketResponse
    {
        private Result result;

        internal static EncryptedAppTicketResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<EncryptedAppTicketResponse>(data, dataSize);
        }

        public Result Result { get { return result; } }
    }

    /// <summary>
    /// Wrapper for the \a GetAuthSessionTicketResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GetAuthSessionTicketResponse
    {
        private AuthTicketHandle authTicket;
        private Result result;

        internal static GetAuthSessionTicketResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GetAuthSessionTicketResponse>(data, dataSize);
        }

        public AuthTicketHandle AuthTicket { get { return authTicket; } }
        public Result Result { get { return result; } }
    }

    /// <summary>
    /// Wrapper for the \a GameWebCallback_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GameWebCallback
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.User.URLNameMax)]
        private string url;

        internal static GameWebCallback Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameWebCallback>(data, dataSize);
        }

        public string URL { get { return url; } }
    }
}
