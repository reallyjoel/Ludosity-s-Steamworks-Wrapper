using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ManagedSteam.SteamTypes
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = NativeHelpers.SteamStructPacking)]
    public struct SteamControllerState
    {
        /// <summary>
        /// If packet num matches that on your prior call, then the controller state hasn't been changed since 
        /// your last call and there is no need to process it
        /// </summary>
        public uint packetNumber;

        /// <summary>
        /// Enum for the buttons, these are flags, so use bitwise operations.
        /// </summary>
        public SteamControllerButtons buttons;

        /// <summary>
        /// Left pad X coordinate
        /// </summary>
        public short LeftPadX;

        /// <summary>
        /// Left pad Y coordinate
        /// </summary>
        public short LeftPadY;

        /// <summary>
        /// Right pad X coordinate
        /// </summary>
        public short sRightPadX;

        /// <summary>
        /// Right pad Y coordinate
        /// </summary>
        public short sRightPadY;
    }
}
