using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum HmdTrackingResult
    {
        Uninitialized           =   1,

        CalibratingInProgress   = 100,
        CalibratingOutOfRange   = 101,

        RunningOK               = 200,
        RunningOutOfRange       = 201,
    };
}
