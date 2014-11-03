using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Stats : SteamService, IStats
    {
        private List<UserStatsReceived> userStatsReceived;
        private List<UserStatsStored> userStatsStored;
        private List<UserAchievementStored> userAchievementStored;
        private List<Result<LeaderboardFindResult>> leaderboardFindResult;
        private List<Result<LeaderboardScoresDownloaded>> leaderboardScoresDownloaded;
        private List<Result<LeaderboardScoreUploaded>> leaderboardScoresUploaded;
        private List<Result<LeaderboardUGCSet>> leaderboardUGCSet;
        private List<Result<NumberOfCurrentPlayers>> numberOfCurrentPlayers;
        private List<UserStatsUnloaded> userStatsUnloaded;
        private List<UserAchievementIconFetched> userAchievementIconFetched;
        private List<Result<GlobalAchievementPercentagesReady>> globalAchievementPercentages;
        private List<Result<GlobalStatsReceived>> globalStatsReceived;

        internal Stats()
        {
            userStatsReceived = new List<UserStatsReceived>();
            userStatsStored = new List<UserStatsStored>();
            userAchievementStored = new List<UserAchievementStored>();
            leaderboardFindResult = new List<Result<LeaderboardFindResult>>();
            leaderboardScoresDownloaded = new List<Result<LeaderboardScoresDownloaded>>();
            leaderboardScoresUploaded = new List<Result<LeaderboardScoreUploaded>>();
            leaderboardUGCSet = new List<Result<LeaderboardUGCSet>>();
            numberOfCurrentPlayers = new List<Result<NumberOfCurrentPlayers>>();
            userStatsUnloaded = new List<UserStatsUnloaded>();
            userAchievementIconFetched = new List<UserAchievementIconFetched>();
            globalAchievementPercentages = new List<Result<GlobalAchievementPercentagesReady>>();
            globalStatsReceived = new List<Result<GlobalStatsReceived>>();

            Callbacks[CallbackID.UserStatsReceived] = (data, size) => userStatsReceived.Add(CallbackStructures.UserStatsReceived.Create(data, size));
            Callbacks[CallbackID.UserStatsStored] = (data, size) => userStatsStored.Add(CallbackStructures.UserStatsStored.Create(data, size));
            Callbacks[CallbackID.UserAchievementStored] = (data, size) => userAchievementStored.Add(CallbackStructures.UserAchievementStored.Create(data, size));
            Results[ResultID.LeaderboardFindResult] = (data, size, flag) => leaderboardFindResult.Add(new Result<LeaderboardFindResult>(CallbackStructures.LeaderboardFindResult.Create(data, size), flag));
            Results[ResultID.LeaderboardScoresDownloaded] = (data, size, flag) => leaderboardScoresDownloaded.Add(new Result<LeaderboardScoresDownloaded>(CallbackStructures.LeaderboardScoresDownloaded.Create(data, size), flag));
            Results[ResultID.LeaderboardScoreUploaded] = (data, size, flag) => leaderboardScoresUploaded.Add(new Result<LeaderboardScoreUploaded>(CallbackStructures.LeaderboardScoreUploaded.Create(data, size), flag));
            Results[ResultID.LeaderboardUGCSet] = (data, size, flag) => leaderboardUGCSet.Add(new Result<LeaderboardUGCSet>(CallbackStructures.LeaderboardUGCSet.Create(data, size), flag));
            Results[ResultID.NumberOfCurrentPlayers] = (data, size, flag) => numberOfCurrentPlayers.Add(new Result<NumberOfCurrentPlayers>(CallbackStructures.NumberOfCurrentPlayers.Create(data, size), flag));
            Callbacks[CallbackID.UserStatsUnloaded] = (data, size) => userStatsUnloaded.Add(CallbackStructures.UserStatsUnloaded.Create(data, size));
            Callbacks[CallbackID.UserAchievementIconFetched] = (data, size) => userAchievementIconFetched.Add(CallbackStructures.UserAchievementIconFetched.Create(data, size));
            Results[ResultID.GlobalAchievementPercentagesReady] = (data, size, flag) => globalAchievementPercentages.Add(new Result<GlobalAchievementPercentagesReady>(CallbackStructures.GlobalAchievementPercentagesReady.Create(data, size), flag));
            Results[ResultID.GlobalStatsReceived] = (data, size, flag) => globalStatsReceived.Add(new Result<GlobalStatsReceived>(CallbackStructures.GlobalStatsReceived.Create(data, size), flag));
        }

        /// <summary>
        /// Invoked by RequestUserStats()
        /// </summary>
        public event CallbackEvent<UserStatsReceived> UserStatsReceived;
        /// <summary>
        /// Invoked by StoreStats()
        /// </summary>
        public event CallbackEvent<UserStatsStored> UserStatsStored;
        /// <summary>
        /// Invoked by StoreStats()
        /// </summary>
        public event CallbackEvent<UserAchievementStored> UserAchievementStored;
        /// <summary>
        /// Invoked by FindOrCreateLeaderboard() and FindLeaderboard()
        /// </summary>
        public event ResultEvent<LeaderboardFindResult> LeaderboardFindResult;
        /// <summary>
        /// Invoked by DownloadLeaderboardEntries() and DownloadLeaderboardEntriesForUsers()
        /// </summary>
        public event ResultEvent<LeaderboardScoresDownloaded> LeaderboardScoresDownloaded;
        /// <summary>
        /// Invoked by UploadLeaderboardScore()
        /// </summary>
        public event ResultEvent<LeaderboardScoreUploaded> LeaderboardScoreUploaded;
        /// <summary>
        /// Invoked by AttachLeaderboardUGC()
        /// </summary>
        public event ResultEvent<LeaderboardUGCSet> LeaderboardUGCSet;
        /// <summary>
        /// Invoked by GetNumberOfCurrentPlayers()
        /// </summary>
        public event ResultEvent<NumberOfCurrentPlayers> NumberOfCurrentPlayers;
        public event CallbackEvent<UserStatsUnloaded> UserStatsUnloaded;
        public event CallbackEvent<UserAchievementIconFetched> UserAchievementIconFetched;
        /// <summary>
        /// Invoked by RequestGlobalAchievementPercentages()
        /// </summary>
        public event ResultEvent<GlobalAchievementPercentagesReady> GlobalAchievementPercentagesReady;
        /// <summary>
        /// Invoked by RequestGlobalStats()
        /// </summary>
        public event ResultEvent<GlobalStatsReceived> GlobalStatsReceived;

        internal override void CheckIfUsableInternal()
        {

        }

        internal override void InvokeEvents()
        {
            InvokeEvents(userStatsReceived, UserStatsReceived);
            InvokeEvents(userStatsStored, UserStatsStored);
            InvokeEvents(userAchievementStored, UserAchievementStored);
            InvokeEvents(leaderboardFindResult, LeaderboardFindResult);
            InvokeEvents(leaderboardScoresDownloaded, LeaderboardScoresDownloaded);
            InvokeEvents(leaderboardScoresUploaded, LeaderboardScoreUploaded);
            InvokeEvents(leaderboardUGCSet, LeaderboardUGCSet);
            InvokeEvents(numberOfCurrentPlayers, NumberOfCurrentPlayers);
            InvokeEvents(userStatsUnloaded, UserStatsUnloaded);
            InvokeEvents(userAchievementIconFetched, UserAchievementIconFetched);
            InvokeEvents(globalAchievementPercentages, GlobalAchievementPercentagesReady);
            InvokeEvents(globalStatsReceived, GlobalStatsReceived);
        }

        internal override void ReleaseManagedResources()
        {
            userStatsReceived = null;
            UserStatsReceived = null;
            userStatsStored = null;
            UserStatsStored = null;
            userAchievementStored = null;
            UserAchievementStored = null;
            leaderboardFindResult = null;
            LeaderboardFindResult = null;
            leaderboardScoresDownloaded = null;
            LeaderboardScoresDownloaded = null;
            leaderboardScoresUploaded = null;
            LeaderboardScoreUploaded = null;
            leaderboardUGCSet = null;
            LeaderboardUGCSet = null;
            numberOfCurrentPlayers = null;
            NumberOfCurrentPlayers = null;
            userStatsUnloaded = null;
            UserStatsUnloaded = null;
            userAchievementIconFetched = null;
            UserAchievementIconFetched = null;
            globalAchievementPercentages = null;
            GlobalAchievementPercentagesReady = null;
            globalStatsReceived = null;
            GlobalStatsReceived = null;
        }


        public bool RequestCurrentStats()
        {
            CheckIfUsable();
            return NativeMethods.Stats_RequestCurrentStats();
        }

        public bool GetStat(string name, out int data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.Stats_GetStatInt(name, ref data);
        }

        public StatsGetStatIntResult GetStatInt(string name)
        {
            StatsGetStatIntResult result = new StatsGetStatIntResult();
            result.Result = GetStat(name, out result.IntValue);
            return result;
        }


        public bool GetStat(string name, out float data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.Stats_GetStatFloat(name, ref data);
        }

        public StatsGetStatFloatResult GetStatFloat(string name)
        {
            StatsGetStatFloatResult result = new StatsGetStatFloatResult();
            result.Result = GetStat(name, out result.FloatValue);
            return result;
        }

        public bool SetStat(string name, int data)
        {
            CheckIfUsable();
            return NativeMethods.Stats_SetStatInt(name, data);
        }

        public bool SetStat(string name, float data)
        {
            CheckIfUsable();
            return NativeMethods.Stats_SetStatFloat(name, data);
        }

        public bool UpdateAverageRateStat(string name, float countThisSession, double sessionLength)
        {
            CheckIfUsable();
            return NativeMethods.Stats_UpdateAverageRateStat(name, countThisSession, sessionLength);
        }

        public bool GetAchievement(string name, out bool achieved)
        {
            CheckIfUsable();
            achieved = false;
            return NativeMethods.Stats_GetAchievement(name, ref achieved);
        }

        public StatsGetAchievementResult GetAchievement(string name)
        {
            StatsGetAchievementResult result = new StatsGetAchievementResult();
            result.result = GetAchievement(name, out result.sender);
            return result;
        }

        public bool SetAchievement(string name)
        {
            CheckIfUsable();
            return NativeMethods.Stats_SetAchievement(name);
        }

        public bool ClearAchievement(string name)
        {
            CheckIfUsable();
            return NativeMethods.Stats_ClearAchievement(name);
        }

        public bool GetAchievementAndUnlockTime(string name, out bool achieved, out uint unlockTime)
        {
            CheckIfUsable();
            achieved = false;
            unlockTime = 0;
            return NativeMethods.Stats_GetAchievementAndUnlockTime(name, ref achieved, ref unlockTime);
        }

        public StatsGetAchievementAndUnlockTimeResult GetAchievementAndUnlockTime(SteamID steamID, string name)
        {
            StatsGetAchievementAndUnlockTimeResult result = new StatsGetAchievementAndUnlockTimeResult();
            result.result = GetUserAchievementAndUnlockTime(steamID, name, out result.achievedSender, out result.unlockTimeSender);
            return result;
        }

        /// <summary>
        /// Invokes UserStatsStored
        /// </summary>
        /// <returns></returns>
        public bool StoreStats()
        {
            CheckIfUsable();
            return NativeMethods.Stats_StoreStats();
        }

        /// <summary>
        /// Gets the icon of the achievement, which is a handle to be used in ISteamUtils::GetImageRGBA(), or 0 if none set. 
        /// A return value of 0 may indicate we are still fetching data, and you can wait for the UserAchievementIconFetched_t callback
        /// which will notify you when the bits are ready. If the callback still returns zero, then there is no image set for the
        /// specified achievement.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /*
        public AchievementIcon GetAchievementIcon(string name)
        {
            CheckIfUsable();
            int value = NativeMethods.Stats_GetAchievementIcon(name);
            return new SteamTypes.AchievementIcon(value);
        }
        */

        public string GetAchievementDisplayAttribute(string name, string key)
        {
            CheckIfUsable();
            IntPtr pointer = NativeMethods.Stats_GetAchievementDisplayAttribute(name, key);
            return NativeHelpers.ToStringAnsi(pointer);
        }

        public bool IndicateAchievementProgress(string name, uint currentProgress, uint maxProgress)
        {
            CheckIfUsable();
            return NativeMethods.Stats_IndicateAchievementProgress(name, currentProgress, maxProgress);
        }

        /// <summary>
        /// Invokes UserStatsReceived
        /// </summary>
        /// <param name="steamID"></param>
        public void RequestUserStats(SteamID steamID)
        {
            CheckIfUsable();
            NativeMethods.Stats_RequestUserStats(steamID.AsUInt64);
        }

        public bool GetUserStat(SteamID steamID, string name, out int data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.Stats_GetUserStatInt(steamID.AsUInt64, name, ref data);
        }

        public StatsGetUserStatResult GetUserStatInt(SteamID steamID, string name)
        {
            StatsGetUserStatResult result = new StatsGetUserStatResult();
            result.result = GetUserStat(steamID, name, out result.intDataSender);
            return result;
        }

        public bool GetUserStat(SteamID steamID, string name, out float data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.Stats_GetUserStatFloat(steamID.AsUInt64, name, ref data);
        }

        public StatsGetUserStatResult GetUserStatFloat(SteamID steamID, string name)
        {
            StatsGetUserStatResult result = new StatsGetUserStatResult();
            result.result = GetUserStat(steamID, name, out result.floatDataSender);
            return result;

        }

        public bool GetUserAchievement(SteamID steamID, string name, out bool achieved)
        {
            CheckIfUsable();
            achieved = false;
            return NativeMethods.Stats_GetUserAchievement(steamID.AsUInt64, name, ref achieved);
        }

        public StatsGetUserAchievementResult GetUserAchievement(SteamID steamID, string name)
        {
            StatsGetUserAchievementResult result = new StatsGetUserAchievementResult();
            result.result = GetUserAchievement(steamID, name, out result.sender);
            return result;
        }



        public bool GetUserAchievementAndUnlockTime(SteamID steamID, string name, out bool achieved,
            out uint unlockTime)
        {
            CheckIfUsable();
            achieved = false;
            unlockTime = 0;
            return NativeMethods.Stats_GetUserAchievementAndUnlockTime(steamID.AsUInt64, name, ref achieved,
                ref unlockTime);
        }

        public StatsGetUserAchievementAndUnlockTimeResult GetUserAchievementAndUnlockTime(SteamID steamID, string name)
        {
            StatsGetUserAchievementAndUnlockTimeResult result = new StatsGetUserAchievementAndUnlockTimeResult();
            result.result = GetUserAchievementAndUnlockTime(steamID, name, out result.achievedSender, out result.unlockTimeSender);
            return result;
        }





        public bool ResetAllStats(bool achievementsToo)
        {
            CheckIfUsable();
            return NativeMethods.Stats_ResetAllStats(achievementsToo);
        }

        /// <summary>
        /// Invokes LeaderboardFindResult.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sortMethod"></param>
        /// <param name="displayType"></param>
        public void FindOrCreateLeaderboard(string name, LeaderboardSortMethod sortMethod, LeaderboardDisplayType displayType)
        {
            CheckIfUsable();
            NativeMethods.Stats_FindOrCreateLeaderboard(name, (int)sortMethod, (int)displayType);
        }

        /// <summary>
        /// Invokes LeaderboardFindResult.
        /// </summary>
        /// <param name="name"></param>
        public void FindLeaderboard(string name)
        {
            CheckIfUsable();
            NativeMethods.Stats_FindLeaderboard(name);
        }

        public string GetLeaderboardName(LeaderboardHandle handle)
        {
            CheckIfUsable();
            IntPtr pointer = NativeMethods.Stats_GetLeaderboardName(handle.AsUInt64);
            return NativeHelpers.ToStringAnsi(pointer);
        }

        public int GetLeaderboardEntryCount(LeaderboardHandle handle)
        {
            CheckIfUsable();
            return NativeMethods.Stats_GetLeaderboardEntryCount(handle.AsUInt64);
        }

        public LeaderboardSortMethod GetLeaderboardSortMethod(LeaderboardHandle handle)
        {
            CheckIfUsable();
            return (LeaderboardSortMethod)NativeMethods.Stats_GetLeaderboardSortMethod(handle.AsUInt64);
        }

        public LeaderboardDisplayType GetLeaderboardDisplayType(LeaderboardHandle handle)
        {
            CheckIfUsable();
            return (LeaderboardDisplayType)NativeMethods.Stats_GetLeaderboardDisplayType(handle.AsUInt64);
        }

        /// <summary>
        /// Invokes LeaderboardScoresDownloaded
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="dataRequest"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void DownloadLeaderboardEntries(LeaderboardHandle handle, LeaderboardDataRequest dataRequest,
            int rangeStart, int rangeEnd)
        {
            CheckIfUsable();
            NativeMethods.Stats_DownloadLeaderboardEntries(handle.AsUInt64, (int)dataRequest, rangeStart, rangeEnd);
        }

        /// <summary>
        /// Invokes LeaderboardScoresDownloaded
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="users"></param>
        public void DownloadLeaderboardEntriesForUsers(LeaderboardHandle handle, SteamID[] users)
        {
            CheckIfUsable();
            // We need to first convert the array of SteamID objects to a byte array
            byte[] rawData = NativeBuffer.ToBytes(users);

            using (NativeBuffer buffer = new NativeBuffer(rawData))
            {
                // Copies the list of user ID's to unmanaged memory
                buffer.WriteToUnmanagedMemory();

                NativeMethods.Stats_DownloadLeaderboardEntriesForUsers(handle.AsUInt64,
                    buffer.UnmanagedMemory, users.Length);
            }
        }

        public bool GetDownloadedLeaderboardEntry(LeaderboardEntriesHandle entries, int index,
            out LeaderboardEntry entry, int[] details)
        {
            CheckIfUsable();
            int numberOfDetails = details == null ? 0 : details.Length;
            using (NativeBuffer entryBuffer = new NativeBuffer(Marshal.SizeOf(typeof(LeaderboardEntry))))
            {
                using (NativeBuffer detailsBuffer = new NativeBuffer(numberOfDetails * sizeof(int)))
                {
                    bool result = NativeMethods.Stats_GetDownloadedLeaderboardEntry(entries.AsUInt64, index,
                        entryBuffer.UnmanagedMemory, detailsBuffer.UnmanagedMemory, numberOfDetails);

                    // Read the entry directly from the unmanaged buffer
                    entry = LeaderboardEntry.Create(entryBuffer.UnmanagedMemory, entryBuffer.UnmanagedSize);

                    for (int i = 0; i < numberOfDetails; i++)
                    {
                        // Read all the detail values from the unmanaged buffer
                        details[i] = Marshal.ReadInt32(detailsBuffer.UnmanagedMemory, sizeof(int) * i);
                    }

                    return result;
                }
            }
        }

        /// <summary>
        /// Invokes LeaderboardScoreUploaded
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="scoreMethod"></param>
        /// <param name="score"></param>
        /// <param name="details"></param>
        public void UploadLeaderboardScore(LeaderboardHandle handle, LeaderboardUploadScoreMethod scoreMethod,
            int score, int[] details)
        {
            CheckIfUsable();
            using (NativeBuffer buffer = new NativeBuffer(NativeBuffer.ToBytes(details)))
            {
                buffer.WriteToUnmanagedMemory();

                NativeMethods.Stats_UploadLeaderboardScore(handle.AsUInt64, (int)scoreMethod, score,
                    buffer.UnmanagedMemory, details.Length);
            }
        }

        /// <summary>
        /// Invokes LeaderboardUGCSet
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="ugcHandle"></param>
        public void AttachLeaderboardUGC(LeaderboardHandle handle, UGCHandle ugcHandle)
        {
            CheckIfUsable();
            NativeMethods.Stats_AttachLeaderboardUGC(handle.AsUInt64, ugcHandle.AsUInt64);
        }

        /// <summary>
        /// Invokes NumberOfCurrentPlayers
        /// </summary>
        public void GetNumberOfCurrentPlayers()
        {
            CheckIfUsable();
            NativeMethods.Stats_GetNumberOfCurrentPlayers();
        }

        /// <summary>
        /// Invokes GlobalAchievementPercentagesReady
        /// </summary>
        public void RequestGlobalAchievementPercentages()
        {
            CheckIfUsable();
            NativeMethods.Stats_RequestGlobalAchievementPercentages();
        }

        public int GetMostAchievedAchievementInfo(out string name, out float percent, out bool achieved)
        {
            CheckIfUsable();
            using (NativeBuffer buffer = new NativeBuffer(Constants.Stats.StatNameMax))
            {
                percent = 0.0f;
                achieved = false;
                int iterator = NativeMethods.Stats_GetMostAchievedAchievementInfo(buffer.UnmanagedMemory,
                    (uint)buffer.UnmanagedSize, ref percent, ref achieved);

                name = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);
                return iterator;
            }
        }

        public StatsGetMostAchievedAchievementInfo GetMostAchievedAchievementInfo()
        {
            StatsGetMostAchievedAchievementInfo result = new StatsGetMostAchievedAchievementInfo();
            result.result = GetMostAchievedAchievementInfo(out result.nameSender, out result.percentSender, out result.achievedSender);
            return result;

        }

        public int GetNextMostAchievedAchievementInfo(int iterator, out string name, out float percent, out bool achieved)
        {
            CheckIfUsable();
            using (NativeBuffer buffer = new NativeBuffer(Constants.Stats.StatNameMax))
            {
                percent = 0.0f;
                achieved = false;
                iterator = NativeMethods.Stats_GetNextMostAchievedAchievementInfo(iterator,
                    buffer.UnmanagedMemory, (uint)buffer.UnmanagedSize, ref percent, ref achieved);

                name = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);
                return iterator;
            }
        }

        public StatsGetNextMostAchievedAchievementInfo GetNextMostAchievedAchievementInfo(int iterator)
        {
            StatsGetNextMostAchievedAchievementInfo result = new StatsGetNextMostAchievedAchievementInfo();
            result.result = GetNextMostAchievedAchievementInfo(iterator, out result.nameSender, out result.percentSender, out result.achievedSender);
            return result;
        }

        public bool GetAchievementAchievedPercent(string name, out float percent)
        {
            CheckIfUsable();
            percent = 0.0f;
            return NativeMethods.Stats_GetAchievementAchievedPercent(name, ref percent);
        }

        public StatsGetAchievmentAchievedPercent GetAchievementAchievedPercent(string name)
        {
            StatsGetAchievmentAchievedPercent result = new StatsGetAchievmentAchievedPercent();
            result.result = GetAchievementAchievedPercent(name, out result.sender);
            return result;

        }

        /// <summary>
        /// Invokes GlobalStatsReceived
        /// </summary>
        /// <param name="historyDays"></param>
        public void RequestGlobalStats(int historyDays)
        {
            CheckIfUsable();
            NativeMethods.Stats_RequestGlobalStats(historyDays);
        }

        public bool GetGlobalStat(string name, out long data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.Stats_GetGlobalStatInt(name, ref data);
        }

        public StatsGetGlobalStat GetGlobalStatLong(string name)
        {
            StatsGetGlobalStat result = new StatsGetGlobalStat();
            result.result = GetGlobalStat(name, out result.longSender);
            return result;
        }

        public bool GetGlobalStat(string name, out double data)
        {
            CheckIfUsable();
            data = 0.0;
            return NativeMethods.Stats_GetGlobalStatDouble(name, ref data);
        }

        public StatsGetGlobalStat GetGlobalStatDouble(string name)
        {
            StatsGetGlobalStat result = new StatsGetGlobalStat();
            result.result = GetGlobalStat(name, out result.doubleSender);
            return result;
        }
        public int GetGlobalStatHistory(string name, out long[] data, int historyDays)
        {
            CheckIfUsable();
            byte[] byteData = new byte[historyDays * sizeof(long)];
            using (NativeBuffer buffer = new NativeBuffer(byteData))
            {
                int result = NativeMethods.Stats_GetGlobalStatHistoryInt(name, buffer.UnmanagedMemory,
                    (uint)historyDays);
                buffer.ReadFromUnmanagedMemory(result);
                data = NativeBuffer.ToLong(byteData);
                return result;
            }
        }

        public StatsGetGlobalStatHistory GetGlobalStatHistoryLong(string name, int historyDays)
        {
            StatsGetGlobalStatHistory result = new StatsGetGlobalStatHistory();
            result.result = GetGlobalStatHistory(name, out result.longSender, historyDays);
            return result;
        }

        public int GetGlobalStatHistory(string name, out double[] data, int historyDays)
        {
            CheckIfUsable();
            byte[] byteData = new byte[historyDays * sizeof(double)];
            using (NativeBuffer buffer = new NativeBuffer(byteData))
            {
                int result = NativeMethods.Stats_GetGlobalStatHistoryDouble(name, buffer.UnmanagedMemory,
                    (uint)historyDays);
                buffer.ReadFromUnmanagedMemory(result);
                data = NativeBuffer.ToDouble(byteData);
                return result;
            }
        }

        public StatsGetGlobalStatHistory GetGlobalStatHistoryDouble(string name, int historyDays)
        {
            StatsGetGlobalStatHistory result = new StatsGetGlobalStatHistory();
            result.result = GetGlobalStatHistory(name, out result.doubleSender, historyDays);
            return result;
        }



    }
}
