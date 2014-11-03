using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if the interface versions for the managed and native dlls mismatch.
    /// This can occur if updating from one version to another and forgetting to update either file.
    /// </summary>
    [Serializable]
    public class InvalidInterfaceVersionException : ManagedException
    {
        internal InvalidInterfaceVersionException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal InvalidInterfaceVersionException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected InvalidInterfaceVersionException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
