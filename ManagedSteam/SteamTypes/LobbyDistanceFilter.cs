using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELobbyDistanceFilter enum
    /// </summary>
    public enum LobbyDistanceFilter
    {
        /// <summary>
        /// only lobbies in the same immediate region will be returned
        /// </summary>
        Close = 0,
        /// <summary>
        /// only lobbies in the same region or near by regions
        /// </summary>
        Default,
        /// <summary>
        /// for games that don't have many latency requirements, will return lobbies about half-way around the globe
        /// </summary>
        Far,
        /// <summary>
        /// no filtering, will match lobbies as far as India to NY (not recommended, expect multiple seconds of latency between the clients)
        /// </summary>
        Worldwide,
    }

}
