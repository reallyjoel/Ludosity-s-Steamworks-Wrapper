using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ERemoteStoragePlatform enum
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2217:DoNotMarkEnumsWithFlags")]
    [Flags]
    public enum RemoteStoragePlatform
    {
        None = 0,
        Windows = (1 << 0),
        OSX = (1 << 1),
        PS3 = (1 << 2),
        Reserved1 = (1 << 3),
        Reserved2 = (1 << 4),


        All = unchecked((int)0xFFFFFFFF),
    }
}
