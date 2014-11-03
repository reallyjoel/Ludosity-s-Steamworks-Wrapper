using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EAuthSessionResponse
    /// </summary>
    public enum AuthSessionResponse
    {
        OK = 0,							// Steam has verified the user is online, the ticket is valid and ticket has not been reused.
        UserNotConnectedToSteam = 1,		// The user in question is not connected to steam
        NoLicenseOrExpired = 2,			// The license has expired.
        VACBanned = 3,					// The user is VAC banned for this game.
        LoggedInElseWhere = 4,			// The user account has logged in elsewhere and the session containing the game instance has been disconnected.
        VACCheckTimedOut = 5,				// VAC has been unable to perform anti-cheat checks on this user
        AuthTicketCanceled = 6,			// The ticket has been canceled by the issuer
        AuthTicketInvalidAlreadyUsed = 7,	// This ticket has already been used, it is not valid.
        AuthTicketInvalid = 8,			// This ticket is not from a user instance currently connected to steam.
    }

}
