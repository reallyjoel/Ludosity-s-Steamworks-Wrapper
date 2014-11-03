using System;
using System.Collections.Generic;
using System.Text;
using ManagedSteam;
using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using System.Diagnostics;

namespace ManagedTest
{
    class StatsTest
    {
        private static readonly SteamID[] friends = new SteamID[1] 
            { 
                new SteamID(76561197964127945) // reallyjoel
            };
        private const string StatIntName = "TestStatInt";
        private const string StatFloatName = "TestStatFloat";
        private const string StatFloatAverageName = "TestStatFloatAverage";

        private Test owner;

        private bool leaderboardsDone;
        private bool achievementsDone;
        private bool statsDone;

        public StatsTest(Test owner)
        {
            this.owner = owner;

            leaderboardsDone = true;
            achievementsDone = true;
            statsDone = true;
        }

        public Action<string> Print { get { return owner.Print; } }
        public Steam Steam { get { return owner.Steam; } }
        public IStats Stats { get { return Steam.Stats; } }

        public bool TestsDone
        {
            get
            {
                return leaderboardsDone && achievementsDone && statsDone;
            }
        }

        public void Run()
        {

            TestLeaderboards();
            TestAchievements();
            TestStats();
        }

        [Conditional("STEAMAPIWRAP_FULL")]
        private void TestLeaderboards()
        {
            leaderboardsDone = false;

            Stats.UserStatsReceived += Leaderboards_UserStatsReceived;
            Stats.LeaderboardScoresDownloaded += LeaderboardScoresDownloaded;
            Stats.LeaderboardFindResult += LeaderboardFindResult;

            Stats.FindLeaderboard(Leaderboards.LeaderboardNames[0]);
        }

        [Conditional("STEAMAPIWRAP_FULL")]
        private void TestAchievements()
        {
            achievementsDone = false;

            Stats.UserStatsReceived += Achievements_UserStatsReceived;
            Stats.UserAchievementStored += Achievements_UserAchievementStored;

            Stats.RequestCurrentStats();
        }

        private void TestStats()
        {
            statsDone = false;
            Stats.UserStatsReceived += Stats_UserStatsReceived;
            Stats.UserStatsStored += Stats_UserStatsStored;
            Stats.GlobalStatsReceived += Stats_GlobalStatsReceived;

            Stats.RequestCurrentStats();
        }

        private void Stats_UserStatsReceived(UserStatsReceived value)
        {
            int dataInt;
            float dataFloat;
            bool lastResult;

            if (value.UserID == Steam.User.GetSteamID())
            {


                lastResult = Stats.GetStat(StatIntName, out dataInt);
                lastResult = Stats.GetStat(StatFloatName, out dataFloat);

                lastResult = Stats.SetStat(StatIntName, dataInt + 1);
                lastResult = Stats.SetStat(StatFloatName, dataFloat + 1);


                lastResult = Stats.UpdateAverageRateStat(StatFloatAverageName, dataFloat, 1.0);

                lastResult = Stats.StoreStats();
            }
            else
            {
                lastResult = Stats.GetUserStat(friends[0], StatIntName, out dataInt);
                lastResult = Stats.GetUserStat(friends[0], StatFloatName, out dataFloat);



                Stats.RequestGlobalStats(10);

                // This is the second time this callback is used, disable it.
                Stats.UserStatsReceived -= Stats_UserStatsReceived;
            }

            if (lastResult)
            {
                Console.WriteLine("Test");
            }
        }

        private void Stats_UserStatsStored(UserStatsStored value)
        {
            Stats.RequestUserStats(friends[0]);

            Stats.UserStatsStored -= Stats_UserStatsStored;
        }

        private void Stats_GlobalStatsReceived(GlobalStatsReceived value, bool flag)
        {
            long dataLong;
            double dataDouble;
            const int historyDays = 5;
            long[] longHistory;
            double[] doubleHistory;
            bool lastResult;

            lastResult = Stats.GetGlobalStat(StatIntName, out dataLong);
            lastResult = Stats.GetGlobalStat(StatFloatName, out dataDouble);

            dataLong = Stats.GetGlobalStatHistory(StatIntName, out longHistory, historyDays);
            dataLong = Stats.GetGlobalStatHistory(StatFloatName, out doubleHistory, historyDays);


            Stats.GlobalStatsReceived -= Stats_GlobalStatsReceived;
            statsDone = true;
        }

        private void Leaderboards_UserStatsReceived(UserStatsReceived value)
        {

        }

        void LeaderboardFindResult(LeaderboardFindResult value, bool flag)
        {
            Print("LeaderboardFindResult");
            Stats.DownloadLeaderboardEntries(value.Leaderboard, LeaderboardDataRequest.Friends, -2, 2);

            //SteamID[] users = new SteamID[2];
            //users[0] = new SteamID(76561197992373255);
            //users[1] = new SteamID(76561197964127945);

            //Stats.DownloadLeaderboardEntriesForUsers(value.Leaderboard, users);
        }

        void LeaderboardScoresDownloaded(LeaderboardScoresDownloaded value, bool flag)
        {
            Print(value.EntryCount.ToString() + " leaderboards downloaded.");
            for (int i = 0; i < value.EntryCount; i++)
            {
                LeaderboardEntry entry;
                int[] details = new int[1];
                if (!Stats.GetDownloadedLeaderboardEntry(value.Entries, i, out entry, null))
                {
                    Failed();
                }

            }

            leaderboardsDone = true;
        }

        void Achievements_UserStatsReceived(UserStatsReceived value)
        {
            bool achieved;
            uint unlockTime;
            if (!Stats.GetAchievementAndUnlockTime(Achievements.LevelNames[0], out achieved, out unlockTime))
            {
                Failed();
            }
            Print(String.Format("Achievement {0}, achieved {1}, unlockTime {2}", Achievements.LevelNames[0],
                achieved, unlockTime));


            bool unlocked;
            if (Stats.GetAchievement("COMPLETED_LEVEL_00", out unlocked))
            {
                if (!unlocked)
                {
                    if (Stats.SetAchievement("COMPLETED_LEVEL_00"))
                    {
                        Print("Achievement unlocked");
                    }
                }
                else
                {
                    achievementsDone = true;
                }
            }

            // Tell the steam client that we want to upload the new stat values.
            // This will cause the UserStatsStored method to be called once the upload is complete.
            Stats.StoreStats();

        }


        private void Achievements_UserAchievementStored(UserAchievementStored value)
        {
            achievementsDone = true;
        }

        private void Failed()
        {
            Test.TestFailed();
        }

        private static class Achievements
        {
            public static readonly string[] LevelNames = 
            { 
                "COMPLETED_LEVEL_00", "COMPLETED_LEVEL_01", "COMPLETED_LEVEL_02", "COMPLETED_LEVEL_03", 
                "COMPLETED_LEVEL_04", "COMPLETED_LEVEL_05", "COMPLETED_LEVEL_06", "COMPLETED_LEVEL_07", 
                "COMPLETED_LEVEL_08"
            };
        }

        private static class Leaderboards
        {
            public static readonly string[] LeaderboardNames =
            {
                "TIME_LEVEL_00", "TIME_LEVEL_01", "TIME_LEVEL_02","TIME_LEVEL_03","TIME_LEVEL_04",
            };
        }
    }
}
