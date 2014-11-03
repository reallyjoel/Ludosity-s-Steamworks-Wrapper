using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELeaderboardDataRequest enum
    /// </summary>
    public enum LeaderboardDataRequest
    {
        Global = 0,
        GlobalAroundUser = 1,
        Friends = 2,
        Users = 3
    }
}
