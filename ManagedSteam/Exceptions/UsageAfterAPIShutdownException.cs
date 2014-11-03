using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if any part of the library is used after \link Steam::Shutdown() Shutdown \endlink or
    /// \link Steam::ReleaseManagedResources() ReleaseManagedResources \endlink is called on the Steam class.
    /// </summary>
    [Serializable]
    public class UsageAfterAPIShutdownException : ManagedException
    {
        internal UsageAfterAPIShutdownException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal UsageAfterAPIShutdownException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected UsageAfterAPIShutdownException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
