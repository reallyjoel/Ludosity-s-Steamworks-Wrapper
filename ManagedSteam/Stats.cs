using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam
{
    /// <summary>
    /// Handles stats, leaderboards and achievements.
    /// Wraps ISteamUserStats.
    /// 
    /// \note
    /// GetAchievementIcon is not implemented in this release
    /// </summary>
    public interface IStats
    {
        /// <summary>
        /// Invoked by RequestUserStats() and RequestCurrentStats()
        /// </summary>
        event CallbackEvent<UserStatsReceived> UserStatsReceived;
        /// <summary>
        /// Invoked by StoreStats()
        /// </summary>
        event CallbackEvent<UserStatsStored> UserStatsStored;
        /// <summary>
        /// Invoked by StoreStats()
        /// </summary>
        event CallbackEvent<UserAchievementStored> UserAchievementStored;
        /// <summary>
        /// Invoked by FindOrCreateLeaderboard() and FindLeaderboard()
        /// </summary>
        event ResultEvent<LeaderboardFindResult> LeaderboardFindResult;
        /// <summary>
        /// Invoked by DownloadLeaderboardEntries() and DownloadLeaderboardEntriesForUsers()
        /// </summary>
        event ResultEvent<LeaderboardScoresDownloaded> LeaderboardScoresDownloaded;
        /// <summary>
        /// Invoked by UploadLeaderboardScore()
        /// </summary>
        event ResultEvent<LeaderboardScoreUploaded> LeaderboardScoreUploaded;
        /// <summary>
        /// Invoked by AttachLeaderboardUGC()
        /// </summary>
        event ResultEvent<LeaderboardUGCSet> LeaderboardUGCSet;
        /// <summary>
        /// Invoked by GetNumberOfCurrentPlayers()
        /// </summary>
        event ResultEvent<NumberOfCurrentPlayers> NumberOfCurrentPlayers;
        event CallbackEvent<UserStatsUnloaded> UserStatsUnloaded;
        event CallbackEvent<UserAchievementIconFetched> UserAchievementIconFetched;
        /// <summary>
        /// Invoked by RequestGlobalAchievementPercentages()
        /// </summary>
        event ResultEvent<GlobalAchievementPercentagesReady> GlobalAchievementPercentagesReady;
        /// <summary>
        /// Invoked by RequestGlobalStats()
        /// </summary>
        event ResultEvent<GlobalStatsReceived> GlobalStatsReceived;

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// 
        /// 
        /// Ask the server to send down this user's data and achievements for this game
        /// </summary>
        bool RequestCurrentStats();

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool GetStat(string name, out int data);

        StatsGetStatIntResult GetStatInt(string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool GetStat(string name, out float data);

        StatsGetStatFloatResult GetStatFloat(string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool SetStat(string name, int data);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool SetStat(string name, float data);


        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool UpdateAverageRateStat(string name, float countThisSession, double sessionLength);

        bool GetAchievement(string name, out bool achieved);

        StatsGetAchievementResult GetAchievement(string name);

        bool SetAchievement(string name);

        bool ClearAchievement(string name);

        /// <summary>
        /// Get the achievement status, and the time it was unlocked if unlocked.
        /// If the return value is true, but the unlock time is zero, that means it was unlocked before Steam 
        /// began tracking achievement unlock times (December 2009). Time is seconds since January 1, 1970. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="achieved"></param>
        /// <param name="unlockTime"></param>
        /// <returns></returns>
        bool GetAchievementAndUnlockTime(string name, out bool achieved, out uint unlockTime);

        StatsGetAchievementAndUnlockTimeResult GetAchievementAndUnlockTime(SteamID steamID, string name);

        /// <summary>
        /// \lite 
        /// Available in Lite
        /// \endlite
        /// Store the current data on the server, will get a callback when set
        /// And one callback for every new achievement
        ///
        /// If the callback has a result of k_EResultInvalidParam, one or more stats 
        /// uploaded has been rejected, either because they broke constraints
        /// or were out of date. In this case the server sends back updated values.
        /// The stats should be re-iterated to keep in sync.
        /// </summary>
        bool StoreStats();

        /*
        SteamTypes.AchievementIcon GetAchievementIcon(string name)
        {
            CheckIfUsable();
            int value = NativeMethods.Stats_GetAchievementIcon(name);
            return new SteamTypes.AchievementIcon(value);
        }
        */

        /// <summary>
        /// Get general attributes for an achievement. Accepts the following keys:
        /// - "name" and "desc" for retrieving the localized achievement name and description (returned in UTF8)
        /// - "hidden" for retrieving if an achievement is hidden (returns "0" when not hidden, "1" when hidden) 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetAchievementDisplayAttribute(string name, string key);

        /// <summary>
        /// Achievement progress - triggers an AchievementProgress callback, that is all.
        /// Calling this w/ N out of N progress will NOT set the achievement, the game must still do that. 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="currentProgress"></param>
        /// <param name="maxProgress"></param>
        /// <returns></returns>
        bool IndicateAchievementProgress(string name, uint currentProgress, uint maxProgress);

        /// <summary>
        /// \lite 
        /// Available in Lite
        /// \endlite
        /// downloads stats for the user
        /// returns a UserStatsReceived_t received when completed
        /// if the other user has no stats, UserStatsReceived_t.m_eResult will be set to k_EResultFail
        /// these stats won't be auto-updated; you'll need to call RequestUserStats() again to refresh any data
        /// </summary>
        /// <param name="steamID"></param>
        void RequestUserStats(SteamID steamID);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        bool GetUserStat(SteamID steamID, string name, out int data);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        StatsGetUserStatResult GetUserStatInt(SteamID steamID, string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        bool GetUserStat(SteamID steamID, string name, out float data);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        StatsGetUserStatResult GetUserStatFloat(SteamID steamID, string name);


        bool GetUserAchievement(SteamID steamID, string name, out bool achieved);

        StatsGetUserAchievementResult GetUserAchievement(SteamID steamID, string name);

        bool GetUserAchievementAndUnlockTime(SteamID steamID, string name, out bool achieved,
            out uint unlockTime);

        StatsGetUserAchievementAndUnlockTimeResult GetUserAchievementAndUnlockTime(SteamID steamID, string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// </summary>
        bool ResetAllStats(bool achievementsToo);

        /// <summary>
        /// Invokes LeaderboardFindResult.
        /// asks the Steam back-end for a leaderboard by name, and will create it if it's not yet
        /// This call is asynchronous, with the result returned in LeaderboardFindResult_t
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sortMethod"></param>
        /// <param name="displayType"></param>
        void FindOrCreateLeaderboard(string name, LeaderboardSortMethod sortMethod, LeaderboardDisplayType displayType);

        /// <summary>
        /// Invokes LeaderboardFindResult.
        /// as above, but won't create the leaderboard if it's not found
        /// This call is asynchronous, with the result returned in LeaderboardFindResult_t
        /// <param name="name"></param>
        void FindLeaderboard(string name);

        /// <summary>
        /// returns the name of a leaderboard
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        string GetLeaderboardName(LeaderboardHandle handle);

        /// <summary>
        /// returns the total number of entries in a leaderboard, as of the last request
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        int GetLeaderboardEntryCount(LeaderboardHandle handle);

        /// <summary>
        /// returns the sort method of the leaderboard
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        LeaderboardSortMethod GetLeaderboardSortMethod(LeaderboardHandle handle);

        /// <summary>
        /// returns the display type of the leaderboard 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        LeaderboardDisplayType GetLeaderboardDisplayType(LeaderboardHandle handle);

        /// <summary>
        /// Invokes LeaderboardScoresDownloaded
        /// Asks the Steam back-end for a set of rows in the leaderboard.
        /// This call is asynchronous, with the result returned in LeaderboardScoresDownloaded_t
        /// LeaderboardScoresDownloaded_t will contain a handle to pull the results from GetDownloadedLeaderboardEntries() (below)
        /// You can ask for more entries than exist, and it will return as many as do exist.
        /// k_ELeaderboardDataRequestGlobal requests rows in the leaderboard from the full table, with nRangeStart & nRangeEnd in the range [1, TotalEntries]
        /// k_ELeaderboardDataRequestGlobalAroundUser requests rows around the current user, nRangeStart being negate
        ///   e.g. DownloadLeaderboardEntries( hLeaderboard, k_ELeaderboardDataRequestGlobalAroundUser, -3, 3 ) will return 7 rows, 3 before the user, 3 after
        /// k_ELeaderboardDataRequestFriends requests all the rows for friends of the current user 
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="dataRequest"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        void DownloadLeaderboardEntries(LeaderboardHandle handle, LeaderboardDataRequest dataRequest,
            int rangeStart, int rangeEnd);

        /// <summary>
        /// as above, but downloads leaderboard entries for an arbitrary set of users - ELeaderboardDataRequest is k_ELeaderboardDataRequestUsers
        /// if a user doesn't have a leaderboard entry, they won't be included in the result
        /// a max of 100 users can be downloaded at a time, with only one outstanding call at a time
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="users"></param>
        void DownloadLeaderboardEntriesForUsers(LeaderboardHandle handle, SteamID[] users);

        /// <summary>
        /// Returns data about a single leaderboard entry
        /// use a for loop from 0 to LeaderboardScoresDownloaded.entryCount to get all the downloaded entries
        /// e.g.
        ///     <example>
        ///		void OnLeaderboardScoresDownloaded( LeaderboardScoresDownloaded value)
        ///		{
        ///			for ( int index = 0; index < value.entryCount; index++ )
        ///			{
        ///				LeaderboardEntry_t leaderboardEntry;
        ///				int32 details[3];		// we know this is how many we've stored previously
        ///				GetDownloadedLeaderboardEntry( pLeaderboardScoresDownloaded->m_hSteamLeaderboardEntries, index, &leaderboardEntry, details, 3 );
        ///				assert( leaderboardEntry.m_cDetails == 3 );
        ///				...
        ///			}
        ///	    </example>
        /// once you've accessed all the entries, the data will be free'd, and the SteamLeaderboardEntries_t handle will become invalid
        /// </summary>
        /// <param name="entries"></param>
        /// <param name="index"></param>
        /// <param name="entry"></param>
        /// <param name="details"></param>
        /// <returns></returns>
        bool GetDownloadedLeaderboardEntry(LeaderboardEntriesHandle entries, int index, out LeaderboardEntry entry, int[] details);

        /// <summary>
        /// Invokes LeaderboardScoreUploaded
        /// Uploads a user score to the Steam back-end.
        /// This call is asynchronous, with the result returned in LeaderboardScoreUploaded_t
        /// Details are extra game-defined information regarding how the user got that score
        /// pScoreDetails points to an array of int32's, cScoreDetailsCount is the number of int32's in the list
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="scoreMethod"></param>
        /// <param name="score"></param>
        /// <param name="details"></param>
        void UploadLeaderboardScore(LeaderboardHandle handle, LeaderboardUploadScoreMethod scoreMethod,
            int score, int[] details);

        /// <summary>
        /// Invokes LeaderboardUGCSet
        /// attaches a piece of user generated content the user's entry on a leaderboard.
        /// hContent is a handle to a piece of user generated content that was shared using ISteamUserRemoteStorage::FileShare().
        /// This call is asynchronous, with the result returned in LeaderboardUGCSet_t.
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="ugcHandle"></param>
        void AttachLeaderboardUGC(LeaderboardHandle handle, UGCHandle ugcHandle);

        /// <summary>
        /// Invokes NumberOfCurrentPlayers
        /// Retrieves the number of players currently playing your game (online + offline)
        /// This call is asynchronous, with the result returned in NumberOfCurrentPlayers_t
        /// </summary>
        void GetNumberOfCurrentPlayers();

        /// <summary>
        /// Invokes GlobalAchievementPercentagesReady
        /// Requests that Steam fetch data on the percentage of players who have received each achievement
        /// for the game globally.
        /// This call is asynchronous, with the result returned in GlobalAchievementPercentagesReady_t.
        /// </summary>
        void RequestGlobalAchievementPercentages();

        /// <summary>
        /// Get the info on the most achieved achievement for the game, returns an iterator index you can use to fetch
        /// the next most achieved afterwards.  Will return -1 if there is no data on achievement 
        /// percentages (ie, you haven't called RequestGlobalAchievementPercentages and waited on the callback).
        /// </summary>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <param name="achieved"></param>
        /// <returns></returns>
        int GetMostAchievedAchievementInfo(out string name, out float percent, out bool achieved);

        /// <summary>
        /// Get the info on the most achieved achievement for the game, returns an iterator index you can use to fetch
        /// the next most achieved afterwards.  Will return -1 if there is no data on achievement 
        /// percentages (ie, you haven't called RequestGlobalAchievementPercentages and waited on the callback).
        /// </summary>
        /// <returns></returns>
        StatsGetMostAchievedAchievementInfo GetMostAchievedAchievementInfo();

        /// <summary>
        /// Get the info on the next most achieved achievement for the game. Call this after GetMostAchievedAchievementInfo or another
        /// GetNextMostAchievedAchievementInfo call passing the iterator from the previous call. Returns -1 after the last
        /// achievement has been iterated.
        /// </summary>
        /// <param name="iterator"></param>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <param name="achieved"></param>
        /// <returns></returns>
        int GetNextMostAchievedAchievementInfo(int iterator, out string name, out float percent, out bool achieved);

        /// <summary>
        /// Get the info on the next most achieved achievement for the game. Call this after GetMostAchievedAchievementInfo or another
        /// GetNextMostAchievedAchievementInfo call passing the iterator from the previous call. Returns -1 after the last
        /// achievement has been iterated.
        /// </summary>
        /// <param name="iterator"></param>
        /// <returns></returns>
        StatsGetNextMostAchievedAchievementInfo GetNextMostAchievedAchievementInfo(int iterator);

        /// <summary>
        /// Returns the percentage of users who have achieved the specified achievement.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        bool GetAchievementAchievedPercent(string name, out float percent);

        /// <summary>
        /// Returns the percentage of users who have achieved the specified achievement.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
        StatsGetAchievmentAchievedPercent GetAchievementAchievedPercent(string name);

        /// <summary>
        /// \lite 
        /// Available in Lite
        /// \endlite
        /// Requests global stats data, which is available for stats marked as "aggregated".
        /// This call is asynchronous, with the results returned in GlobalStatsReceived_t.
        /// nHistoryDays specifies how many days of day-by-day history to retrieve in addition
        /// to the overall totals. The limit is 60.
        /// Invokes GlobalStatsReceived.
        /// </summary>
        /// <param name="historyDays"></param>
        void RequestGlobalStats(int historyDays);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets the lifetime totals for an aggregated stat
        /// </summary>
        bool GetGlobalStat(string name, out long data);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets the lifetime totals for an aggregated stat
        /// </summary>
        StatsGetGlobalStat GetGlobalStatLong(string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets the lifetime totals for an aggregated stat
        /// </summary>
        bool GetGlobalStat(string name, out double data);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets the lifetime totals for an aggregated stat
        /// </summary>
        StatsGetGlobalStat GetGlobalStatDouble(string name);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets history for an aggregated stat. pData will be filled with daily values, starting with today.
        /// So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago, 
        /// etc. cubData is the size in bytes of the pubData buffer. Returns the number of 
        /// elements actually set.
        /// </summary>
        int GetGlobalStatHistory(string name, out long[] data, int historyDays);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets history for an aggregated stat. pData will be filled with daily values, starting with today.
        /// So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago, 
        /// etc. cubData is the size in bytes of the pubData buffer. Returns the number of 
        /// elements actually set.
        /// </summary>
        StatsGetGlobalStatHistory GetGlobalStatHistoryLong(string name, int historyDays);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets history for an aggregated stat. pData will be filled with daily values, starting with today.
        /// So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago, 
        /// etc. cubData is the size in bytes of the pubData buffer. Returns the number of 
        /// elements actually set.
        /// </summary>
        int GetGlobalStatHistory(string name, out double[] data, int historyDays);

        /// <summary>
        /// \lite
        /// Available in Lite
        /// \endlite
        /// Gets history for an aggregated stat. pData will be filled with daily values, starting with today.
        /// So when called, pData[0] will be today, pData[1] will be yesterday, and pData[2] will be two days ago, 
        /// etc. cubData is the size in bytes of the pubData buffer. Returns the number of 
        /// elements actually set.
        /// </summary>
        StatsGetGlobalStatHistory GetGlobalStatHistoryDouble(string name, int historyDays);
    }


    public struct StatsGetStatIntResult
    {
        public bool Result;
        public int IntValue;
    }

    public struct StatsGetStatFloatResult
    {
        public bool Result;
        public float FloatValue;
    }



    public struct StatsGetAchievementResult
    {
        public bool result;
        public bool sender;

    }

    public struct StatsGetAchievementAndUnlockTimeResult
    {
        public bool result;
        public bool achievedSender;
        public uint unlockTimeSender;
    }



    public struct StatsGetUserStatResult
    {
        public bool result;
        public int intDataSender;
        public int floatDataSender;
    }

    public struct StatsGetUserAchievementResult
    {
        public bool result;
        public bool sender;
    }

    public struct StatsGetUserAchievementAndUnlockTimeResult
    {
        public bool result;
        public bool achievedSender;
        public uint unlockTimeSender;

    }


    public struct StatsGetMostAchievedAchievementInfo
    {
        public int result;
        public string nameSender;
        public float percentSender;
        public bool achievedSender;

    }

    public struct StatsGetNextMostAchievedAchievementInfo
    {
        public int result;
        public string nameSender;
        public float percentSender;
        public bool achievedSender;

    }


    public struct StatsGetAchievmentAchievedPercent
    {
        public bool result;
        public float sender;
    }

    public struct StatsGetGlobalStat
    {
        public bool result;
        public long longSender;
        public double doubleSender;

    }


    public struct StatsGetGlobalStatHistory
    {
        public int result;
        public long[] longSender;
        public double[] doubleSender;
    }



}