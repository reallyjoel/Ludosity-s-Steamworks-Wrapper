using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EChatEntryType enum
    /// </summary>
    [Flags]
    public enum ChatEntryType
    {
        Invalid = 0,
        ChatMsg = 1,		// Normal text message from another user
        Typing = 2,			// Another user is typing (not used in multi-user chat)
        InviteGame = 3,		// Invite from other user into that users current game
        Emote = 4,			// text emote message
        //LobbyGameStart = 5,	// lobby game is starting (dead - listen for LobbyGameCreated_t callback instead)
        LeftConversation = 6, // user has left the conversation ( closed chat window )
        // Above are previous FriendMsgType entries, now merged into more generic chat entry types
    }
}
