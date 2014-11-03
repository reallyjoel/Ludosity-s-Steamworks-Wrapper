using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EMatchMakingServerResponse enum
    /// </summary>
    public enum MatchMakingServerResponse
    {
        ServerResponded = 0,
        ServerFailedToRespond,
        /// <summary>
        /// for the Internet query type, returned in response callback if no servers of this type match
        /// </summary>
        NoServersListedOnMasterServer,
    }
}
