using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELeaderboardDisplayType enum
    /// </summary>
    public enum LeaderboardDisplayType
    {
        None = 0,
        /// <summary>
        /// Simple numerical score
        /// </summary>
        Numeric = 1,
        /// <summary>
        /// the score represents a time, in seconds
        /// </summary>
        TimeSeconds = 2,
        /// <summary>
        /// the score represents a time, in milliseconds
        /// </summary>
        TimeMilliSeconds = 3,
    }
}
