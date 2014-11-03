using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \steamref UserUGCList enum
    /// 
    /// Matching UGC types for queries
    /// </summary>
    public enum EUGCMatchingUGCType
    {
        /// <summary>
        /// both mtx items and ready-to-use items
        /// </summary>
        Items = 0,
        Items_Mtx = 1,
        Items_ReadyToUse = 2,
        Collections = 3,
        Artwork = 4,
        Videos = 5,
        Screenshots = 6,
        /// <summary>
        /// both web guides and integrated guides
        /// </summary>
        AllGuides = 7,
        WebGuides = 8,
        IntegratedGuides = 9,
        /// <summary>
        /// ready-to-use items and integrated guides
        /// </summary>
        UsableInGame = 10,
        ControllerBindings = 11,
    }
}
