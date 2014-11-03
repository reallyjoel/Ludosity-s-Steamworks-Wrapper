using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if the call to CSteamAPIContext::Init() fails.
    /// Happens if an old version of the Steamworks SDK is used.
    /// \see \ref version_info
    /// </summary>
    [Serializable]
    public class SteamInterfaceInitializeFailedException : NativeException
    {
        internal SteamInterfaceInitializeFailedException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal SteamInterfaceInitializeFailedException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected SteamInterfaceInitializeFailedException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
