using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if the call to SteamAPI_InitSafe() fails. Usually the result of a missing steam_appid.txt file
    /// or if the Steam client is not running.
    /// </summary>
    [Serializable]
    public class SteamInitializeFailedException : NativeException
    {
        internal SteamInitializeFailedException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal SteamInitializeFailedException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected SteamInitializeFailedException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
