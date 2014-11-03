using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum VoiceResult
    {
        OK = 0,

        NotInitialized = 1,

        NotRecording = 2,

        NoData = 3,

        BufferToSmall = 4,

        DataCorrupted = 5,

        Restricted = 6,

        UnsupportedCodec = 7
    }
}
