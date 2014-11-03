using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Base for all exceptions caused by errors in the native code.
    /// </summary>
    [Serializable]
    public class NativeException : Exception
    {
        internal NativeException(ErrorCodes code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        internal NativeException(StringID code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        protected NativeException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
