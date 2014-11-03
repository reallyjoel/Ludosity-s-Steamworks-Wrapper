using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.SteamTypes;
using ManagedSteam.CallbackStructures;

namespace ManagedSteam
{
    /// <summary>
    /// Purpose: interface to steam for game servers
    /// </summary>
    public interface IGameServerStats
    {
        event ResultEvent<GSStatsReceived> GSStatsReceived;
        event ResultEvent<GSStatsStored> GSStatsStored;
        event CallbackEvent<GSStatsUnloaded> GSStatsUnloaded;

        /// <summary>
        /// downloads stats for the user
        /// returns a GSStatsReceived_t callback when completed
        /// if the user has no stats, GSStatsReceived_t.m_eResult will be set to k_EResultFail
        /// these stats will only be auto-updated for clients playing on the server. For other
        /// users you'll need to call RequestUserStats() again to refresh any data
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <returns></returns>
        void RequestUserStats(SteamID steamIDUser);

        /// <summary>
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool GetUserStat(SteamID steamIDUser, string name, out int data);

        /// <summary>
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        GameServerStatsGetUserStatIntResult GetUserStatInt(SteamID steamIDUser, string name);

        /// <summary>
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool GetUserStat(SteamID steamIDUser, string name, out float data);

        /// <summary>
        /// requests stat information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        GameServerStatsGetUserStatFloatResult GetUserStatFloat(SteamID steamIDUser, string name);


        /// <summary>
        /// requests achievement information for a user, usable after a successful call to RequestUserStats()
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="achieved"></param>
        /// <returns></returns>
        bool GetUserAchievement(SteamID steamIDUser, string name, out bool achieved);


        GameServerGetUserAchievementResult GetUserAchievement(SteamID steamIDUser, string name);

        /// <summary>
        /// Set stats
        /// Note: This update will work only on stats game servers are allowed to edit and only for 
        /// game servers that have been declared as officially controlled by the game creators. 
        /// Set the IP range of your official servers on the Steamworks page
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool SetUserStat(SteamID steamIDUser, string name, int data);

        /// <summary>
        /// Set stats 
        /// Note: This update will work only on stats game servers are allowed to edit and only for 
        /// game servers that have been declared as officially controlled by the game creators. 
        /// Set the IP range of your official servers on the Steamworks page
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        bool SetUserStat(SteamID steamIDUser, string name, float data);

        /// <summary>
        /// Update stats. 
        /// Note: This update will work only on stats game servers are allowed to edit and only for 
        /// game servers that have been declared as officially controlled by the game creators. 
        /// Set the IP range of your official servers on the Steamworks page
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <param name="countThisSession"></param>
        /// <param name="sessionLength"></param>
        /// <returns></returns>
        bool UpdateUserAvgRateStat(SteamID steamIDUser, string name, float countThisSession, double sessionLength);

        /// <summary>
        /// Set achievements. 
        /// Note: This updates will work only on achievements game servers are allowed to edit and only for 
        /// game servers that have been declared as officially controlled by the game creators. 
        /// Set the IP range of your official servers on the Steamworks page
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool SetUserAchievement(SteamID steamIDUser, string name);

        /// <summary>
        /// Clear achievements. 
        /// Note: This will work only on achievements game servers are allowed to edit and only for 
        /// game servers that have been declared as officially controlled by the game creators. 
        /// Set the IP range of your official servers on the Steamworks page
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool ClearUserAchievement(SteamID steamIDUser, string name);

        /// <summary>
        /// Store the current data on the server, will get a GSStatsStored_t callback when set.
        ///
        /// If the callback has a result of k_EResultInvalidParam, one or more stats 
        /// uploaded has been rejected, either because they broke constraints
        /// or were out of date. In this case the server sends back updated values.
        /// The stats should be re-iterated to keep in sync.
        /// </summary>
        /// <param name="steamIDUser"></param>
        /// <returns></returns>
        void StoreUserStats(SteamID steamIDUser);

    }



    public struct GameServerStatsGetUserStatIntResult
    {
        public bool Result;
        public int IntValue;
    }

    public struct GameServerStatsGetUserStatFloatResult
    {
        public bool Result;
        public float FloatValue;
    }


    public struct GameServerGetUserAchievementResult
    {
        public bool Result;
        public bool Achieved;
    }

}
