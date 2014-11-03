using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Specifies the Universe this client is connected to.
    /// </summary>
    public enum Universe
    {
        /// <summary>
        /// Invalid Universe
        /// </summary>
        Invalid = 0,
        /// <summary>
        /// Public Universe
        /// </summary>
        Public = 1,
        /// <summary>
        /// Beta Universe
        /// </summary>
        Beta = 2,
        /// <summary>
        /// Internal Universe
        /// </summary>
        Internal = 3,
        /// <summary>
        /// Dev Universe
        /// </summary>
        Dev = 4,
        /// <summary>
        /// RC Universe
        /// </summary>
        RC = 5,
    }
}
