using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a MatchMakingKeyValuePair_t struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking, CharSet = CharSet.Ansi)]
    public struct MatchMakingKeyValuePair
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.KeyValuePairMaxKeySize)]
        private string key;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Constants.Matchmaking.KeyValuePairMaxValueSize)]
        private string value;

        public MatchMakingKeyValuePair(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string Key
        {
            get { return key; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.KeyValuePairMaxKeySize)
                {
                    throw new ArgumentOutOfRangeException("key", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.KeyValuePairMaxKeySize));
                }

                key = value;
            }
        }

        public string Value
        {
            get { return value; }
            set
            {
                if (Utility.StringHelper.GetByteCountUtf8(value) > Constants.Matchmaking.KeyValuePairMaxValueSize)
                {
                    throw new ArgumentOutOfRangeException("value", StringMap.GetString(ErrorCodes.StringIsToBig, Constants.Matchmaking.KeyValuePairMaxValueSize));
                }

                this.value = value;
            }
        }
    }
}
