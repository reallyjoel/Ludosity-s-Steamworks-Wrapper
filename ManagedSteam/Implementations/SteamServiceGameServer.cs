using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Implementations
{
    abstract class SteamServiceGameServer : SteamService
    {
        internal static new Dictionary<CallbackID, NativeCallback> Callbacks
        {
            get { return ServicesGameServer.Instance.Callbacks; }
        }
        internal static new Dictionary<ResultID, NativeResultCallback> Results
        {
            get { return ServicesGameServer.Instance.ResultCallbacks; }
        }
    }
}
