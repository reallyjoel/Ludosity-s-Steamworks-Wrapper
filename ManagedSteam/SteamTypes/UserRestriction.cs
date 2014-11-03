using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EUserRestriction enum
    /// </summary>
    [Flags]
    public enum UserRestriction
    {
        /// <summary>
        /// no known chat/content restriction
        /// </summary>
        None = 0,
        /// <summary>
        /// we don't know yet (user offline)
        /// </summary>
        Unknown = 1,
        /// <summary>
        /// user is not allowed to (or can't) send/recv any chat
        /// </summary>
        AnyChat = 2,
        /// <summary>
        /// user is not allowed to (or can't) send/recv voice chat
        /// </summary>
        VoiceChat = 4,
        /// <summary>
        /// user is not allowed to (or can't) send/recv group chat
        /// </summary>
        GroupChat = 8,
        /// <summary>
        /// user is too young according to rating in current region
        /// </summary>
        Rating = 16,
        /// <summary>
        /// user cannot send or recv game invites (e.g. mobile)
        /// </summary>
        GameInvites = 32,
        /// <summary>
        /// user cannot participate in trading (console, mobile)
        /// </summary>
        Trading = 64,
    }
}
