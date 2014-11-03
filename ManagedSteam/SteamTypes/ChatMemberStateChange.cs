using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref EChatMemberStateChange enum
    /// 
    /// Purpose: Used in ChatInfo messages - fields specific to a chat member
    /// </summary>
    [Flags]
    public enum ChatMemberStateChange
    {
        /// <summary>
        /// This user has joined or is joining the chat room
        /// </summary>
        Entered = 0x0001,
        /// <summary>
        /// This user has left or is leaving the chat room
        /// </summary>
        Left = 0x0002,
        /// <summary>
        /// User disconnected without leaving the chat first
        /// </summary>
        Disconnected = 0x0004,
        /// <summary>
        /// User kicked
        /// </summary>
        Kicked = 0x0008,
        /// <summary>
        /// User kicked and banned
        /// </summary>
        Banned = 0x0010,
    }
}
