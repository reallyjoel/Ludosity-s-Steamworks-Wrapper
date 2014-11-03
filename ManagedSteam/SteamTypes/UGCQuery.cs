using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref UserUGCList enum
    /// 
    /// Combination of sorting and filtering for queries across all UGC
    /// </summary>
    public enum EUGCQuery
    {
        RankedByVote = 0,
        RankedByPublicationDate = 1,
        AcceptedForGameRankedByAcceptanceDate = 2,
        RankedByTrend = 3,
        FavoritedByFriendsRankedByPublicationDate = 4,
        CreatedByFriendsRankedByPublicationDate = 5,
        RankedByNumTimesReported = 6,
        CreatedByFollowedUsersRankedByPublicationDate = 7,
        NotYetRated = 8,
        RankedByTotalVotesAsc = 9,
        RankedByVotesUp = 10,
        RankedByTextSearch = 11,
    };
}
