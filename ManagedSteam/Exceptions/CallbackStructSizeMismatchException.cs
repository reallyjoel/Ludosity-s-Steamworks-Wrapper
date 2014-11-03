using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if the structure sizes mismatch between the native and managed code.
    /// This is never thrown as a result of usage error.
    /// </summary>
    [Serializable]
    public class CallbackStructSizeMismatchException : ManagedException
    {
        internal CallbackStructSizeMismatchException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal CallbackStructSizeMismatchException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected CallbackStructSizeMismatchException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
