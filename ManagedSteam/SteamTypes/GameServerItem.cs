using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
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
    /// Managed version of the \a gameserveritem_t class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct GameServerItem
    {
        private ServerNetworkAddress serverAddress;
        private s32 ping;
        [MarshalAs(UnmanagedType.I1)]
        private bool hadSuccessfulResponse;
        [MarshalAs(UnmanagedType.I1)]
        private bool doNotRefresh;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.MaxGameServerGameDir)]
        private string gameDir;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.MaxGameServerMapName)]
        private string map;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.MaxGameServerGameDescription)]
        private string gameDescription;
        private u32 appID;
        private s32 players;
        private s32 maxPlayers;
        private s32 botPlayers;
        [MarshalAs(UnmanagedType.I1)]
        private bool password;
        [MarshalAs(UnmanagedType.I1)]
        private bool secure;
        private u32 timeLastPlayed;
        private s32 serverVersion;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.MaxGameServerName)]
        private string serverName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.MaxGameServerTags)]
        private string gameTags;
        private SteamID steamID;

        internal static GameServerItem Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<GameServerItem>(data, dataSize);
        }

        /// <summary>
        /// IP/Query Port/Connection Port for this server
        /// </summary>
        public ServerNetworkAddress ServerNetworkAddress
        {
            get { return serverAddress; }
            set { serverAddress = value; }
        }

        /// <summary>
        /// current ping time in milliseconds
        /// </summary>
        public int Ping
        {
            get { return ping; }
            set { ping = value; }
        }

        /// <summary>
        /// server has responded successfully in the past
        /// </summary>
        public bool HadSuccessfulResponse
        {
            get { return hadSuccessfulResponse; }
            set { hadSuccessfulResponse = value; }
        }

        /// <summary>
        /// server is marked as not responding and should no longer be refreshed
        /// </summary>
        public bool DoNotRefresh
        {
            get { return doNotRefresh; }
            set { doNotRefresh = value; }
        }

        /// <summary>
        /// current game directory
        /// </summary>
        public string GameDir
        {
            get { return gameDir; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.MaxGameServerGameDir)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.MaxGameServerGameDir));
                }
                gameDir = value;
            }
        }

        /// <summary>
        /// current map
        /// </summary>
        public string Map
        {
            get { return map; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.MaxGameServerMapName)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.MaxGameServerMapName));
                }
                map = value;
            }
        }

        /// <summary>
        /// game description
        /// </summary>
        public string GameDescription
        {
            get { return gameDescription; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.MaxGameServerGameDescription)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.MaxGameServerGameDescription));
                }
                gameDescription = value;
            }
        }

        /// <summary>
        /// Steam App ID of this server
        /// </summary>
        public AppID AppID
        {
            get { return new AppID(appID); }
            set { appID = value.AsUInt32; }
        }

        /// <summary>
        /// total number of players currently on the server.  INCLUDES BOTS!!
        /// </summary>
        public int Players
        {
            get { return players; }
            set { players = value; }
        }

        /// <summary>
        /// Maximum players that can join this server
        /// </summary>
        public int MaxPlayers
        {
            get { return maxPlayers; }
            set { maxPlayers = value; }
        }

        /// <summary>
        /// Number of bots (i.e simulated players) on this server
        /// </summary>
        public int BotPlayers
        {
            get { return botPlayers; }
            set { botPlayers = value; }
        }

        /// <summary>
        /// true if this server needs a password to join
        /// </summary>
        public bool Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Is this server protected by VAC
        /// </summary>
        public bool Secure
        {
            get { return secure; }
            set { secure = value; }
        }

        /// <summary>
        /// time (in unix time) when this server was last played on (for favorite/history servers)
        /// </summary>
        public uint TimeLastPlayed
        {
            get { return timeLastPlayed; }
            set { timeLastPlayed = value; }
        }

        /// <summary>
        /// server version as reported to Steam
        /// </summary>
        public int ServerVersion
        {
            get { return serverVersion; }
            set { serverVersion = value; }
        }

        /// <summary>
        /// Game server name
        /// </summary>
        public string ServerName
        {
            get
            {
                if (string.IsNullOrEmpty(serverName))
                {
                    return serverAddress.GetConnectionAddressString();
                }
                return serverName;
            }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.MaxGameServerName)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.MaxGameServerName));
                }
                serverName = value;
            }
        }

        /// <summary>
        /// the tags this server exposes
        /// </summary>
        public string GameTags
        {
            get { return gameTags; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.MaxGameServerTags)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.MaxGameServerTags));
                }
                gameTags = value;
            }
        }

        /// <summary>
        /// steamID of the game server - invalid if it's doesn't have one (old server, or not connected to Steam)
        /// </summary>
        public SteamID SteamID
        {
            get { return steamID; }
            set { steamID = value; }
        }


        /// <summary>
        /// The server name. Will return the same value as the ServerName property
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return ServerName;
        }

        /// <summary>
        /// Changes the server name. The same as assigning to the ServerName property
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            ServerName = name;
        }
    }
}
