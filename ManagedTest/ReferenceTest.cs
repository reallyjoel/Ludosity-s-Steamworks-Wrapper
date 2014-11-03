using System;
using System.Collections.Generic;
using System.Text;
using ManagedSteam;
using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedTest
{
    /// <summary>
    /// This class references all the public things in the library.
    /// This will catch any breaking changes to the public interface.
    /// </summary>
    class ReferenceTest
    {
        Steam steam = null;

        bool b = false;
        int i = 0;
        uint ui = 0;
        long l = 0;
        float f = 0;
        double d = 0;
        string s = string.Empty;
        UGCHandle ugcHandle = default(UGCHandle);
        AppID appID = default(AppID);
        SteamID steamID = default(SteamID);
        byte[] ba = new byte[0];
        int[] ia = new int[0];
        long[] la = new long[0];
        float[] fa = new float[0];
        double[] da = new double[0];
        SteamID[] sia = new SteamID[0];

        void SteamTest()
        {
            steam = Steam.Initialize();
            steam = Steam.Instance;

            b = steam.IsAvailable;
            appID = steam.AppID;
            Settings setting = steam.Settings;
            ICloud cloud = steam.Cloud;
            IStats stats = steam.Stats;
            IUser user = steam.User;

            steam.Shutdown();
            steam.Update();
            steam.ReleaseManagedResources();
        }


        void TestCloud()
        {
            ICloud cloud = null;
            RemoteStoragePlatform remoteStorrage = RemoteStoragePlatform.All;

            cloud.CloudFileShareResult += (CloudFileShareResult x, bool y) => { };
            cloud.CloudDownloadUGCResult += (CloudDownloadUGCResult x, bool y) => { };
            b = cloud.Write(s, ba);
            i = cloud.Read(s, ba);
            b = cloud.Forget(s);
            b = cloud.Delete(s);
            cloud.Share(s);
            b = cloud.SetSyncPlatforms(s, remoteStorrage);
            b = cloud.Exists(s);
            b = cloud.Persisted(s);
            i = cloud.GetSize(s);
            l = cloud.Timestamp(s);
            remoteStorrage = cloud.GetSyncPlatforms(s);
            i = cloud.GetFileCount();
            s = cloud.GetFileNameAndSize(i, out i);
            b = cloud.GetQuota(out i, out i);
            b = cloud.IsEnabledForAccount();
            b = cloud.IsEnabledForApplication();
            cloud.SetEnabledForApplication(b);
            cloud.UGCDownload(ugcHandle);
            b = cloud.GetUGCDetails(ugcHandle, out appID, out s, out i, out steamID);
            i = cloud.UGCRead(ugcHandle, ba);
            i = cloud.GetCachedUGCCount();
            ugcHandle = cloud.GetUGCHandle(i);
        }

        void TestStats()
        {
            IStats stats = null;

            LeaderboardHandle lHandle = default(LeaderboardHandle);
            LeaderboardEntriesHandle leHandle = default(LeaderboardEntriesHandle);
            LeaderboardEntry entry = default(LeaderboardEntry);

            LeaderboardSortMethod sort = LeaderboardSortMethod.None;
            LeaderboardDisplayType display = LeaderboardDisplayType.None;
            LeaderboardDataRequest request = LeaderboardDataRequest.Friends;
            LeaderboardUploadScoreMethod score = LeaderboardUploadScoreMethod.None;

            switch (sort)
            {
                case LeaderboardSortMethod.None:
                    break;
                case LeaderboardSortMethod.Ascending:
                    break;
                case LeaderboardSortMethod.Descending:
                    break;
                default:
                    break;
            }
            switch (display)
            {
                case LeaderboardDisplayType.None:
                    break;
                case LeaderboardDisplayType.Numeric:
                    break;
                case LeaderboardDisplayType.TimeSeconds:
                    break;
                case LeaderboardDisplayType.TimeMilliSeconds:
                    break;
                default:
                    break;
            }
            switch (request)
            {
                case LeaderboardDataRequest.Global:
                    break;
                case LeaderboardDataRequest.GlobalAroundUser:
                    break;
                case LeaderboardDataRequest.Friends:
                    break;
                case LeaderboardDataRequest.Users:
                    break;
                default:
                    break;
            }
            switch (score)
            {
                case LeaderboardUploadScoreMethod.None:
                    break;
                case LeaderboardUploadScoreMethod.KeepBest:
                    break;
                case LeaderboardUploadScoreMethod.ForceUpdate:
                    break;
                default:
                    break;
            }

            stats.UserStatsReceived += (UserStatsReceived x) => { };
            stats.UserStatsStored += (UserStatsStored x) => { };
            stats.UserAchievementStored += (UserAchievementStored x) => { };
            stats.LeaderboardFindResult += (LeaderboardFindResult x, bool y) => { };
            stats.LeaderboardScoresDownloaded += (LeaderboardScoresDownloaded x, bool y) => { };
            stats.LeaderboardScoreUploaded += (LeaderboardScoreUploaded x, bool y) => { };
            stats.LeaderboardUGCSet += (LeaderboardUGCSet x, bool y) => { };
            stats.NumberOfCurrentPlayers += (NumberOfCurrentPlayers x, bool y) => { };
            stats.UserStatsUnloaded += (UserStatsUnloaded x) => { };
            stats.UserAchievementIconFetched += (UserAchievementIconFetched x) => { };
            stats.GlobalAchievementPercentagesReady += (GlobalAchievementPercentagesReady x, bool y) => { };
            stats.GlobalStatsReceived += (GlobalStatsReceived x, bool y) => { };

            b = stats.RequestCurrentStats();
            b = stats.GetStat(s, out i);
            b = stats.GetStat(s, out f);
            b = stats.SetStat(s, i);
            b = stats.SetStat(s, f);
            b = stats.UpdateAverageRateStat(s, f, d);
            b = stats.GetAchievement(s, out b);
            b = stats.SetAchievement(s);
            b = stats.ClearAchievement(s);
            b = stats.GetAchievementAndUnlockTime(s, out b, out ui);
            b = stats.StoreStats();
            s = stats.GetAchievementDisplayAttribute(s, s);
            b = stats.IndicateAchievementProgress(s, ui, ui);
            stats.RequestUserStats(steamID);
            b = stats.GetUserStat(steamID, s, out i);
            b = stats.GetUserStat(steamID, s, out f);
            b = stats.GetUserAchievement(steamID, s, out b);
            b = stats.GetUserAchievementAndUnlockTime(steamID, s, out b, out ui);
            b = stats.ResetAllStats(b);
            stats.FindOrCreateLeaderboard(s, sort, display);
            stats.FindLeaderboard(s);
            s = stats.GetLeaderboardName(lHandle);
            i = stats.GetLeaderboardEntryCount(lHandle);
            sort = stats.GetLeaderboardSortMethod(lHandle);
            display = stats.GetLeaderboardDisplayType(lHandle);
            stats.DownloadLeaderboardEntries(lHandle, request, i, i);
            stats.DownloadLeaderboardEntriesForUsers(lHandle, sia);
            b = stats.GetDownloadedLeaderboardEntry(leHandle, i, out entry, ia);
            stats.UploadLeaderboardScore(lHandle, score, i, ia);
            stats.AttachLeaderboardUGC(lHandle, ugcHandle);
            stats.GetNumberOfCurrentPlayers();
            stats.RequestGlobalAchievementPercentages();
            i = stats.GetMostAchievedAchievementInfo(out s, out f, out b);
            i = stats.GetNextMostAchievedAchievementInfo(i, out s, out f, out b);
            b = stats.GetAchievementAchievedPercent(s, out f);
            stats.RequestGlobalStats(i);
            b = stats.GetGlobalStat(s, out l);
            b = stats.GetGlobalStat(s, out d);
            i = stats.GetGlobalStatHistory(s, out la, i);
            i = stats.GetGlobalStatHistory(s, out da, i);
        }

        void TestUser()
        {
            IUser user = null;

            b = user.IsLoggedOn();
            steamID = user.GetSteamID();

        }
    }
}
