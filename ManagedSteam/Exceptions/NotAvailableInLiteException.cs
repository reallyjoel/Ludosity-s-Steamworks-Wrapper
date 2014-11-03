using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.Exceptions
{
    [Serializable]
    public class NotAvailableInLiteException : ManagedException
    {
        internal NotAvailableInLiteException()
            : base(ErrorCodes.NotAvailableInLite)
        {
        }


        protected NotAvailableInLiteException(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {

        }
    }
}
