// This file is used by both the C# and C++ projects.
// This way the error codes are always in sync

#if !__cplusplus
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagedSteam
{
#endif

#if __cplusplus
namespace SteamAPIWrap
{
    struct EErrorCodes
    {

    enum Enum
#else
    /// <summary>
    /// Internal error codes
    /// </summary>
    enum ErrorCodes
#endif
    {
        Ok,

        // Add new error codes at the end

        //////////////////////////////////////////////////////////////////
        StartOfNativeErrors,

        AlreadyLoaded,
        SteamInitializeFailed,
        SteamInterfaceInitializeFailed,

        EndOfNativeErrors = 4000,
        //////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////
        StartOfManagedErrors = 5000,

        InvalidInterfaceVersion,
        UsageAfterAPIShutdown,

        CallbackStructSizeMissmatch,

        NotAvailableInLite,
        NoCallbackEvent,
        NoResultEvent,

        CantChangeEncoding,

        SteamInstanceIsNull,
        MatchmakingServersIsNull,

        StringIsToBig,

        EndOfManagedErrors = 9000,
        //////////////////////////////////////////////////////////////////
    }
#if __cplusplus
        ;
    };
#endif

} // namespace, used by both c# and C++
