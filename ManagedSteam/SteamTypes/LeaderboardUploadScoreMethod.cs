using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELeaderboardUploadScoreMethod enum
    /// </summary>
    public enum LeaderboardUploadScoreMethod
    {
        None = 0,
        KeepBest = 1,	// Leaderboard will keep user's best score
        ForceUpdate = 2,	// Leaderboard will always replace score with specified
    }
}
