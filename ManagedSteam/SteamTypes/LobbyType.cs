using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELobbyType enum
    /// </summary>
    public enum LobbyType
    {
        /// <summary>
        /// only way to join the lobby is to invite to someone else
        /// </summary>
        Private = 0,
        /// <summary>
        /// shows for friends or invitees, but not in lobby list
        /// </summary>
        FriendsOnly = 1,
        /// <summary>
        /// visible for friends and in lobby list
        /// </summary>
        Public = 2,
        /// <summary>
        /// returned by search, but not visible to other friends 
        /// useful if you want a user in two lobbies, for example matching groups together
        /// a user can be in only one regular lobby, and up to two invisible lobbies
        /// </summary>
        Invisible = 3,
    }

}
