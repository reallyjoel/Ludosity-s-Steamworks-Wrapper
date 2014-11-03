using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{   
    /// <summary>
    /// Managed version of the \a ECheckFileSignature.
    /// 
    /// </summary>
    public enum ECheckFileSignature
    {
        InvalidSignature = 0,

        ValidSignature = 1,
        
        FileNotFound = 2,
        
        NoSignaturesFoundForThisApp = 3,
        
        NoSignaturesFoundForThisFile = 4,
    }
}
