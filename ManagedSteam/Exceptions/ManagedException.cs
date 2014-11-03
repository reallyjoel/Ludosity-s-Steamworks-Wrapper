using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// The base for all exceptions caused by errors in the managed code.
    /// </summary>
    [Serializable]
    public class ManagedException : Exception
    {
        internal ManagedException(ErrorCodes code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        internal ManagedException(StringID code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        protected ManagedException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
