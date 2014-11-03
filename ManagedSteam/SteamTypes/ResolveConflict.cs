using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EResolveConflict enum
    /// </summary>
    public enum ResolveConflict
    {
        /// <summary>
        /// The local version of each file will be used to overwrite the server version
        /// </summary>
        KeepClient = 1,
        /// <summary>
        /// The server version of each file will be used to overwrite the local version
        /// </summary>
        KeepServer = 2,
    };
}
