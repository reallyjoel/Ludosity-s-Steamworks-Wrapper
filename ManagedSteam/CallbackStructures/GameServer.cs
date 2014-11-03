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
    /// Client has been approved to connect to this game server
    /// 
    /// Wrapper for the \steamref GSClientApprove_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSClientApprove
    {
        SteamID steamID;
        SteamID ownerSteamID;

        internal static GSClientApprove Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSClientApprove>(data, dataSize);
        }

        public SteamID SteamIDClient { get { return steamID; } }
        public SteamID SteamIDOwner { get { return ownerSteamID; } }
    }

    /// <summary>
    /// Client has been denied to connection to this game server
    /// 
    /// Wrapper for the \steamref GSClientDeny_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSClientDeny
    {
        SteamID steamID;
        DenyReason denyReason;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.GameServer.GSClientDenyText)]
        string optionalText;

        internal static GSClientDeny Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSClientDeny>(data, dataSize);
        }

        public SteamID SteamIDClient { get { return steamID; } }
        public DenyReason DenyReason { get { return denyReason; } }
        public string OptionalText { get { return optionalText; } }
    }

    /// <summary>
    /// request the game server should kick the user
    /// 
    /// Wrapper for the \steamref GSClientKick_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSClientKick
    {
        SteamID steamID;
        DenyReason denyReason;

        internal static GSClientKick Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSClientKick>(data, dataSize);
        }

        public SteamID SteamID { get { return steamID; } }
        public DenyReason DenyReason { get { return denyReason; } }

    }

    /// <summary>
    /// client achievement info
    /// 
    /// Wrapper for the \steamref GSClientAchievementStatus_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSClientAchievementStatus
    {
        SteamID steamID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.GameServer.GSClientAchievementStatusText)]
        string achievement;
        [MarshalAs(UnmanagedType.I1)]
        bool unlocked;

        internal static GSClientAchievementStatus Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSClientAchievementStatus>(data, dataSize);
        }

        public SteamID SteamID { get { return steamID; } }
        public string Achievement { get { return achievement; } }
        bool Unlocked { get { return unlocked; } }

    }

    /// <summary>
    /// received when the game server requests to be displayed as secure (VAC protected)
    /// Secure is true if the game server should display itself as secure to users, false otherwise
    /// 
    /// Wrapper for the \steamref GSPolicyResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSPolicyResponse
    {
        u8 secure;

        internal static GSPolicyResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSPolicyResponse>(data, dataSize);
        }

        public bool Secure { get { return secure != 0; } }
    }

    /// <summary>
    /// GS gameplay stats info
    /// 
    /// Wrapper for the \steamref GSGameplayStats_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSGameplayStats
    {
        Result result;
        s32 rank;
        u32 totalConnects;
        u32 totalMinutesPlayed;

        internal static GSGameplayStats Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSGameplayStats>(data, dataSize);
        }

        /// <summary>
        /// Result of the call
        /// </summary>
        public Result Result { get { return result; } }
        /// <summary>
        /// Overall rank of the server (0-based)
        /// </summary>
        public int Rank { get { return rank; } }
        /// <summary>
        /// Total number of clients who have ever connected to the server
        /// </summary>
        public uint TotalConnects { get { return totalConnects; } }
        /// <summary>
        /// Total number of minutes ever played on the server
        /// </summary>
        public uint TotalMinutesPlayed { get { return totalMinutesPlayed; } }

    }

    /// <summary>
    /// send as a reply to RequestUserGroupStatus()
    /// 
    /// Wrapper for the \steamref GSClientGroupStatus_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSClientGroupStatus
    {
        SteamID steamIDUser;
        SteamID steamIDGroup;
        [MarshalAs(UnmanagedType.I1)]
        bool member;
        [MarshalAs(UnmanagedType.I1)]
        bool officer;

        internal static GSClientGroupStatus Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSClientGroupStatus>(data, dataSize);
        }

        public SteamID SteamIDUser { get { return steamIDUser; } }
        public SteamID SteamIDGroup { get { return steamIDGroup; } }
        public bool Member { get { return member; } }
        public bool Officer { get { return officer; } }

    }

    /// <summary>
    /// Sent as a reply to GetServerReputation()
    /// 
    /// Wrapper for the \steamref GSReputation_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GSReputation
    {
        Result result;
        u32 reputationScore;
        [MarshalAs(UnmanagedType.I1)]
        bool banned;

        u32 bannedIP;
        u16 bannedPort;		// The port of the banned server
        GameID bannedGameID;	// The game ID the banned server is serving
        u32 banExpires;		// Time the ban expires, expressed in the Unix epoch (seconds since 1/1/1970)


        internal static GSReputation Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GSReputation>(data, dataSize);
        }

        /// <summary>
        /// Result of the call;
        /// </summary>
        public Result Result { get { return result; } }
        /// <summary>
        /// The reputation score for the game server
        /// </summary>
        public uint ReputationScore { get { return reputationScore; } }
        /// <summary>
        /// True if the server is banned from the Steam master servers
        /// </summary>
        public bool Banned { get { return banned; } }

        /// <summary>
        /// The following members are only filled out if m_bBanned is true. They will all 
        /// be set to zero otherwise. Master server bans are by IP so it is possible to be
        /// banned even when the score is good high if there is a bad server on another port.
        /// This information can be used to determine which server is bad.
        /// 
        /// The IP of the banned server
        /// </summary>
        public uint BannedIP { get { return bannedIP; } }
        /// <summary>
        /// The port of the banned server
        /// </summary>
        public ushort BannedPort { get { return bannedPort; } }
        /// <summary>
        /// The game ID the banned server is serving
        /// </summary>
        public GameID BannedGameID { get { return bannedGameID; } }
        /// <summary>
        /// Time the ban expires, expressed in the Unix epoch (seconds since 1/1/1970)
        /// </summary>
        public uint BanExpires { get { return banExpires; } }
    }

    /// <summary>
    /// Sent as a reply to AssociateWithClan()
    /// 
    /// Wrapper for the \steamref AssociateWithClanResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct AssociateWithClanResult
    {
        Result result;

        internal static AssociateWithClanResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<AssociateWithClanResult>(data, dataSize);
        }

        /// <summary>
        /// Result of the call;
        /// </summary>
        public Result Result { get { return result; } }

    }

    /// <summary>
    /// Sent as a reply to ComputeNewPlayerCompatibility()
    /// 
    /// Wrapper for the \steamref ComputeNewPlayerCompatibilityResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ComputeNewPlayerCompatibilityResult
    {
        Result result;
        s32 playersThatDontLikeCandidate;
        s32 playersThatCandidateDoesntLike;
        s32 clanPlayersThatDontLikeCandidate;
        SteamID steamIDCandidate;

        internal static ComputeNewPlayerCompatibilityResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ComputeNewPlayerCompatibilityResult>(data, dataSize);
        }

        /// <summary>
        /// Result of the call
        /// </summary>
        public Result Result { get { return result; } }
        public int PlayersThatDontLikeCandidate { get { return playersThatDontLikeCandidate; } }
        public int PlayersThatCandidateDoesntLike { get { return playersThatCandidateDoesntLike; } }
        public int ClanPlayersThatDontLikeCandidate { get { return clanPlayersThatDontLikeCandidate; } }
        public SteamID SteamIDCandidate { get { return steamIDCandidate; } }

    }

}
