using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;
using ManagedSteam.Utility;

namespace ManagedSteam.Implementations
{
    class SteamController : SteamService, ISteamController
    {
        public SteamController()
        {

        }

        internal override void CheckIfUsableInternal()
        {

        }

        internal override void InvokeEvents()
        {

        }

        internal override void ReleaseManagedResources()
        {

        }

        public bool Init(string absolutPathToControllerConfigVDF)
        {
            CheckIfUsable();

            return NativeMethods.SteamController_Init( absolutPathToControllerConfigVDF );
        }

        public bool Shutdown()
        {
            CheckIfUsable();

            return NativeMethods.SteamController_Shutdown();
        }

        public void RunFrame()
        {
            CheckIfUsable();

            NativeMethods.SteamController_RunFrame();
        }

        public bool GetControllerState(uint controllerIndex, out SteamControllerState state)
        {
            CheckIfUsable();

            using (NativeBuffer bufferKey = new NativeBuffer(Marshal.SizeOf(typeof(SteamControllerState))))
            {
                bool result = NativeMethods.SteamController_GetControllerState(controllerIndex, bufferKey.UnmanagedMemory);
                state = NativeHelpers.ConvertStruct<SteamControllerState>(bufferKey.UnmanagedMemory, bufferKey.UnmanagedSize);

                return result;
            }
        }

        public SteamControllerGetControllerStateResult GetControllerState(uint controllerIndex)
        {
            CheckIfUsable();

            SteamControllerGetControllerStateResult result;

            using (NativeBuffer bufferKey = new NativeBuffer(Marshal.SizeOf(typeof(SteamControllerState))))
            {
                result.Result = NativeMethods.SteamController_GetControllerState(controllerIndex, bufferKey.UnmanagedMemory);
                result.State = NativeHelpers.ConvertStruct<SteamControllerState>(bufferKey.UnmanagedMemory, bufferKey.UnmanagedSize);

                return result;
            }
        }

        public void TriggerHapticPulse(uint controllerIndex, SteamControllerPad targetPad, ushort durationMicroSec)
        {
            NativeMethods.SteamController_TriggerHapticPulse( controllerIndex, (int)targetPad, durationMicroSec );
        }

        public void SetOverrideMode(string mode)
        {
            NativeMethods.SteamController_SetOverrideMode( mode );
        }
    }
}
