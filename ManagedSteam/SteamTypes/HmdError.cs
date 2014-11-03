using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    public enum HmdError
    {
        None                            = 0,

        InitInstallationNotFound        = 100,
        InitInstallationCorrupt         = 101,
        InitVRClientDLLNotFound         = 102,
        InitFileNotFound                = 103,
        InitFactoryNotFound             = 104,
        InitInterfaceNotFound           = 105,
        InitInvalidInterface            = 106,
        InitUserConfigDirectoryInvalid  = 107,
        InitHmdNotFound                 = 108,
        InitNotInitialized              = 109,

        DriverFailed                    = 200,

        IPCServerInitFailed             = 300,
        IPCConnectFailed                = 301,
        IPCSharedStateInitFailed        = 302,
    }
}
