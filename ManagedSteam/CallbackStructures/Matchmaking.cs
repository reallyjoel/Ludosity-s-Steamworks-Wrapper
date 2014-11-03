using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using ManagedSteam.SteamTypes;

namespace ManagedSteam.CallbackStructures
{
    using u8 = Byte;
    using s8 = SByte;
    using u16 = UInt16;
    using s16 = Int16;
    using u32 = UInt32;
    using s32 = Int32;
    using u64 = UInt64;
    using s64 = Int64;
    using f32 = Single;
    using f64 = Double;

    using Enum = Int32;


    /// <summary>
    /// a server was added/removed from the favorites list, you should refresh now
    /// 
    /// Wrapper for the \steamref FavoritesListChanged_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct FavoritesListChanged
    {
        private u32 ip;
        private u32 queryPort;
        private u32 connPort;
        private u32 appID;
        private u32 flags;
        [MarshalAs(UnmanagedType.I1)]
        private bool add;

        internal static FavoritesListChanged Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FavoritesListChanged>(data, dataSize);
        }

        /// <summary>
        /// an IP of 0 means reload the whole list, any other value means just one server
        /// </summary>
        public uint IP { get { return ip; } }
        public uint QueryPort { get { return queryPort; } }
        public uint ConnPort { get { return connPort; } }
        public AppID AppID { get { return new AppID(appID); } }
        public uint Flags { get { return flags; } }
        /// <summary>
        /// true if this is adding the entry, otherwise it is a remove
        /// </summary>
        public bool Add { get { return add; } }
    }

    /// <summary>
    /// Someone has invited you to join a Lobby.
    /// Normally you don't need to do anything with this, since
    /// the Steam UI will also display a '<user> has invited you to the lobby, join?' dialog
    /// 
    /// If the user outside a game chooses to join, your game will be launched with the 
    /// parameter "+connect_lobby <64-bit lobby id>",
    /// or with the callback GameLobbyJoinRequested_t if they're already in-game
    /// 
    /// Wrapper for the \steamref LobbyInvite_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyInvite
    {
        private SteamID steamIDUser;
        private SteamID steamIDLobby;
        private GameID gameID;


        internal static LobbyInvite Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyInvite>(data, dataSize);
        }

        public SteamID SteamIDUser { get { return steamIDUser; } }
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        public GameID GameID { get { return gameID; } }

    }

    /// <summary>
    /// Sent on entering a lobby, or on failing to enter
    ///	ChatRoomEnterResponse will be set to Success on success,
    ///	or a higher value on failure (see enum ChatRoomEnterResponse)
    /// 
    /// Wrapper for the \a LobbyEnter_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyEnter
    {
        private SteamID steamIDLobby;
        private u32 chatPermissions;
        [MarshalAs(UnmanagedType.I1)]
        private bool locked;
        private u32 chatRoomEnterResponse;

        internal static LobbyEnter Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyEnter>(data, dataSize);
        }

        /// <summary>
        /// SteamID of the Lobby you have entered
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// Permissions of the current user
        /// </summary>
        public uint ChatPermissions { get { return chatPermissions; } }
        /// <summary>
        /// If true, then only invited users may join
        /// </summary>
        public bool Locked { get { return locked; } }
        /// <summary>
        /// EChatRoomEnterResponse
        /// </summary>
        public ChatRoomEnterResponse ChatRoomEnterResponse { get { return (ChatRoomEnterResponse)chatRoomEnterResponse; } }
    }

    /// <summary>
    /// The lobby metadata has changed
    ///	
    /// if m_ulSteamIDMember is the steamID of a lobby member, use GetLobbyMemberData() to access per-user details
    /// 
    ///	if m_ulSteamIDMember == m_ulSteamIDLobby, use GetLobbyData() to access lobby metadata
    /// 
    /// Wrapper for the \a LobbyDataUpdate_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyDataUpdate
    {
        private SteamID steamIDLobby;
        private SteamID steamIDMember;
        private u8 success;

        internal static LobbyDataUpdate Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyDataUpdate>(data, dataSize);
        }

        /// <summary>
        /// SteamID of the Lobby
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// steamID of the member whose data changed, or the room itself
        /// </summary>
        public SteamID SteamIDMember { get { return steamIDMember; } }
        /// <summary>
        /// true if we lobby data was successfully changed; 
        /// will only be false if RequestLobbyData() was called on a lobby that no longer exists
        /// </summary>
        public bool Success { get { return success == 1; } }

    }


    /// <summary>
    /// The lobby chat room state has changed.
    ///	This is usually sent when a user has joined or left the lobby
    /// 
    /// Wrapper for the \a LobbyChatUpdate_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyChatUpdate
    {
        private SteamID steamIDLobby;
        private SteamID steamIDUserChanged;
        private SteamID steamIDMakingChange;
        private Enum chatMemberStateChange;

        internal static LobbyChatUpdate Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyChatUpdate>(data, dataSize);
        }

        /// <summary>
        /// Lobby ID
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// user who's status in the lobby just changed - can be recipient
        /// </summary>
        public SteamID SteamIDUserChanged { get { return steamIDUserChanged; } }
        /// <summary>
        /// Chat member who made the change (different from SteamIDUserChange if kicking, muting, etc.).
        /// For example, if one user kicks another from the lobby, this will be set to the id of the user who initiated the kick
        /// </summary>
        public SteamID SteamIDMakingChange { get { return steamIDMakingChange; } }
        public ChatMemberStateChange ChatMemberStateChange { get { return (ChatMemberStateChange)chatMemberStateChange; } }
    }

    /// <summary>
    /// A chat message for this lobby has been sent.
    ///	Use GetLobbyChatEntry( m_iChatID ) to retrieve the contents of this message
    /// 
    /// Wrapper for the \a LobbyChatMsg_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyChatMsg
    {
        private SteamID steamIDLobby;
        private SteamID steamIDUser;
        private u8 chatEntryType;
        private u32 chatID;

        internal static LobbyChatMsg Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyChatMsg>(data, dataSize);
        }

        /// <summary>
        /// the lobby id this is in
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// steamID of the user who has sent this message
        /// </summary>
        public SteamID SteamIDUser { get { return steamIDUser; } }
        /// <summary>
        /// type of message
        /// </summary>
        public ChatEntryType ChatEntryType { get { return (ChatEntryType)chatEntryType; } }
        /// <summary>
        /// index of the chat entry to lookup
        /// </summary>
        public uint ChatID { get { return chatID; } }
    }

    /// <summary>
    /// A game created a game for all the members of the lobby to join,
    ///	as triggered by a SetLobbyGameServer()
    ///	it's up to the individual clients to take action on this; the usual
    ///	game behavior is to leave the lobby and connect to the specified game server
    /// 
    /// Wrapper for the \a LobbyGameCreated_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyGameCreated
    {
        private SteamID steamIDLobby;
        private SteamID steamIDGameServer;
        private u32 ip;
        private u16 port;

        internal static LobbyGameCreated Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyGameCreated>(data, dataSize);
        }

        /// <summary>
        /// the lobby we were in
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// the new game server that has been created or found for the lobby members
        /// </summary>
        public SteamID SteamIDGameServer { get { return steamIDGameServer; } }
        /// <summary>
        /// IP of the game server (if any)
        /// </summary>
        public u32 IP { get { return ip; } }
        public u16 Port { get { return port; } }
    }


    /// <summary>
    /// Number of matching lobbies found.
    ///	Iterate the returned lobbies with GetLobbyByIndex(), from values 0 to m_nLobbiesMatching-1
    /// 
    /// Wrapper for the \a LobbyMatchList_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyMatchList
    {
        private u32 lobbiesMatching;

        internal static LobbyMatchList Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyMatchList>(data, dataSize);
        }

        /// <summary>
        /// Number of lobbies that matched search criteria and we have SteamIDs for
        /// </summary>
        public uint LobbiesMatching { get { return lobbiesMatching; } }
    }

    /// <summary>
    /// posted if a user is forcefully removed from a lobby.
    ///	can occur if a user loses connection to Steam
    /// 
    /// Wrapper for the \a LobbyKicked_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyKicked
    {
        private SteamID steamIDLobby;
        private SteamID steamIDAdmin;
        private u8 kickedDueToDisconnect;

        internal static LobbyKicked Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyKicked>(data, dataSize);
        }

        /// <summary>
        /// Lobby
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
        /// <summary>
        /// User who kicked you - possibly the ID of the lobby itself
        /// </summary>
        public SteamID SteamIDAdmin { get { return steamIDAdmin; } }
        /// <summary>
        /// true if you were kicked from the lobby due to the user losing connection 
        /// to Steam (currently always true)
        /// </summary>
        public bool KickedDueToDisconnect { get { return kickedDueToDisconnect == 1; } }
    }


    /// <summary>
    /// Result of our request to create a Lobby.
    ///	m_eResult == k_EResultOK on success
    ///	at this point, the lobby has been joined and is ready for use
    ///	a LobbyEnter_t callback will also be received (since the local user is joining their own lobby)
    /// 
    /// Wrapper for the \a LobbyCreated_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct LobbyCreated
    {
        private Result result;
        private SteamID steamIDLobby;

        internal static LobbyCreated Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LobbyCreated>(data, dataSize);
        }

        /// <summary>
        /// \li OK - the lobby was successfully created
        /// \li NoConnection - your Steam client doesn't have a connection to the back-end
        /// \li Timeout - you the message to the Steam servers, but it didn't respond
        /// \li Fail - the server responded, but with an unknown internal error
        /// \li AccessDenied - your game isn't set to allow lobbies, or your client does haven't rights to play the game
        /// \li LimitExceeded - your game client has created too many lobbies
        /// </summary>
        public Result Result { get { return result; } }
        /// <summary>
        /// chat room, zero if failed
        /// </summary>
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
    }

}
