using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// list of possible errors returned by SendP2PPacket() API
    /// these will be posted in the P2PSessionConnectFail_t callback
    /// 
    /// Managed version of the \a EP2PSessionError enum
    /// </summary>
    public enum P2PSessionError
    {
        None = 0,
        /// <summary>
        /// target is not running the same game
        /// </summary>
        NotRunningApp = 1,
        /// <summary>
        /// local user doesn't own the app that is running
        /// </summary>
        NoRightsToApp = 2,
        /// <summary>
        /// target user isn't connected to Steam
        /// </summary>
        DestinationNotLoggedIn = 3,
        /// <summary>
        /// target isn't responding, perhaps not calling AcceptP2PSessionWithUser().
        /// corporate firewalls can also block this (NAT traversal is not firewall traversal)
        /// make sure that UDP ports 3478, 4379, and 4380 are open in an outbound direction
        /// </summary>
        Timeout = 4,

        Max = 5
    }

}
