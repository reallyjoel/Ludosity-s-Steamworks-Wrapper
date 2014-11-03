using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface IApps
    {
        event CallbackEvent<DlcInstalled> DlcInstalled;
        event CallbackEvent<RegisterActivationCodeResponse> RegisterActivationCodeResponse;
        event CallbackEvent<AppProofOfPurchaseKeyResponse> AppProofOfPurchaseKeyResponse;
        event CallbackEvent<NewLaunchQueryParameters> NewLaunchQueryParameters;

        bool IsSubscribed();
        bool IsLowViolence();
        bool IsCybercafe();
        bool IsVACBanned();

        /// <summary>
        /// Returns a string with the current game language
        /// </summary>
        /// <returns></returns>
        string GetCurrentGameLanguage();
        string GetAvailableGameLanguages();
        
        /// <summary>
        /// Only use this member if you need to check ownership of another game related to yours, a demo for example
        /// </summary>
        /// <returns></returns>
        bool IsSubscribedApp(AppID appID);

        /// <summary>
        /// Takes AppID of DLC and checks if the user owns the DLC & if the DLC is installed
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        bool IsDlcInstalled(AppID appID);

        /// <summary>
        /// Returns the Unix time of the purchase of the app
        /// </summary>
        /// <param name="appID"></param>
        /// <returns></returns>
        uint GetEarliestPurchaseUnixTime(AppID appID);

        /// <summary>
        /// Checks if the user is subscribed to the current app through a free weekend
        /// This function will return false for users who have a retail or other type of license
        /// Before using, please ask your Valve technical contact how to package and secure your free weekened
        /// </summary>
        /// <returns></returns>
        bool IsSubscribedFromFreeWeekend();

        /// <summary>
        /// Returns the number of DLC pieces for the running app
        /// </summary>
        /// <returns></returns>
        int GetDLCCount();

        /// <summary>
        /// Returns metadata for DLC by index, of range [0, GetDLCCount()]
        /// </summary>
        /// <param name="iDLC">DLC index for the running app</param>
        /// <param name="pAppID">Contains AppID for the DLC upon return</param>
        /// <param name="pbAvailable">Contains whether the DLC is available to the client or not (true if the client owns the DLC) upon return</param>
        /// <param name="pchName">Contains name for DLC upon return</param>
        /// <returns>True if call was successful</returns>
        bool GetDLCDataByIndex(int iDLC, out AppID pAppID, out bool pbAvailable, out string pchName);

        /// <summary>
        /// Returns metadata for DLC by index, of range [0, GetDLCCount()]
        /// </summary>
        /// <param name="iDLC">DLC index for current AppID</param>
        /// <returns></returns>
        AppsGetDLCDataByIndexResult GetDLCDataByIndex(int iDLC);

        /// <summary>
        /// Install control for optional DLC
        /// </summary>
        /// <param name="appID"></param>
        void InstallDLC(AppID appID);
        /// <summary>
        /// Uninstall control for optional DLC
        /// </summary>
        /// <param name="appID"></param>
        void UninstallDLC(AppID appID);

        /// <summary>
        /// Request cd-key for yourself or owned DLC. If you are interested in this
        /// data then make sure you provide us with a list of valid keys to be distributed
        /// to users when they purchase the game, before the game ships.
        /// You'll receive an AppProofOfPurchaseKeyResponse_t callback when
        /// the key is available (which may be immediately).
        /// </summary>
        /// <param name="appID"></param>
        void RequestAppProofOfPurchaseKey(AppID appID);

        /// <summary>
        /// Returns current beta branch name, 'public' is the default branch
        /// </summary>
        /// <param name="pchName"></param>
        /// <returns></returns>
        bool GetCurrentBetaName(out string pchName);

        /// <summary>
        /// Returns struct containing current beta branch name and bool result for original function.
        /// </summary>
        /// <returns></returns>
        AppsGetCurrentBetaNameResult GetCurrentBetaName();

        /// <summary>
        /// Signal Steam that game files seems corrupt or missing
        /// </summary>
        /// <param name="bMissingFilesOnly"></param>
        /// <returns></returns>
        bool MarkContentCorrupt(bool bMissingFilesOnly);

        /// <summary>
        /// Return installed depots in mount order
        /// </summary>
        /// <param name="appID"></param>
        /// <param name="pDepotID"></param>
        /// <param name="maxDepots"></param>
        /// <returns></returns>
        uint GetInstalledDepots(AppID appID, out DepotID pDepotID, uint maxDepots);

        /// <summary>
        /// Returns the SteamID of the original owner. If different from current user, it's borrowed
        /// </summary>
        /// <returns></returns>
        SteamID GetAppOwner();

        /// <summary>
        /// Returns the associated launch param if the game is run via steam://run/<appid>//?param1=value1;param2=value2;param3=value3 etc.
        /// Parameter names starting with the character '@' are reserved for internal use and will always return and empty string.
        /// Parameter names starting with an underscore '_' are reserved for steam features -- they can be queried by the game,
        /// but it is advised that you not param names beginning with an underscore for your own features.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetLaunchQueryParam(string key);
    }

    public struct AppsGetDLCDataByIndexResult
    {
        public bool Result;
        public AppID AppID;
        public bool Available;
        public string Name;
    }

    public struct AppsGetCurrentBetaNameResult
    {
        public bool Result;
        public string Name;
    }
}
