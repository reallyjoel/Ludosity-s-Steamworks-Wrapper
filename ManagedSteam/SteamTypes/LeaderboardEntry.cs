using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Wrapper for the \a LeaderboardEntry_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct LeaderboardEntry // LeaderboardEntry_t
    {
        SteamID user;
        int rank;
        int score;
        int numberOfDetails;
        UGCHandle handle;

        internal static LeaderboardEntry Create(IntPtr data, int dataSize)
        {
            return NativeHelpers.ConvertStruct<LeaderboardEntry>(data, dataSize);
        }

        public SteamID User { get { return user; } }
        public int Rank { get { return rank; } }
        public int Score { get { return score; } }
        public int NumberOfDetails { get { return numberOfDetails; } }
        public UGCHandle Handle { get { return handle; } }
    };
}
