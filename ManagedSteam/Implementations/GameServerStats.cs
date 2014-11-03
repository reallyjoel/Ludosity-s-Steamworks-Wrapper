using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class GameServerStats : SteamServiceGameServer, IGameServerStats
    {

        private List<Result<GSStatsReceived>> gsStatsReceived;
        private List<Result<GSStatsStored>> gsStatsStored;
        private List<GSStatsUnloaded> gsStatsUnloaded;


        public GameServerStats()
        {
            gsStatsReceived = new List<Result<GSStatsReceived>>();
            gsStatsStored = new List<Result<GSStatsStored>>();
            gsStatsUnloaded = new List<GSStatsUnloaded>();

            Results[ResultID.GSStatsReceived] = (data, size, flag) => gsStatsReceived.Add(new Result<GSStatsReceived>(CallbackStructures.GSStatsReceived.Create(data, size), flag));
            Results[ResultID.GSStatsStored] = (data, size, flag) => gsStatsStored.Add(new Result<GSStatsStored>(CallbackStructures.GSStatsStored.Create(data, size), flag));
            Callbacks[CallbackID.GSStatsUnloaded] = (data, size) => gsStatsUnloaded.Add(CallbackStructures.GSStatsUnloaded.Create(data, size));
        }

        public event ResultEvent<GSStatsReceived> GSStatsReceived;
        public event ResultEvent<GSStatsStored> GSStatsStored;
        public event CallbackEvent<GSStatsUnloaded> GSStatsUnloaded;


        internal override void CheckIfUsableInternal()
        {

        }

        internal override void ReleaseManagedResources()
        {
            gsStatsReceived = null;
            GSStatsReceived = null;
            gsStatsStored = null;
            GSStatsStored = null;
            gsStatsUnloaded = null;
            GSStatsUnloaded = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(gsStatsReceived, GSStatsReceived);
            InvokeEvents(gsStatsStored, GSStatsStored);
            InvokeEvents(gsStatsUnloaded, GSStatsUnloaded);
        }

        public void RequestUserStats(SteamID steamIDUser)
        {
            CheckIfUsable();
            NativeMethods.GameServerStats_RequestUserStats(steamIDUser.AsUInt64);
        }

        public bool GetUserStat(SteamID steamIDUser, string name, out int data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.GameServerStats_GetUserStatInt(steamIDUser.AsUInt64, name, ref data);
        }

        public GameServerStatsGetUserStatIntResult GetUserStatInt(SteamID steamIDUser, string name)
        {
            GameServerStatsGetUserStatIntResult result = new GameServerStatsGetUserStatIntResult();

            result.Result = GetUserStat(steamIDUser, name, out result.IntValue);

            return result;
        }

        public bool GetUserStat(SteamID steamIDUser, string name, out float data)
        {
            CheckIfUsable();
            data = 0;
            return NativeMethods.GameServerStats_GetUserStatFloat(steamIDUser.AsUInt64, name, ref data);
        }

        public GameServerStatsGetUserStatFloatResult GetUserStatFloat(SteamID steamIDUser, string name)
        {
            GameServerStatsGetUserStatFloatResult result = new GameServerStatsGetUserStatFloatResult();

            result.Result = GetUserStat(steamIDUser, name, out result.FloatValue);

            return result;

        }

        public bool GetUserAchievement(SteamID steamIDUser, string name, out bool achieved)
        {
            CheckIfUsable();
            achieved = false;
            return NativeMethods.GameServerStats_GetUserAchievement(steamIDUser.AsUInt64, name, ref achieved);
        }

        public GameServerGetUserAchievementResult GetUserAchievement(SteamID steamIDUser, string name)
        {
            GameServerGetUserAchievementResult result = new GameServerGetUserAchievementResult();

            result.Result = GetUserAchievement(steamIDUser, name, out result.Achieved);
            return result;
        }

        public bool SetUserStat(SteamID steamIDUser, string name, int data)
        {
            CheckIfUsable();
            return NativeMethods.GameServerStats_SetUserStatInt(steamIDUser.AsUInt64, name, data);
        }

        public bool SetUserStat(SteamID steamIDUser, string name, float data)
        {
            CheckIfUsable();
            return NativeMethods.GameServerStats_SetUserStatFloat(steamIDUser.AsUInt64, name, data);
        }

        public bool UpdateUserAvgRateStat(SteamID steamIDUser, string name, float countThisSession, double sessionLength)
        {
            CheckIfUsable();
            return NativeMethods.GameServerStats_UpdateUserAvgRateStat(steamIDUser.AsUInt64, name, countThisSession, sessionLength);
        }

        public bool SetUserAchievement(SteamID steamIDUser, string name)
        {
            CheckIfUsable();
            return NativeMethods.GameServerStats_SetUserAchievement(steamIDUser.AsUInt64, name);
        }

        public bool ClearUserAchievement(SteamID steamIDUser, string name)
        {
            CheckIfUsable();
            return NativeMethods.GameServerStats_ClearUserAchievement(steamIDUser.AsUInt64, name);
        }

        public void StoreUserStats(SteamID steamIDUser)
        {
            CheckIfUsable();
            NativeMethods.GameServerStats_StoreUserStats(steamIDUser.AsUInt64);
        }
    }
}