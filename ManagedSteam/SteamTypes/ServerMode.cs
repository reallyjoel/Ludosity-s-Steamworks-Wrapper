using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EServerMode Enum
    /// </summary>
    [Flags]
    public enum ServerMode
    {
        eServerModeInvalid = 0, // DO NOT USE		
        eServerModeNoAuthentication = 1, // Don't authenticate user logins and don't list on the server list
        eServerModeAuthentication = 2, // Authenticate users, list on the server list, don't run VAC on clients that connect
        eServerModeAuthenticationAndSecure = 3, // Authenticate users, list on the server list and VAC protect clients
    }
}
