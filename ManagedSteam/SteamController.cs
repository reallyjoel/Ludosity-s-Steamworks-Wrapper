using System;
using System.Collections.Generic;
using System.Text;

using ManagedSteam.CallbackStructures;
using ManagedSteam.SteamTypes;

namespace ManagedSteam
{
    public interface ISteamController
    {
        bool Init(string absolutPathToControllerConfigVDF);
        bool Shutdown();

        void RunFrame();

        bool GetControllerState(uint controllerIndex, out SteamControllerState state);
        void TriggerHapticPulse(uint controllerIndex, SteamControllerPad targetPad, ushort durationMicroSec);

        void SetOverrideMode(string mode);
    }

    public struct SteamControllerGetControllerStateResult
    {
        public bool Result;
        public SteamControllerState State;
    }
}
