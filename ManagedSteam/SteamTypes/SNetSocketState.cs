using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ESNetSocketState enum
    /// </summary>
    public enum SNetSocketState
    {
        Invalid = 0,

        /// <summary>
        /// communication is valid
        /// </summary>
        Connected = 1,

        /// <summary>
        /// states while establishing a connection.
        /// 
        /// the connection state machine has started
        /// </summary>
        Initiated = 10,


        /// <summary>
        /// p2p connections
        /// 
        /// we've found our local IP info
        /// </summary>
        LocalCandidatesFound = 11,
        /// <summary>
        /// p2p connections
        /// 
        /// we've received information from the remote machine, via the Steam back-end, about their IP info
        /// </summary>
        ReceivedRemoteCandidates = 12,

        /// <summary>
        /// direct connections
        /// 
        /// we've received a challenge packet from the server
        /// </summary>
        ChallengeHandshake = 15,

        /// <summary>
        /// failure states
        /// 
        /// the API shut it down, and we're in the process of telling the other end	
        /// </summary>
        Disconnecting = 21,
        /// <summary>
        /// failure states
        /// 
        /// the API shut it down, and we've completed shutdown
        /// </summary>
        LocalDisconnect = 22,
        /// <summary>
        /// failure states
        /// 
        /// we timed out while trying to creating the connection
        /// </summary>
        TimeoutDuringConnect = 23,
        /// <summary>
        /// failure states
        /// 
        /// the remote end has disconnected from us
        /// </summary>
        RemoteEndDisconnected = 24,
        /// <summary>
        /// failure states
        /// 
        /// connection has been broken; either the other end has disappeared or our local network connection has broke
        /// </summary>
        ConnectionBroken = 25,
    }

}
