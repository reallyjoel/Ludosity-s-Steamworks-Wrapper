using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EWorkshopEnumerationType enum
    /// </summary>
    public enum WorkshopEnumerationType
    {
        RankedByVote = 0,
        Recent = 1,
        Trending = 2,
        FavoritesOfFriends = 3,
        VotedByFriends = 4,
        ContentByFriends = 5,
        RecentFromFollowedUsers = 6,
    }
}
