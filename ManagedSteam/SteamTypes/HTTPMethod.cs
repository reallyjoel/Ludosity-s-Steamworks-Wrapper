using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of EHTTPMethod enum
    /// </summary>
    public enum HTTPMethod
    {
        /// <summary></summary>
        Invalid = 0,
        /// <summary></summary>
        GET = 1,
        /// <summary></summary>
        HEAD = 2,
        /// <summary></summary>
        POST = 3,
        /// <summary></summary>
        PUT,
        /// <summary></summary>
        DELETE,
        /// <summary></summary>
        OPTIONS,

        // The remaining HTTP methods are not yet supported, per rfc2616 section 5.1.1 only GET and HEAD are required for 
        // a compliant general purpose server.  We'll likely add more as we find uses for them.

        // k_EHTTPMethodTRACE,
        // k_EHTTPMethodCONNECT
    }
}
