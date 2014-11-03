using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ManagedSteam
{
    /// <summary>
    /// A class that contains all the strings that are presented to the user.
    /// </summary>
    internal static class StringMap
    {
        private const char VariableToken = '%';
        private static Dictionary<StringID, string> strings = new Dictionary<StringID, string>()
        {
            { StringID.OnlyOneInstance, "Can only have one instance of the % class." },
        };
        private static Dictionary<ErrorCodes, string> errorStrings = new Dictionary<ErrorCodes, string>()
        {
            { ErrorCodes.Ok, "Unexpected error." },
            { ErrorCodes.UsageAfterAPIShutdown, "Can't use Steam features after the API has been shutdown." },
            { ErrorCodes.InvalidInterfaceVersion, "Invalid interface version. This is caused by a mismatch between dll versions. Make sure that all dll files is from the same package. Restart Unity and reimport the package from the asset store. Native %, Managed %." },

            { ErrorCodes.CallbackStructSizeMissmatch, "Mismatch of structure size for struct %. Please report this as it is not an usage error." },
            { ErrorCodes.NotAvailableInLite, "This method/operation is not available in Lite mode." },

            { ErrorCodes.NoCallbackEvent, "No callback handler for event %! Please report this as it is not an usage error." },
            { ErrorCodes.NoResultEvent, "No result handler for event %! Please report this as it is not an usage error." },

            { ErrorCodes.CantChangeEncoding, "Can't change the encoding of a native string." },

            { ErrorCodes.SteamInstanceIsNull, "No Steam object exist. Use Steam.Initialize() to create one." },
            { ErrorCodes.MatchmakingServersIsNull, "No MatchmakingServers object exist. Use Steam.Initialize() to initialize the plugin and one will be created." },
            
            { ErrorCodes.StringIsToBig, "The string is too big. Maximum allowed size in bytes, including null terminator, is %" },
        };


        private static CultureInfo Culture
        {
            // Always use the invariant culture as these messages should not be reported to the end-user.
            get { return CultureInfo.InvariantCulture; }
        }


        private static string SafeGetString(StringID id)
        {
            if (strings.ContainsKey(id))
            {
                return strings[id];
            }
            return id.ToString();
        }

        public static string GetString(StringID id, params object[] variables)
        {
            return GetString(SafeGetString(id), variables);
        }

        private static string SafeGetString(ErrorCodes id)
        {
            if (errorStrings.ContainsKey(id))
            {
                return errorStrings[id];
            }
            return id.ToString();
        }

        /// <summary>
        /// Replaces any % with a value from the variables list. Does not throw any exception if 
        /// the number of variables does not match.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public static string GetString(ErrorCodes id, params object[] variables)
        {
            return GetString(SafeGetString(id), variables);
        }

        private static string GetString(string message, params object[] variables)
        {
            if (variables == null)
            {
                return message;
            }

            string[] messageParts = message.Split(VariableToken);

            // Start with enough memory for 4 chars per variable
            StringBuilder processedMessage = new StringBuilder(message.Length + (messageParts.Length - 1) * 4);
            int p = 0;
            foreach (string part in messageParts)
            {
                processedMessage.Append(part);

                if (p++ < variables.Length)
                {
                    // Convert the variable to a string and append it to the text
                    processedMessage.AppendFormat(Culture, "{0}", variables[p - 1]);
                }
            }

            return processedMessage.ToString();
        }
    }
}
