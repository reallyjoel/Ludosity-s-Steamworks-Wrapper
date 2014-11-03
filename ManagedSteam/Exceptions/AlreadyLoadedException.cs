using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    /// <summary>
    /// Thrown if Steam::Initialize() is called twice.
    /// </summary>
    [Serializable]
    public class AlreadyLoadedException : NativeException
    {
        internal AlreadyLoadedException(ErrorCodes code, params object[] args)
            : base(code, args)
        {
        }

        internal AlreadyLoadedException(StringID code, params object[] args)
            : base(code, args)
        {
        }

        protected AlreadyLoadedException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
