using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref UserUGCList enum
    /// 
    /// Different lists of published UGC for a user.
    /// If the current logged in user is different than the specified user, then some options may not be allowed.
    /// </summary>
    public enum UserUGCList
    {
	    Published = 0,
	    VotedOn = 1,
	    VotedUp = 2,
	    VotedDown = 3,
	    WillVoteLater = 4,
	    Favorited = 5,
	    Subscribed = 6,
	    UsedOrPlayed = 7,
	    Followed = 8,
    }

}
