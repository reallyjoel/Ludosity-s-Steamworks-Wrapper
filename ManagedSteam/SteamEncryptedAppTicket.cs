using System.Runtime.InteropServices;
using System;

namespace ManagedSteam
{
    public class SteamEncryptedAppTicket
    {
        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_BDecryptTicket", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SteamEncryptedAppTicket_BDecryptTicket(IntPtr encryptedTicketBuffer, uint encryptedTicketSize, IntPtr decryptedTicketBuffer, ref uint decryptedTicketSize, IntPtr keyBuffer, uint keySize);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_BIsTicketForApp", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SteamEncryptedAppTicket_BIsTicketForApp(IntPtr decryptedTicket, uint ticketSize, uint nAppID);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_GetTicketIssueTime", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SteamEncryptedAppTicket_GetTicketIssueTime(IntPtr decryptedTicket, uint decryptedTicketSize);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_GetTicketSteamID", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SteamEncryptedAppTicket_GetTicketSteamID(IntPtr decryptedTicket, uint decryptedTicketSize, out UInt64 psteamID);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_GetTicketAppID", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SteamEncryptedAppTicket_GetTicketAppID(IntPtr decryptedTicket, uint decryptedTicketSize);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_BUserOwnsAppInTicket", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SteamEncryptedAppTicket_BUserOwnsAppInTicket(IntPtr decryptedTicket, uint decryptedTicketSize, UInt64 nAppID);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_BUserIsVacBanned", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SteamEncryptedAppTicket_BUserIsVacBanned(IntPtr decryptedTicket, uint decryptedTicketSize);

        [System.Runtime.InteropServices.DllImportAttribute("sdkencryptedappticket", EntryPoint = "SteamEncryptedAppTicket_GetUserVariableData", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SteamEncryptedAppTicket_GetUserVariableData(IntPtr decryptedTicket, uint decryptedTicketSize, out uint userDataSize);
    }
}