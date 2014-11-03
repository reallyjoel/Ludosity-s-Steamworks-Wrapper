using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Apps : SteamService, IApps
    {
        private List<DlcInstalled> dlcInstalled;
        private List<RegisterActivationCodeResponse> registerActivationCodeResponse;
        private List<AppProofOfPurchaseKeyResponse> appProofOfPurchaseKeyResponse;
        private List<NewLaunchQueryParameters> newLaunchQueryParameters;

        public Apps()
        {
            dlcInstalled = new List<DlcInstalled>();
            registerActivationCodeResponse = new List<RegisterActivationCodeResponse>();
            appProofOfPurchaseKeyResponse = new List<AppProofOfPurchaseKeyResponse>();
            newLaunchQueryParameters = new List<NewLaunchQueryParameters>();

            Callbacks[CallbackID.DlcInstalled] = (data, dataSize) => dlcInstalled.Add(CallbackStructures.DlcInstalled.Create(data, dataSize));
            Callbacks[CallbackID.RegisterActivationCodeResponse] = (data, dataSize) => registerActivationCodeResponse.Add(CallbackStructures.RegisterActivationCodeResponse.Create(data, dataSize));
            Callbacks[CallbackID.AppProofOfPurchaseKeyResponse] = (data, dataSize) => appProofOfPurchaseKeyResponse.Add(CallbackStructures.AppProofOfPurchaseKeyResponse.Create(data, dataSize));
            Callbacks[CallbackID.NewLaunchQueryParameters] = (data, dataSize) => newLaunchQueryParameters.Add(CallbackStructures.NewLaunchQueryParameters.Create(data, dataSize));
        }

        public event CallbackEvent<DlcInstalled> DlcInstalled;
        public event CallbackEvent<RegisterActivationCodeResponse> RegisterActivationCodeResponse;
        public event CallbackEvent<AppProofOfPurchaseKeyResponse> AppProofOfPurchaseKeyResponse;
        public event CallbackEvent<NewLaunchQueryParameters> NewLaunchQueryParameters;

        internal override void CheckIfUsableInternal()
        {
            
        }

        internal override void ReleaseManagedResources()
        {
            dlcInstalled = null;
            DlcInstalled = null;
            registerActivationCodeResponse = null;
            RegisterActivationCodeResponse = null;
            appProofOfPurchaseKeyResponse = null;
            AppProofOfPurchaseKeyResponse = null;
            newLaunchQueryParameters = null;
            NewLaunchQueryParameters = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(dlcInstalled, DlcInstalled);
            InvokeEvents(registerActivationCodeResponse, RegisterActivationCodeResponse);
            InvokeEvents(appProofOfPurchaseKeyResponse, AppProofOfPurchaseKeyResponse);
            InvokeEvents(newLaunchQueryParameters, NewLaunchQueryParameters);
        }


        public bool IsSubscribed()
        {
            CheckIfUsable();

            return NativeMethods.Apps_IsSubscribed();
        }

        public bool IsLowViolence()
        {
            CheckIfUsable();

            return NativeMethods.Apps_IsLowViolence();
        }

        public bool IsCybercafe()
        {
            CheckIfUsable();

            return NativeMethods.Apps_IsCybercafe();
        }

        public bool IsVACBanned()
        {
            CheckIfUsable();

            return NativeMethods.Apps_IsVACBanned();
        }

        public string GetCurrentGameLanguage()
        {
            CheckIfUsable();

            return NativeHelpers.ToStringAnsi(NativeMethods.Apps_GetCurrentGameLanguage());
        }

        public string GetAvailableGameLanguages()
        {
            CheckIfUsable();

            return NativeHelpers.ToStringAnsi(NativeMethods.Apps_GetAvailableGameLanguages());
        }

        public bool IsSubscribedApp(AppID appID)
        {
            CheckIfUsable();
            return NativeMethods.Apps_IsSubscribedApp( appID.AsUInt32 );
        }

        public bool IsDlcInstalled(AppID appID)
        {
            CheckIfUsable();
            return NativeMethods.Apps_IsDlcInstalled( appID.AsUInt32 );
        }

        public uint GetEarliestPurchaseUnixTime(AppID appID)
        {
            CheckIfUsable();
            return NativeMethods.Apps_GetEarliestPurchaseUnixTime( appID.AsUInt32 );
        }

        public bool IsSubscribedFromFreeWeekend()
        {
            CheckIfUsable();
            return NativeMethods.Apps_IsSubscribedFromFreeWeekend();
        }

        public int GetDLCCount()
        {
            CheckIfUsable();
            return NativeMethods.Apps_GetDLCCount();
        }

        public bool GetDLCDataByIndex(int iDLC, out AppID pAppID, out bool pbAvailable, out string pchName)
        {
            CheckIfUsable();
            using (NativeBuffer buffer = new NativeBuffer(Constants.Apps.MaxAchievementNameLength))
            {
                uint localAppId = 0;
                pbAvailable = false;
                
                bool result = NativeMethods.Apps_GetDLCDataByIndex(iDLC, ref localAppId, ref pbAvailable, buffer.UnmanagedMemory, buffer.UnmanagedSize);
                pAppID = new AppID(localAppId);

                pchName = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }

        public AppsGetDLCDataByIndexResult GetDLCDataByIndex(int iDLC)
        {
            AppsGetDLCDataByIndexResult result = new AppsGetDLCDataByIndexResult();

            result.Result = GetDLCDataByIndex(iDLC, out result.AppID, out result.Available, out result.Name);

            return result;
        }

        public void InstallDLC(AppID appID)
        {
            CheckIfUsable();
            NativeMethods.Apps_InstallDLC( appID.AsUInt32 );
        }

        public void UninstallDLC(AppID appID)
        {
            CheckIfUsable();
            NativeMethods.Apps_UninstallDLC( appID.AsUInt32 );
        }

        public void RequestAppProofOfPurchaseKey(AppID appID)
        {
            CheckIfUsable();
            NativeMethods.Apps_RequestAppProofOfPurchaseKey( appID.AsUInt32 );
        }

        public bool GetCurrentBetaName(out string pchName)
        {
            CheckIfUsable();
            using (NativeBuffer buffer = new NativeBuffer(Constants.Apps.MaxBetaNameLength))
            {
                bool result = NativeMethods.Apps_GetCurrentBetaName(buffer.UnmanagedMemory, buffer.UnmanagedSize);
                pchName = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }

        public AppsGetCurrentBetaNameResult GetCurrentBetaName()
        {
            AppsGetCurrentBetaNameResult result = new AppsGetCurrentBetaNameResult();

            result.Result = GetCurrentBetaName(out result.Name);

            return result;
        }

        public bool MarkContentCorrupt(bool bMissingFilesOnly)
        {
            CheckIfUsable();
            return NativeMethods.Apps_MarkContentCorrupt( bMissingFilesOnly );
        }

        public uint GetInstalledDepots(AppID appID, out DepotID pDepotID, uint maxDepots)
        {
            CheckIfUsable();

            uint localDepotId = 0;

            uint result = NativeMethods.Apps_GetInstalledDepots(appID.AsUInt32, ref localDepotId, maxDepots);

            pDepotID = new DepotID(localDepotId);

            return result;
        }

        public SteamID GetAppOwner()
        {
            CheckIfUsable();

            return new SteamID(NativeMethods.Apps_GetAppOwner());
        }

        public string GetLaunchQueryParam(string key)
        {
            CheckIfUsable();

            return NativeHelpers.ToStringAnsi(NativeMethods.Apps_GetLaunchQueryParam(key));
        }
    }
}
