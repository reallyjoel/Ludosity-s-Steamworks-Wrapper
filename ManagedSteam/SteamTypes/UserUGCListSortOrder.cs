using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref UserUGCList enum
    /// 
    /// Sort order for user published UGC lists (defaults to creation order descending)
    /// </summary>
    public enum EUserUGCListSortOrder
    {
        CreationOrderDesc = 0,
        CreationOrderAsc = 1,
        TitleAsc = 2,
        LastUpdatedDesc = 3,
        SubscriptionDateDesc = 4,
        VoteScoreDesc = 5,
        ForModeration = 6,
    }
}