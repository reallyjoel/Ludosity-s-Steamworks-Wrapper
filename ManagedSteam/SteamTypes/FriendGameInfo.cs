using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// friend game played information
    /// 
    /// Wrapper for the \a FriendGameInfo_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct FriendGameInfo
    {
        private GameID gameID;
        private UInt32 gameIP;
        private UInt16 gamePort;
        private UInt16 queryPort;
        private SteamID steamIDLobby;

        internal static FriendGameInfo Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<FriendGameInfo>(data, dataSize);
        }

        public GameID GameID { get { return gameID; } }
        public uint GameIP { get { return gameIP; } }
        public ushort GamePort { get { return gamePort; } }
        public ushort QueryPort { get { return queryPort; } }
        public SteamID SteamIDLobby { get { return steamIDLobby; } }
    }
}
