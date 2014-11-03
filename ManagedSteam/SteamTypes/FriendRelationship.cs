using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EFriendRelationship enum
    /// </summary>
    public enum FriendRelationship
    {
        None = 0,
        Blocked = 1,
        RequestRecipient = 2,
        Friend = 3,
        RequestInitiator = 4,
        Ignored = 5,
        IgnoredFriend = 6,
        Suggested = 7,


        Max = 8,
    };
}
