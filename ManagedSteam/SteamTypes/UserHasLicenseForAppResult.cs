using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EUserhasLicenseForAppResult enum
    /// </summary>
    public enum UserHasLicenseForAppResult
    {
        /// <summary>
        /// User has a license for specified app
        /// </summary>
        HasLicense = 0,
        /// <summary>
        /// User does not have a license for the specified app
        /// </summary>
        DoesNotHaveLicense = 1,
        /// <summary>
        /// User has not been authenticated
        /// </summary>
        NoAuth = 2,
    }

}
