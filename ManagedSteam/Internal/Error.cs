using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using ManagedSteam.Exceptions;

namespace ManagedSteam
{
    static class Error
    {
        [Conditional("STEAMAPIWRAP_LITE")]
        public static void NotAvailableInLite()
        {
            throw new NotAvailableInLiteException();
        }

        public static void ThrowError(ErrorCodes code, params object[] args)
        {
            switch (code)
            {
                // <Native>
                case ErrorCodes.AlreadyLoaded:
                    throw new AlreadyLoadedException(code, args);
                case ErrorCodes.SteamInitializeFailed:
                    throw new SteamInitializeFailedException(code, args);
                case ErrorCodes.SteamInterfaceInitializeFailed:
                    throw new SteamInterfaceInitializeFailedException(code, args);
                // </Native>

                // <Managed>
                case ErrorCodes.InvalidInterfaceVersion:
                    throw new InvalidInterfaceVersionException(code, args);
                case ErrorCodes.UsageAfterAPIShutdown:
                    throw new UsageAfterAPIShutdownException(code, args);
                case ErrorCodes.CallbackStructSizeMissmatch:
                    throw new CallbackStructSizeMismatchException(code, args);
                // </Managed>
            }

            if (code >= ErrorCodes.StartOfNativeErrors && code <= ErrorCodes.EndOfNativeErrors)
            {
                throw new NativeException(code);
            }
            if (code >= ErrorCodes.StartOfManagedErrors && code <= ErrorCodes.EndOfManagedErrors)
            {
                throw new ManagedException(code);
            }
            throw new UnexpectedException(code);
        }
    }
}
