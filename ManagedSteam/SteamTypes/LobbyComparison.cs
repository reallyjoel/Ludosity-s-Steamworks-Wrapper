using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a ELobbyComparison enum
    /// </summary>
    public enum LobbyComparison
    {
        EqualToOrLessThan = -2,
        LessThan = -1,
        Equal = 0,
        GreaterThan = 1,
        EqualToOrGreaterThan = 2,
        NotEqual = 3,
    }

}
