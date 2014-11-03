using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EBeginAuthSessionResult enum
    /// </summary>
    public enum BeginAuthSessionResult
    {
        /// <summary>
        /// Ticket is valid for this game and this steamID.
        /// </summary>
        OK = 0,
        /// <summary>
        /// Ticket is not valid.
        /// </summary>
        InvalidTicket = 1,
        /// <summary>
        /// A ticket has already been submitted for this steamID
        /// </summary>
        DuplicateRequest = 2,
        /// <summary>
        /// Ticket is from an incompatible interface version
        /// </summary>
        InvalidVersion = 3,
        /// <summary>
        /// Ticket is not for this game
        /// </summary>
        GameMismatch = 4,
        /// <summary>
        /// Ticket has expired
        /// </summary>
        ExpiredTicket = 5,
    }

}
