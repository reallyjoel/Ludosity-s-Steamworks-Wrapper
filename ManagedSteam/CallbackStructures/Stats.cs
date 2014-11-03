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

    #region User stats
    /// <summary>
    /// Wrapper for the \a UserStatsReceived_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UserStatsReceived // UserStatsReceived_t
    {
        private GameID gameID;
        private Result result;
        private SteamID userID;

        internal static UserStatsReceived Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UserStatsReceived>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public Result Result { get { return result; } }
        public SteamID UserID { get { return userID; } }
    }

    /// <summary>
    /// Wrapper for the \a UserStatsStored_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UserStatsStored // UserStatsStored_t
    {
        private GameID gameID;
        private Result result;

        internal static UserStatsStored Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UserStatsStored>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public Result Result { get { return result; } }
    }

    /// <summary>
    /// Wrapper for the \a UserStatsUnloaded_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct UserStatsUnloaded // UserStatsUnloaded_t
    {
        private SteamID userID;

        internal static UserStatsUnloaded Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UserStatsUnloaded>(data, dataSize);
        }

        public SteamID UserID { get { return userID; } }
    }

    /// <summary>
    /// Wrapper for the \a GlobalStatsReceived_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct GlobalStatsReceived // GlobalStatsReceived_t
    {
        private GameID gameID;
        private Result result;

        internal static GlobalStatsReceived Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GlobalStatsReceived>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public Result Result { get { return result; } }
    }

    /// <summary>
    /// Wrapper for the \a NumberOfCurrentPlayers_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct NumberOfCurrentPlayers // NumberOfCurrentPlayers_t
    {
        private u8 success;
        private s32 numberOfPlayers;

        internal static NumberOfCurrentPlayers Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<NumberOfCurrentPlayers>(data, dataSize);
        }

        public byte Success { get { return success; } }
        public int NumberOfPlayers { get { return numberOfPlayers; } }
    }

    #endregion

    #region Achievements
    /// <summary>
    /// Wrapper for the \a UserAchievementStored_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct UserAchievementStored // UserAchievementStored_t
    {
        private GameID gameID;
        [MarshalAs(UnmanagedType.I1)]
        private bool groupAchievement;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Stats.StatNameMax)]
        private string name;
        private u32 currentProgress;
        private u32 maxProgress;


        internal static UserAchievementStored Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UserAchievementStored>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public bool GroupAchievement { get { return groupAchievement; } }
        public string Name { get { return name; } }
        public uint CurrentProgress { get { return currentProgress; } }
        public uint MaxProgress { get { return maxProgress; } }
    }

    /// <summary>
    /// Wrapper for the \a UserAchievementIconFetched_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct UserAchievementIconFetched // UserAchievementIconFetched_t
    {
        private GameID gameID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Stats.StatNameMax)]
        private string name;
        [MarshalAs(UnmanagedType.I1)]
        private bool achieved;
        private IconHandle iconHandle;

        internal static UserAchievementIconFetched Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<UserAchievementIconFetched>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public string Name { get { return name; } }
        public bool Achieved { get { return achieved; } }
        public IconHandle IconHandle { get { return iconHandle; } }
    }

    /// <summary>
    /// Wrapper for the \a GlobalAchievementPercentagesReady_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct GlobalAchievementPercentagesReady // GlobalAchievementPercentagesReady_t
    {
        private GameID gameID;
        private Result result;

        internal static GlobalAchievementPercentagesReady Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GlobalAchievementPercentagesReady>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public Result Result { get { return result; } }
    }

    #endregion

    #region Leaderboards

    /// <summary>
    /// Wrapper for the \a LeaderboardFindResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct LeaderboardFindResult // LeaderboardFindResult_t
    {
        private LeaderboardHandle leaderboard;
        private u8 leaderboardFound;

        internal static LeaderboardFindResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LeaderboardFindResult>(data, dataSize);
        }

        public LeaderboardHandle Leaderboard { get { return leaderboard; } }
        public byte LeaderboardFound { get { return leaderboardFound; } }
    };

    /// <summary>
    /// Wrapper for the \a LeaderboardScoresDownloaded_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct LeaderboardScoresDownloaded // LeaderboardScoresDownloaded_t
    {
        private LeaderboardHandle leaderboard;
        private LeaderboardEntriesHandle entries;
        private s32 entryCount;

        internal static LeaderboardScoresDownloaded Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LeaderboardScoresDownloaded>(data, dataSize);
        }

        public LeaderboardHandle Leaderboard { get { return leaderboard; } }
        public LeaderboardEntriesHandle Entries { get { return entries; } }
        public int EntryCount { get { return entryCount; } }
    }

    /// <summary>
    /// Wrapper for the \a LeaderboardScoreUploaded_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct LeaderboardScoreUploaded // LeaderboardScoreUploaded_t
    {
        private u8 success;
        private LeaderboardHandle leaderboard;
        private s32 score;
        private u8 scoreChanged;
        private s32 rankNew;
        private s32 rankPrevious;

        internal static LeaderboardScoreUploaded Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LeaderboardScoreUploaded>(data, dataSize);
        }

        public byte Success { get { return success; } }
        public LeaderboardHandle Leaderboard { get { return leaderboard; } }
        public int Score { get { return score; } }
        public byte ScoreChanged { get { return scoreChanged; } }
        public int RankNew { get { return rankNew; } }
        public int RankPrevious { get { return rankPrevious; } }
    }

    /// <summary>
    /// Wrapper for the \a LeaderboardUGCSet_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct LeaderboardUGCSet // LeaderboardUGCSet_t
    {
        private Result result;
        private LeaderboardHandle leaderboard;

        internal static LeaderboardUGCSet Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LeaderboardUGCSet>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public LeaderboardHandle Leaderboard { get { return leaderboard; } }
    };

    #endregion

}
