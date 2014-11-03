using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class Utils : SteamService, IUtils
    {
        private List<IPCountry> ipCountry;
        private List<LowBatteryPower> lowBatteryPower;
        private List<SteamAPICallCompleted> steamAPICallCompleted;
        private List<SteamShutdown> steamShutdown;
        private List<CheckFileSignature> checkFileSignature;
        private List<GamepadTextInputDismissed> gamepadTextInputDismissed;

        public Utils()
        {
            ipCountry = new List<IPCountry>();
            lowBatteryPower = new List<LowBatteryPower>();
            steamAPICallCompleted = new List<SteamAPICallCompleted>();
            steamShutdown = new List<SteamShutdown>();
            checkFileSignature = new List<CheckFileSignature>();
            gamepadTextInputDismissed = new List<GamepadTextInputDismissed>();

            Callbacks[CallbackID.IPCountry] = (data, size) => ipCountry.Add(CallbackStructures.IPCountry.Create(data, size));
            Callbacks[CallbackID.LowBatteryPower] = (data, size) => lowBatteryPower.Add(CallbackStructures.LowBatteryPower.Create(data, size));
            Callbacks[CallbackID.SteamShutdown] = (data, size) => steamShutdown.Add(CallbackStructures.SteamShutdown.Create(data, size));
            Callbacks[CallbackID.CheckFileSignature] = (data, size) => checkFileSignature.Add(CallbackStructures.CheckFileSignature.Create(data, size));
            Callbacks[CallbackID.GamepadTextInputDismissed] = (data, size) => gamepadTextInputDismissed.Add(CallbackStructures.GamepadTextInputDismissed.Create(data, size));
        }

        public event CallbackEvent<IPCountry> IPCountry;
        public event CallbackEvent<LowBatteryPower> LowBatteryPower;
        public event CallbackEvent<SteamAPICallCompleted> SteamAPICallCompleted;
        public event CallbackEvent<SteamShutdown> SteamShutdown;
        public event CallbackEvent<CheckFileSignature> CheckFileSignature;
        public event CallbackEvent<GamepadTextInputDismissed> GamepadTextInputDismissed;

        internal override void CheckIfUsableInternal()
        {
        }

        internal override void ReleaseManagedResources()
        {
            ipCountry = null;
            IPCountry = null;
            lowBatteryPower = null;
            LowBatteryPower = null;
            steamAPICallCompleted = null;
            SteamAPICallCompleted = null;
            steamShutdown = null;
            SteamShutdown = null;
            checkFileSignature = null;
            CheckFileSignature = null;
            gamepadTextInputDismissed = null;
            GamepadTextInputDismissed = null;
        }

        internal override void InvokeEvents()
        {
            InvokeEvents(ipCountry, IPCountry);
            InvokeEvents(lowBatteryPower, LowBatteryPower);
            InvokeEvents(steamAPICallCompleted, SteamAPICallCompleted);
            InvokeEvents(steamShutdown, SteamShutdown);
            InvokeEvents(checkFileSignature, CheckFileSignature);
            InvokeEvents(gamepadTextInputDismissed, GamepadTextInputDismissed);
        }

        public uint GetSecondsSinceAppActive()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetSecondsSinceAppActive();
        }

        public uint GetSecondsSinceComputerActive()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetSecondsSinceComputerActive();
        }

        public Universe GetConnectedUniverse()
        {
            return (Universe)NativeMethods.Utils_GetConnectedUniverse();
        }

        public uint GetServerRealTime()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetServerRealTime();
        }

        public string GetIPCountry()
        {
            CheckIfUsable();

            IntPtr stringPointer = NativeMethods.Utils_GetIPCountry();
            return NativeHelpers.ToStringAnsi(stringPointer);
        }

        public bool GetImageSize(ImageHandle image, out uint width, out uint height)
        {
            CheckIfUsable();

            width = 0;
            height = 0;
            return NativeMethods.Utils_GetImageSize(image.AsInt32, ref width, ref height);
        }

        public UtilsGetImageSizeResult GetImageSize(ImageHandle image)
        {
            UtilsGetImageSizeResult result = new UtilsGetImageSizeResult();

            result.Result = GetImageSize(image, out result.Width, out result.Height);

            return result;
        }

        public bool GetImageRGBA(ImageHandle image, System.IntPtr buffer, int bufferSize)
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetImageRGBA(image.AsInt32, buffer, bufferSize);
        }

        public bool GetCSERIPPort(out uint unIP, out ushort usPort)
        {
            CheckIfUsable();

            unIP = 0;
            usPort = 0;
            return NativeMethods.Utils_GetCSERIPPort(ref unIP, ref usPort);
        }

        public UtilsGetCSERIPPortResult GetCSERIPPort()
        {
            UtilsGetCSERIPPortResult result = new UtilsGetCSERIPPortResult();

            result.Result = GetCSERIPPort(out result.IP, out result.Port);

            return result;
        }

        public int GetCurrentBatteryPower()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetCurrentBatteryPower();
        }
        
        public void SetOverlayNotificationPosition(NotificationPosition notificationPosition)
        {
            NativeMethods.Utils_SetOverlayNotificationPosition((int)notificationPosition);
        }

        public bool IsAPICallCompleted(SteamAPICall steamAPICall, out bool failed)
        {
            failed = false;
            return NativeMethods.Utils_IsAPICallCompleted(steamAPICall.AsUInt64, ref failed);
        }

        [ThreadStatic]
        static byte[] _CallResultBuffer;

        public bool GetAPICallResult<T>(SteamAPICall steamAPICall, ref T callback, out bool failed) where T : struct
        {
            failed = false;
            int structSize = Marshal.SizeOf(typeof(T));
            if (_CallResultBuffer == null)
                _CallResultBuffer = new byte[256];
            GCHandle handle = GCHandle.Alloc(_CallResultBuffer, GCHandleType.Pinned);
            try
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(_CallResultBuffer, 0);
                bool result = NativeMethods.Utils_GetAPICallResult(steamAPICall.AsUInt64, ptr, 256, 154, ref failed);
                callback = (T)Marshal.PtrToStructure(ptr, typeof(T));
                return result;
            }
            finally
            {
                handle.Free();
            }
        }

        public void RunFrame()
        {
            CheckIfUsable();

            NativeMethods.Utils_RunFrame();
        }

        public uint GetIPCCallCount()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetIPCCallCount();
        }

        public bool IsOverlayEnabled()
        {
            CheckIfUsable();

            return NativeMethods.Utils_IsOverlayEnabled();
        }

        public bool OverlayNeedsPresent()
        {
            CheckIfUsable();

            return NativeMethods.Utils_OverlayNeedsPresent();
        }

        public bool ShowGamepadTextInput(GamepadTextInputMode inputMode, GamepadTextInputLineMode lineInputMode, string description, uint charMax)
        {
            CheckIfUsable();

            return NativeMethods.Utils_ShowGamepadTextInput((int)inputMode, (int)lineInputMode, description, charMax);
        }

        public uint GetEnteredGamepadTextLength()
        {
            CheckIfUsable();

            return NativeMethods.Utils_GetEnteredGamepadTextLength();
        }
        
        public bool GetEnteredGamepadTextInput(out string pchText)
        {
            CheckIfUsable();

            using (NativeBuffer buffer = new NativeBuffer(Constants.Apps.MaxGamepadTextInputLength))
            {
                bool result = NativeMethods.Utils_GetEnteredGamepadTextInput(buffer.UnmanagedMemory, (uint)buffer.UnmanagedSize);

                pchText = NativeHelpers.ToStringAnsi(buffer.UnmanagedMemory);

                return result;
            }
        }

        public UtilsGetEnteredGamepadTextInputResult GetEnteredGamepadTextInput()
        {
            UtilsGetEnteredGamepadTextInputResult result = new UtilsGetEnteredGamepadTextInputResult();

            result.Result = GetEnteredGamepadTextInput(out result.Text);

            return result;
        }

        public bool IsSteamRunningInVR()
        {
            return NativeMethods.Utils_IsSteamRunningInVR();
        }
    }
}
