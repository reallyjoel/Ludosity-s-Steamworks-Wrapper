using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EPersonaState enum
    /// </summary>
    public enum PersonaState
    {
        /// <summary>
        /// friend is not currently logged on
        /// </summary>
        Offline = 0,
        /// <summary>
        /// friend is logged on
        /// </summary>
        Online = 1,
        /// <summary>
        /// user is on, but busy
        /// </summary>
        Busy = 2,
        /// <summary>
        /// auto-away feature
        /// </summary>
        Away = 3,
        /// <summary>
        /// auto-away for a long time
        /// </summary>
        Snooze = 4,
        /// <summary>
        /// Online, trading
        /// </summary>
        LookingToTrade = 5,
        /// <summary>
        /// Online, wanting to play
        /// </summary>
        LookingToPlay = 6,

        Max,
    }
}
