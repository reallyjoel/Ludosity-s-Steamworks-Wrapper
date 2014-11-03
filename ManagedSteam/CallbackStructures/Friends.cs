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
    /// called when a friends' status changes
    /// 
    /// Wrapper for the \steamref PersonaStateChange_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct PersonaStateChange
    {
        private SteamID steamID;
        private s32 changeFlags;

        internal static PersonaStateChange Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<PersonaStateChange>(data, dataSize);
        }

        /// <summary>
        /// steamID of the friend who changed
        /// </summary>
        public SteamID SteamID { get { return steamID; } }
        /// <summary>
        /// what's changed
        /// </summary>
        public PersonaChange ChangeFlags { get { return (PersonaChange)changeFlags; } }
    }

    /// <summary>
    /// posted when game overlay activates or deactivates.
    ///	the game can use this to be pause or resume single player games
    ///			
    /// Wrapper for the \steamref GameOverlayActivated_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct GameOverlayActivated
    {
        private u8 active;

        internal static GameOverlayActivated Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameOverlayActivated>(data, dataSize);
        }

        /// <summary>
        /// true if it's just been activated, false otherwise
        /// </summary>
        public bool Active { get { return active != 0; } }
    }

    /// <summary>
    /// called when the user tries to join a different game server from their friends list.
    ///	game client should attempt to connect to specified server when this is received
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GameServerChangeRequested
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Friends.ServerAddressMaxLength)]
        private string server;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Friends.ServerPasswordMaxLength)]
        private string password;

        internal static GameServerChangeRequested Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameServerChangeRequested>(data, dataSize);
        }

        /// <summary>
        /// server address ("127.0.0.1:27015", "tf2.valvesoftware.com")
        /// </summary>
        public string Server { get { return server; } }
        /// <summary>
        /// server password, if any
        /// </summary>
        public string Password { get { return password; } }

    };

    /// <summary>
    /// called when the user tries to join a lobby from their friends list.
    /// game client should attempt to connect to specified lobby when this is received
    ///
    /// Wrapper for the \steamref GameLobbyJoinRequested_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GameLobbyJoinRequested
    {
        private SteamID lobbyID;
        private SteamID friendID;

        internal static GameLobbyJoinRequested Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameLobbyJoinRequested>(data, dataSize);
        }

        public SteamID LobbyID { get { return lobbyID; } }
        /// <summary>
        /// The friend they did the join via (will be invalid if not directly via a friend)
        /// </summary>
        public SteamID FriendID { get { return friendID; } }
    }


    /// <summary>
    /// called when an avatar is loaded in from a previous GetLargeFriendAvatar() call.
    /// if the image wasn't already available
    ///
    /// Wrapper for the \steamref AvatarImageLoaded_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4/*NativeHelpers.SteamStructPacking*/, Size=20, CharSet = CharSet.Ansi)]
    public struct AvatarImageLoaded
    {
        private SteamID steamID;
        private ImageHandle image;
        private s32 wide;
        private s32 tall;

        internal static AvatarImageLoaded Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<AvatarImageLoaded>(data, dataSize);
        }

        /// <summary>
        /// steamid the avatar has been loaded for
        /// </summary>
        public SteamID SteamID { get { return steamID; } }
        /// <summary>
        /// the image index of the now loaded image
        /// </summary>
        public ImageHandle Image { get { return image; } }
        /// <summary>
        /// width of the loaded image
        /// </summary>
        public int Width { get { return wide; } }
        /// <summary>
        /// height of the loaded image
        /// </summary>
        public int Height { get { return tall; } }
    }

    /// <summary>
    /// marks the return of a request officer list call
    /// 
    /// Wrapper for the \steamref ClanOfficerListResponse_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct ClanOfficerListResponse
    {
        private SteamID steamIDClan;
        private s32 officers;
        private u8 success;

        internal static ClanOfficerListResponse Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<ClanOfficerListResponse>(data, dataSize);
        }

        public SteamID SteamIDClan { get { return steamIDClan; } }
        public int Officers { get { return officers; } }
        public bool Success { get { return success != 0; } }

    }

    /// <summary>
    /// callback indicating updated data about friends rich presence information
    ///    
    /// Wrapper for the \steamref FriendRichPresenceUpdate_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 /*NativeHelpers.SteamStructPacking*/, Size=12, CharSet = CharSet.Ansi)]
    public struct FriendRichPresenceUpdate
    {
        private SteamID steamIDFriend;
        private u32 gameAppID;

        internal static FriendRichPresenceUpdate Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FriendRichPresenceUpdate>(data, dataSize);
        }

        /// <summary>
        /// friend who's rich presence has changed
        /// </summary>
        public SteamID SteamIDFriend { get { return steamIDFriend; } }
        /// <summary>
        /// the appID of the game (should always be the current game)
        /// </summary>
        public AppID GameAppID { get { return new AppID(gameAppID); } }

    };

    /// <summary>
    /// called when the user tries to join a game from their friends list.
    ///	rich presence will have been set with the "connect" key which is set here
    ///			
    /// Wrapper for the \steamref GameRichPresenceJoinRequested_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GameRichPresenceJoinRequested
    {
        private SteamID steamIDFriend;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Friends.MaxRichPresenceValueLength)]
        private string connect;

        internal static GameRichPresenceJoinRequested Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameRichPresenceJoinRequested>(data, dataSize);
        }

        /// <summary>
        /// the friend they did the join via (will be invalid if not directly via a friend)
        /// </summary>
        public SteamID SteamIDFriend { get { return steamIDFriend; } }
        public string Connect { get { return connect; } }
    }


    /// <summary>
    /// a chat message has been received for a clan chat the game has joined
    ///    
    /// Wrapper for the \steamref GameConnectedClanChatMsg_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4/*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct GameConnectedClanChatMsg
    {
        private SteamID steamIDClanChat;
        private SteamID steamIDUser;
        private s32 messageID;

        internal static GameConnectedClanChatMsg Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameConnectedClanChatMsg>(data, dataSize);
        }


        public SteamID SteamIDClanChat { get { return steamIDClanChat; } }
        public SteamID SteamIDUser { get { return steamIDUser; } }
        public int MessageID { get { return messageID; } }
    };


    /// <summary>
    /// a user has joined a clan chat
    /// 
    /// Wrapper for the \steamref GameConnectedChatJoin_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct GameConnectedChatJoin
    {
        private SteamID steamIDClanChat;
        private SteamID steamIDUser;

        internal static GameConnectedChatJoin Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameConnectedChatJoin>(data, dataSize);
        }

        public SteamID SteamIDClanChat { get { return steamIDClanChat; } }
        public SteamID SteamIDUser { get { return steamIDUser; } }
    };

    /// <summary>
    /// a user has left the chat we're in
    /// 
    /// Wrapper for the \steamref GameConnectedChatLeave_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct GameConnectedChatLeave
    {
        private SteamID steamIDClanChat;
        private SteamID steamIDUser;
        [MarshalAs(UnmanagedType.I1)]
        private bool kicked;
        [MarshalAs(UnmanagedType.I1)]
        private bool dropped;


        internal static GameConnectedChatLeave Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameConnectedChatLeave>(data, dataSize);
        }

        public SteamID SteamIDClanChat { get { return steamIDClanChat; } }
        public SteamID SteamIDUser { get { return steamIDUser; } }
        /// <summary>
        /// true if admin kicked
        /// </summary>
        public bool Kicked { get { return kicked; } }
        /// <summary>
        /// true if Steam connection dropped
        /// </summary>
        public bool Dropped { get { return dropped; } }

    };

    /// <summary>
    /// a DownloadClanActivityCounts() call has finished
    /// 
    /// Wrapper for the \steamref DownloadClanActivityCountsResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct DownloadClanActivityCountsResult
    {
        [MarshalAs(UnmanagedType.I1)]
        private bool success;

        internal static DownloadClanActivityCountsResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<DownloadClanActivityCountsResult>(data, dataSize);
        }

        public bool Success { get { return success; } }
    };

    /// <summary>
    /// a JoinClanChatRoom() call has finished
    /// 
    /// Wrapper for the \steamref JoinClanChatRoomCompletionResult_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct JoinClanChatRoomCompletionResult
    {
        private SteamID steamIDClanChat;
        private ChatRoomEnterResponse chatRoomEnterResponse;

        internal static JoinClanChatRoomCompletionResult Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<JoinClanChatRoomCompletionResult>(data, dataSize);
        }

        public SteamID SteamIDClanChat { get { return steamIDClanChat; } }
        public ChatRoomEnterResponse ChatRoomEnterResponse { get { return chatRoomEnterResponse; } }
    };

    /// <summary>
    /// a chat message has been received from a user
    /// 
    /// Wrapper for the \steamref GameConnectedFriendChatMsg_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct GameConnectedFriendChatMsg
    {
        private SteamID steamIDUser;
        private s32 messageID;

        internal static GameConnectedFriendChatMsg Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameConnectedFriendChatMsg>(data, dataSize);
        }

        public SteamID SteamIDUser { get { return steamIDUser; } }
        public int MessageID { get { return messageID; } }
    };

    /// <summary>
    /// Wrapper for the \steamref FriendsGetFollowerCount_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4 /*Pack = NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct FriendsGetFollowerCount
    {
        private Result result;
        private SteamID steamID;
        private s32 count;

        internal static FriendsGetFollowerCount Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FriendsGetFollowerCount>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public SteamID SteamID { get { return steamID; } }
        public int Count { get { return count; } }
    };

    /// <summary>
    /// Wrapper for the \steamref FriendsIsFollowing_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4 /*Pack = NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct FriendsIsFollowing
    {
        private Result result;
        private SteamID steamID;
        //[MarshalAs(UnmanagedType.I1)]
        private bool isFollowing;

        internal static FriendsIsFollowing Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FriendsIsFollowing>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public SteamID SteamID { get { return steamID; } }
        public bool IsFollowing { get { return isFollowing; } }
    };

    /// <summary>
    /// Wrapper for the \steamref FriendsEnumerateFollowingList_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4 /*NativeHelpers.SteamStructPacking*/, CharSet = CharSet.Ansi)]
    public struct FriendsEnumerateFollowingList
    {
        private Result result;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.Friends.EnumerateFollowersMax)]
        private SteamID[] steamID;
        private s32 resultsReturned;
        private s32 totalResultCount;

        internal static FriendsEnumerateFollowingList Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FriendsEnumerateFollowingList>(data, dataSize);
        }

        public Result Result { get { return result; } }
        public SteamID[] SteamID { get { return steamID; } }
        public int ResultReturned { get { return resultsReturned; } }
        public int TotalResultCount { get { return totalResultCount; } }
    };

}
