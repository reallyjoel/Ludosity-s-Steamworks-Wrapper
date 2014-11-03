using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EChatRoomEnterRepsonse enum
    /// </summary>
    public enum ChatRoomEnterResponse
    {
        /// <summary>
        /// Success
        /// </summary>
        Success = 1,
        /// <summary>
        /// Chat doesn't exist (probably closed)
        /// </summary>
        DoesntExist = 2,
        /// <summary>
        /// General Denied - You don't have the permissions needed to join the chat
        /// </summary>
        NotAllowed = 3,
        /// <summary>
        /// Chat room has reached its maximum size
        /// </summary>
        Full = 4,
        /// <summary>
        /// Unexpected Error
        /// </summary>
        Error = 5,
        /// <summary>
        /// You are banned from this chat room and may not join
        /// </summary>
        Banned = 6,
        /// <summary>
        /// Joining this chat is not allowed because you are a limited user (no value on account)
        /// </summary>
        Limited = 7,
        /// <summary>
        /// Attempt to join a clan chat when the clan is locked or disabled
        /// </summary>
        ClanDisabled = 8,
        /// <summary>
        /// Attempt to join a chat when the user has a community lock on their account
        /// </summary>
        CommunityBan = 9,
        /// <summary>
        /// Join failed - some member in the chat has blocked you from joining
        /// </summary>
        MemberBlockedYou = 10,
        /// <summary>
        /// Join failed - you have blocked some member already in the chat
        /// </summary>
        YouBlockedMember = 11,
        /// <summary>
        /// There is no ranking data available for the lobby 
        /// </summary>
        NoRankingDataLobby = 12,
        /// <summary>
        /// There is no ranking data available for the user
        /// </summary>
        NoRankingDataUser = 13,
        /// <summary>
        /// The user is out of the allowable ranking range
        /// </summary>
        RankOutOfRange = 14,
    }

}
