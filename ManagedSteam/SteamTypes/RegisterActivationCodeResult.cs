using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{

    public enum RegisterActivationCodeResult
    {
        OK = 0,

        Fail = 1,

        AlreadyRegistered = 2,

        Timeout = 3,

        AlreadyOwned = 4,
    }
}
