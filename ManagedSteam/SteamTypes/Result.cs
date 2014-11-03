using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// Managed version of the \a EResult enum
    /// </summary>
    public enum Result
    {
        /// <summary>
        /// success
        /// </summary>
        OK = 1,
        /// <summary>
        /// generic failure 
        /// </summary>
        Fail = 2,
        /// <summary>
        /// no/failed network connection
        /// </summary>
        NoConnection = 3,
        //	k_EResultNoConnectionRetry = 4,				// OBSOLETE - removed
        /// <summary>
        /// password/ticket is invalid
        /// </summary>
        InvalidPassword = 5,
        /// <summary>
        /// same user logged in elsewhere
        /// </summary>
        LoggedInElsewhere = 6,
        /// <summary>
        /// protocol version is incorrect
        /// </summary>
        InvalidProtocolVer = 7,
        /// <summary>
        /// a parameter is incorrect
        /// </summary>
        InvalidParam = 8,
        /// <summary>
        /// file was not found
        /// </summary>
        FileNotFound = 9,
        /// <summary>
        /// called method busy - action not taken
        /// </summary>
        Busy = 10,
        /// <summary>
        /// called object was in an invalid state
        /// </summary>
        InvalidState = 11,
        /// <summary>
        /// name is invalid
        /// </summary>
        InvalidName = 12,
        /// <summary>
        /// email is invalid
        /// </summary>
        InvalidEmail = 13,
        /// <summary>
        /// name is not unique
        /// </summary>
        DuplicateName = 14,
        /// <summary>
        /// access is denied
        /// </summary>
        AccessDenied = 15,
        /// <summary>
        /// operation timed out
        /// </summary>
        Timeout = 16,
        /// <summary>
        /// VAC2 banned
        /// </summary>
        Banned = 17,
        /// <summary>
        /// account not found
        /// </summary>
        AccountNotFound = 18,
        /// <summary>
        /// steamID is invalid
        /// </summary>
        InvalidSteamID = 19,
        /// <summary>
        /// The requested service is currently unavailable
        /// </summary>
        ServiceUnavailable = 20,
        /// <summary>
        /// The user is not logged on
        /// </summary>
        NotLoggedOn = 21,
        /// <summary>
        /// Request is pending (may be in process, or waiting on third party)
        /// </summary>
        Pending = 22,
        /// <summary>
        /// Encryption or Decryption failed
        /// </summary>
        EncryptionFailure = 23,
        /// <summary>
        /// Insufficient privilege
        /// </summary>
        InsufficientPrivilege = 24,
        /// <summary>
        /// Too much of a good thing
        /// </summary>
        LimitExceeded = 25,
        /// <summary>
        /// Access has been revoked (used for revoked guest passes)
        /// </summary>
        Revoked = 26,
        /// <summary>
        /// License/Guest pass the user is trying to access is expired
        /// </summary>
        Expired = 27,
        /// <summary>
        /// Guest pass has already been redeemed by account, cannot be acked again
        /// </summary>
        AlreadyRedeemed = 28,
        /// <summary>
        /// The request is a duplicate and the action has already occurred in the past, ignored this time
        /// </summary>
        DuplicateRequest = 29,
        /// <summary>
        /// All the games in this guest pass redemption request are already owned by the user
        /// </summary>
        AlreadyOwned = 30,
        /// <summary>
        /// IP address not found
        /// </summary>
        IPNotFound = 31,
        /// <summary>
        /// failed to write change to the data store
        /// </summary>
        PersistFailed = 32,
        /// <summary>
        /// failed to acquire access lock for this operation
        /// </summary>
        LockingFailed = 33,
        LogonSessionReplaced = 34,
        ConnectFailed = 35,
        HandshakeFailed = 36,
        IOFailure = 37,
        RemoteDisconnect = 38,
        /// <summary>
        /// failed to find the shopping cart requested
        /// </summary>
        ShoppingCartNotFound = 39,
        /// <summary>
        /// a user didn't allow it
        /// </summary>
        Blocked = 40,
        /// <summary>
        /// target is ignoring sender
        /// </summary>
        Ignored = 41,
        /// <summary>
        /// nothing matching the request found
        /// </summary>
        NoMatch = 42,
        AccountDisabled = 43,
        /// <summary>
        /// this service is not accepting content changes right now
        /// </summary>
        ServiceReadOnly = 44,
        /// <summary>
        /// account doesn't have value, so this feature isn't available
        /// </summary>
        AccountNotFeatured = 45,
        /// <summary>
        /// allowed to take this action, but only because requester is admin
        /// </summary>
        AdministratorOK = 46,
        /// <summary>
        /// A Version mismatch in content transmitted within the Steam protocol.
        /// </summary>
        ContentVersion = 47,
        /// <summary>
        /// The current CM can't service the user making a request, user should try another.
        /// </summary>
        TryAnotherCM = 48,
        /// <summary>
        /// You are already logged in elsewhere, this cached credential login has failed.
        /// </summary>
        PasswordRequiredToKickSession = 49,
        /// <summary>
        /// You are already logged in elsewhere, you must wait
        /// </summary>
        AlreadyLoggedInElsewhere = 50,
        /// <summary>
        /// Long running operation (content download) suspended/paused
        /// </summary>
        Suspended = 51,
        /// <summary>
        /// Operation canceled (typically by user: content download)
        /// </summary>
        Cancelled = 52,
        /// <summary>
        /// Operation canceled because data is ill formed or unrecoverable
        /// </summary>
        DataCorruption = 53,
        /// <summary>
        /// Operation canceled - not enough disk space.
        /// </summary>
        DiskFull = 54,
        /// <summary>
        /// an remote call or IPC call failed
        /// </summary>
        RemoteCallFailed = 55,
        /// <summary>
        /// Password could not be verified as it's unset server side
        /// </summary>
        PasswordUnset = 56,
        /// <summary>
        /// External account (PSN, Facebook...) is not linked to a Steam account
        /// </summary>
        ExternalAccountUnlinked = 57,
        /// <summary>
        /// PSN ticket was invalid
        /// </summary>
        PSNTicketInvalid = 58,
        /// <summary>
        /// External account (PSN, Facebook...) is already linked to some other account, must explicitly request to replace/delete the link first
        /// </summary>
        ExternalAccountAlreadyLinked = 59,
        /// <summary>
        /// The sync cannot resume due to a conflict between the local and remote files
        /// </summary>
        RemoteFileConflict = 60,
        /// <summary>
        /// The requested new password is not legal
        /// </summary>
        IllegalPassword = 61,
        /// <summary>
        /// new value is the same as the old one ( secret question and answer )
        /// </summary>
        SameAsPreviousValue = 62,
        /// <summary>
        /// account login denied due to 2nd factor authentication failure
        /// </summary>
        AccountLogonDenied = 63,
        /// <summary>
        /// The requested new password is not legal
        /// </summary>
        CannotUseOldPassword = 64,
        /// <summary>
        /// account login denied due to auth code invalid
        /// </summary>
        InvalidLoginAuthCode = 65,
        /// <summary>
        /// account login denied due to 2nd factor auth failure - and no mail has been sent
        /// </summary>
        AccountLogonDeniedNoMail = 66,
        HardwareNotCapableOfIPT = 67,
        IPTInitError = 68,
        /// <summary>
        /// operation failed due to parental control restrictions for current user
        /// </summary>
        ParentalControlRestricted = 69,
        /// <summary>
        /// Facebook query returned an error
        /// </summary>
        FacebookQueryError = 70,
        /// <summary>
        /// account login denied due to auth code expired
        /// </summary>
        ExpiredLoginAuthCode = 71,

        /// <summary>
        /// 
        /// </summary>
        IPLoginRestrictionFailed = 72,

        /// <summary>
        /// 
        /// </summary>
        AccountLockedDown = 73,

        /// <summary>
        /// 
        /// </summary>
        AccountLogonDeniedVerifiedEmailRequired = 74,

        /// <summary>
        /// 
        /// </summary>
        NoMatchingURL = 75,

        /// <summary>
        /// parse failure, missing field, etc.
        /// </summary>
        BadResponse = 76,
        
        /// <summary>
        /// The user cannot complete the action until they re-enter their password
        /// </summary>
        RequirePasswordReEntry = 77,
        
        /// <summary>
        /// the value entered is outside the acceptable range
        /// </summary>
        ValueOutOfRange = 78,

        /// <summary>
        /// something happened that we didn't expect to ever happen
        /// </summary>
        UnexpectedError = 79,

        /// <summary>
        /// The requested service has been configured to be unavailable
        /// </summary>
        Disabled = 80,
        
        /// <summary>
        /// The set of files submitted to the CEG server are not valid!
        /// </summary>
        InvalidCEGSubmission = 81,

        /// <summary>
        /// The device being used is not allowed to perform this action
        /// </summary>
        RestrictedDevice = 82,

        /// <summary>
        /// The action could not be complete because it is region restricted
        /// </summary>
        RegionLocked = 83,

        /// <summary>
        /// Temporary rate limit exceeded, try again later, different from LimitExceeded which may be permanent
        /// </summary>
        RateLimitExceeded = 84,
    }
}
