using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    [Serializable]
    public class UnexpectedException : Exception
    {
        internal UnexpectedException(ErrorCodes code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        internal UnexpectedException(StringID code, params object[] args)
            : base(StringMap.GetString(code, args))
        {
        }

        protected UnexpectedException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
