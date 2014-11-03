using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum SteamAPICallFailure
    {
        /// <summary>
        /// No Failure
        /// </summary>
        None = -1,

        /// <summary>
        /// The local steam process has gone away
        /// </summary>
        SteamGone = 0,

        /// <summary>
        /// The network connection to Steam has been broken, or was already broken.
        /// SteamServersDisconnected callback will be sent around this time.
        /// SteamServersConnected will be sent when the client is able to talk to the Steam servers again.
        /// </summary>
        NetworkFailure = 1,

        /// <summary>
        /// The SteamAPICall handle passed in no longer exists.
        /// </summary>
        InvalidHandle = 2,

        /// <summary>
        /// GetAPICallResult() was called with the wrong callback for this API call
        /// </summary>
        MismatchedCallback = 3,

    }
}
