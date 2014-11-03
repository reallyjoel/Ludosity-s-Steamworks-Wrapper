using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELeaderboardSortMethod enum
    /// </summary>
    public enum LeaderboardSortMethod
    {
        None = 0,
        /// <summary>
        /// top-score is lowest number
        /// </summary>
        Ascending = 1,
        /// <summary>
        /// top-score is highest number
        /// </summary>
        Descending = 2,
    };
}
